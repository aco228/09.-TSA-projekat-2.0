namespace _09.TSA_projekat
{
    partial class form_Rekompozicija
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
            this.tab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rezultat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tab.Location = new System.Drawing.Point(9, 4);
            this.tab.Name = "tab";
            this.tab.Size = new System.Drawing.Size(645, 122);
            this.tab.TabIndex = 39;
            this.tab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(649, 5);
            this.label1.TabIndex = 40;
            // 
            // rezultat
            // 
            this.rezultat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rezultat.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rezultat.Location = new System.Drawing.Point(6, 144);
            this.rezultat.Name = "rezultat";
            this.rezultat.Size = new System.Drawing.Size(651, 21);
            this.rezultat.TabIndex = 41;
            this.rezultat.Text = "65498449465465454";
            this.rezultat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // form_Rekompozicija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 170);
            this.Controls.Add(this.rezultat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(15000000, 204);
            this.Name = "form_Rekompozicija";
            this.ShowInTaskbar = false;
            this.Text = "Информације о рекомпозицији";
            this.Load += new System.EventHandler(this.form_Rekompozicija_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rezultat;
    }
}