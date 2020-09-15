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
    public partial class ShipDeploy : Form
    {

        int mouseCellX;
        int mouseCellY;
        int currentShip;
        bool shipRotation;
        bool[] shipDeployed = new bool[5];
        Player player;

        public ShipDeploy()
        {
            InitializeComponent();

            MaximizeBox = false;
            CenterToParent();

            mouseCellX = 0;
            mouseCellY = 0;
            currentShip = 0;
            shipRotation = true;

            if (Game.playerSwitch)
            {
                Text = "Battleships: " + Game.player1.Name + "’s deployment";
                player = Game.player1;
            }
            else
            {
                Text = "Battleships: " + Game.player2.Name + "’s deployment";
                player = Game.player2;
            }
        }

        private void deckPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentShip != -1)
            {
                // Check xem con trỏ có ở trên bàn cờ không ?
                if (GraphicContext.GetCoorX(this, deckPictureBox) != -1 && GraphicContext.GetCoorY(this, deckPictureBox) != -1)
                {
                    // Xét ô mà con  trỏ đang nằm
                    if (GraphicContext.GetCell(GraphicContext.GetCoorX(this, deckPictureBox)) != mouseCellX || GraphicContext.GetCell(GraphicContext.GetCoorY(this, deckPictureBox)) != mouseCellY)
                    {
                        // Đặt lại tọa độ
                        mouseCellX = GraphicContext.GetCell(GraphicContext.GetCoorX(this, deckPictureBox));
                        mouseCellY = GraphicContext.GetCell(GraphicContext.GetCoorY(this, deckPictureBox));

                        // Vẽ lại bàn, tránh hiện tượng vẽ full ô
                        deckPictureBox.Refresh();

                        // Nằm ngang
                        if (shipRotation)
                        {
                            // Vẽ tàu với độ dài tương ứng.
                            for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                            {
                                // Nếu không chạm rìa bàn cờ
                                if (mouseCellX + i <= 9)
                                {
                                    //Tô outline cell
                                    GraphicContext.DrawInnerFrameCell(mouseCellX + i, mouseCellY, currentShip, this, deckPictureBox);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // Nằm dọc.
                            for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                            {
                                if (mouseCellY + i <= 9)
                                {
                                    GraphicContext.DrawInnerFrameCell(mouseCellX, mouseCellY + i, currentShip, this, deckPictureBox);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Ra ngoài rìa bàn cờ
                    if (mouseCellX != 0 || mouseCellY != 0)
                    {
                        mouseCellX = 0;
                        mouseCellY = 0;
                     
                        deckPictureBox.Refresh();
                    }
                }
                
            }
        }

        // Sự kiện tô màu ô trên deck
        private void deckPictureBox_Click(object sender, EventArgs e)
        {
            if (currentShip != -1 && mouseCellX != -1 && mouseCellY != -1)
            {
                if (Game.ShipDeployed(currentShip, mouseCellX, mouseCellY, shipRotation, player.ShipSet))
                {
                    shipRotateButton.Enabled = false;
                    shipDeployed[currentShip] = true;

                    switch (currentShip)
                    {
                        case 0:
                            {
                                deployShip0Button.Enabled = false;
                                deleteShip0Button.Enabled = true;
                                break;
                            }
                        case 1:
                            {
                                deployShip1Button.Enabled = false;
                                deleteShip1Button.Enabled = true;
                                break;
                            }
                        case 2:
                            {
                                deployShip2Button.Enabled = false;
                                deleteShip2Button.Enabled = true;
                                break;
                            }
                        case 3:
                            {
                                deployShip3Button.Enabled = false;
                                deleteShip3Button.Enabled = true;
                                break;
                            }
                        case 4:
                            {
                                deployShip4Button.Enabled = false;
                                deleteShip4Button.Enabled = true;
                                break;
                            }
                    }

                    Game.DeployShip(currentShip, mouseCellX, mouseCellY, shipRotation, player.ShipSet);

                    deckPictureBox.Refresh();

                    currentShip = -1;

                    //Kiểm tra tất cả tàu đã được đặt trên bàn cờ chưa ?
                    bool areAllShipsDeployed = true;
                    foreach (bool isDeployed in shipDeployed)
                    {
                        if (!isDeployed)
                        {
                            areAllShipsDeployed = false;
                        }
                    }

                    if (areAllShipsDeployed)
                    {
                        doneButton.Enabled = true;
                    }
                }
            }
        }

        // Sự kiện nút xóa tàu
        private void DeleteShip0ButtonClick(object sender, EventArgs e)
        {
            // Xóa tàu
            Game.DeleteShip(0, player.ShipSet);
            // Vẽ lại deck
            deckPictureBox.Refresh();
            deployShip0Button.Enabled = true;
            deleteShip0Button.Enabled = false;
            doneButton.Enabled = false;
        }

        private void DeleteShip1ButtonClick(object sender, EventArgs e)
        {
            Game.DeleteShip(1, player.ShipSet);
            deckPictureBox.Refresh();
            deployShip1Button.Enabled = true;
            deleteShip1Button.Enabled = false;
            doneButton.Enabled = false;
        }

        private void DeleteShip2ButtonClick(object sender, EventArgs e)
        {
            Game.DeleteShip(2, player.ShipSet);
            deckPictureBox.Refresh();
            deployShip2Button.Enabled = true;
            deleteShip2Button.Enabled = false;
            doneButton.Enabled = false;
        }

        private void DeleteShip3ButtonClick(object sender, EventArgs e)
        {
            Game.DeleteShip(3, player.ShipSet);
            deckPictureBox.Refresh();
            deployShip3Button.Enabled = true;
            deleteShip3Button.Enabled = false;
            doneButton.Enabled = false;
        }

        private void DeleteShip4ButtonClick(object sender, EventArgs e)
        {
            Game.DeleteShip(4, player.ShipSet);
            deckPictureBox.Refresh();
            deployShip4Button.Enabled = true;
            deleteShip4Button.Enabled = false;
            doneButton.Enabled = false;
        }

        //Xoay tàu
        private void shipRotateButton_Click_1(object sender, EventArgs e)
        {
            shipRotation = !shipRotation;
        }


        // Sự kiện chọn tàu
        private void Ship0ButtonClick(object sender, EventArgs e)
        {
            currentShip = 0;
            shipRotateButton.Enabled = true;
        }
        private void Ship1ButtonClick(object sender, EventArgs e)
        {
            currentShip = 1;
            shipRotateButton.Enabled = true;
        }

        private void Ship2ButtonClick(object sender, EventArgs e)
        {
            currentShip = 2;
            shipRotateButton.Enabled = true;
        }

        private void Ship3ButtonClick(object sender, EventArgs e)
        {
            currentShip = 3;
            shipRotateButton.Enabled = true;
        }

        private void Ship4ButtonClick(object sender, EventArgs e)
        {
            currentShip = 4;
            shipRotateButton.Enabled = true;
        }

        // Sự kiện tô tàu trên deck
        private void DeckPictureBoxPaint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawShipSet(player.ShipSet, e);
        }


        private void doneButton_Click(object sender, EventArgs e)
        {
            

            if (Game.playerSwitch)
            {
                Game.playerSwitch = !Game.playerSwitch;
                PvsP_Game pvspForm = new PvsP_Game();
                pvspForm.Location = Location;
                pvspForm.Show();

                Dispose();
            }
            else
            {
                MainGame mainGame = new MainGame();
                mainGame.Location = Location;
                mainGame.Show();

                Dispose();
            }

        }
    }
}
