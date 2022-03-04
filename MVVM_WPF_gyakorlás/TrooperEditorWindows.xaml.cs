using MVVM_WPF_gyakorlás.Models;
using MVVM_WPF_gyakorlás.ViewModels;
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

namespace MVVM_WPF_gyakorlás
{
    /// <summary>
    /// Interaction logic for TrooperEditorWindows.xaml
    /// </summary>
    public partial class TrooperEditorWindows : Window
    {
        public TrooperEditorWindows(Trooper trooper)
        {
            InitializeComponent();
            this.DataContext = new TrooperEditorWindowViewModel();
            (this.DataContext as TrooperEditorWindowViewModel).Setup(trooper);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
