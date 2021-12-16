
namespace OnlineBusReservation
{
    partial class PassengerHome
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchTripBtn = new System.Windows.Forms.Button();
            this.datePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.toCBox = new System.Windows.Forms.ComboBox();
            this.fromCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(30, 135);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1089, 500);
            this.flowLayoutPanel2.TabIndex = 72;
            // 
            // SearchTripBtn
            // 
            this.SearchTripBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(144)))), ((int)(((byte)(194)))));
            this.SearchTripBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchTripBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SearchTripBtn.ForeColor = System.Drawing.Color.White;
            this.SearchTripBtn.Location = new System.Drawing.Point(952, 61);
            this.SearchTripBtn.Name = "SearchTripBtn";
            this.SearchTripBtn.Size = new System.Drawing.Size(155, 55);
            this.SearchTripBtn.TabIndex = 71;
            this.SearchTripBtn.Text = "Search";
            this.SearchTripBtn.UseVisualStyleBackColor = false;
            this.SearchTripBtn.Click += new System.EventHandler(this.SearchTripBtn_Click);
            // 
            // datePicker1
            // 
            this.datePicker1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.datePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker1.Location = new System.Drawing.Point(608, 86);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(267, 30);
            this.datePicker1.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(613, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 36);
            this.label3.TabIndex = 69;
            this.label3.Text = "Date";
            // 
            // toCBox
            // 
            this.toCBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toCBox.FormattingEnabled = true;
            this.toCBox.Location = new System.Drawing.Point(323, 86);
            this.toCBox.Name = "toCBox";
            this.toCBox.Size = new System.Drawing.Size(211, 31);
            this.toCBox.TabIndex = 68;
            // 
            // fromCBox
            // 
            this.fromCBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fromCBox.FormattingEnabled = true;
            this.fromCBox.Location = new System.Drawing.Point(43, 86);
            this.fromCBox.Name = "fromCBox";
            this.fromCBox.Size = new System.Drawing.Size(211, 31);
            this.fromCBox.TabIndex = 67;
            this.fromCBox.SelectedIndexChanged += new System.EventHandler(this.fromCBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(319, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 36);
            this.label1.TabIndex = 66;
            this.label1.Text = "To(destination)";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(48, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 36);
            this.label2.TabIndex = 65;
            this.label2.Text = "From(departure)";
            // 
            // PassengerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.SearchTripBtn);
            this.Controls.Add(this.datePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toCBox);
            this.Controls.Add(this.fromCBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "PassengerHome";
            this.Size = new System.Drawing.Size(1148, 670);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button SearchTripBtn;
        private System.Windows.Forms.DateTimePicker datePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox toCBox;
        private System.Windows.Forms.ComboBox fromCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton FemaleBtn;
        private System.Windows.Forms.RadioButton MaleBtn;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.TextBox NameBox;
    }
}
