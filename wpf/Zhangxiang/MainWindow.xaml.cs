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
using Zhangxiang.Models;

namespace Zhangxiang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            List<SystemType> systems = new();
            systems.Add(new SystemType()
            {
                Code = "0",
                Name = "OA"
            });
            systems.Add(new SystemType()
            {
                Code = "1",
                Name = "SAP"
            });
            systems.Add(new SystemType()
            {
                Code = "2",
                Name = "WMS "
            });
            SystemTypes.ItemsSource = systems;
            SystemTypes.DisplayMemberPath = "Name";
            SystemTypes.SelectedValuePath = "Code";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var system = SystemTypes.SelectedValue;
            var input = Input.Text;


            Output.Text = $"系统参数为:{system} 输入参数为:{input}";
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            SystemTypes.SelectedValue = null;
            Input.Text = string.Empty;
            Output.Text = string.Empty;
        }
    }
}
