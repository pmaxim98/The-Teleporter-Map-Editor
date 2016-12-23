using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPMapEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeWindowSize();
            InitializeMenuStrip();
        }

        private void InitializeMenuStrip()
        {
            foreach (ToolStripMenuItem menuItem in MenuStrip.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
            MenuStrip.Renderer = new MenuStripRenderer();
        }

        private void InitializeWindowSize()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int newWidth = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int newHeight = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            Location = new Point((screen.Width - newWidth) / 2, (screen.Height - newHeight) / 2);
            Size = new Size(newWidth, newHeight);
        }

        private void QuitFileMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
