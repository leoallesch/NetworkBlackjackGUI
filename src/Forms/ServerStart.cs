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
    public partial class ServerStart : Form
    {
        Server server;
        public ServerStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server(textBox1.Text, Int32.Parse(textBox2.Text));
                server.Start();
                ServerGame game = new ServerGame(server);
                this.Hide();
                game.ShowDialog();
                this.Close();
            } 
            catch
            {
                MessageBox.Show("Error starting server, check ip and port.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                if (server.running)
                {
                    
                    ServerGame game = new ServerGame(server);
                    this.Hide();
                    game.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Cannot start game. Server not running.");
            }  
        }

    }
}
