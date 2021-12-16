
namespace OnlineBusReservation
{
    partial class PassengerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassengerForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.MyTripsBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.welcomeLable = new System.Windows.Forms.Label();
            this.myTrips1 = new OnlineBusReservation.MyTrips();
            this.passengerHome1 = new OnlineBusReservation.PassengerHome();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Salmon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(279, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 31);
            this.panel2.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(279, 31);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(62)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.MyTripsBtn);
            this.panel1.Controls.Add(this.HomeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 833);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(86)))), ((int)(((byte)(105)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 226);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "      Dashboard";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::OnlineBusReservation.Properties.Resources.Passenger1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Location = new System.Drawing.Point(1, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 173);
            this.panel4.TabIndex = 5;
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.Salmon;
            this.SidePanel.Location = new System.Drawing.Point(-3, 296);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(26, 66);
            this.SidePanel.TabIndex = 4;
            // 
            // MyTripsBtn
            // 
            this.MyTripsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MyTripsBtn.FlatAppearance.BorderSize = 0;
            this.MyTripsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyTripsBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyTripsBtn.ForeColor = System.Drawing.Color.White;
            this.MyTripsBtn.Image = ((System.Drawing.Image)(resources.GetObject("MyTripsBtn.Image")));
            this.MyTripsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MyTripsBtn.Location = new System.Drawing.Point(31, 368);
            this.MyTripsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.MyTripsBtn.Name = "MyTripsBtn";
            this.MyTripsBtn.Size = new System.Drawing.Size(244, 66);
            this.MyTripsBtn.TabIndex = 4;
            this.MyTripsBtn.Text = "       My Trips";
            this.MyTripsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MyTripsBtn.UseVisualStyleBackColor = true;
            this.MyTripsBtn.Click += new System.EventHandler(this.MyTripsBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeBtn.FlatAppearance.BorderSize = 0;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.White;
            this.HomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("HomeBtn.Image")));
            this.HomeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeBtn.Location = new System.Drawing.Point(31, 294);
            this.HomeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(244, 66);
            this.HomeBtn.TabIndex = 4;
            this.HomeBtn.Text = "       Home";
            this.HomeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // button13
            // 
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(1329, 50);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(67, 63);
            this.button13.TabIndex = 9;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // welcomeLable
            // 
            this.welcomeLable.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.welcomeLable.Location = new System.Drawing.Point(530, 50);
            this.welcomeLable.Name = "welcomeLable";
            this.welcomeLable.Size = new System.Drawing.Size(603, 63);
            this.welcomeLable.TabIndex = 42;
            this.welcomeLable.Text = "*****";
            this.welcomeLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myTrips1
            // 
            this.myTrips1.Location = new System.Drawing.Point(279, 163);
            this.myTrips1.Name = "myTrips1";
            this.myTrips1.Size = new System.Drawing.Size(1148, 670);
            this.myTrips1.TabIndex = 11;
            // 
            // passengerHome1
            // 
            this.passengerHome1.Location = new System.Drawing.Point(279, 163);
            this.passengerHome1.Name = "passengerHome1";
            this.passengerHome1.Size = new System.Drawing.Size(1148, 670);
            this.passengerHome1.TabIndex = 10;
            // 
            // PassengerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 833);
            this.Controls.Add(this.welcomeLable);
            this.Controls.Add(this.myTrips1);
            this.Controls.Add(this.passengerHome1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PassengerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PassengerForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button MyTripsBtn;
        private PassengerHome passengerHome1;
        private MyTrips myTrips1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label welcomeLable;
    }
}