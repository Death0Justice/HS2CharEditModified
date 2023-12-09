using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static HS2CharEdit.MainWindow;

namespace HS2CharEdit
{
    /// <summary>
    /// Export.xaml 的交互逻辑
    /// </summary>
    public partial class Export : Window
    {
        private List<ConfigJson1> originalUndefined;

        public Export(List<ConfigJson1> undefined)
        {
            originalUndefined = undefined;
            InitializeComponent();
            this.undefined.ItemsSource = originalUndefined;
            if (undefined.Count == 0)
            {
                this.undefined.Visibility = Visibility.Collapsed;
                undefinedSliders.Content = "所有滑块均已读取完毕";
            }
        }

        public void OnExportClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            for (int i = 0; i < undefined.Items.Count; i++)
            {
                object row = undefined.Items[i];
                //originalUndefined[i].DefaultValue = row.DefaultValue;
            }
            Close();
        }

        public bool? IsDismissed()
        {
            return dismiss.IsChecked;
        }
    }
}
