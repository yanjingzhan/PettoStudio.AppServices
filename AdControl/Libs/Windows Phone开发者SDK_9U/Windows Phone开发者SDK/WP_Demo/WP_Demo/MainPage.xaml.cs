using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP_Demo.Resources;

namespace WP_Demo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 点击回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jyad_ClickBackMessageEvent(object sender, JiuYouWp8Ad.ClickBackMessage e)
        {
            switch (e.ClickBackMessageNo)//点击结果编号
            {
                case 1:
                    click_text.Text = "无效点击";
                    break;
                case 2:
                    click_text.Text = "有效点击";
                    break;
                case 3:
                    click_text.Text = "服务器无法处理请求";
                    break;
            }
        }

        /// <summary>
        /// 请求回掉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jyad_GetAdBackMessageEvent(object sender, JiuYouWp8Ad.GetAdBackMessage e)
        {
            switch (e.GetAdBackMessageNo)//请求结果编号
            { 
                case 1:
                    get_text.Text = "正常请求有返回广告";
                    break;
                case 2:
                    get_text.Text = "没有请求到广告";
                    break;
                case 3:
                    get_text.Text = "服务器无法处理请求或未联网，默认正常请求";
                    break;
            }
        }
        /// <summary>
        /// 请求广告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            jyad.Start();//持续请求广告
            // jyad.StartOnce();//只请求一个广告
        }

        /// <summary>
        /// 停止广告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            jyad.Stop();//停止广告
            get_text.Text = "广告停止,控件隐藏";
            click_text.Text = "";
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}