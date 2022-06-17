using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TowerDefense;
/// <summary>
/// Spended time: 23h 20m
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        places[0] = place1;
        places[1] = place2;
        IsBusy.Add(new List<bool>());
        IsBusy.Add(new List<bool>());
        NumOfBusy.Add(new List<int> { -1 });
        NumOfBusy.Add(new List<int> { -1 });
        IsBusy[0].Add(false);
        IsBusy[1].Add(false);
        build = new Build();
        up = new Upgrade();
        Spawner = new Thread(Spawn);
        Spawner.Start(num);
    }

    public static bool ppp = true;
    bool debug = false;
    int newer = 0;
    List<int> order = new List<int>();
    int[] hisnum = new int[500];
    double[] hp = new double[500];
    int[,] range = new int[2, 2] { { 290, 136 }, { 503, 184 } };// x|y
    Thread EnemyThread;
    Thread Spawner;
    int num = 0;
    Thread thread;
    public static int NumOfPlace;
    public static Button[] places = new Button[2];
    public static int[] upgrade = new int[] { 0, 0 };
    public static List<List<bool>> IsBusy = new List<List<bool>>();
    public static List<List<int>> NumOfBusy = new List<List<int>>();
    Build build;
    Upgrade up;
    List<Image> imageControl = new List<Image>();
    List<Label> HpControl = new List<Label>();
    private void Spawn(object? obj) {
        int o = (int)obj;

        place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
            HpControl.Add(new Label());
            HpControl[o].Margin = new Thickness(-20, 195, 0, 0);
            HpControl[o].Foreground = Brushes.White;
            imageControl.Add(new Image());
            imageControl[o].Height = 50;
            imageControl[o].Width = 50;
            imageControl[o].Margin = new Thickness(-20, 175, 0, 0);
            imageControl[o].Source = ghost.Source;
            canv.Children.Add(imageControl[o]);
            canv.Children.Add(HpControl[o]);
        }));
        EnemyThread = new Thread(EnemyMovement);
        o = num + 1; order.Add(o); EnemyThread.Start(++num);
        while (ppp) {
            place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                HpControl.Add(new Label());
                HpControl[o].Margin = new Thickness(-20, 195, 0, 0);
                HpControl[o].Foreground = Brushes.White;
                imageControl.Add(new Image());
                imageControl[o].Height = 50;
                imageControl[o].Width = 50;
                imageControl[o].Margin = new Thickness(-20, 175, 0, 0);
                imageControl[o].Source = ghost.Source;
                canv.Children.Add(imageControl[o]);
                canv.Children.Add(HpControl[o]);
            }));
            Thread.Sleep(1200);
            EnemyThread = new Thread(EnemyMovement);
            if (newer > 0) {
                o = hisnum[newer]; order.Remove(o); order.Add(o); newer--; EnemyThread.Start(hisnum[newer + 1]);
            }
            else { o = num + 1; order.Add(o); EnemyThread.Start(++num); }

        }
    }
    int[] VIP = new int[] { -1, -1 };
    int[] Vl = new int[] { -1, -1 };
    int[] Vt = new int[] { -1, -1 };
    int[] ti = new int[] { 0, 0 };
    private void EnemyMovement(object? obj) {
        int o = (int)obj;
        hp[o] = 100;
        int l = -20, t = 175;

        while (ppp) {
            Thread.Sleep(10);

            int qw = -1;
            for (int i = 0; i < upgrade.Length; i++) {
                int o2 = o, l2 = l, t2 = t;
                if (VIP[i] != -1) {
                    o = VIP[i];
                    VIP[i] = -1;
                    l = Vl[i];
                    t = Vt[i];
                }
                bool SomeMath = Math.Sqrt(Math.Abs((range[i, 0] - l) * (range[i, 0] - l)) + Math.Abs((range[i, 1] - t) * (range[i, 1] - t))) < 177;
                place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                    if (i == 0 && SomeMath && e1.Visibility == Visibility.Hidden && upgrade[0] > 0) { e1.Visibility = Visibility.Visible; ti[i] = 0; }
                    if (i == 1 && SomeMath && e2.Visibility == Visibility.Hidden && upgrade[1] > 0) { e2.Visibility = Visibility.Visible; ti[i] = 0; }
                }));
                if (NumOfBusy[i].Contains(o) && !SomeMath) {
                    for (int f = 0; f < IsBusy[i].Count; f++) {
                        if (IsBusy[i][f] == false) continue;
                        IsBusy[i][f] = false;
                        break;
                    }
                }
                if ((IsBusy[i].Contains(false) || NumOfBusy[i].Contains(o)) && SomeMath) {

                    bool both = false;
                    if (o == qw) {
                        both = true;
                    }
                    qw = o;
                    double dmg = 0;
                    if (upgrade[i] == 1) { dmg = 0.2; }
                    else if (upgrade[i] == 11) { dmg = 0.2; }
                    else if (upgrade[i] == 2) { dmg = 0.5; }
                    else if (upgrade[i] == 3) { dmg = 2.2; }
                    else if (upgrade[i] == 12) { dmg = 1.3; }
                    else if (upgrade[i] == 13) { dmg = 3.6; }
                    if (both) hp[o] -= dmg;
                    hp[o] -= dmg;
                    if (hp[o] < 1) {
                        for (int f = 0; f < IsBusy[i].Count; f++) {
                            if (IsBusy[i][f] == true && NumOfBusy[i][f] != -1 && IsBusy[i].Count > 1) continue;
                            /*if (NumOfBusy[i].Count > 1 && NumOfBusy[i][f] == NumOfBusy[i][f + 1] && f < 2) { 
                                NumOfBusy[i][f + 1] = -1; IsBusy[i][f + 1] = false; }*/
                            IsBusy[i][f] = true;
                            NumOfBusy[i][f] = order[order.IndexOf(o) + 1];
                            break;
                        }
                        VIP[i] = order[order.IndexOf(o) + 1];
                        Vl[i] = l;
                        Vt[i] = t;
                        place1.Dispatcher.Invoke(new Action(() => {
                            canv.Children.Remove(imageControl[o]);
                            canv.Children.Remove(HpControl[o]);
                        }));
                        hisnum[++newer] = o;
                        return;
                    }
                    else if (IsBusy[i].Contains(false)) {
                        for (int f = 0; f < IsBusy[i].Count; f++) {
                            if (((IsBusy[i][f] == true && NumOfBusy[i][f] != -1) ||
                                NumOfBusy[i].Contains(o)) && IsBusy[i].Count > 1) continue;
                            IsBusy[i][f] = true;
                            NumOfBusy[i][f] = o;
                            break;
                        }
                    }

                }
                else {
                    if (ti[i] < order.Count + 10) { ti[i]++; }
                    else {
                        place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() => {
                            if (!IsBusy[0].Contains(true) && e1.Visibility == Visibility.Visible) {
                                e1.Visibility = Visibility.Hidden;
                            }
                            if (!IsBusy[1].Contains(true) && e2.Visibility == Visibility.Visible) {
                                e2.Visibility = Visibility.Hidden;
                            }
                        }));
                        ti[i] = 0;
                    }
                }
                o = o2; t = t2; l = l2;
            }
            place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                imageControl[o].Margin = new Thickness(l, t, 0, 0);
                HpControl[o].Margin = new Thickness(l + 8, t + 22, 0, 0);
                HpControl[o].Content = (int)hp[o];
            }));
            if (l == 180 && t > 5) { t--; }
            else if (l == 390 && t < 230) { t++; }
            else if (l == 690 && t > 120) { t--; }
            else l++;
            if (l >= 1100) {
                place1.Dispatcher.Invoke(new Action(() => {
                    canv.Children.Remove(imageControl[o]);
                    canv.Children.Remove(HpControl[o]);
                }));
                hisnum[++newer] = o; return;
            }
        }
    }

    //first buy
    private void Button_Click(object sender, RoutedEventArgs e) {
        NumOfPlace = int.Parse((string)(sender as Button).Content) - 1;
        double l = (sender as Button).Margin.Left, t = (sender as Button).Margin.Top;
        int u = 124;
        if (upgrade[NumOfPlace] == 0) {
            build.Left = Left + l + 5;
            build.Top = Top + t + u;
            build.Show();
            thread = new Thread(wait);
            thread.Start(build);
        }
        else {
            up.Left = Left + l + 5;
            up.Top = Top + t + u;
            up.Show();
            thread = new Thread(wait);
            thread.Start(up);
        }

    }
    //uphgrade
    private async void wait(object? obj) {
        while (ppp) {
            Thread.Sleep(1);
            if (upgrade[NumOfPlace] == 0) {
                place1.Dispatcher.Invoke(() => {
                    if (!(obj as Window).IsActive) {
                        (obj as Window).Hide();
                        if (Build.selected == 0) {
                            places[NumOfPlace].Background = new SolidColorBrush(Color.FromRgb(235, 91, 91));
                            Build.selected = -1; upgrade[NumOfPlace] = 1;
                        }
                        if (Build.selected == 1) {
                            places[NumOfPlace].Background = new SolidColorBrush(Color.FromRgb(82, 169, 235));
                            Build.selected = -1; upgrade[NumOfPlace] = 11; NumOfBusy[NumOfPlace].Add(-1); NumOfBusy[NumOfPlace].Add(-1); IsBusy[NumOfPlace].Add(false); IsBusy[NumOfPlace].Add(false);
                        }
                        return;
                    }
                });
            }
            else if (upgrade[NumOfPlace] > 0) {
                place1.Dispatcher.Invoke(() => {
                    if (!(obj as Window).IsActive) {
                        (obj as Window).Hide();
                        if (Upgrade.Destroy == 0) {
                            if (upgrade[NumOfPlace] == 1) { places[NumOfPlace].Background = Brushes.Red; }
                            if (upgrade[NumOfPlace] == 2) { places[NumOfPlace].Background = new SolidColorBrush(Color.FromRgb(122, 5, 5)); }
                            if (upgrade[NumOfPlace] == 11) {
                                places[NumOfPlace].Background = Brushes.Blue; ;
                            }
                            if (upgrade[NumOfPlace] == 12) {
                                places[NumOfPlace].Background = new SolidColorBrush(Color.FromRgb(12, 44, 150));
                            }
                            if (upgrade[NumOfPlace] != 13 && upgrade[NumOfPlace] != 3) upgrade[NumOfPlace]++;
                            Upgrade.Destroy = -1;
                        }//destroy
                        else if (Upgrade.Destroy == 1) {
                            for (int i = 1; i < IsBusy[NumOfPlace].Count; i++) {
                                IsBusy[NumOfPlace].RemoveAt(i);
                                NumOfBusy[NumOfPlace].RemoveAt(i);
                            }
                            places[NumOfPlace].Background = Brushes.White;
                            upgrade[NumOfPlace] = 0;
                            Upgrade.Destroy = -1;
                            if (NumOfPlace == 0) e1.Visibility = Visibility.Hidden;
                            else e2.Visibility = Visibility.Hidden;
                        }
                        return;
                    }
                });
            }
        }
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
        ppp = false;
        up.Close();
        build.Close();
    }
}
