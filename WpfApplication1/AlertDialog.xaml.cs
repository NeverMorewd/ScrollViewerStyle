using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommonControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AlertDialog : Window
    {
        #region 变量定义
        /// <summary>
        /// 对话框的类型
        /// </summary>
        private CommonDialogType commonDialogType;

        /// <summary>
        /// 对话框标题
        /// </summary>
        private string title = string.Empty;

        /// <summary>
        /// 对话框消息
        /// </summary>
        private string message = string.Empty;

        /// <summary>
        /// 定时器
        /// </summary>
        //private DispatcherTimer timerObject;
        #endregion

        #region 常量定义
        /// <summary>
        /// 定时器间隔时间
        /// </summary>
        private const double TIME_INTERVAL = 0.1;

        /// <summary>
        /// 关闭按钮路径1
        /// </summary>
        private const string MESSAGE_COLSE_1 = "/Julong.CCM.Views;component/images/MessageColse1.png";

        /// <summary>
        /// 关闭按钮路径2
        /// </summary>
        private const string MESSAGE_COLSE_2 = "/Julong.CCM.Views;component/images/MessageColse2.png";

        /// <summary>
        /// 提示图标路径
        /// </summary>
        private const string PROMPT_IMAGE = "/Julong.CCM.Views;component/images/warn.ico";

        #endregion

        #region API声明
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);
        #endregion
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="message">消息</param>
        /// <param name="commonDialogType">对话框的类型</param>
        public AlertDialog(string title, string message, CommonDialogType commonDialogType)
        {
            this.InitializeComponent();
            var window = this.GetTopWindow();
            if (window != null)
            {
                this.Owner = window;
            }
            this.ShowInTaskbar = false;
            this.commonDialogType = commonDialogType;
            this.title = title;
            this.message = message;
            this.Init();
        }
        /// <summary>
        /// 初始化对话框
        /// </summary>
        private void Init()
        {
            this.TxtMessage.Text = this.message;
            this.TxtTitle.Text = this.title;

            switch (this.commonDialogType)
            {
                case CommonDialogType.Question:
                    this.YesButton.Visibility = Visibility.Visible;
                    this.NoButton.Visibility = Visibility.Visible;
                    this.ConfirmButton.Visibility = Visibility.Hidden;
                    break;

                case CommonDialogType.Error:
                    this.YesButton.Visibility = Visibility.Hidden;
                    this.NoButton.Visibility = Visibility.Hidden;
                    this.ConfirmButton.Visibility = Visibility.Visible;
                    break;
                case CommonDialogType.Infomation:
                    this.YesButton.Visibility = Visibility.Hidden;
                    this.NoButton.Visibility = Visibility.Hidden;
                    this.ConfirmButton.Visibility = Visibility.Visible;
                    break;
            }
        }
        /// <summary>
        /// 是按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
        }

        /// <summary>
        /// 否按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false;
        }

        /// <summary>
        /// 确认按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
        }
        /// <summary>
        /// 调用GetForegroundWindow然后调用GetWindowFromHwnd
        /// </summary>
        /// <returns></returns>
        private Window GetTopWindow()
        {
            var hwnd = GetForegroundWindow();
            if (hwnd == null) return null;
            return GetWindowFromHwnd(hwnd);
        }
        /// <summary>
        /// 从Handle中获取Window对象
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        private Window GetWindowFromHwnd(IntPtr hwnd)
        {
            var obj = HwndSource.FromHwnd(hwnd);
            if (obj != null)
            {
                var window = obj.RootVisual;
                return (Window)window;
            }
            return null;
        }
        /// <summary>
        /// GetForegroundWindow API
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// 对话框类型
        /// </summary>
        public enum CommonDialogType
        {
            Question = 0,
            Error,
            Infomation,
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // 获取鼠标相对标题栏位置  
            Point position = e.GetPosition(gridTitleBar);

            // 如果鼠标位置在标题栏内，允许拖动  
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (position.X >= 0 && position.X < gridTitleBar.ActualWidth && position.Y >= 0 && position.Y < gridTitleBar.ActualHeight)
                {
                    this.DragMove();
                }
            }
        }  
    }
}
