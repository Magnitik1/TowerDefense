using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TowerDefense;
/// <summary>
/// Interaction logic for Upgrade.xaml
/// </summary>
public partial class Upgrade : Window {
    public Upgrade() {
        InitializeComponent();
    }
    public static int Destroy=-1;

    private void ListBoxItem_Selected(object sender, RoutedEventArgs e) {

    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        if ((sender as ListBox).SelectedIndex == 0) Destroy = 0;
        if ((sender as ListBox).SelectedIndex == 1) Destroy=1;
            (sender as ListBox).SelectedItem = null;
            Hide();
    }
}

