namespace BattleShip_Test_3
{
    partial class ShipDeploy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox ship4GroupBox;
            System.Windows.Forms.GroupBox ship3GroupBox;
            System.Windows.Forms.GroupBox ship2GroupBox;
            System.Windows.Forms.GroupBox ship0GroupBox;
            System.Windows.Forms.GroupBox ship1GroupBox;
            System.Windows.Forms.GroupBox shipRotateGroupBox;
            System.Windows.Forms.GroupBox doneGroupBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipDeploy));
            this.doneButton = new System.Windows.Forms.Button();
            this.shipRotateButton = new System.Windows.Forms.Button();
            this.deleteShip4Button = new System.Windows.Forms.Button();
            this.deployShip4Button = new System.Windows.Forms.Button();
            this.deleteShip3Button = new System.Windows.Forms.Button();
            this.deployShip3Button = new System.Windows.Forms.Button();
            this.deleteShip2Button = new System.Windows.Forms.Button();
            this.deployShip2Button = new System.Windows.Forms.Button();
            this.deleteShip0Button = new System.Windows.Forms.Button();
            this.deployShip0Button = new System.Windows.Forms.Button();
            this.deployShip1Button = new System.Windows.Forms.Button();
            this.deleteShip1Button = new System.Windows.Forms.Button();
            this.deckPictureBox = new System.Windows.Forms.PictureBox();
            ship4GroupBox = new System.Windows.Forms.GroupBox();
            ship3GroupBox = new System.Windows.Forms.GroupBox();
            ship2GroupBox = new System.Windows.Forms.GroupBox();
            ship0GroupBox = new System.Windows.Forms.GroupBox();
            ship1GroupBox = new System.Windows.Forms.GroupBox();
            shipRotateGroupBox = new System.Windows.Forms.GroupBox();
            doneGroupBox = new System.Windows.Forms.GroupBox();
            ship4GroupBox.SuspendLayout();
            ship3GroupBox.SuspendLayout();
            ship2GroupBox.SuspendLayout();
            ship0GroupBox.SuspendLayout();
            ship1GroupBox.SuspendLayout();
            shipRotateGroupBox.SuspendLayout();
            doneGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deckPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ship4GroupBox
            // 
            ship4GroupBox.Controls.Add(this.deleteShip4Button);
            ship4GroupBox.Controls.Add(this.deployShip4Button);
            ship4GroupBox.Location = new System.Drawing.Point(12, 280);
            ship4GroupBox.Name = "ship4GroupBox";
            ship4GroupBox.Size = new System.Drawing.Size(198, 61);
            ship4GroupBox.TabIndex = 22;
            ship4GroupBox.TabStop = false;
            ship4GroupBox.Text = "Aircraft Carrier (5):";
            // 
            // ship3GroupBox
            // 
            ship3GroupBox.Controls.Add(this.deleteShip3Button);
            ship3GroupBox.Controls.Add(this.deployShip3Button);
            ship3GroupBox.Location = new System.Drawing.Point(12, 213);
            ship3GroupBox.Name = "ship3GroupBox";
            ship3GroupBox.Size = new System.Drawing.Size(198, 61);
            ship3GroupBox.TabIndex = 21;
            ship3GroupBox.TabStop = false;
            ship3GroupBox.Text = "Battleship (4):";
            // 
            // ship2GroupBox
            // 
            ship2GroupBox.Controls.Add(this.deleteShip2Button);
            ship2GroupBox.Controls.Add(this.deployShip2Button);
            ship2GroupBox.Location = new System.Drawing.Point(12, 146);
            ship2GroupBox.Name = "ship2GroupBox";
            ship2GroupBox.Size = new System.Drawing.Size(198, 61);
            ship2GroupBox.TabIndex = 20;
            ship2GroupBox.TabStop = false;
            ship2GroupBox.Text = "Destroyer (3):";
            // 
            // ship0GroupBox
            // 
            ship0GroupBox.Controls.Add(this.deleteShip0Button);
            ship0GroupBox.Controls.Add(this.deployShip0Button);
            ship0GroupBox.Location = new System.Drawing.Point(12, 12);
            ship0GroupBox.Name = "ship0GroupBox";
            ship0GroupBox.Size = new System.Drawing.Size(198, 61);
            ship0GroupBox.TabIndex = 18;
            ship0GroupBox.TabStop = false;
            ship0GroupBox.Text = "Patrol Boat (2):";
            // 
            // ship1GroupBox
            // 
            ship1GroupBox.Controls.Add(this.deployShip1Button);
            ship1GroupBox.Controls.Add(this.deleteShip1Button);
            ship1GroupBox.Location = new System.Drawing.Point(12, 79);
            ship1GroupBox.Name = "ship1GroupBox";
            ship1GroupBox.Size = new System.Drawing.Size(198, 61);
            ship1GroupBox.TabIndex = 19;
            ship1GroupBox.TabStop = false;
            ship1GroupBox.Text = "Submarine (3):";
            // 
            // shipRotateGroupBox
            // 
            shipRotateGroupBox.Controls.Add(this.shipRotateButton);
            shipRotateGroupBox.Location = new System.Drawing.Point(12, 347);
            shipRotateGroupBox.Name = "shipRotateGroupBox";
            shipRotateGroupBox.Size = new System.Drawing.Size(80, 67);
            shipRotateGroupBox.TabIndex = 23;
            shipRotateGroupBox.TabStop = false;
            shipRotateGroupBox.Text = "Ship Rotate:";
            // 
            // doneGroupBox
            // 
            doneGroupBox.Controls.Add(this.doneButton);
            doneGroupBox.Location = new System.Drawing.Point(98, 347);
            doneGroupBox.Name = "doneGroupBox";
            doneGroupBox.Size = new System.Drawing.Size(112, 67);
            doneGroupBox.TabIndex = 17;
            doneGroupBox.TabStop = false;
            doneGroupBox.Text = "Done:";
            // 
            // doneButton
            // 
            this.doneButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("doneButton.BackgroundImage")));
            this.doneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.doneButton.Enabled = false;
            this.doneButton.Location = new System.Drawing.Point(6, 16);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(100, 45);
            this.doneButton.TabIndex = 11;
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // shipRotateButton
            // 
            this.shipRotateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shipRotateButton.BackgroundImage")));
            this.shipRotateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.shipRotateButton.Enabled = false;
            this.shipRotateButton.Location = new System.Drawing.Point(6, 16);
            this.shipRotateButton.Name = "shipRotateButton";
            this.shipRotateButton.Size = new System.Drawing.Size(69, 45);
            this.shipRotateButton.TabIndex = 5;
            this.shipRotateButton.UseVisualStyleBackColor = true;
            this.shipRotateButton.Click += new System.EventHandler(this.shipRotateButton_Click_1);
            // 
            // deleteShip4Button
            // 
            this.deleteShip4Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteShip4Button.BackgroundImage")));
            this.deleteShip4Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteShip4Button.Enabled = false;
            this.deleteShip4Button.Location = new System.Drawing.Point(153, 16);
            this.deleteShip4Button.Name = "deleteShip4Button";
            this.deleteShip4Button.Size = new System.Drawing.Size(39, 39);
            this.deleteShip4Button.TabIndex = 8;
            this.deleteShip4Button.UseVisualStyleBackColor = true;
            this.deleteShip4Button.Click += new System.EventHandler(this.DeleteShip4ButtonClick);
            // 
            // deployShip4Button
            // 
            this.deployShip4Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deployShip4Button.BackgroundImage")));
            this.deployShip4Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deployShip4Button.Location = new System.Drawing.Point(6, 16);
            this.deployShip4Button.Name = "deployShip4Button";
            this.deployShip4Button.Size = new System.Drawing.Size(141, 39);
            this.deployShip4Button.TabIndex = 7;
            this.deployShip4Button.UseVisualStyleBackColor = true;
            this.deployShip4Button.Click += new System.EventHandler(this.Ship4ButtonClick);
            // 
            // deleteShip3Button
            // 
            this.deleteShip3Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteShip3Button.BackgroundImage")));
            this.deleteShip3Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteShip3Button.Enabled = false;
            this.deleteShip3Button.Location = new System.Drawing.Point(153, 16);
            this.deleteShip3Button.Name = "deleteShip3Button";
            this.deleteShip3Button.Size = new System.Drawing.Size(39, 39);
            this.deleteShip3Button.TabIndex = 6;
            this.deleteShip3Button.UseVisualStyleBackColor = true;
            this.deleteShip3Button.Click += new System.EventHandler(this.DeleteShip3ButtonClick);
            // 
            // deployShip3Button
            // 
            this.deployShip3Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deployShip3Button.BackgroundImage")));
            this.deployShip3Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deployShip3Button.Location = new System.Drawing.Point(6, 16);
            this.deployShip3Button.Name = "deployShip3Button";
            this.deployShip3Button.Size = new System.Drawing.Size(141, 39);
            this.deployShip3Button.TabIndex = 3;
            this.deployShip3Button.UseVisualStyleBackColor = true;
            this.deployShip3Button.Click += new System.EventHandler(this.Ship3ButtonClick);
            // 
            // deleteShip2Button
            // 
            this.deleteShip2Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteShip2Button.BackgroundImage")));
            this.deleteShip2Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteShip2Button.Enabled = false;
            this.deleteShip2Button.Location = new System.Drawing.Point(153, 16);
            this.deleteShip2Button.Name = "deleteShip2Button";
            this.deleteShip2Button.Size = new System.Drawing.Size(39, 39);
            this.deleteShip2Button.TabIndex = 6;
            this.deleteShip2Button.UseVisualStyleBackColor = true;
            this.deleteShip2Button.Click += new System.EventHandler(this.DeleteShip2ButtonClick);
            // 
            // deployShip2Button
            // 
            this.deployShip2Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deployShip2Button.BackgroundImage")));
            this.deployShip2Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deployShip2Button.Location = new System.Drawing.Point(6, 16);
            this.deployShip2Button.Name = "deployShip2Button";
            this.deployShip2Button.Size = new System.Drawing.Size(141, 39);
            this.deployShip2Button.TabIndex = 2;
            this.deployShip2Button.UseVisualStyleBackColor = true;
            this.deployShip2Button.Click += new System.EventHandler(this.Ship2ButtonClick);
            // 
            // deleteShip0Button
            // 
            this.deleteShip0Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteShip0Button.BackgroundImage")));
            this.deleteShip0Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteShip0Button.Enabled = false;
            this.deleteShip0Button.Location = new System.Drawing.Point(153, 16);
            this.deleteShip0Button.Name = "deleteShip0Button";
            this.deleteShip0Button.Size = new System.Drawing.Size(39, 39);
            this.deleteShip0Button.TabIndex = 6;
            this.deleteShip0Button.UseVisualStyleBackColor = true;
            this.deleteShip0Button.Click += new System.EventHandler(this.DeleteShip0ButtonClick);
            // 
            // deployShip0Button
            // 
            this.deployShip0Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deployShip0Button.BackgroundImage")));
            this.deployShip0Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deployShip0Button.Location = new System.Drawing.Point(6, 16);
            this.deployShip0Button.Name = "deployShip0Button";
            this.deployShip0Button.Size = new System.Drawing.Size(141, 39);
            this.deployShip0Button.TabIndex = 0;
            this.deployShip0Button.UseVisualStyleBackColor = true;
            this.deployShip0Button.Click += new System.EventHandler(this.Ship0ButtonClick);
            // 
            // deployShip1Button
            // 
            this.deployShip1Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deployShip1Button.BackgroundImage")));
            this.deployShip1Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deployShip1Button.Location = new System.Drawing.Point(6, 16);
            this.deployShip1Button.Name = "deployShip1Button";
            this.deployShip1Button.Size = new System.Drawing.Size(141, 39);
            this.deployShip1Button.TabIndex = 1;
            this.deployShip1Button.UseVisualStyleBackColor = true;
            this.deployShip1Button.Click += new System.EventHandler(this.Ship1ButtonClick);
            // 
            // deleteShip1Button
            // 
            this.deleteShip1Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteShip1Button.BackgroundImage")));
            this.deleteShip1Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteShip1Button.Enabled = false;
            this.deleteShip1Button.Location = new System.Drawing.Point(153, 16);
            this.deleteShip1Button.Name = "deleteShip1Button";
            this.deleteShip1Button.Size = new System.Drawing.Size(39, 39);
            this.deleteShip1Button.TabIndex = 7;
            this.deleteShip1Button.UseVisualStyleBackColor = true;
            this.deleteShip1Button.Click += new System.EventHandler(this.DeleteShip1ButtonClick);
            // 
            // deckPictureBox
            // 
            this.deckPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.deckPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("deckPictureBox.Image")));
            this.deckPictureBox.Location = new System.Drawing.Point(292, 37);
            this.deckPictureBox.Name = "deckPictureBox";
            this.deckPictureBox.Size = new System.Drawing.Size(377, 377);
            this.deckPictureBox.TabIndex = 16;
            this.deckPictureBox.TabStop = false;
            this.deckPictureBox.Click += new System.EventHandler(this.deckPictureBox_Click);
            this.deckPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DeckPictureBoxPaint);
            this.deckPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deckPictureBox_MouseMove);
            // 
            // ShipDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 430);
            this.Controls.Add(doneGroupBox);
            this.Controls.Add(shipRotateGroupBox);
            this.Controls.Add(ship4GroupBox);
            this.Controls.Add(ship3GroupBox);
            this.Controls.Add(ship2GroupBox);
            this.Controls.Add(ship0GroupBox);
            this.Controls.Add(ship1GroupBox);
            this.Controls.Add(this.deckPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShipDeploy";
            this.Text = "Form1";
            ship4GroupBox.ResumeLayout(false);
            ship3GroupBox.ResumeLayout(false);
            ship2GroupBox.ResumeLayout(false);
            ship0GroupBox.ResumeLayout(false);
            ship1GroupBox.ResumeLayout(false);
            shipRotateGroupBox.ResumeLayout(false);
            doneGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deckPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox deckPictureBox;
        private System.Windows.Forms.Button deleteShip4Button;
        private System.Windows.Forms.Button deployShip4Button;
        private System.Windows.Forms.Button deleteShip3Button;
        private System.Windows.Forms.Button deployShip3Button;
        private System.Windows.Forms.Button deleteShip2Button;
        private System.Windows.Forms.Button deployShip2Button;
        private System.Windows.Forms.Button deleteShip0Button;
        private System.Windows.Forms.Button deployShip0Button;
        private System.Windows.Forms.Button deployShip1Button;
        private System.Windows.Forms.Button deleteShip1Button;
        private System.Windows.Forms.Button shipRotateButton;
        private System.Windows.Forms.Button doneButton;
    }
}

