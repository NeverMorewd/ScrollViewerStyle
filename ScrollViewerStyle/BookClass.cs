using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BookClass
{
    public string Title { get; set; }//自动使用DataGridTextColumn模板
    public string Author { get; set; }//自动使用DataGridTextColumn模板
    public DateTime Time { get { return DateTime.Now; } }//不可修改,只读
    public bool IsCheck { get; set; }//自动使用DataGridCheckBoxColumn模板

    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="title">书名</param>
    /// <param name="author">作者</param>
    /// <param name="ischeck">是否选择</param>
    public BookClass(string title, string author,bool ischeck)
    {
        Title = title;
        Author = author;
        IsCheck = ischeck;
    }
}
