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
        }

        /// <summary>
        /// 画表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawTable_Paint(object sender, PaintEventArgs e)
        {
            
            //绘制表格
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(color, widthPen);  //设置画笔颜色和Pen
            //横线
            int hightRow = this.Height / numRow;    //行高
            for (int y = 0; y <= this.Height; y += hightRow)
            {
                graphics.DrawLine(pen, 0, y, this.Width, y);
            }

            //竖线
            int widthColumn = this.Width / numColumn;
            for (int x = 0; x <= this.Width;x += widthColumn)
            {
                graphics.DrawLine(pen, x, 0, x, this.Height);
                
            }
            


        }
    }
}
