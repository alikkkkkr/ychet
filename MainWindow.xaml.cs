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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac4sharp
{
    public partial class MainWindow : Window
    {
        List<MyClass> json_list = new List<MyClass>();
        List<MyClass> dela_today = new List<MyClass>();
        List<string> strings = new List<string>() { "хозяйство", "налоги", "зарплата" };
        generic generic = new generic();
        public MainWindow()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString();
            type_combobox.ItemsSource = strings;
        }

        private void add_but_Click(object sender, RoutedEventArgs e)
        {
            if (name != null && sum_user != null && type_combobox.SelectedValue != null)
            {
                MyClass dela = new MyClass(name.Text, type_combobox.SelectedValue.ToString(), Convert.ToInt32(sum_user.Text), date.Text);
                json_list.Add(dela);
                poseril();
                deseril();
            }
        }

        private void poseril()
        {
            generic.serializ<List<MyClass>>(json_list, "C:\\Users\\alinaryzhkova\\source\\repos\\prac4sharp\\prac4sharp\\json_all.json");
        }
        private void deseril()
        {
            name.Text = "";
            sum_user.Text = "";
            type_combobox.Text = "";

            json_list.Clear();
            dela_today.Clear();
            json_list = generic.deserializ<List<MyClass>>("C:\\Users\\alinaryzhkova\\source\\repos\\prac4sharp\\prac4sharp\\json_all.json");
            foreach (MyClass dela in json_list)
                if (dela.date_buy.ToString() == date.Text)
                    dela_today.Add(dela);

            datagrid.ItemsSource = null;
            datagrid.ItemsSource = dela_today;

            int itog_i = 0;
            foreach (MyClass i in dela_today)
                if (i.plus_minus == true)
                    itog_i += i.money;
            else itog_i -= i.money;
            itog.Text = itog_i.ToString();
        }
        private void change_but_Click(object sender, RoutedEventArgs e)
        {
            (datagrid.SelectedItem as MyClass).name = name.Text;
            (datagrid.SelectedItem as MyClass).type_buy = type_combobox.Text;
            (datagrid.SelectedItem as MyClass).money = Convert.ToInt32(sum_user.Text);
            poseril();
            deseril();
        }

        private void delete_but_Click(object sender, RoutedEventArgs e)
        {
            json_list.Remove(datagrid.SelectedItem as MyClass);
            poseril();
            deseril();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                name.Text = (datagrid.SelectedItem as MyClass).name;
                type_combobox.Text = (datagrid.SelectedItem as MyClass).type_buy;
                sum_user.Text = (datagrid.SelectedItem as MyClass).money.ToString();
            }
        }

        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            deseril();
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            deseril();
        }
    }
}
