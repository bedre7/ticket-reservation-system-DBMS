
namespace OnlineBusReservation
{
    partial class TripPanel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.assignComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddTripBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTrip = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DeleteTripBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.deleteTripBox = new System.Windows.Forms.TextBox();
            this.dgvDelTrip = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvUpd = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.newPriceBox = new System.Windows.Forms.TextBox();
            this.UpdatePriceBtn = new System.Windows.Forms.Button();
            this.updTripIdBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrip)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelTrip)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpd)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 636);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dgvTrip);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1140, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "       Add       ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.priceBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.toComboBox);
            this.groupBox1.Controls.Add(this.fromComboBox);
            this.groupBox1.Controls.Add(this.assignComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.AddTripBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(23, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 329);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trip Information";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(602, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 36);
            this.label5.TabIndex = 52;
            this.label5.Text = "₺";
            // 
            // priceBox
            // 
            this.priceBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.priceBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.priceBox.Location = new System.Drawing.Point(456, 217);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(140, 31);
            this.priceBox.TabIndex = 51;
            this.priceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceBox_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(291, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 36);
            this.label3.TabIndex = 50;
            this.label3.Text = "Ticket Price";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(456, 82);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 38);
            this.dateTimePicker2.TabIndex = 49;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(21, 269);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 38);
            this.dateTimePicker1.TabIndex = 48;
            // 
            // toComboBox
            // 
            this.toComboBox.FormattingEnabled = true;
            this.toComboBox.Location = new System.Drawing.Point(21, 176);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(211, 39);
            this.toComboBox.TabIndex = 47;
            // 
            // fromComboBox
            // 
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(21, 95);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(211, 39);
            this.fromComboBox.TabIndex = 46;
            this.fromComboBox.SelectedIndexChanged += new System.EventHandler(this.fromComboBox_SelectedIndexChanged);
            // 
            // assignComboBox
            // 
            this.assignComboBox.FormattingEnabled = true;
            this.assignComboBox.Location = new System.Drawing.Point(456, 145);
            this.assignComboBox.Name = "assignComboBox";
            this.assignComboBox.Size = new System.Drawing.Size(211, 39);
            this.assignComboBox.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(291, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 36);
            this.label7.TabIndex = 44;
            this.label7.Text = "Assign Driver";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(291, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 36);
            this.label6.TabIndex = 37;
            this.label6.Text = "Arrival time";
            // 
            // AddTripBtn
            // 
            this.AddTripBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(144)))), ((int)(((byte)(194)))));
            this.AddTripBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddTripBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AddTripBtn.ForeColor = System.Drawing.Color.White;
            this.AddTripBtn.Location = new System.Drawing.Point(738, 256);
            this.AddTripBtn.Name = "AddTripBtn";
            this.AddTripBtn.Size = new System.Drawing.Size(279, 51);
            this.AddTripBtn.TabIndex = 1;
            this.AddTripBtn.Text = "Add Trip";
            this.AddTripBtn.UseVisualStyleBackColor = false;
            this.AddTripBtn.Click += new System.EventHandler(this.AddTripBtn_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(16, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 36);
            this.label4.TabIndex = 33;
            this.label4.Text = "Departure time";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 36);
            this.label1.TabIndex = 30;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 36);
            this.label2.TabIndex = 29;
            this.label2.Text = "From";
            // 
            // dgvTrip
            // 
            this.dgvTrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrip.Location = new System.Drawing.Point(23, 341);
            this.dgvTrip.Name = "dgvTrip";
            this.dgvTrip.ReadOnly = true;
            this.dgvTrip.RowHeadersWidth = 51;
            this.dgvTrip.RowTemplate.Height = 24;
            this.dgvTrip.Size = new System.Drawing.Size(1088, 239);
            this.dgvTrip.TabIndex = 44;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DeleteTripBtn);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.deleteTripBox);
            this.tabPage3.Controls.Add(this.dgvDelTrip);
            this.tabPage3.Location = new System.Drawing.Point(4, 36);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1140, 596);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "       Delete       ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DeleteTripBtn
            // 
            this.DeleteTripBtn.BackColor = System.Drawing.Color.Red;
            this.DeleteTripBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteTripBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DeleteTripBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteTripBtn.Location = new System.Drawing.Point(390, 18);
            this.DeleteTripBtn.Name = "DeleteTripBtn";
            this.DeleteTripBtn.Size = new System.Drawing.Size(267, 55);
            this.DeleteTripBtn.TabIndex = 55;
            this.DeleteTripBtn.Text = "Delete Trip";
            this.DeleteTripBtn.UseVisualStyleBackColor = false;
            this.DeleteTripBtn.Click += new System.EventHandler(this.DeleteTripBtn_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(41, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 38);
            this.label11.TabIndex = 54;
            this.label11.Text = "TripID";
            // 
            // deleteTripBox
            // 
            this.deleteTripBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.deleteTripBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteTripBox.Location = new System.Drawing.Point(138, 35);
            this.deleteTripBox.Name = "deleteTripBox";
            this.deleteTripBox.Size = new System.Drawing.Size(211, 31);
            this.deleteTripBox.TabIndex = 53;
            // 
            // dgvDelTrip
            // 
            this.dgvDelTrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelTrip.Location = new System.Drawing.Point(45, 101);
            this.dgvDelTrip.Name = "dgvDelTrip";
            this.dgvDelTrip.ReadOnly = true;
            this.dgvDelTrip.RowHeadersWidth = 51;
            this.dgvDelTrip.RowTemplate.Height = 24;
            this.dgvDelTrip.Size = new System.Drawing.Size(1030, 453);
            this.dgvDelTrip.TabIndex = 45;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvUpd);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1140, 596);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "        Update       ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvUpd
            // 
            this.dgvUpd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpd.Location = new System.Drawing.Point(234, 314);
            this.dgvUpd.Name = "dgvUpd";
            this.dgvUpd.ReadOnly = true;
            this.dgvUpd.RowHeadersWidth = 51;
            this.dgvUpd.RowTemplate.Height = 24;
            this.dgvUpd.Size = new System.Drawing.Size(601, 225);
            this.dgvUpd.TabIndex = 47;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.newPriceBox);
            this.groupBox3.Controls.Add(this.UpdatePriceBtn);
            this.groupBox3.Controls.Add(this.updTripIdBox);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(174, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(712, 238);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Price";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(413, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 36);
            this.label9.TabIndex = 51;
            this.label9.Text = "New Price";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(110, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 36);
            this.label8.TabIndex = 37;
            this.label8.Text = "Trip ID";
            // 
            // newPriceBox
            // 
            this.newPriceBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.newPriceBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newPriceBox.Location = new System.Drawing.Point(417, 96);
            this.newPriceBox.Name = "newPriceBox";
            this.newPriceBox.Size = new System.Drawing.Size(211, 31);
            this.newPriceBox.TabIndex = 36;
            this.newPriceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceBox_KeyPress);
            // 
            // UpdatePriceBtn
            // 
            this.UpdatePriceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(184)))), ((int)(((byte)(77)))));
            this.UpdatePriceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdatePriceBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UpdatePriceBtn.ForeColor = System.Drawing.Color.White;
            this.UpdatePriceBtn.Location = new System.Drawing.Point(274, 166);
            this.UpdatePriceBtn.Name = "UpdatePriceBtn";
            this.UpdatePriceBtn.Size = new System.Drawing.Size(259, 49);
            this.UpdatePriceBtn.TabIndex = 1;
            this.UpdatePriceBtn.Text = "Update Price";
            this.UpdatePriceBtn.UseVisualStyleBackColor = false;
            this.UpdatePriceBtn.Click += new System.EventHandler(this.UpdatePriceBtn_Click);
            // 
            // updTripIdBox
            // 
            this.updTripIdBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.updTripIdBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updTripIdBox.Location = new System.Drawing.Point(114, 96);
            this.updTripIdBox.Name = "updTripIdBox";
            this.updTripIdBox.Size = new System.Drawing.Size(212, 31);
            this.updTripIdBox.TabIndex = 31;
            this.updTripIdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceBox_KeyPress);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(634, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 34);
            this.label10.TabIndex = 61;
            this.label10.Text = "₺";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TripPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TripPanel";
            this.Size = new System.Drawing.Size(1148, 636);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrip)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelTrip)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddTripBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTrip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.ComboBox assignComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox deleteTripBox;
        private System.Windows.Forms.DataGridView dgvDelTrip;
        private System.Windows.Forms.Button DeleteTripBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvUpd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox newPriceBox;
        private System.Windows.Forms.Button UpdatePriceBtn;
        private System.Windows.Forms.TextBox updTripIdBox;
        private System.Windows.Forms.Label label10;
    }
}
