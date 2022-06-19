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
/// Spended time: 36h 25m
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
    bool bug = false;
    int newer = 0;
    List<int> order = new List<int>();
    List<int> ban = new List<int>();
    List<bool> ttt = new List<bool>();
    List<string> pos = new List<string>();
    List<int> count = new List<int>();
    List<int> hisnum = new List<int>();
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
        num = -1;
        while (ppp) {
            bug = false;
            EnemyThread = new Thread(EnemyMovement);
            for (int i = 0; i < HpControl.Count; i++) {
                place1.Dispatcher.Invoke(new Action(() => {

                    if (pos[i] == imageControl[i].Margin.ToString()) {
                        if (count[i] < 3) { count[i]++; }
                        else {
                            count[i] = 0;
                        }
                        if (count[i] >= 2 && hp[i] >= 1) {
                            imageControl[i].Margin = new Thickness(-101, -101, 0, 0);
                            canv.Children.Remove(imageControl[i]);
                            canv.Children.Remove(HpControl[i]);
                            hp[i] = -1;
                            ttt[i] = false;
                            order.Remove(i);
                            if (order.Count > 0) order.RemoveAt(0);
                            if (order.Count > 1) order.RemoveAt(1);
                            if (order.Count > 2) order.RemoveAt(2);
                            if (order.Count > 3) order.RemoveAt(3);
                            count[i] = 0;
                            ban.Add(i);
                            for (int za = 0; za < NumOfPlace; za++) {
                                    IsBusy[za][0] = true;
                                    NumOfBusy[za][0] = order[0];
                            }
                        }
                    }
                }));
            }
            for (int j = 0; j < NumOfPlace; j++) {
                    for (int i = 0; i < NumOfBusy[j].Count(); i++) {
                    if (hp[NumOfBusy[j][i]]<1) {
                        IsBusy[j][i] = false;
                        NumOfBusy[j][i] = order[0];
                    }
                    }
                }
            int op = hisnum.Distinct().Count();
            if (hisnum.Count != op) {
                var temp = hisnum.Distinct();
                hisnum.Clear();
                
                foreach (var tt in temp) {
                    hisnum.Add(tt);
                }
            }
            bool cont = ban.Contains(o);
            if (hisnum.Count > 0 && !cont) {
                o = hisnum[hisnum.Count - 1];
                order.Remove(o); ttt[o] = true; order.Add(o); EnemyThread.Start(o);
                hisnum.RemoveAt(hisnum.Count - 1);
            }
            else { o = num + 1; order.Add(o); count.Add(0); pos.Add("-20,175,0,0"); ttt.Add(true); EnemyThread.Start(++num); }
            place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                if (!cont && hisnum.Count == 0) {
                    imageControl.Add(new Image());
                    HpControl.Add(new Label());
                    pos.Add("-20,175,0,0");
                }
                pos[o] = imageControl[o].Margin.ToString();
                HpControl[o].Margin = new Thickness(-20, 195, 0, 0);
                HpControl[o].Foreground = Brushes.White;
                imageControl[o].Height = 50;
                imageControl[o].Width = 50;
                imageControl[o].Margin = new Thickness(-20, 175, 0, 0);
                count[o] = 0;
                imageControl[o].Source = ghost.Source;
                if (!canv.Children.Contains(imageControl[o])) {
                    canv.Children.Add(imageControl[o]);
                    canv.Children.Add(HpControl[o]);
                }
            }));
            Thread.Sleep(1200);
        }
    }
    int[] VIP = new int[] { -1, -1 };
    int[] Vl = new int[] { -1, -1 };
    int[] Vt = new int[] { -1, -1 };
    int[] ti = new int[] { 0, 0 };
    List<int> dead = new List<int>();
    private void EnemyMovement(object? obj) {
        int o = (int)obj;
        hp[o] = 100;
        int l = -20, t = 175;
        while (ppp && ttt[o]) {
            bool death = false;
            Thread.Sleep(10);
            int qw = -1;
            for (int i = 0; i < upgrade.Length; i++) {
                int o2 = o, l2 = l, t2 = t;
                bool bol = false;
                
                if (hp[o] < 1) { bol = true; }
                if (VIP[i] != -1) {
                    o = VIP[i];
                    VIP[i] = -1;
                    l = Vl[i];
                    t = Vt[i];
                }
                if (o < 0) o = o2;
                if (hp[o] < 1 || bol) {
                    int my = 1;
                    int ord = order.IndexOf(o);
                    if (ord == order.Count - 1) my = 0;
                    VIP[i] = order[ord + my];
                    Vl[i] = l;
                    Vt[i] = t;
                    death = true;
                }
                bool SomeMath = Math.Sqrt(Math.Abs((range[i, 0] - l) * (range[i, 0] - l)) + Math.Abs((range[i, 1] - t) * (range[i, 1] - t))) < 177;
                place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                    pos[o] = imageControl[o].Margin.ToString();
                    if (i == 0 && SomeMath && e1.Visibility == Visibility.Hidden && upgrade[0] > 0) { e1.Visibility = Visibility.Visible; ti[i] = 0; }
                    if (i == 1 && SomeMath && e2.Visibility == Visibility.Hidden && upgrade[1] > 0) { e2.Visibility = Visibility.Visible; ti[i] = 0; }
                }));
                bool contain = NumOfBusy[i].Contains(o);
                if (contain && !SomeMath && o == o2) {
                    for (int f = 0; f < IsBusy[i].Count; f++) {
                        if (IsBusy[i][f] == false) continue;
                        IsBusy[i][f] = false;
                        break;
                    }
                }
                if (o == NumOfBusy[i][0] && upgrade[i] == 3) {
                    int r = 0;
                }
                if ((IsBusy[i].Contains(false) || contain) && SomeMath) {
                    bool both = false;
                    if (o == qw) {
                        both = true;
                    }
                    qw = o;
                    double dmg = 0;
                    if (upgrade[i] == 1) { dmg = 0.2; }
                    else if (upgrade[i] == 11) { dmg = 0.14; }
                    else if (upgrade[i] == 2) { dmg = 0.4; }
                    else if (upgrade[i] == 3) { dmg = 0.8; }
                    else if (upgrade[i] == 12) { dmg = 0.27; }
                    else if (upgrade[i] == 13) { dmg = 0.55; }
                    if (both) hp[o] -= dmg;
                    hp[o] -= dmg;
                    if (dmg == 0 && i == 1 && upgrade[1] > 0) {
                        for (int j = 0; j < IsBusy[i].Count; j++) {
                            IsBusy[i][j] = false;
                            NumOfBusy[i][j] = -1;
                        }
                        hp[o] = -1;
                    }
                    if (hp[o] < 1) {
                        int my = 1;
                        int ord = order.IndexOf(o);
                        if (ord == order.Count - 1) my = 0;
                        VIP[i] = order[ord + my];
                        Vl[i] = l;
                        Vt[i] = t;
                        death = true;
                    }
                    else if (IsBusy[i].Contains(false)) {
                        for (int f = 0; f < IsBusy[i].Count; f++) {
                            if (IsBusy[i].Count > 1 && ((IsBusy[i][f] == true && NumOfBusy[i][f] != -1) ||
                                NumOfBusy[i].Contains(o))) continue;
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
            if (death) {
                for(int i = 0; i < NumOfPlace; i++) {
                    for (int f = 0; f < IsBusy[i].Count; f++) {
                        if (IsBusy[i][f] == true && NumOfBusy[i][f] != -1 && IsBusy[i].Count > 1) continue;
                        int ty = 1;
                        int tw = order.IndexOf(o);
                        if (tw == order.Count - 1) ty = 0;
                        NumOfBusy[i][f] = order[tw + ty];
                        IsBusy[i][f] = true;
                        break;
                    }
                }
                place1.Dispatcher.Invoke(new Action(() => {
                    canv.Children.Remove(imageControl[o]);
                    canv.Children.Remove(HpControl[o]);
                    pos[o] = imageControl[o].Margin.ToString();
                }));
                hisnum.Add(o);
                ++newer; return; }
            place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                imageControl[o].Margin = new Thickness(l, t, 0, 0);
                HpControl[o].Margin = new Thickness(l + 8, t + 22, 0, 0);
                HpControl[o].Content =  (int)hp[o];//l + "/" + t +  "(" + o + ") " +
                pos[o] = imageControl[o].Margin.ToString();
                count[o] = 0;
            }));
            if (l == 180 && t > 5) { t--; }
            else if (l == 390 && t < 230) { t++; }
            else if (l == 690 && t > 120) { t--; }
            else if (l > -21) l++;
            if (l >= 1100) {
                place1.Dispatcher.Invoke(new Action(() => {
                    canv.Children.Remove(imageControl[o]);
                    canv.Children.Remove(HpControl[o]);
                }));
                order.Remove(o);
                hisnum.Add(o);
                ++newer;
                return;
            }
        }
    }
    //first buy
    private void Button_Click(object sender, RoutedEventArgs e) {
        NumOfPlace = int.Parse((string)(sender as Button).Name.Substring(5)) - 1;
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
                        Image img = new Image();
                        if (Build.selected == 0) {
                            img.Source = pic5.Source;
                            places[NumOfPlace].Content = img;
                            Build.selected = -1; upgrade[NumOfPlace] = 1;
                        }
                        if (Build.selected == 1) {
                            img.Source = pic.Source;
                            places[NumOfPlace].Content = img;
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
                            Image img = new Image();
                            if (upgrade[NumOfPlace] == 1) {
                                img.Source = pic3.Source;
                                places[NumOfPlace].Content = img;
                            }
                            if (upgrade[NumOfPlace] == 2) {
                                img.Source = pic4.Source;
                                places[NumOfPlace].Content = img;
                            }
                            if (upgrade[NumOfPlace] == 11) {
                                img.Source = pic1.Source;
                                places[NumOfPlace].Content = img;
                            }
                            if (upgrade[NumOfPlace] == 12) {
                                img.Source = pic2.Source;
                                places[NumOfPlace].Content = img;
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
