using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace BattleShip_Test_3
{

    static class GlobalContext
    {

        public static MainMenuForm MainMenuForm { get; set; }

    }


    public class Player
    {
        // Tên người chơi
        public string Name { get; set; }
        // Vị trí tàu được đặt
        public int[,] ShipSet { get; set; }
        // Vị trí ô đã được chọn
        public bool[,] RevealedCells { get; set; }
        // Số ô của tàu 
        public int[] ShipLeftCells { get; set; }
        // Ô vừa được chọn
        public int[] LastCells { get; set; }
        // Số ô của tàu
        public int ShipCells { get; set; }
        // Số tàu còn lại
        public int ShipsLeft { get; set; }



        public Player()
        {
            ShipLeftCells = new int[] { 2, 3, 3, 4, 5 };

            ShipCells = 17;

            ShipsLeft = 5;

            RevealedCells = new bool[10, 10];

            ShipSet = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ShipSet[i, j] = -1;
                    RevealedCells[i, j] = false;
                }
            }

            LastCells = new int[2];
            LastCells[0] = -1;
            LastCells[1] = -1;
        }


    }
    static class Game
    {
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };

        public static int roundCount;

        public static bool gameMode;

        //[true] Player1 / [False] Player2
        public static bool playerSwitch;
        //Player in4
        public static Player player1;
        public static Player player2;


        // Khởi tạo
        static public void Initialize()
        {
            playerSwitch = true;
            roundCount = 1;
        }

        

        // Đặt tàu
        public static bool ShipDeployed (int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {

            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            // Chiều ngang
            if (isHorizontal)
            {
                if (cellX + Game.shipLengths[currentShip] - 1 <= 9 )
                {
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(9, cellX + Game.shipLengths[currentShip]); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(9, cellY + 1); j++)
                        {
                            if (shipSet[i, j] != -1)
                            {
                                // Tìm thấy ô trống
                                return false;
                            }
                        }
                    }

                    // Không thấy ô trống
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // Chiều dọc
                if (cellY + Game.shipLengths[currentShip] - 1 <= 9)
                {
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(9, cellX + 1); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(9, cellY + Game.shipLengths[currentShip]); j++)
                        {
                            if (shipSet[i, j] != -1)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    // Full ô
                    return false;
                }
            }
        }

        
        // Đặt tàu + Xoay tàu
        static public void DeployShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            if (isHorizontal)
            {
                for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                {
                    shipSet[cellX + i, cellY] = currentShip;
                }
            }
            else
            {
                for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                {
                    shipSet[cellX, cellY + i] = currentShip;
                }
            }
        }

        // Xóa tàu
        static public void DeleteShip(int currentShip, int[,] shipSet)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (shipSet[x, y] == currentShip)
                    {
                        shipSet[x, y] = -1;
                    }
                }
            }
        }


        // Sự kiện tấn công
        public static bool Attack(int cellX, int cellY, Player attacker, Player attacked)
        {
            attacked.RevealedCells[cellX, cellY] = true;

            AudioContext.PlayShot();
            Thread.Sleep(500);

            // Hiển thị ô vừa được chọn
            attacked.LastCells[0] = cellX;
            attacked.LastCells[1] = cellY;

            // Nếu bắn trúng
            if (attacked.ShipSet[cellX, cellY] != -1)
            {
                AudioContext.PlayHit();

                attacked.ShipCells--;

                // Giảm số ô của tàu bị bắn
                attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]]--;

                // Nếu bắn trúng hết ô của tàu
                if (attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]] == 0)
                {

                    attacked.ShipsLeft--;

                    // Tìm ô trống xung quanh ô bắn trúng
                    int revealedCellsNearby = 0;

                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (attacked.ShipSet[x, y] == attacked.ShipSet[cellX, cellY])
                            {
                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y - 1])
                                    {
                                        attacked.RevealedCells[x - 1, y - 1] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y ])
                                    {
                                        attacked.RevealedCells[x - 1, y ] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y + 1])
                                    {
                                        attacked.RevealedCells[x - 1, y + 1] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x , y - 1])
                                    {
                                        attacked.RevealedCells[x , y - 1] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y - 1])
                                    {
                                        attacked.RevealedCells[x + 1, y - 1] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y ])
                                    {
                                        attacked.RevealedCells[x + 1, y ] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y + 1])
                                    {
                                        attacked.RevealedCells[x + 1, y + 1] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x , y + 1])
                                    {
                                        attacked.RevealedCells[x , y + 1] = true;
                                        revealedCellsNearby++;
                                    }
                                }
                                catch { };
                            }
                        }
                    }

                    if (attacked.ShipsLeft == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    // Chưa bắn hết ô của tàu 
                    return false;
                }
            }
            else
            {
                // Bắn không trúng
                return false;
            }

        }

    }

    static class AudioContext
    {
        static public readonly SoundPlayer hitSound = new SoundPlayer(Properties.Resources.hitSound);
        static public readonly SoundPlayer shotSound = new SoundPlayer(Properties.Resources.shotSound);

        public static void PlayShot()
        {
            AudioContext.shotSound.Play();
        }

        public static void PlayHit()
        {
            AudioContext.hitSound.Play();
        }
    }
    static class GraphicContext
    {
        private static readonly Bitmap hitImage =new Bitmap( Properties.Resources.hitImage);
        private static readonly Bitmap missImage = new Bitmap(Properties.Resources.missImage);


        private static int generalOpacity = 150;
        private static int spacialOpacity = 200;
        public static readonly Brush[] colors = new SolidBrush[8]
        {
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 255, 0)),   // [0] Vàng
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 0, 0)),     // [1] Đỏ
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 255, 0)),     // [2] Xanh lá
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 0, 255)),     // [3] Xanh dương
            new SolidBrush(Color.FromArgb(generalOpacity, 150, 0, 200)),   // [4] Tím
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 255, 255)), // [5] Trắng
            new SolidBrush(Color.FromArgb(spacialOpacity, 0, 255, 255)),   // [6] Xanh da trời
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 0, 140))    // [7] Đỏ tươi
        };

        // Tọa độ trục hoành
        static public int GetCoorX(Form form, PictureBox deckPictureBox)
        {
            int borderWidth = (form.Width - form.ClientSize.Width) / 2;
            int coorX = Control.MousePosition.X - form.Location.X - deckPictureBox.Location.X - borderWidth;
            return (coorX < 35 || coorX > 342) ? -1 : coorX;
        }
        // Tọa đọ trục tung
        static public int GetCoorY(Form form, PictureBox deckPictureBox)
        {
            int borderWidth = (form.Width - form.ClientSize.Width) / 2;
            int titleBarHeight = form.Height - form.ClientSize.Height - 2 * borderWidth;
            int coorY = Control.MousePosition.Y - form.Location.Y - deckPictureBox.Location.Y - titleBarHeight - borderWidth;
            return (coorY < 33 || coorY > 342) ? -1 : coorY;
        }

        // Chia ô
        static public int GetCell(int coor)
        {
            return (coor - 33) / 31;
        }

        // Vẽ viền trong của ô
        static public void DrawInnerFrameCell(int cellX, int cellY, int color, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            Pen framePen = new Pen(colors[color], 3);
            g.DrawRectangle(framePen, (cellX + 1) * 31 + 3, (cellY + 1) * 31 + 3, 25, 25);
        }

        // Vẽ đường outline bên ngoài ô
        static public void DrawOuterFrameCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            Pen framePen = new Pen(colors[color], 3);
            e.Graphics.DrawRectangle(framePen, (cellX + 1) * 31 + -3, (cellY + 1) * 31 + -3, 37, 37);
        }
        static public void DrawOuterFrameCell(int cellX, int cellY, int color, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            Pen framePen = new Pen(colors[color], 3);
            g.DrawRectangle(framePen, (cellX + 1) * 31 + -3, (cellY + 1) * 31 + -3, 37, 37);
        }

        // Vẽ màu tương ứng với tàu
        static public void DrawColoredCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(GraphicContext.colors[color], (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1, 30, 30);
        }

        // Vẽ ô bắn trúng
        static public void DrawHitCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hitImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        // Vẽ ô bắn hụt
        static public void DrawMissCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(missImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        // Sự kiện tô màu trên deck - tạo ship
        static public void DrawShipSet(int[,] shipSet, PaintEventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (shipSet[x, y] != -1)
                    {
                        DrawColoredCell(x, y, shipSet[x, y], e);
                    }
                }
            }
        }


        // Sự kiện hiển thị tình trạng ô
        static public void DrawDeckStatus(bool[,] deckStatus, int[,] shipSet, PaintEventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (deckStatus[x, y])
                    {
                        if (shipSet[x, y] != -1)
                        {
                            DrawHitCell(x, y, e);
                        }
                        else
                        {
                            DrawMissCell(x, y, e);
                        }
                    }
                }
            }
        }
    }


    //public class SocketManager
    //{
    //    #region Client
    //    Socket client;
    //    public bool ConnectServer()
    //    {
    //        IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
    //        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    //        try
    //        {
    //            client.Connect(iep);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //    #endregion

    //    #region server

    //    Socket server;
    //    public void CreateServer()
    //    {
    //        IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
    //        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    //        server.Bind(iep);
    //        server.Listen(10);

    //        Thread acceptClient = new Thread(() =>
    //        {
    //            client = server.Accept();
    //        });
    //        acceptClient.IsBackground = true;
    //        acceptClient.Start();
    //    }
    //    #endregion

    //    #region Both
    //    public string IP = "127.0.0.1";
    //    public int PORT = 9999;
    //    public const int BUFFER = 1024;
    //    public bool isServer = true;

    //    public bool Send(object data)
    //    {
    //        byte[] sendData = SerializeData(data);

    //        return SendData(client, sendData);
    //    }

    //    public object Receive()
    //    {
    //        byte[] receiveData = new byte[BUFFER];
    //        bool isOk = ReceiveData(client, receiveData);

    //        return DeserializeData(receiveData);
    //    }

    //    private bool SendData(Socket target, byte[] data)
    //    {
    //        return target.Send(data) == 1 ? true : false;
    //    }


    //    private bool ReceiveData(Socket target, byte[] data)
    //    {
    //        return target.Receive(data) == 1 ? true : false;
    //    }

    //    /// Nén đối tượng thành mảng byte[]

    //    public byte[] SerializeData(Object o)
    //    {
    //        MemoryStream ms = new MemoryStream();
    //        BinaryFormatter bf1 = new BinaryFormatter();
    //        bf1.Serialize(ms, o);
    //        return ms.ToArray();
    //    }

    //    /// Giải nén mảng byte[] thành đối tượng object

    //    public object DeserializeData(byte[] theByteArray)
    //    {
    //        MemoryStream ms = new MemoryStream(theByteArray);
    //        BinaryFormatter bf1 = new BinaryFormatter();
    //        ms.Position = 0;
    //        return bf1.Deserialize(ms);
    //    }

    //    /// Lấy ra IP V4 của card mạng đang dùng

    //    public string GetLocalIPv4(NetworkInterfaceType _type)
    //    {
    //        string output = "";
    //        foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
    //        {
    //            if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
    //            {
    //                foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
    //                {
    //                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
    //                    {
    //                        output = ip.Address.ToString();
    //                    }
    //                }
    //            }
    //        }
    //        return output;
    //    }

    //    #endregion
    //}

    //[Serializable]
    //public class SocketData
    //{
    //    private int command;

    //    public int Command
    //    {
    //        get; set;
    //    }

    //    private Point point;

    //    public Point Point
    //    {
    //        get { return point; }
    //        set { point = value; }
    //    }

    //    private string message;

    //    public string Message
    //    {
    //        get { return message; }
    //        set { message = value; }
    //    }

    //    public SocketData(int command, string message, Point point)
    //    {
    //        this.Command = command;
    //        this.Point = point;
    //        this.Message = message;
    //    }
    //}

    //public enum SocketCommand
    //{
    //    SEND_POINT,
    //    NOTIFY,
    //    NEW_GAME,
    //    UNDO,
    //    END_GAME,
    //    QUIT,
    //    TIME_OUT
    //}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the main menu and run the application.
            MainMenuForm mainMenuForm = new MainMenuForm();
            GlobalContext.MainMenuForm = mainMenuForm;
            Application.Run(mainMenuForm);
        }
    }
}
