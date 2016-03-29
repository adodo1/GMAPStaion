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
            this.labelRight = new System.Windows.Forms.Label();
            this.labelLeft = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMAP = new System.Windows.Forms.Label();
            this.labelBottom = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.dataGridViewTiles = new System.Windows.Forms.DataGridView();
            this.groupBoxTongji = new System.Windows.Forms.GroupBox();
            this.buttonMakePY = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.labelMAPNAME = new System.Windows.Forms.Label();
            this.ColumnCheaked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBuffer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBuffer = new System.Windows.Forms.Button();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTiles)).BeginInit();
            this.groupBoxTongji.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelMAPNAME);
            this.groupBoxInfo.Controls.Add(this.labelTop);
            this.groupBoxInfo.Controls.Add(this.labelBottom);
            this.groupBoxInfo.Controls.Add(this.labelRight);
            this.groupBoxInfo.Controls.Add(this.labelLeft);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.labelMAP);
            this.groupBoxInfo.Location = new System.Drawing.Point(9, 9);
            this.groupBoxInfo.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(323, 95);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "信息";
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(199, 44);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(101, 12);
            this.labelRight.TabIndex = 3;
            this.labelRight.Text = "经度 右：109.000";
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(64, 44);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(101, 12);
            this.labelLeft.TabIndex = 2;
            this.labelLeft.Text = "经度 左：108.000";
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
            // labelMAP
            // 
            this.labelMAP.AutoSize = true;
            this.labelMAP.Location = new System.Drawing.Point(17, 21);
            this.labelMAP.Name = "labelMAP";
            this.labelMAP.Size = new System.Drawing.Size(65, 12);
            this.labelMAP.TabIndex = 0;
            this.labelMAP.Text = "地图服务：";
            // 
            // labelBottom
            // 
            this.labelBottom.AutoSize = true;
            this.labelBottom.Location = new System.Drawing.Point(64, 66);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(95, 12);
            this.labelBottom.TabIndex = 4;
            this.labelBottom.Text = "纬度 下：24.000";
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.Location = new System.Drawing.Point(199, 66);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(95, 12);
            this.labelTop.TabIndex = 5;
            this.labelTop.Text = "纬度 上：25.000";
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSetting.Controls.Add(this.dataGridViewTiles);
            this.groupBoxSetting.Location = new System.Drawing.Point(335, 9);
            this.groupBoxSetting.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(253, 260);
            this.groupBoxSetting.TabIndex = 1;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "瓦片";
            // 
            // dataGridViewTiles
            // 
            this.dataGridViewTiles.AllowUserToAddRows = false;
            this.dataGridViewTiles.AllowUserToDeleteRows = false;
            this.dataGridViewTiles.AllowUserToOrderColumns = true;
            this.dataGridViewTiles.AllowUserToResizeColumns = false;
            this.dataGridViewTiles.AllowUserToResizeRows = false;
            this.dataGridViewTiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheaked,
            this.ColumnLevel,
            this.ColumnBuffer,
            this.ColumnNum});
            this.dataGridViewTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTiles.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewTiles.Name = "dataGridViewTiles";
            this.dataGridViewTiles.RowHeadersVisible = false;
            this.dataGridViewTiles.RowTemplate.Height = 23;
            this.dataGridViewTiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTiles.Size = new System.Drawing.Size(247, 240);
            this.dataGridViewTiles.TabIndex = 0;
            this.dataGridViewTiles.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTiles_CellValidated);
            // 
            // groupBoxTongji
            // 
            this.groupBoxTongji.Controls.Add(this.richTextBoxInfo);
            this.groupBoxTongji.Location = new System.Drawing.Point(9, 107);
            this.groupBoxTongji.Name = "groupBoxTongji";
            this.groupBoxTongji.Size = new System.Drawing.Size(323, 162);
            this.groupBoxTongji.TabIndex = 2;
            this.groupBoxTongji.TabStop = false;
            // 
            // buttonMakePY
            // 
            this.buttonMakePY.Location = new System.Drawing.Point(445, 276);
            this.buttonMakePY.Name = "buttonMakePY";
            this.buttonMakePY.Size = new System.Drawing.Size(75, 23);
            this.buttonMakePY.TabIndex = 3;
            this.buttonMakePY.Text = "生成脚本";
            this.buttonMakePY.UseVisualStyleBackColor = true;
            this.buttonMakePY.Click += new System.EventHandler(this.buttonMakePY_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(526, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxInfo.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.Size = new System.Drawing.Size(317, 142);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "提示：\n 1.中国大陆地区目前影像最高等级19级\n 2.缓冲值表示往外扩展瓦片数量\n 3.值A表示该等级瓦片全部下载";
            // 
            // labelMAPNAME
            // 
            this.labelMAPNAME.AutoSize = true;
            this.labelMAPNAME.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMAPNAME.ForeColor = System.Drawing.Color.Brown;
            this.labelMAPNAME.Location = new System.Drawing.Point(88, 21);
            this.labelMAPNAME.Name = "labelMAPNAME";
            this.labelMAPNAME.Size = new System.Drawing.Size(26, 12);
            this.labelMAPNAME.TabIndex = 6;
            this.labelMAPNAME.Text = "XXX";
            // 
            // ColumnCheaked
            // 
            this.ColumnCheaked.DataPropertyName = "CHECKED";
            this.ColumnCheaked.FillWeight = 53.4267F;
            this.ColumnCheaked.HeaderText = "";
            this.ColumnCheaked.Name = "ColumnCheaked";
            // 
            // ColumnLevel
            // 
            this.ColumnLevel.DataPropertyName = "LEVEL";
            this.ColumnLevel.FillWeight = 101.5228F;
            this.ColumnLevel.HeaderText = "等级";
            this.ColumnLevel.Name = "ColumnLevel";
            // 
            // ColumnBuffer
            // 
            this.ColumnBuffer.DataPropertyName = "BUFFER";
            this.ColumnBuffer.FillWeight = 122.5252F;
            this.ColumnBuffer.HeaderText = "缓冲";
            this.ColumnBuffer.Name = "ColumnBuffer";
            // 
            // ColumnNum
            // 
            this.ColumnNum.DataPropertyName = "NUMBER";
            this.ColumnNum.FillWeight = 122.5252F;
            this.ColumnNum.HeaderText = "数量";
            this.ColumnNum.Name = "ColumnNum";
            // 
            // buttonBuffer
            // 
            this.buttonBuffer.Location = new System.Drawing.Point(338, 276);
            this.buttonBuffer.Name = "buttonBuffer";
            this.buttonBuffer.Size = new System.Drawing.Size(75, 23);
            this.buttonBuffer.TabIndex = 4;
            this.buttonBuffer.Text = "智能外扩";
            this.buttonBuffer.UseVisualStyleBackColor = true;
            this.buttonBuffer.Click += new System.EventHandler(this.buttonBuffer_Click);
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 307);
            this.Controls.Add(this.buttonBuffer);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTiles)).EndInit();
            this.groupBoxTongji.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMAP;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.DataGridView dataGridViewTiles;
        private System.Windows.Forms.GroupBox groupBoxTongji;
        private System.Windows.Forms.Button buttonMakePY;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Label labelMAPNAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheaked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBuffer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;
        private System.Windows.Forms.Button buttonBuffer;
    }
}