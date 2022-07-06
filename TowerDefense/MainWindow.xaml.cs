using System;
using System.Collections.Generic;
using System.Linq;
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
/// Spended time: 50h
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        SetAll();
        build = new Build();
        Spawner = new Thread(Spawn);
        Spawner.Start(num);
    }
    List<double> positions_x = new List<double>(30);
    List<double> positions_y = new List<double>(30);
    bool test = true;
    int count = 0;
    public static bool ppp = true;
    int newer = 0;
    List<int> order = new List<int>();
    List<int> SmthngLikeCount = new List<int>();
    int[] hisnum = new int[500];
    double[] hp = new double[500];
    int[,] range = new int[30, 2];// x|y
    Thread EnemyThread;
    Thread Spawner;
    int num = 0;
    Thread thread;
    int NumOfPlace;
    Button[] places = new Button[30];
    Ellipse[] ellipses = new Ellipse[30];
    int[] upgrade = new int[30];
    bool[] IsBusy = new bool[30];
    int[] NumOfBusy = new int[30];
    int[] dmga = new int[30];
    double[] ddmg = new double[30];
    Build build;
    List<Image> imageControl = new List<Image>();
    List<Label> HpControl = new List<Label>();
    int death = 0;
    private void Spawn(object? obj) {
        int o = (int)obj;
        num = -1;
        EnemyThread = new Thread(EnemyMovement);
        while (ppp) {
            EnemyThread = new Thread(EnemyMovement);
            if (newer > 0) {
                o = hisnum[newer];
                order[order.Count - 1] = o;
                newer--;
                EnemyThread.Start(hisnum[newer + 1]);

            }
            else { o = ++num; order.Add(o); EnemyThread.Start(o); }
            if (death > 4) {
                death-=4;
                newhp += 5;
            }
            place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                if (newer == 0) {
                    imageControl.Add(new Image());
                    HpControl.Add(new Label());
                }
                HpControl[o].Foreground = Brushes.White;
                imageControl[o].Height = 50;
                imageControl[o].Width = 50;
                imageControl[o].Margin = new Thickness(-20, 275, 0, 0);
                imageControl[o].Source = God_ghost.Source;
                canv.Children.Add(imageControl[o]);
                canv.Children.Add(HpControl[o]);
            }));

            Thread.Sleep(3000);

        }
    }
    int newhp = 100;
    ScaleTransform flipTrans = new ScaleTransform();
    int coin_flip = 0;
    private void EnemyMovement(object? obj) {
        int o = (int)obj;
        hp[o] = newhp;
        double l = -20, t = 275;

        while (ppp) {
            if (hp[o] < 1) {
                order.RemoveAt(o); order.Add(o);
                place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                    canv.Children.Remove(imageControl[o]);
                    HpControl[o].Margin = new Thickness(-100, 0, 0, 0);
                    canv.Children.Remove(HpControl[o]);
                }));
                hisnum[++newer] = o;
                return;
            }

            Thread.Sleep(10);
           
            place1.Dispatcher.Invoke(new Action(() => { build.dmg.Content = (int)ddmg[NumOfPlace];
                for (int i = 0; i < ellipses.Length; i++) {
                    if (IsBusy[i] && ellipses[i].Visibility == Visibility.Hidden && upgrade[i] > 0) { ellipses[i].Visibility = Visibility.Visible; }
                }
            }));
            for (int i = 0; i < IsBusy.Length; i++) {
                dmga[i]++;
                if (dmga[i] > order.Count + 5) { IsBusy[i] = false; dmga[i] = 0; }
                bool SomeMath = Math.Sqrt(Math.Abs((range[i, 0] - l) * (range[i, 0] - l)) + Math.Abs((range[i, 1] - t + 90) * (range[i, 1] - t + 90))) < 175;
                if (upgrade[i] > 10 && SomeMath) { IsBusy[i] = false; }
                else {
                    if ((NumOfBusy[i] == o) && !SomeMath) {
                        IsBusy[i] = false;
                        int rt = order.IndexOf(o);
                        int one = rt == order.Count - 1 ? 0 : 1;
                        NumOfBusy[i] = order[rt + one];
                    }
                }
                if (((!IsBusy[i] || NumOfBusy[i] == o) && SomeMath)) {
                    double dmg = 0;
                    if (upgrade[i] == 1) { dmg = 0.2; }
                    else if (upgrade[i] == 11) { dmg = 0.05; }
                    else if (upgrade[i] == 2) { dmg = 0.6; }
                    else if (upgrade[i] == 3) { dmg = 1.8; }
                    else if (upgrade[i] == 12) { dmg = 0.1; }
                    else if (upgrade[i] == 13) { dmg = 0.2; }
                    hp[o] -= dmg;
                    ddmg[i] += dmg;
                    if (dmg != 0) dmga[i] = 0;
                    if (hp[o] < 1) {
                        death++;
                        IsBusy[i] = true;
                        place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                            money.Content = (int)money.Content + 5;
                            canv.Children.Remove(imageControl[o]);
                            HpControl[o].Margin = new Thickness(-100, 0, 0, 0);
                            canv.Children.Remove(HpControl[o]);
                        }));
                        int ee = order.IndexOf(o) + 1;
                        order.RemoveAt(o); order.Add(o); hisnum[++newer] = o;
                        NumOfBusy[i] = ee;
                        return;
                    }
                    else { IsBusy[i] = true; NumOfBusy[i] = o; }

                }
                else {
                    place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                        for (int i = 0; i < ellipses.Length; i++) {
                            if (!IsBusy[i] && ellipses[i].Visibility == Visibility.Visible) { ellipses[i].Visibility = Visibility.Hidden; }
                        }
                    }));
                }
            }
            place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                imageControl[o].Margin = new Thickness(l, t, 0, 0);
                HpControl[o].Margin = new Thickness(l + 8, t + 22, 0, 0);
                HpControl[o].Content = (int)hp[o];
            }));
            if (l == 184 && t > 105) { t--; }
            else if (l == 386 && t < 330) { t++; }
            else if (l == 690 && t > 220) { t--; }
            else l++;
            if (l >= 1100) {
                order.RemoveAt(o); order.Add(o);
                place1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() => {
                    canv.Children.Remove(imageControl[o]);
                    HpControl[o].Margin = new Thickness(-100, 0, 0, 0);
                    canv.Children.Remove(HpControl[o]);
                }));
                hisnum[++newer] = o; return;
            }
        }
    }
    //upgrade button
    private void Button_Click(object sender, RoutedEventArgs e) {
        NumOfPlace = int.Parse((string)(sender as Button).Name.Substring(5)) - 1;
        double l = (sender as Button).Margin.Left, t = (sender as Button).Margin.Top;
        int u = 124;
        build.Left = Left + l + 5;
        build.Top = Top + t + u;
        thread = new Thread(wait);
        if (upgrade[NumOfPlace] == 1) { build.upg.Content = 35; build.des.Content = 12; }
        if (upgrade[NumOfPlace] == 2) { build.upg.Content = 50; build.des.Content = 30; }
        if (upgrade[NumOfPlace] == 3) { build.upg.Content = "max"; build.des.Content = 55; }
        if (upgrade[NumOfPlace] == 11) { build.upg.Content = 50; build.des.Content = 17; }
        if (upgrade[NumOfPlace] == 12) { build.upg.Content = 70; build.des.Content = 42; }
        if (upgrade[NumOfPlace] == 13) { build.upg.Content = "max"; build.des.Content = 77; }
        build.Show();
        build.Focus();
        thread.Start(build);
    }
    //upgrade
    private async void wait(object? obj) {
        while (ppp) {
            Thread.Sleep(1);
            if (upgrade[NumOfPlace] > 0) {
                place1.Dispatcher.Invoke(() => {
                    if (!(obj as Window).IsActive) {
                        if (Build.Destroy == 0) {
                            Image img = new Image();
                            int pr = 0;
                            int u = upgrade[NumOfPlace];
                            if (u == 1) { pr = 35; }
                            if (u == 2) { pr = 50; }
                            if (u == 11) { pr = 50; }
                            if (u == 12) { pr = 70; }
                            int m = (int)money.Content;
                            if (m >= pr) { 
                            if (u == 1) { img.Source = bow2.Source; places[NumOfPlace].Content = img; pr = 35; }
                            if (u == 2) { img.Source = bow3.Source; places[NumOfPlace].Content = img; pr = 50; }
                            if (u == 11) { img.Source = wiz2.Source; places[NumOfPlace].Content = img; pr = 50; }
                            if (u == 12) { img.Source = wiz3.Source; places[NumOfPlace].Content = img; pr = 70; }
                            if (u != 13 && u != 3) {
                                money.Content = m - pr;
                                upgrade[NumOfPlace]++;
                            }
                            }
                            Build.Destroy = -1;
                        }//destroy
                        else if (Build.Destroy == 1) {
                            SmthngLikeCount.Remove(NumOfPlace);
                            money.Content = (int)money.Content + (int)build.des.Content;
                            places[NumOfPlace].Background = Brushes.White;
                            upgrade[NumOfPlace] = 0;
                            Build.Destroy = -1;
                            places[NumOfPlace].Visibility = Visibility.Hidden;
                            positions_x[NumOfPlace] = -300;
                            positions_y[NumOfPlace] = -300;

                        }
                        return;
                    }
                });
            }
        }
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
        ppp = false;
        build.Close();
    }
    int type = 0;
    private void bowman_MouseMove(object sender, MouseEventArgs e) {
        if (e.LeftButton == MouseButtonState.Pressed) {
            type = 0;
            DragDrop.DoDragDrop(bow, bow, DragDropEffects.Move);
        }
    }
    private void canv_DragOver(object sender, DragEventArgs e) {
        Point dpos = e.GetPosition(canv);
        last_pos.X = dpos.X - 68;
        last_pos.Y = dpos.Y - 38;
        if (type == 0) {
            Canvas.SetLeft(bow, dpos.X - 47.5);
            Canvas.SetTop(bow, dpos.Y - 47.5);
        }
        if (type == 1) {
            Canvas.SetLeft(wiz, dpos.X - 47.5);
            Canvas.SetTop(wiz, dpos.Y - 47.5);
        }
    }
    Point last_pos;
    private void wizard_MouseMove(object sender, MouseEventArgs e) {
        if (e.LeftButton == MouseButtonState.Pressed) {
            type = 1;
            DragDrop.DoDragDrop(wiz, wiz, DragDropEffects.Move);
        }
    }

    private void canv_Drop(object sender, DragEventArgs e) {
        if (type == 0) {//return archer to start position
            Canvas.SetLeft(bow, 33);
            Canvas.SetTop(bow, 426);
        }
        if (type == 1) {
            Canvas.SetLeft(wiz, 147);
            Canvas.SetTop(wiz, 426);
        }

        if (last_pos.X < 190 && last_pos.Y > 185 && last_pos.Y < 326) { return; }
        if (last_pos.X > 50 && last_pos.X < 220 && last_pos.Y > 23 && last_pos.Y < 250) { return; }
        if (last_pos.X > 190 && last_pos.X < 400 && last_pos.Y > 23 && last_pos.Y < 166) { return; }
        if (last_pos.X > 267 && last_pos.X < 436 && last_pos.Y > 15 && last_pos.Y < 392) { return; }
        if (last_pos.X > 267 && last_pos.X < 727 && last_pos.Y > 240 && last_pos.Y < 393) { return; }
        if (last_pos.X > 556 && last_pos.X < 727 && last_pos.Y > 128 && last_pos.Y < 393) { return; }
        if (last_pos.X < 222 && last_pos.Y > 340) { return; }
        if (last_pos.X > 556 && last_pos.Y > 128 && last_pos.Y < 281) { return; }
        for (int i = 0; i < count; i++) {
            if (positions_x[i] + 96 > last_pos.X && positions_x[i] - 96 < last_pos.X &&
                positions_y[i] + 96 > last_pos.Y && positions_y[i] - 96 < last_pos.Y) { return; }
        }
        int m = (int)money.Content;
        int pr = 0;
        if (type == 0) pr = 25;
        if (type == 1) pr = 35;
        if (m < pr) { return; }
        money.Content = m - pr;

        for (int i = 0; i < 31; i++) {
            if (!SmthngLikeCount.Contains(i)) {
                SmthngLikeCount.Add(i);
                NumOfPlace = i;
                break;
            }
        }
        Image image = new Image();
        if (type == 0) {
            image.Source = bow.Source;
            places[NumOfPlace].Content = image;
            upgrade[NumOfPlace] = 1;
        }
        if (type == 1) {
            image.Source = wiz.Source;
            places[NumOfPlace].Content = image;
            upgrade[NumOfPlace] = 11;
        }
        places[NumOfPlace].Margin = new Thickness(last_pos.X, last_pos.Y, 0, 0);
        range[NumOfPlace, 0] = (int)(last_pos.X + 25);//write down position of the place  
        range[NumOfPlace, 1] = (int)(last_pos.Y - 47.5);
        places[NumOfPlace].Visibility = Visibility.Visible;
        double top = places[NumOfPlace].Margin.Top;
        double left = places[NumOfPlace].Margin.Left;
        ellipses[NumOfPlace].Margin = new Thickness(left - 127, top - 127, 0, 0);
        if (test) { test = false; Button_Click(place1, null); }
        if (NumOfPlace >= count) {
            positions_x.Add(left);
            positions_y.Add(top);
            count++;
        }
        else {
            positions_x[NumOfPlace] = left;
            positions_y[NumOfPlace] = top;
        }

    }
    void SetAll() {
        money.Content = 50;
        flipTrans.ScaleX = 1;
        for (int i = 0; i < NumOfBusy.Length; i++) {
            NumOfBusy[i] = -1;
        }
        places[0] = place1;
        places[1] = place2;
        places[2] = place3;
        places[3] = place4;
        places[4] = place5;
        places[5] = place6;
        places[6] = place7;
        places[7] = place8;
        places[8] = place9;
        places[9] = place10;
        places[10] = place11;
        places[11] = place12;
        places[12] = place13;
        places[13] = place14;
        places[14] = place15;
        places[15] = place16;
        places[16] = place17;
        places[17] = place18;
        places[18] = place19;
        places[19] = place20;
        places[20] = place21;
        places[21] = place22;
        places[22] = place23;
        places[23] = place24;
        places[24] = place25;
        places[25] = place26;
        places[26] = place27;
        places[27] = place28;
        places[28] = place29;
        places[29] = place30;

        ellipses[0] = e1;
        ellipses[1] = e2;
        ellipses[2] = e3;
        ellipses[3] = e4;
        ellipses[4] = e5;
        ellipses[5] = e6;
        ellipses[6] = e7;
        ellipses[7] = e8;
        ellipses[8] = e9;
        ellipses[9] = e10;
        ellipses[10] = e11;
        ellipses[11] = e12;
        ellipses[12] = e13;
        ellipses[13] = e14;
        ellipses[14] = e15;
        ellipses[15] = e16;
        ellipses[16] = e17;
        ellipses[17] = e18;
        ellipses[18] = e19;
        ellipses[19] = e20;
        ellipses[20] = e21;
        ellipses[21] = e22;
        ellipses[22] = e23;
        ellipses[23] = e24;
        ellipses[24] = e25;
        ellipses[25] = e26;
        ellipses[26] = e27;
        ellipses[27] = e28;
        ellipses[28] = e29;
        ellipses[29] = e30;
    }
}