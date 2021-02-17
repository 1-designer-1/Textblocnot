using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textblocnot
{
    public partial class Form1 : Form
    {
        Bloknot Bloknot;
        public Form1()
        {
            InitializeComponent();
            Bloknot = new Bloknot(richTextBox1);
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();

        }

        private void СоздатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bloknot.Create();
            this.Text = Bloknot.Namefile;
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bloknot.OpenFile();
        }
    }
}
