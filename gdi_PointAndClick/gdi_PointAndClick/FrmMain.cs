using System.Collections.Generic; // ben�tigt f�r Listen

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

            Random groe�enGenerator = new Random();
            int groe�e = groe�enGenerator.Next(40, 120);

            Rectangle r = new Rectangle(mausposition.X - groe�e/2, mausposition.Y - groe�e/2, groe�e, groe�e);

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