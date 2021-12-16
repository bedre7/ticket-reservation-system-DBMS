
namespace OnlineBusReservation
{
    partial class DiscountPanel
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
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDiscount = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.discComboBox = new System.Windows.Forms.ComboBox();
            this.updateDiscBtn = new System.Windows.Forms.Button();
            this.newDiscUpdown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newDiscUpdown)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(631, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 39);
            this.label5.TabIndex = 5;
            this.label5.Text = "Discounts List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDiscount
            // 
            this.dgvDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscount.Location = new System.Drawing.Point(500, 170);
            this.dgvDiscount.Name = "dgvDiscount";
            this.dgvDiscount.ReadOnly = true;
            this.dgvDiscount.RowHeadersWidth = 51;
            this.dgvDiscount.RowTemplate.Height = 24;
            this.dgvDiscount.Size = new System.Drawing.Size(475, 315);
            this.dgvDiscount.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.discComboBox);
            this.groupBox1.Controls.Add(this.updateDiscBtn);
            this.groupBox1.Controls.Add(this.newDiscUpdown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(93, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 461);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Update Discounts";
            // 
            // discComboBox
            // 
            this.discComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.discComboBox.FormattingEnabled = true;
            this.discComboBox.Location = new System.Drawing.Point(28, 168);
            this.discComboBox.Name = "discComboBox";
            this.discComboBox.Size = new System.Drawing.Size(212, 31);
            this.discComboBox.TabIndex = 36;
            // 
            // updateDiscBtn
            // 
            this.updateDiscBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(144)))), ((int)(((byte)(194)))));
            this.updateDiscBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateDiscBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateDiscBtn.ForeColor = System.Drawing.Color.White;
            this.updateDiscBtn.Location = new System.Drawing.Point(28, 367);
            this.updateDiscBtn.Name = "updateDiscBtn";
            this.updateDiscBtn.Size = new System.Drawing.Size(253, 64);
            this.updateDiscBtn.TabIndex = 1;
            this.updateDiscBtn.Text = "Update";
            this.updateDiscBtn.UseVisualStyleBackColor = false;
            this.updateDiscBtn.Click += new System.EventHandler(this.updateDiscBtn_Click);
            // 
            // newDiscUpdown
            // 
            this.newDiscUpdown.AutoSize = true;
            this.newDiscUpdown.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newDiscUpdown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.newDiscUpdown.Location = new System.Drawing.Point(223, 253);
            this.newDiscUpdown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.newDiscUpdown.Name = "newDiscUpdown";
            this.newDiscUpdown.Size = new System.Drawing.Size(83, 31);
            this.newDiscUpdown.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(24, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 36);
            this.label4.TabIndex = 33;
            this.label4.Text = "Discount Rate(%)";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(24, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 36);
            this.label2.TabIndex = 29;
            this.label2.Text = "Type";
            // 
            // DiscountPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvDiscount);
            this.Controls.Add(this.groupBox1);
            this.Name = "DiscountPanel";
            this.Size = new System.Drawing.Size(1148, 636);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newDiscUpdown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDiscount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button updateDiscBtn;
        private System.Windows.Forms.NumericUpDown newDiscUpdown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox discComboBox;
    }
}
