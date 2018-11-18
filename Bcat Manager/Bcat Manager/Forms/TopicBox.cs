using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcat_Manager.Forms
{
    public partial class TopicBox : UserControl
    {
        private int _shadowSize = 2;
        private int _selectSize = 3;
        private float _intensity = 0.2f;
        private bool _sel = false;
        private NewsData _topic = null;


        public NewsData Topic
        {
            get { return _topic; }
            set { _topic = value; Invalidate(); }
        }
        public bool Selected
        {
            get { return _sel; }
            set {

                if (value != _sel)
                {
                    _sel = value;
                    Invalidate();
                }
            }
        }
        public Color SelectColor { get; set; } = SystemColors.ActiveCaption;
        public Color TopicColor { get; set; } = Color.White;

        public int SelectionSize
        {
            get { return _selectSize; }
            set
            {
                if (value >= Width / 2 || value >= Height / 2)
                    throw new Exception("SelectionSize cannot be greater than the Width or the Height");
                _selectSize = value;
            }
        }
        public int ShadowSize
        {
            get { return _shadowSize; }
            set {
                if (value >= Width / 2 || value >= Height / 2)
                    throw new Exception("ShadowSize cannot be greater than the Width or the Height");
                _shadowSize = value;
            }
        }
        public float ShadowIntensity
        {
            get { return _intensity; }
            set
            {
                if (value > 1.0 || value < 0.0)
                    throw new Exception("ShadowIntensity must be between 0.0 and 1.0");
                _intensity = value;
            }
        }

        public TopicBox()
        {
            InitializeComponent();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (_topic != null)
            {
                using (Bitmap bmp = Utils.GetBitmap(_topic.list_image))
                {
                    int margin = Math.Max(_shadowSize, _selectSize);
                    int imgWidth = Width - margin * 2;
                    float ratio = (float)bmp.Width / imgWidth;
                    int imgHeight = (int)(bmp.Height / ratio);

                    DrawShadow(e.Graphics, new Rectangle(margin, margin, imgWidth, Height - 2 * margin), _shadowSize, _intensity);
                    e.Graphics.FillRectangle(new SolidBrush(TopicColor), new Rectangle(margin, margin, imgWidth, Height - 2 * margin));
                    e.Graphics.DrawImage(bmp, margin, margin, imgWidth, imgHeight);

                    
                    int textMargX = 10;
                    int textMargY = 5;

                    var rec = new Rectangle(
                        margin + textMargX,
                        margin + imgHeight + textMargY,
                        imgWidth - 2 * textMargX,
                        Height - imgHeight - margin * 2 - textMargY * 2);
                    
                    SmartDrawString(e.Graphics, _topic.subject.text, Font, ForeColor, rec);
                    

                    if (_sel)
                    {
                        Brush b = new SolidBrush(SelectColor);
                        e.Graphics.FillRectangle(b, new Rectangle(0, 0, Width, _selectSize)); //top
                        e.Graphics.FillRectangle(b, new Rectangle(0, Height-_selectSize, Width, _selectSize)); //bottom
                        e.Graphics.FillRectangle(b, new Rectangle(0, 0, _selectSize, Height)); //left
                        e.Graphics.FillRectangle(b, new Rectangle(Width-_selectSize, 0, _selectSize, Height));//right
                    }
                }
            }
        }

        public void DrawShadow(Graphics g, Rectangle rec, int size, float intensity)
        {
            if (intensity > 1.0) intensity = 1.0f;
            if (intensity < 0.0) intensity = 0.0f;

            int a = (int)(intensity * 255);
            int ratio = a / size;

            for (int i = 0; i < size; i++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(a - i * ratio, 0, 0, 0)), rec.X - i, rec.Y - i, rec.Width + 2 * i, rec.Height + 2 * i);
            }
        }

        public void SmartDrawString(Graphics g, string text, Font f, Color c, Rectangle rec)
        {
            if (text == "L'un des plus grands jeux d'aventure de tous les temps est de retour, meilleur que jamais.")
            {
                Console.WriteLine("");
            }

            int lineCount = (int)Math.Floor(rec.Height / g.MeasureString("A", f).Height);

            string total = "";
            string[] lines = new string[lineCount];

            string[] words = text.Split(' ');

            int line = 0;
            bool fulltext = false;

            for (int i = 0; i < words.Length && line < lineCount; i++)
            {
                if (g.MeasureString(total + " " + words[i], f).Width > rec.Width)
                {
                    lines[line++] = total;
                    total = words[i] + " ";
                    //check if line >= lineCount
                }
                else
                {
                    total += words[i] + " ";
                }

                if (i + 1 >= words.Length && line < lineCount)
                {
                    lines[line] = total;
                    fulltext = true;
                }
            }

            if (!fulltext)
            {
                lines[lineCount-1] += "...";
            }


            total = "";
            for (int i = 0; i < lineCount; i++)
                total += (i+1 < lineCount) ? lines[i] + "\r\n" : lines[i];

            g.DrawString(total, f, new SolidBrush(c), rec.X, rec.Y);

        }
    }
}
