using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ScrollViewerStyle
{
	/// <summary>
	/// DataGrid.xaml 的交互逻辑
	/// </summary>
	public partial class DataGrid : Window
	{
        ObservableCollection<BookClass> list;
        int count=0;
		public DataGrid()
		{
			this.InitializeComponent();
            DataBinding();
			// 在此点之下插入创建对象所需的代码。
		}
        public void DataBinding()
        {
            list = new ObservableCollection<BookClass>() { 
                new BookClass("《射雕英雄传》", "金庸           ", true), 
                new BookClass("《完美世界》", "辰东         ", false), 
            };
            gridAutoGenerateColumns.ItemsSource = list;
        }


        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (list != null)
            {
                count++;
                list.Add(new BookClass("Book" + count.ToString(), "Author" + count.ToString(), false));
            }
            gridAutoGenerateColumns.ItemsSource = list;
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            list.RemoveAt(list.Count - 1);
            gridAutoGenerateColumns.ItemsSource = list;
        }
	}
}