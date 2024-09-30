namespace BoCuuDe
{
    partial class Form1
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
            this.inputBo = new System.Windows.Forms.TextBox();
            this.inputDe = new System.Windows.Forms.TextBox();
            this.inputCuu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.soluong = new System.Windows.Forms.Button();
            this.sinhsan = new System.Windows.Forms.Button();
            this.themgiasuc = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // inputBo
            // 
            this.inputBo.Location = new System.Drawing.Point(128, 50);
            this.inputBo.Name = "inputBo";
            this.inputBo.Size = new System.Drawing.Size(100, 20);
            this.inputBo.TabIndex = 0;
            // 
            // inputDe
            // 
            this.inputDe.Location = new System.Drawing.Point(561, 50);
            this.inputDe.Name = "inputDe";
            this.inputDe.Size = new System.Drawing.Size(100, 20);
            this.inputDe.TabIndex = 1;
            // 
            // inputCuu
            // 
            this.inputCuu.Location = new System.Drawing.Point(336, 50);
            this.inputCuu.Name = "inputCuu";
            this.inputCuu.Size = new System.Drawing.Size(100, 20);
            this.inputCuu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "So luong Bo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "So luong Cuu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "So luong De";
            // 
            // soluong
            // 
            this.soluong.Location = new System.Drawing.Point(330, 117);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(92, 23);
            this.soluong.TabIndex = 6;
            this.soluong.Text = "Số lượng";
            this.soluong.UseVisualStyleBackColor = true;
            this.soluong.Click += new System.EventHandler(this.button1_Click);
            // 
            // sinhsan
            // 
            this.sinhsan.Location = new System.Drawing.Point(330, 146);
            this.sinhsan.Name = "sinhsan";
            this.sinhsan.Size = new System.Drawing.Size(92, 23);
            this.sinhsan.TabIndex = 7;
            this.sinhsan.Text = "Sinh sản";
            this.sinhsan.UseVisualStyleBackColor = true;
            this.sinhsan.Click += new System.EventHandler(this.button2_Click);
            // 
            // themgiasuc
            // 
            this.themgiasuc.Location = new System.Drawing.Point(330, 178);
            this.themgiasuc.Name = "themgiasuc";
            this.themgiasuc.Size = new System.Drawing.Size(92, 23);
            this.themgiasuc.TabIndex = 9;
            this.themgiasuc.Text = "Thêm gia súc ";
            this.themgiasuc.UseVisualStyleBackColor = true;
            this.themgiasuc.Click += new System.EventHandler(this.button3_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(80, 218);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(600, 220);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.themgiasuc);
            this.Controls.Add(this.sinhsan);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputCuu);
            this.Controls.Add(this.inputDe);
            this.Controls.Add(this.inputBo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBo;
        private System.Windows.Forms.TextBox inputDe;
        private System.Windows.Forms.TextBox inputCuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button soluong;
        private System.Windows.Forms.Button sinhsan;
        private System.Windows.Forms.Button themgiasuc;
        private System.Windows.Forms.ListView listView1;
    }
}

