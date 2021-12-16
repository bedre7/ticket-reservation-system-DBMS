
namespace OnlineBusReservation
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.discountsButton = new System.Windows.Forms.Button();
            this.driversButton = new System.Windows.Forms.Button();
            this.busButton = new System.Windows.Forms.Button();
            this.routesButton = new System.Windows.Forms.Button();
            this.tripsButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.discountPanel1 = new OnlineBusReservation.DiscountPanel();
            this.tripPanel1 = new OnlineBusReservation.TripPanel();
            this.routePanel1 = new OnlineBusReservation.RoutePanel();
            this.driverPanel1 = new OnlineBusReservation.DriverPanel();
            this.busPanel1 = new OnlineBusReservation.BusPanel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(144)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(279, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 31);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::OnlineBusReservation.Properties.Resources.admin;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Location = new System.Drawing.Point(1, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 173);
            this.panel4.TabIndex = 5;
            // 
            // button13
            // 
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(1347, 43);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(67, 63);
            this.button13.TabIndex = 6;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::OnlineBusReservation.Properties.Resources.travel_white;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(673, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 145);
            this.panel3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(144)))), ((int)(((byte)(194)))));
            this.label4.Location = new System.Drawing.Point(4, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 51);
            this.label4.TabIndex = 7;
            this.label4.Text = "  Epix Travels";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(62)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.discountsButton);
            this.panel1.Controls.Add(this.driversButton);
            this.panel1.Controls.Add(this.busButton);
            this.panel1.Controls.Add(this.routesButton);
            this.panel1.Controls.Add(this.tripsButton);
            this.panel1.Controls.Add(this.homeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 833);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(279, 31);
            this.flowLayoutPanel1.TabIndex = 9;
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
            this.label1.Text = "         Admin";
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(167)))), ((int)(((byte)(211)))));
            this.SidePanel.Location = new System.Drawing.Point(-3, 296);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(26, 66);
            this.SidePanel.TabIndex = 4;
            // 
            // discountsButton
            // 
            this.discountsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discountsButton.FlatAppearance.BorderSize = 0;
            this.discountsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discountsButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountsButton.ForeColor = System.Drawing.Color.White;
            this.discountsButton.Image = ((System.Drawing.Image)(resources.GetObject("discountsButton.Image")));
            this.discountsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.discountsButton.Location = new System.Drawing.Point(31, 631);
            this.discountsButton.Margin = new System.Windows.Forms.Padding(4);
            this.discountsButton.Name = "discountsButton";
            this.discountsButton.Size = new System.Drawing.Size(244, 66);
            this.discountsButton.TabIndex = 4;
            this.discountsButton.Text = "       Discounts";
            this.discountsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.discountsButton.UseVisualStyleBackColor = true;
            this.discountsButton.Click += new System.EventHandler(this.discountsButton_Click);
            // 
            // driversButton
            // 
            this.driversButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.driversButton.FlatAppearance.BorderSize = 0;
            this.driversButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driversButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversButton.ForeColor = System.Drawing.Color.White;
            this.driversButton.Image = ((System.Drawing.Image)(resources.GetObject("driversButton.Image")));
            this.driversButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.driversButton.Location = new System.Drawing.Point(31, 559);
            this.driversButton.Margin = new System.Windows.Forms.Padding(4);
            this.driversButton.Name = "driversButton";
            this.driversButton.Size = new System.Drawing.Size(244, 66);
            this.driversButton.TabIndex = 4;
            this.driversButton.Text = "       Drivers";
            this.driversButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.driversButton.UseVisualStyleBackColor = true;
            this.driversButton.Click += new System.EventHandler(this.driversButton_Click);
            // 
            // busButton
            // 
            this.busButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.busButton.FlatAppearance.BorderSize = 0;
            this.busButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.busButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busButton.ForeColor = System.Drawing.Color.White;
            this.busButton.Image = ((System.Drawing.Image)(resources.GetObject("busButton.Image")));
            this.busButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.busButton.Location = new System.Drawing.Point(31, 493);
            this.busButton.Margin = new System.Windows.Forms.Padding(4);
            this.busButton.Name = "busButton";
            this.busButton.Size = new System.Drawing.Size(244, 66);
            this.busButton.TabIndex = 4;
            this.busButton.Text = "       Buses";
            this.busButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.busButton.UseVisualStyleBackColor = true;
            this.busButton.Click += new System.EventHandler(this.busButton_Click);
            // 
            // routesButton
            // 
            this.routesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.routesButton.FlatAppearance.BorderSize = 0;
            this.routesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routesButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routesButton.ForeColor = System.Drawing.Color.White;
            this.routesButton.Image = ((System.Drawing.Image)(resources.GetObject("routesButton.Image")));
            this.routesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.routesButton.Location = new System.Drawing.Point(31, 427);
            this.routesButton.Margin = new System.Windows.Forms.Padding(4);
            this.routesButton.Name = "routesButton";
            this.routesButton.Size = new System.Drawing.Size(244, 66);
            this.routesButton.TabIndex = 4;
            this.routesButton.Text = "       Routes";
            this.routesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.routesButton.UseVisualStyleBackColor = true;
            this.routesButton.Click += new System.EventHandler(this.routesButton_Click);
            // 
            // tripsButton
            // 
            this.tripsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tripsButton.FlatAppearance.BorderSize = 0;
            this.tripsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tripsButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tripsButton.ForeColor = System.Drawing.Color.White;
            this.tripsButton.Image = ((System.Drawing.Image)(resources.GetObject("tripsButton.Image")));
            this.tripsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tripsButton.Location = new System.Drawing.Point(31, 360);
            this.tripsButton.Margin = new System.Windows.Forms.Padding(4);
            this.tripsButton.Name = "tripsButton";
            this.tripsButton.Size = new System.Drawing.Size(244, 66);
            this.tripsButton.TabIndex = 4;
            this.tripsButton.Text = "       Trips";
            this.tripsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tripsButton.UseVisualStyleBackColor = true;
            this.tripsButton.Click += new System.EventHandler(this.tripsButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.White;
            this.homeButton.Image = ((System.Drawing.Image)(resources.GetObject("homeButton.Image")));
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.Location = new System.Drawing.Point(31, 294);
            this.homeButton.Margin = new System.Windows.Forms.Padding(4);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(244, 66);
            this.homeButton.TabIndex = 4;
            this.homeButton.Text = "       Home";
            this.homeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // discountPanel1
            // 
            this.discountPanel1.Location = new System.Drawing.Point(279, 197);
            this.discountPanel1.Name = "discountPanel1";
            this.discountPanel1.Size = new System.Drawing.Size(1148, 636);
            this.discountPanel1.TabIndex = 11;
            // 
            // tripPanel1
            // 
            this.tripPanel1.Location = new System.Drawing.Point(279, 194);
            this.tripPanel1.Name = "tripPanel1";
            this.tripPanel1.Size = new System.Drawing.Size(1148, 636);
            this.tripPanel1.TabIndex = 10;
            // 
            // routePanel1
            // 
            this.routePanel1.Location = new System.Drawing.Point(279, 197);
            this.routePanel1.Name = "routePanel1";
            this.routePanel1.Size = new System.Drawing.Size(1148, 636);
            this.routePanel1.TabIndex = 9;
            // 
            // driverPanel1
            // 
            this.driverPanel1.Location = new System.Drawing.Point(279, 197);
            this.driverPanel1.Name = "driverPanel1";
            this.driverPanel1.Size = new System.Drawing.Size(1148, 636);
            this.driverPanel1.TabIndex = 8;
            // 
            // busPanel1
            // 
            this.busPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.busPanel1.Location = new System.Drawing.Point(282, 194);
            this.busPanel1.Name = "busPanel1";
            this.busPanel1.Size = new System.Drawing.Size(1148, 636);
            this.busPanel1.TabIndex = 7;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 833);
            this.Controls.Add(this.discountPanel1);
            this.Controls.Add(this.tripPanel1);
            this.Controls.Add(this.routePanel1);
            this.Controls.Add(this.driverPanel1);
            this.Controls.Add(this.busPanel1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admn Dashboard";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button discountsButton;
        private System.Windows.Forms.Button driversButton;
        private System.Windows.Forms.Button busButton;
        private System.Windows.Forms.Button routesButton;
        private System.Windows.Forms.Button tripsButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private BusPanel busPanel1;
        private DriverPanel driverPanel1;
        private RoutePanel routePanel1;
        private TripPanel tripPanel1;
        private DiscountPanel discountPanel1;
    }
}