using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizer
{
    public partial class Form1 : Form
    {
        Treeshold tree = new Treeshold();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPreOrd_Click(object sender, EventArgs e)
        {
            tree.add(textExp.Text);
            tree.growTree();
            textBox1.Text = tree.preOrder();
            textBox3.Text = Convert.ToString(tree.doPreOrder(textBox1.Text));
        }

        private void buttonPosOrd_Click(object sender, EventArgs e)
        {
            tree.add(textExp.Text);
            tree.growTree();
            textBox2.Text = tree.preOrder();
            textBox4.Text = Convert.ToString(tree.doPreOrder(textBox2.Text));
        }
    }
}
