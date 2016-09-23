using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CommonControl
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        void app_Startup(object sender, StartupEventArgs e)
        {
            // Create a window
            AlertDialog window = new AlertDialog("发行基金物流管理系统", " 进程之间通讯的几种方法:在Windows程序中，各个进程之间常常需要交换数据，进行数据通讯。常用的方法有使用内存映射文件通过共享内存DLL共享内存使用SendMessage向另一进程发送WM_COPYDATA消息比起前两种的复杂实现来,WM_COPYDATA消息无疑是一种经济实惠的一中方法.（ZT）WM_COPYDATA消息的主要目的是允许在进程间传递只读数据。Windows在通过WM_COPYDATA消息传递期间，不提供继承同步方式。SDK文档推荐用户使用SendMessage函数，接受方在数据拷贝完成前不返回，这样发送方就不可能删除和修改数据：这个函数的原型及其要用到的结构如下:SendMessage(hwnd,WM_COPYDATA,wParam,lParam);其中,WM_COPYDATA对应的十六进制数为0x004AwParam设置为包含数据的窗口的句柄。lParam指向一个COPYDATASTRUCT的结构：typedef struct tagCOPYDATASTRUCT{DWORD dwData;//用户定义数据DWORD cbData;//数据大小PVOID lpData;//指向数据的指针}COPYDATASTRUCT;该结构用来定义用户数据。具体过程如下:首先,在发送方,用FindWindow找到接受方的句柄,然后向接受方发送WM_COPYDATA消息.接受方在DefWndProc事件中,来处理这条消息.由于中文编码是两个字节,所以传递中文时候字节长度要搞清楚.", AlertDialog.CommonDialogType.Question);

            // Open a window
            window.Show();
        }
    }
}
