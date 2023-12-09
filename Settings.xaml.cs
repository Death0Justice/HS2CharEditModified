using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace HS2CharEdit
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Window
    {
        static Dictionary<string, string> tr = new()
        {
            { "StartupWindow", "启动时显示作者链接" },
            { "ExportWindow", "导出时显示未定滑块" },
            { "LZ4FastDecompress", "快速解压mod数据（可能失效）" },
        };
        private List<Setting> settings;
        private Configuration config;

        public Settings(Configuration config)
        {
            InitializeComponent();

            // Convert the KeyValueConfigurationCollection to an ordered enumerable of key-value pairs
            var s = config.AppSettings.Settings;
            settings = s
                .AllKeys
                .Select(key => new Setting(key, tr.GetValueOrDefault(key, key), s[key].Value == "Yes"))
                .OrderBy(pair => pair.Text)
                .ToList();
            this.config = config;

            configurations.ItemsSource = settings;
        }

        public void Confirm(object? sender, EventArgs e)
        {
            foreach (var setting in settings)
            {
                config.AppSettings.Settings[setting.Key].Value = setting.Value ? "Yes" : "No";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Close();
        }

        public void Cancel(object? sender, EventArgs e)
        {
            Close();
        }
    }

    public class Setting
    {
        public string Key;
        public string Text { get; }
        public bool Value { get; set; }

        public Setting(string Key, string Text, bool Value)
        {
            this.Key = Key;
            this.Text = Text;
            this.Value = Value;
        }
    }
}
