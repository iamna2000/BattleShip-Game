using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;

namespace BattleShip_Test_3
{



    public partial class MainGame : Form
    {

        int mouseCellX;
        int mouseCellY;

        //SocketManager socket;

        Player player1;
        Player player2;

        public MainGame()
        {
            InitializeComponent();

            CenterToScreen();

            MaximizeBox = false;

            if (Game.playerSwitch)
            {
                player1 = Game.player1;
                player2 = Game.player2;
            }
            else
            {
                player1 = Game.player2;
                player2 = Game.player1;
            }

            if (Game.playerSwitch)
            {
                Text = "Battleships: " + Game.player1.Name + "’s turn";
                player1 = Game.player1;
                player2 = Game.player2;
            }
            else
            {
                Text = "Battleships: " + Game.player2.Name + "’s turn";
                player1 = Game.player2;
                player2 = Game.player1;
            }

            mouseCellX = -1;
            mouseCellY = -1;

            //socket = new SocketManager();

            roundTextBox.Text = Game.roundCount.ToString();
        }

        private void deck1PictureBox_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawShipSet(player1.ShipSet, e);
            GraphicContext.DrawDeckStatus(player1.RevealedCells, player1.ShipSet, e);

            if (player1.LastCells[0] != -1 && player1.LastCells[1] != -1)
            {
                GraphicContext.DrawOuterFrameCell(player1.LastCells[0], player1.LastCells[1], 7, e);
            }
        }

        private void deck2PictureBox_Click(object sender, EventArgs e)
        {
            // Xét game kết thúc chưa /

            if (mouseCellX != -1 && mouseCellY != -1 && !player2.RevealedCells[mouseCellX, mouseCellY])
            {
                if (Game.Attack(mouseCellX, mouseCellY, player1, player2))
                {
                    deck2PictureBox.Refresh();

                    MessageBox.Show("Congratulations " + player1.Name + " ! You wonnnnn !");

                    Dispose();

                    GlobalContext.MainMenuForm.Location = Location;
                    GlobalContext.MainMenuForm.Show();

                }
                else
                {
                    deck2PictureBox.Refresh();

                    if (Game.gameMode)
                    {
                        
                    }
                    else
                    {
                        if (!Game.playerSwitch)
                        {
                            Game.roundCount++;
                        }

                        // Đổi người chơi / đổi form
                        Dispose();
                        Game.playerSwitch = !Game.playerSwitch;

                        MainGame mainGameForm = new MainGame();
                        mainGameForm.Location = Location;
                        mainGameForm.Show();
                    }
                }

            }
        }
  

        private void deck2PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (GraphicContext.GetCoorX(this, deck2PictureBox) != -1 && GraphicContext.GetCoorY(this, deck2PictureBox) != -1)
            {
                // Con trỏ di chuyển qua ô khác chưa ?
                if (GraphicContext.GetCell(GraphicContext.GetCoorX(this, deck2PictureBox)) != mouseCellX || GraphicContext.GetCell(GraphicContext.GetCoorY(this, deck2PictureBox)) != mouseCellY)
                {
                    // Đặt lại tọa độ con trỏ
                    mouseCellX = GraphicContext.GetCell(GraphicContext.GetCoorX(this, deck2PictureBox));
                    mouseCellY = GraphicContext.GetCell(GraphicContext.GetCoorY(this, deck2PictureBox));

                    deck2PictureBox.Refresh();

                    // Vẽ outline ô đã chọn
                    GraphicContext.DrawOuterFrameCell(mouseCellX, mouseCellY, 5, this, deck2PictureBox);
                }
            }
            else
            {
                // Con trỏ rời bàn cờ
                mouseCellX = 0;
                mouseCellY = 0;

                // Repaint 
                deck2PictureBox.Refresh();
            }
        }

        private void deck2PictureBox_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawDeckStatus(player2.RevealedCells, player2.ShipSet, e);

            if (player2.LastCells[0] != -1 && player2.LastCells[1] != -1)
            {
                GraphicContext.DrawOuterFrameCell(player2.LastCells[0], player2.LastCells[1], 6, e);
            }
        }

        private void MainGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult quitToMainMenu = MessageBox.Show("Do you really want to quit game to Main menu?", "Battleships: Quitting game...", MessageBoxButtons.YesNo);
            if (quitToMainMenu == DialogResult.Yes)
            {

                // Load lại menu
                GlobalContext.MainMenuForm.Location = Location;
                GlobalContext.MainMenuForm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        //private void LANButton_Click(object sender, EventArgs e)
        //{
        //    socket.IP = IPTextBox.Text;

        //    if (!socket.ConnectServer())
        //    {
        //        socket.isServer = true;

        //        socket.CreateServer();
        //    }
        //    else
        //    {
        //        socket.isServer = false;
        //        Listen();
        //    }
        //}

        //private void MainGame_Shown(object sender, EventArgs e)
        //{
        //    IPTextBox.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

        //    if (string.IsNullOrEmpty(IPTextBox.Text))
        //    {
        //        IPTextBox.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
        //    }
        //}

        //void Listen()
        //{
        //    Thread listenThread = new Thread(() =>
        //    {
        //        try
        //        {
        //            SocketData data = (SocketData)socket.Receive();

        //            ProcessData(data);
        //        }
        //        catch (Exception e)
        //        {
        //        }
        //    });
        //    listenThread.IsBackground = true;
        //    listenThread.Start();
        //}

        //private void ProcessData(SocketData data)
        //{
        //    switch (data.Command)
        //    {
        //        case (int)SocketCommand.NOTIFY:
        //            MessageBox.Show(data.Message);
        //            break;
        //        case (int)SocketCommand.NEW_GAME:
        //            this.Invoke((MethodInvoker)(() =>
        //            {


        //            }));
        //            break;
        //        case (int)SocketCommand.SEND_POINT:
        //            this.Invoke((MethodInvoker)(() =>
        //            {


        //            }));
        //            break;
        //        case (int)SocketCommand.UNDO:

        //            break;
        //        case (int)SocketCommand.END_GAME:
        //            MessageBox.Show("Đã 5 con trên 1 hàng");
        //            break;
        //        case (int)SocketCommand.TIME_OUT:

        //            break;
        //        case (int)SocketCommand.QUIT:

        //            MessageBox.Show("Người chơi đã thoát");
        //            break;
        //        default:
        //            break;
        //    }

        //    Listen();
        //}
    }


}
