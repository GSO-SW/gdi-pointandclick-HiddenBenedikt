using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;

            Random farbengenerator= new Random();

            // Zeichenmittel
  


            for (int i = 0; i < rectangles.Count; i++)
            {
                Color farbe = Color.FromArgb(farbengenerator.Next(256), farbengenerator.Next(256), farbengenerator.Next(256));
                Brush b = new SolidBrush(farbe);

                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            bool contains = false;

            Random groeßenGenerator = new Random();
            int groeße = groeßenGenerator.Next(40, 120);

            Rectangle r = new Rectangle(mausposition.X - groeße/2, mausposition.Y - groeße/2, groeße, groeße);

            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].Contains(mausposition))
                {
                    contains = true;

                    if (e.Button == MouseButtons.Right)
                    {
                        rectangles.RemoveAt(i);
                    }
                    else
                    {
                        break;
                    }

                }

            }
            if (contains == false)
            {
                rectangles.Add(r);
            }
            Refresh();

        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}