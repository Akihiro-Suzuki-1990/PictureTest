namespace PictureTest
{
    partial class frmPicTest
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblFolderCap = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMax1 = new System.Windows.Forms.Label();
            this.lblMax2 = new System.Windows.Forms.Label();
            this.lblMax3 = new System.Windows.Forms.Label();
            this.lblAve1 = new System.Windows.Forms.Label();
            this.lblAve2 = new System.Windows.Forms.Label();
            this.lblAve3 = new System.Windows.Forms.Label();
            this.lblAve = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.lblMax6 = new System.Windows.Forms.Label();
            this.lblAve6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAve4 = new System.Windows.Forms.Label();
            this.lblMax4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 19);
            this.textBox1.TabIndex = 1;
            // 
            // lblFolderCap
            // 
            this.lblFolderCap.AutoSize = true;
            this.lblFolderCap.Location = new System.Drawing.Point(12, 9);
            this.lblFolderCap.Name = "lblFolderCap";
            this.lblFolderCap.Size = new System.Drawing.Size(269, 12);
            this.lblFolderCap.TabIndex = 0;
            this.lblFolderCap.Text = "フォルダ（この中の画像を全て読んで時間を計測します。)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Image.FromFile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(269, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Image.FromStream";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(269, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Image.FromStream+Usingの範囲を小さくする";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(399, 49);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(26, 12);
            this.lblMax.TabIndex = 2;
            this.lblMax.Text = "Max";
            // 
            // lblMax1
            // 
            this.lblMax1.AutoSize = true;
            this.lblMax1.Location = new System.Drawing.Point(399, 78);
            this.lblMax1.Name = "lblMax1";
            this.lblMax1.Size = new System.Drawing.Size(23, 12);
            this.lblMax1.TabIndex = 5;
            this.lblMax1.Text = "000";
            // 
            // lblMax2
            // 
            this.lblMax2.AutoSize = true;
            this.lblMax2.Location = new System.Drawing.Point(399, 107);
            this.lblMax2.Name = "lblMax2";
            this.lblMax2.Size = new System.Drawing.Size(23, 12);
            this.lblMax2.TabIndex = 8;
            this.lblMax2.Text = "000";
            // 
            // lblMax3
            // 
            this.lblMax3.AutoSize = true;
            this.lblMax3.Location = new System.Drawing.Point(399, 136);
            this.lblMax3.Name = "lblMax3";
            this.lblMax3.Size = new System.Drawing.Size(23, 12);
            this.lblMax3.TabIndex = 11;
            this.lblMax3.Text = "000";
            // 
            // lblAve1
            // 
            this.lblAve1.AutoSize = true;
            this.lblAve1.Location = new System.Drawing.Point(467, 78);
            this.lblAve1.Name = "lblAve1";
            this.lblAve1.Size = new System.Drawing.Size(23, 12);
            this.lblAve1.TabIndex = 6;
            this.lblAve1.Text = "000";
            // 
            // lblAve2
            // 
            this.lblAve2.AutoSize = true;
            this.lblAve2.Location = new System.Drawing.Point(467, 107);
            this.lblAve2.Name = "lblAve2";
            this.lblAve2.Size = new System.Drawing.Size(23, 12);
            this.lblAve2.TabIndex = 9;
            this.lblAve2.Text = "000";
            // 
            // lblAve3
            // 
            this.lblAve3.AutoSize = true;
            this.lblAve3.Location = new System.Drawing.Point(467, 136);
            this.lblAve3.Name = "lblAve3";
            this.lblAve3.Size = new System.Drawing.Size(23, 12);
            this.lblAve3.TabIndex = 12;
            this.lblAve3.Text = "000";
            // 
            // lblAve
            // 
            this.lblAve.AutoSize = true;
            this.lblAve.Location = new System.Drawing.Point(467, 49);
            this.lblAve.Name = "lblAve";
            this.lblAve.Size = new System.Drawing.Size(25, 12);
            this.lblAve.TabIndex = 3;
            this.lblAve.Text = "Ave";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 194);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(269, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "C++のDLLとBitmapData";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // lblMax6
            // 
            this.lblMax6.AutoSize = true;
            this.lblMax6.Location = new System.Drawing.Point(399, 194);
            this.lblMax6.Name = "lblMax6";
            this.lblMax6.Size = new System.Drawing.Size(23, 12);
            this.lblMax6.TabIndex = 17;
            this.lblMax6.Text = "000";
            // 
            // lblAve6
            // 
            this.lblAve6.AutoSize = true;
            this.lblAve6.Location = new System.Drawing.Point(467, 194);
            this.lblAve6.Name = "lblAve6";
            this.lblAve6.Size = new System.Drawing.Size(23, 12);
            this.lblAve6.TabIndex = 18;
            this.lblAve6.Text = "000";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(498, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 200);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // lblAve4
            // 
            this.lblAve4.AutoSize = true;
            this.lblAve4.Location = new System.Drawing.Point(467, 165);
            this.lblAve4.Name = "lblAve4";
            this.lblAve4.Size = new System.Drawing.Size(23, 12);
            this.lblAve4.TabIndex = 15;
            this.lblAve4.Text = "000";
            // 
            // lblMax4
            // 
            this.lblMax4.AutoSize = true;
            this.lblMax4.Location = new System.Drawing.Point(399, 165);
            this.lblMax4.Name = "lblMax4";
            this.lblMax4.Size = new System.Drawing.Size(23, 12);
            this.lblMax4.TabIndex = 14;
            this.lblMax4.Text = "000";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(269, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "ReadAllBytesとBitmapData";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmPicTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 261);
            this.Controls.Add(this.lblAve4);
            this.Controls.Add(this.lblMax4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAve6);
            this.Controls.Add(this.lblMax6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lblAve);
            this.Controls.Add(this.lblAve3);
            this.Controls.Add(this.lblAve2);
            this.Controls.Add(this.lblAve1);
            this.Controls.Add(this.lblMax3);
            this.Controls.Add(this.lblMax2);
            this.Controls.Add(this.lblMax1);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFolderCap);
            this.Controls.Add(this.textBox1);
            this.Name = "frmPicTest";
            this.Text = "画像読み込みテスト";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFolderCap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMax1;
        private System.Windows.Forms.Label lblMax2;
        private System.Windows.Forms.Label lblMax3;
        private System.Windows.Forms.Label lblAve1;
        private System.Windows.Forms.Label lblAve2;
        private System.Windows.Forms.Label lblAve3;
        private System.Windows.Forms.Label lblAve;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblMax6;
        private System.Windows.Forms.Label lblAve6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAve4;
        private System.Windows.Forms.Label lblMax4;
        private System.Windows.Forms.Button button4;
    }
}

