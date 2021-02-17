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
    public partial class Permutation : Form
    {
        public Permutation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDown1.Value == (int)numericUpDown2.Value)
            {
                MessageBox.Show("Значение строк должно быть разное", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
