using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Monitor
{
    /// <summary>
    /// 自定义圆环靶标控件
    /// 参考：https://www.cnblogs.com/qylost/articles/11437998.html
    /// </summary>
    class CircleTarget : Control
    {
        private int targetNumber = 0;       //中靶的数字，默认0代表没有中靶
        private int size = 280;     //这个靶标所处矩形区域的默认尺寸(圆形靶标必须是矩形)
        private Pen penBottom = null;//底层画笔
        private Pen penTop = null;//上层画笔

        //-------------------颜色
        private Color bottomColor = Color.FromArgb(1, 229, 222);
        private Color topColor = Color.FromArgb(255, 0, 0);

        //解决控件批量更新时带来的闪烁
        protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.ExStyle |= 0x02000000; return cp; } }

        public CircleTarget()
        {
            

            //初始化控件大小,背景颜色
            this.Width = size;       
            this.Height = size;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);     //支持透明背景色
            //this.BackColor = Color.Transparent;

            this.penBottom = new Pen(this.bottomColor, 2);      //画笔
            this.penTop = new Pen(this.topColor, 2);

            this.SizeChanged += delegate
            {
                this.Invalidate();
            };
        }


        //对Control进行绘制
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            DrawShape(e.Graphics);
        }

        /// <summary>
        /// 进度值
        /// </summary>
        public int TargetNumber
        {
            get { return this.targetNumber; }
            set
            {
                this.targetNumber = value;      //设置靶心，重绘
                this.Invalidate();
            }
        }


        /// <summary>
        /// 初始化和中靶时，都需要重绘整个图形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="numTarget">中的靶子</param>
        private void DrawShape(Graphics g)
        {
            if (this.Width < 100 || this.Height < 100)
            {
                return;
            }
            
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            //1、绘制背景
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, this.Width, this.Height));
            
            //2、绘制靶子
            int sizeOffset = 2;//进度条距离最外侧的偏移量
            int total = 10;     //总共绘制圆的数量
            int sizeMax = Math.Min(this.Width, this.Height);//最外圈圆的大小
            int interval = sizeMax / total;
            for (int i = 0; i < 10; i++) 
            {
                int curentSize = sizeMax - interval * i;
                Rectangle rectangle = new Rectangle(this.Width / 2 - curentSize / 2 + sizeOffset, this.Height / 2 - curentSize / 2 + sizeOffset, curentSize - (sizeOffset * 2), curentSize - (sizeOffset * 2));//计算圆的范围
                if (i == targetNumber - 1)
                {
                    g.DrawArc(this.penTop, rectangle, 0, 360);//绘制命中环
                }
                else
                {
                    g.DrawArc(this.penBottom, rectangle, 0, 360);//绘制普通环
                }

                
            }
            
           
           
            
        }

    }
}
