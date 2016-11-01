using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace poke_a_mole
{
    public partial class f2 : Form
    {
        public f2()
        {
            InitializeComponent();
        }
        public static string aaa = "";
        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 f1 = (Form1)this.Owner;
            aaa = textBox1.Text;
            Close();
        }
    }
}
