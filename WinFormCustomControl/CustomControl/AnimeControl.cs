using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    /// <summary>
    /// 动画展示控件
    /// 参考:
    /// [C# winform也能实现动画效果](https://blog.csdn.net/arrowzz/article/details/77649137)
    /// [Winform小火车动画](https://download.csdn.net/download/myinc/9953781)
    /// [How we design a beautiful animation](http://jeremie-martinez.com/2016/09/15/train-animations/)
    /// </summary>
    public partial class AnimeControl : UserControl
    {
        public AnimeControl()
        {
            InitializeComponent();
        }
    }
}
