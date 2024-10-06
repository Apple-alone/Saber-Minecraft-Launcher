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
using Panuon.UI.Silver;
using KMCCC.Launcher;
using KMCCC.Authentication;
using Microsoft.Win32;
using System.Diagnostics;

namespace Saber_Minecraft_Launcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public static LauncherCore Core = LauncherCore.Create();
        public MainWindow()
        {
            InitializeComponent();
            var versions = Core.GetVersions().ToArray();
            versionCombo.ItemsSource = versions; //版本查询
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.JavaPath = @"C:\Program Files\Java\jdk-17\bin\javaw.exe";
            var ver = (KMCCC.Launcher.Version)versionCombo.SelectedItem;
            var result = Core.Launch(new LaunchOptions
            {
                Version = ver, //Ver为Versions里你要启动的版本名字
                MaxMemory = 1024, //最大内存，int类型
                Authenticator = new OfflineAuthenticator("Ocean_Prince"), //离线启动，ZhaiSoul那儿为你要设置的游戏名
                                                                          //Authenticator = new YggdrasilLogin("邮箱", "密码", true), // 正版启动
                Mode = LaunchMode.MCLauncher, //启动模式
                Size = new WindowSize { Height = 768, Width = 1280 } //设置窗口大小

            });
        }

        private void JavaSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
