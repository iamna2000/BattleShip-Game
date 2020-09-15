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
    public partial class PvsP_Game : Form
    {
        public PvsP_Game()
        {
            InitializeComponent();

            MaximizeBox = false;

            CenterToParent();

            if (Game.playerSwitch)
            {
                Text = "Battleships: Player 1's settings";
            }
            else
            {
                Text = "Battleships: Player 2's settings";
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (Game.playerSwitch)
            {
                Game.player1.Name = nameTextBox.Text;
            }
            else
            {
                Game.player2.Name = nameTextBox.Text;
            }

            ShipDeploy shipDeploymentForm = new ShipDeploy();
            shipDeploymentForm.Location = Location;
            shipDeploymentForm.Show();

            // Dispose does not trigger FormClosing event.
            Dispose();
        }
    }
}
