using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTLauncher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Screen screen = Screen.FromPoint(new Point(Cursor.Position.X, Cursor.Position.Y));
            int x = screen.WorkingArea.X + screen.WorkingArea.Width - this.Width;
            int y = screen.WorkingArea.Y + screen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }
    }
}
