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
    /// 画表格，该控件在一篇区域上均匀的布置表格
    /// 参考:https://blog.csdn.net/qq_22955427/article/details/76252582
    /// </summary>
    public partial class DrawTable : UserControl
    {

        //定义输入变量
        private Color color = Color.Black;      //默认画笔颜色
        int widthPen = 3;       //默认画笔宽度
        int numColumn = 2;      //列
        int numRow = 10;      //行数目
        public DrawTable()
        {
            InitializeComponent();
            //当尺寸改变时，进行重绘
            this.SizeChanged += delegate
            {
                this.Invalidate();
            };
        }

        //解决控件批量更新时带来的闪烁
        protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.ExStyle |= 0x02000000; return cp; } }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);      //重写 OnPaint时，通常应调用基类的 OnPaint 方法，以便注册的委托接收 Paint 事件。 但是，绘制整个图面的控件不应调用基类的 OnPaint，因为这会引入闪烁

            Graphics graphics = e.Graphics;
                 
            Pen pen = new Pen(color, widthPen);  //设置画笔颜色和Pen
            //横线
            graphics.DrawLine(pen, 0, this.Height - widthPen, this.Width, this.Height - widthPen);//为了防止线露头，把最后一根单独画
            int hightRow = this.Height / numRow;    //行高
            int y = 0;
            for (int i = 0; i < numRow; i++)
            {
                graphics.DrawLine(pen, 0, y + i * hightRow, this.Width, y + i * hightRow);
            }

            //竖线
            graphics.DrawLine(pen, this.Width - widthPen, 0, this.Width - widthPen, this.Height);       //为了防止线露头，把最后一根单独画
            int widthColumn = this.Width / numColumn;
            int x = 0;
            for (int i = 0; i <= numColumn; i++)
            {
                graphics.DrawLine(pen, x + i * widthColumn, 0, x + i * widthColumn, this.Height);

            }
        }

        
    }
}
