using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Textblocnot;

namespace Textblocnot
{
    public partial class Form1 : Form
    {
        Bloknot Bloknot;
        public string title = "" + " - " + "Notebook";
        public Form1()
        {
            InitializeComponent();
            Bloknot = new Bloknot(richTextBox1);
            this.Text = title;
        }

        private void СоздатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bloknot.Create();
            this.Text = Bloknot.Namefile;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bloknot.Save(ref title);
            this.Text = title;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bloknot.SaveAs(ref title);
            this.Text = title;
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bloknot.OpenFile();
            this.Text = title;
        }


        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вствавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool exit = false;
            Bloknot.Exit(ref exit);
            e.Cancel = exit;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool exit = false;
            Bloknot.Exit(ref exit);
        }
    }
}
