
namespace OnlineBusReservation
{
    partial class BusPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addBusBtn = new System.Windows.Forms.Button();
            this.seatsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modelBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.brandBox = new System.Windows.Forms.TextBox();
            this.plateBox = new System.Windows.Forms.TextBox();
            this.dgvBus = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchBusBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seatsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBus)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addBusBtn);
            this.groupBox1.Controls.Add(this.seatsUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.modelBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.brandBox);
            this.groupBox1.Controls.Add(this.plateBox);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(40, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 535);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bus Information";
            // 
            // addBusBtn
            // 
            this.addBusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(144)))), ((int)(((byte)(194)))));
            this.addBusBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBusBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addBusBtn.ForeColor = System.Drawing.Color.White;
            this.addBusBtn.Location = new System.Drawing.Point(20, 454);
            this.addBusBtn.Name = "addBusBtn";
            this.addBusBtn.Size = new System.Drawing.Size(279, 51);
            this.addBusBtn.TabIndex = 1;
            this.addBusBtn.Text = "Add Bus";
            this.addBusBtn.UseVisualStyleBackColor = false;
            this.addBusBtn.Click += new System.EventHandler(this.addBusBtn_Click);
            // 
            // seatsUpDown
            // 
            this.seatsUpDown.AutoSize = true;
            this.seatsUpDown.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.seatsUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seatsUpDown.Location = new System.Drawing.Point(216, 384);
            this.seatsUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.seatsUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seatsUpDown.Name = "seatsUpDown";
            this.seatsUpDown.Size = new System.Drawing.Size(83, 31);
            this.seatsUpDown.TabIndex = 35;
            this.seatsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(23, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 36);
            this.label3.TabIndex = 34;
            this.label3.Text = "Number of seats";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(23, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 36);
            this.label4.TabIndex = 33;
            this.label4.Text = "Model";
            // 
            // modelBox
            // 
            this.modelBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.modelBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.modelBox.Location = new System.Drawing.Point(27, 322);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(212, 31);
            this.modelBox.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(24, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 36);
            this.label1.TabIndex = 30;
            this.label1.Text = "Brand Name";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(24, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 36);
            this.label2.TabIndex = 29;
            this.label2.Text = "Plate Number";
            // 
            // brandBox
            // 
            this.brandBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.brandBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.brandBox.Location = new System.Drawing.Point(28, 243);
            this.brandBox.Name = "brandBox";
            this.brandBox.Size = new System.Drawing.Size(211, 31);
            this.brandBox.TabIndex = 28;
            // 
            // plateBox
            // 
            this.plateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.plateBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plateBox.Location = new System.Drawing.Point(27, 155);
            this.plateBox.Name = "plateBox";
            this.plateBox.Size = new System.Drawing.Size(211, 31);
            this.plateBox.TabIndex = 27;
            this.plateBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.plateBox_KeyPress);
            // 
            // dgvBus
            // 
            this.dgvBus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBus.Location = new System.Drawing.Point(391, 116);
            this.dgvBus.Name = "dgvBus";
            this.dgvBus.ReadOnly = true;
            this.dgvBus.RowHeadersWidth = 51;
            this.dgvBus.RowTemplate.Height = 24;
            this.dgvBus.Size = new System.Drawing.Size(718, 479);
            this.dgvBus.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(386, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 39);
            this.label5.TabIndex = 2;
            this.label5.Text = "Buses List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(98)))), ((int)(((byte)(128)))));
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.searchBtn.ForeColor = System.Drawing.Color.White;
            this.searchBtn.Location = new System.Drawing.Point(995, 59);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(114, 51);
            this.searchBtn.TabIndex = 36;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchBusBox
            // 
            this.searchBusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.searchBusBox.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.searchBusBox.Location = new System.Drawing.Point(574, 72);
            this.searchBusBox.Name = "searchBusBox";
            this.searchBusBox.Size = new System.Drawing.Size(381, 34);
            this.searchBusBox.TabIndex = 37;
            // 
            // BusPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchBusBox);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvBus);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BusPanel";
            this.Size = new System.Drawing.Size(1148, 636);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seatsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addBusBtn;
        private System.Windows.Forms.NumericUpDown seatsUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox modelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox brandBox;
        private System.Windows.Forms.TextBox plateBox;
        private System.Windows.Forms.DataGridView dgvBus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchBusBox;
    }
}
