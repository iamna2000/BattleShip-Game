using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Test_3
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();

            CenterToScreen();
        }

        private void playButton_Click(object sender, EventArgs e)
        {

            Game.gameMode = false;
            Game.Initialize();

            Game.player1 = new Player();
            Game.player2 = new Player();

            PvsP_Game pvspForm = new PvsP_Game();
            pvspForm.Location = Location;
            pvspForm.Show();

            Hide();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
