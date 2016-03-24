namespace GMAPStaion
{
    partial class DownloadForm
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
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.dataGridViewLevel = new System.Windows.Forms.DataGridView();
            this.groupBoxTongji = new System.Windows.Forms.GroupBox();
            this.buttonMakePY = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.ColumnCheaked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBuffer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLevel)).BeginInit();
            this.groupBoxTongji.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.label6);
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Location = new System.Drawing.Point(9, 9);
            this.groupBoxInfo.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(323, 95);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "经度 右：109.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "经度 左：108.000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "范围：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地图服务：XXXXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "纬度 下：24.000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "纬度 上：25.000";
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSetting.Controls.Add(this.dataGridViewLevel);
            this.groupBoxSetting.Location = new System.Drawing.Point(335, 9);
            this.groupBoxSetting.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(253, 260);
            this.groupBoxSetting.TabIndex = 1;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "级别";
            // 
            // dataGridViewLevel
            // 
            this.dataGridViewLevel.AllowUserToDeleteRows = false;
            this.dataGridViewLevel.AllowUserToOrderColumns = true;
            this.dataGridViewLevel.AllowUserToResizeColumns = false;
            this.dataGridViewLevel.AllowUserToResizeRows = false;
            this.dataGridViewLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLevel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheaked,
            this.ColumnLevel,
            this.ColumnBuffer,
            this.ColumnNum});
            this.dataGridViewLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLevel.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewLevel.Name = "dataGridViewLevel";
            this.dataGridViewLevel.RowHeadersVisible = false;
            this.dataGridViewLevel.RowTemplate.Height = 23;
            this.dataGridViewLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLevel.Size = new System.Drawing.Size(247, 240);
            this.dataGridViewLevel.TabIndex = 0;
            // 
            // groupBoxTongji
            // 
            this.groupBoxTongji.Controls.Add(this.richTextBoxInfo);
            this.groupBoxTongji.Location = new System.Drawing.Point(9, 107);
            this.groupBoxTongji.Name = "groupBoxTongji";
            this.groupBoxTongji.Size = new System.Drawing.Size(323, 162);
            this.groupBoxTongji.TabIndex = 2;
            this.groupBoxTongji.TabStop = false;
            this.groupBoxTongji.Text = "统计";
            // 
            // buttonMakePY
            // 
            this.buttonMakePY.Location = new System.Drawing.Point(426, 276);
            this.buttonMakePY.Name = "buttonMakePY";
            this.buttonMakePY.Size = new System.Drawing.Size(75, 23);
            this.buttonMakePY.TabIndex = 3;
            this.buttonMakePY.Text = "生成脚本";
            this.buttonMakePY.UseVisualStyleBackColor = true;
            this.buttonMakePY.Click += new System.EventHandler(this.buttonMakePY_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(510, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxInfo.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.Size = new System.Drawing.Size(317, 142);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // ColumnCheaked
            // 
            this.ColumnCheaked.FillWeight = 53.4267F;
            this.ColumnCheaked.HeaderText = "";
            this.ColumnCheaked.Name = "ColumnCheaked";
            // 
            // ColumnLevel
            // 
            this.ColumnLevel.FillWeight = 101.5228F;
            this.ColumnLevel.HeaderText = "等级";
            this.ColumnLevel.Name = "ColumnLevel";
            // 
            // ColumnBuffer
            // 
            this.ColumnBuffer.FillWeight = 122.5252F;
            this.ColumnBuffer.HeaderText = "缓冲";
            this.ColumnBuffer.Name = "ColumnBuffer";
            // 
            // ColumnNum
            // 
            this.ColumnNum.FillWeight = 122.5252F;
            this.ColumnNum.HeaderText = "数量";
            this.ColumnNum.Name = "ColumnNum";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 307);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMakePY);
            this.Controls.Add(this.groupBoxTongji);
            this.Controls.Add(this.groupBoxSetting);
            this.Controls.Add(this.groupBoxInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图下载";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLevel)).EndInit();
            this.groupBoxTongji.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.DataGridView dataGridViewLevel;
        private System.Windows.Forms.GroupBox groupBoxTongji;
        private System.Windows.Forms.Button buttonMakePY;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheaked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBuffer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;
    }
}