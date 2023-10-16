using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Network;

namespace Forms
{
    public partial class ClientStart : Form
    {
        Client c;

        public ClientStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                c = new Client(textBox1.Text, Int32.Parse(textBox2.Text));
                c.Connect();
                ClientGame game = new ClientGame(c);
                this.Hide();
                game.ShowDialog();
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error connnecting to server, check ip and port.");
                Console.WriteLine(ex);
            }
        }
    }
}
