namespace RemGRE
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbWord = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.跳至ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxJumpTo = new System.Windows.Forms.ToolStripTextBox();
            this.sHOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.遗忘列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtfResult = new System.Windows.Forms.RichTextBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbWord
            // 
            this.lbWord.AutoSize = true;
            this.lbWord.ContextMenuStrip = this.contextMenuStrip1;
            this.lbWord.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWord.ForeColor = System.Drawing.Color.White;
            this.lbWord.Location = new System.Drawing.Point(6, 7);
            this.lbWord.Name = "lbWord";
            this.lbWord.Size = new System.Drawing.Size(326, 39);
            this.lbWord.TabIndex = 0;
            this.lbWord.Text = "Welcome to RemGRE";
            this.lbWord.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbWord_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试ToolStripMenuItem,
            this.跳至ToolStripMenuItem,
            this.sHOWToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.加载ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 158);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.测试ToolStripMenuItem.Text = "测试";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 21);
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // 跳至ToolStripMenuItem
            // 
            this.跳至ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxJumpTo});
            this.跳至ToolStripMenuItem.Name = "跳至ToolStripMenuItem";
            this.跳至ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.跳至ToolStripMenuItem.Text = "跳至";
            // 
            // toolStripTextBoxJumpTo
            // 
            this.toolStripTextBoxJumpTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxJumpTo.Name = "toolStripTextBoxJumpTo";
            this.toolStripTextBoxJumpTo.Size = new System.Drawing.Size(100, 21);
            this.toolStripTextBoxJumpTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxJumpTo_KeyPress);
            // 
            // sHOWToolStripMenuItem
            // 
            this.sHOWToolStripMenuItem.Name = "sHOWToolStripMenuItem";
            this.sHOWToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sHOWToolStripMenuItem.Text = "显示遗忘列表";
            this.sHOWToolStripMenuItem.Click += new System.EventHandler(this.sHOWToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.遗忘列表ToolStripMenuItem,
            this.当前列表ToolStripMenuItem});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 遗忘列表ToolStripMenuItem
            // 
            this.遗忘列表ToolStripMenuItem.Name = "遗忘列表ToolStripMenuItem";
            this.遗忘列表ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.遗忘列表ToolStripMenuItem.Text = "遗忘列表";
            this.遗忘列表ToolStripMenuItem.Click += new System.EventHandler(this.遗忘列表ToolStripMenuItem_Click);
            // 
            // 当前列表ToolStripMenuItem
            // 
            this.当前列表ToolStripMenuItem.Name = "当前列表ToolStripMenuItem";
            this.当前列表ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.当前列表ToolStripMenuItem.Text = "当前列表";
            this.当前列表ToolStripMenuItem.Click += new System.EventHandler(this.当前列表ToolStripMenuItem_Click);
            // 
            // 加载ToolStripMenuItem
            // 
            this.加载ToolStripMenuItem.Name = "加载ToolStripMenuItem";
            this.加载ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.加载ToolStripMenuItem.Text = "加载";
            this.加载ToolStripMenuItem.Click += new System.EventHandler(this.加载ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // rtfResult
            // 
            this.rtfResult.BackColor = System.Drawing.Color.Black;
            this.rtfResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfResult.ContextMenuStrip = this.contextMenuStrip1;
            this.rtfResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtfResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtfResult.ForeColor = System.Drawing.Color.White;
            this.rtfResult.Location = new System.Drawing.Point(13, 58);
            this.rtfResult.Name = "rtfResult";
            this.rtfResult.ReadOnly = true;
            this.rtfResult.Size = new System.Drawing.Size(313, 104);
            this.rtfResult.TabIndex = 1;
            this.rtfResult.Text = "Press \':\' to start console for actions";
            this.rtfResult.Enter += new System.EventHandler(this.rtfResult_Enter);
            // 
            // txtConsole
            // 
            this.txtConsole.AutoCompleteCustomSource.AddRange(new string[] {
            ":about",
            ":help",
            ":jump",
            ":save",
            ":load",
            ":look",
            ":test",
            ":quit",
            ":clear",
            ":clearall"});
            this.txtConsole.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtConsole.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtConsole.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(6, 143);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(320, 16);
            this.txtConsole.TabIndex = 2;
            this.txtConsole.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConsole_KeyUp);
            this.txtConsole.LostFocus += new System.EventHandler(this.txtConsole_LostFocus);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(346, 165);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.rtfResult);
            this.Controls.Add(this.lbWord);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(354, 199);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 199);
            this.Name = "Form1";
            this.Text = "RemGRE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void txtConsole_LostFocus(object sender, System.EventArgs e)
        {
            //this.txtConsole.Hide();
        }

        #endregion

        private System.Windows.Forms.Label lbWord;
        private System.Windows.Forms.RichTextBox rtfResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.ToolStripMenuItem sHOWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 遗忘列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 跳至ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxJumpTo;


    }
}

