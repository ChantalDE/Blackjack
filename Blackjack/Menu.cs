using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    //Class for menu to launch table
    public partial class Menu : Form
    {
        //this code is required in order for this
        //form to be the startup form
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        //Create a new table
        private void button_play_Click(object sender, EventArgs e)
        {
            Blackjack f = new Blackjack(checkBox_soft17.Checked, comboBox_numberOfDecks.Text, textBox_seed.Text);
            f.Show();
        }
    }
}
