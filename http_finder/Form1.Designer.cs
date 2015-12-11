namespace http_finder
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
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtFound = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetHtml = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTarget.Location = new System.Drawing.Point(12, 26);
            this.txtTarget.Multiline = true;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(170, 271);
            this.txtTarget.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(206, 26);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFound
            // 
            this.txtFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFound.Location = new System.Drawing.Point(347, 26);
            this.txtFound.Multiline = true;
            this.txtFound.Name = "txtFound";
            this.txtFound.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFound.Size = new System.Drawing.Size(170, 271);
            this.txtFound.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Target";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Found";
            // 
            // btnGetHtml
            // 
            this.btnGetHtml.Location = new System.Drawing.Point(206, 55);
            this.btnGetHtml.Name = "btnGetHtml";
            this.btnGetHtml.Size = new System.Drawing.Size(104, 23);
            this.btnGetHtml.TabIndex = 6;
            this.btnGetHtml.Text = "Get HTML";
            this.btnGetHtml.UseVisualStyleBackColor = true;
            this.btnGetHtml.Click += new System.EventHandler(this.btnGetHtml_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(12, 318);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(505, 142);
            this.txtStatus.TabIndex = 7;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 472);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnGetHtml);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFound);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtTarget);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Http Founder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetHtml;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
    }
}

