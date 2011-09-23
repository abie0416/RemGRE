namespace RemGRE
{
    partial class ShowMissings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowMissings));
            this.rtfMissings = new System.Windows.Forms.RichTextBox();
            this.lbNull = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtfMissings
            // 
            this.rtfMissings.BackColor = System.Drawing.Color.Black;
            this.rtfMissings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfMissings.ForeColor = System.Drawing.Color.White;
            this.rtfMissings.Location = new System.Drawing.Point(0, 0);
            this.rtfMissings.Name = "rtfMissings";
            this.rtfMissings.ReadOnly = true;
            this.rtfMissings.Size = new System.Drawing.Size(344, 374);
            this.rtfMissings.TabIndex = 0;
            this.rtfMissings.Text = "";
            this.rtfMissings.Enter += new System.EventHandler(this.rtfMissings_Enter);
            // 
            // lbNull
            // 
            this.lbNull.AutoSize = true;
            this.lbNull.Location = new System.Drawing.Point(187, 24);
            this.lbNull.Name = "lbNull";
            this.lbNull.Size = new System.Drawing.Size(0, 17);
            this.lbNull.TabIndex = 1;
            // 
            // ShowMissings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 374);
            this.Controls.Add(this.lbNull);
            this.Controls.Add(this.rtfMissings);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowMissings";
            this.Text = "Missings";
            this.Load += new System.EventHandler(this.ShowMissings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfMissings;
        private System.Windows.Forms.Label lbNull;
    }
}