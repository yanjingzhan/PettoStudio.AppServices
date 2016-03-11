namespace DevAccountsManager
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_StoreType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Spliter = new System.Windows.Forms.TextBox();
            this.button_AddTextFile = new System.Windows.Forms.Button();
            this.button_Do = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_StoreType
            // 
            this.comboBox_StoreType.FormattingEnabled = true;
            this.comboBox_StoreType.Items.AddRange(new object[] {
            "360",
            "百度",
            "小米"});
            this.comboBox_StoreType.Location = new System.Drawing.Point(110, 32);
            this.comboBox_StoreType.Name = "comboBox_StoreType";
            this.comboBox_StoreType.Size = new System.Drawing.Size(152, 23);
            this.comboBox_StoreType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "商店类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "自定义分隔符";
            // 
            // textBox_Spliter
            // 
            this.textBox_Spliter.Location = new System.Drawing.Point(426, 29);
            this.textBox_Spliter.Name = "textBox_Spliter";
            this.textBox_Spliter.Size = new System.Drawing.Size(148, 25);
            this.textBox_Spliter.TabIndex = 3;
            // 
            // button_AddTextFile
            // 
            this.button_AddTextFile.Location = new System.Drawing.Point(26, 93);
            this.button_AddTextFile.Name = "button_AddTextFile";
            this.button_AddTextFile.Size = new System.Drawing.Size(120, 52);
            this.button_AddTextFile.TabIndex = 4;
            this.button_AddTextFile.Text = "倒入文件";
            this.button_AddTextFile.UseVisualStyleBackColor = true;
            this.button_AddTextFile.Click += new System.EventHandler(this.button_AddTextFile_Click);
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(239, 93);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(141, 52);
            this.button_Do.TabIndex = 5;
            this.button_Do.Text = "执行";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 648);
            this.Controls.Add(this.button_Do);
            this.Controls.Add(this.button_AddTextFile);
            this.Controls.Add(this.textBox_Spliter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_StoreType);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_StoreType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Spliter;
        private System.Windows.Forms.Button button_AddTextFile;
        private System.Windows.Forms.Button button_Do;
    }
}

