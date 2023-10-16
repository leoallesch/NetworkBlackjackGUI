using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class SelectMode : Form
    {
        public SelectMode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientStart start = new ClientStart();
            this.Hide();
            start.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerStart start = new ServerStart();
            this.Hide();
            start.ShowDialog();
            this.Close();
        }
    }
}
