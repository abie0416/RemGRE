using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Resources;

namespace RemGRE
{
    public partial class Form1 : Form
    {
        private bool flag=false;
        private Browser browser;
        private int p_key = 0;
        private Stack<DictionaryEntry> trace = new Stack<DictionaryEntry>();
        public ArrayList lists = new ArrayList();
        private Hashtable[] allWords;
        private Hashtable wordsToBeTested = new Hashtable();
        private Hashtable nextTime = new Hashtable();
        private ArrayList keys = new ArrayList();
        private ToolStripMenuItem[] switch_items;
        public String CurrentWord
        {
            get { return this.lbWord.Text; }
        }
        private String Shortcut(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    return ":show";
                case Keys.H:
                    return ":help";
                case Keys.Q:
                    return ":quit";
                case Keys.L:
                    this.加载ToolStripMenuItem.PerformClick();
                    return null;
                default:
                    return null;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (txtConsole.Visible && txtConsole.Focused)
                return;

            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Oem1)
            {
                this.txtConsole.Text = ":";
                this.txtConsole.Show();
                this.txtConsole.Focus();
                this.txtConsole.Select(this.txtConsole.Text.Length, 0);
                return;
            }
            String cmd = Shortcut(e);
            if (cmd != null)
            {
                ExecuteCmd(cmd);
            }
            if (flag)
            {
                if (e.KeyCode == Keys.Back)
                {
                    try
                    {
                        DictionaryEntry entry = trace.Pop();
                        p_key = Convert.ToInt32(entry.Key);
                        if (!Convert.ToBoolean(entry.Value))
                            this.nextTime.Remove(keys[p_key]);                        
                        ShowNextWord();
                    }
                    catch (InvalidOperationException ioe)
                    {
                    }
                }
                if (e.KeyValue == 74)
                {
                    this.rtfResult.Visible = true;
                }
                if (e.KeyValue == 73)
                {
                    if (this.rtfResult.Visible)
                    {
                        trace.Push(new DictionaryEntry(p_key, true));
                        p_key++;
                        if (p_key == keys.Count)
                        {
                            if (nextTime.Count > 0)
                            {
                                InitNewWordsToBeTested(nextTime);
                                MessageBox.Show("Now comes a new round, hurry up!", "COURAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                ShowNextWord();
                            }
                            else
                            {
                                MessageBox.Show("Congratulations for passing the test!", "CONGRATULATIONS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                InitAll();
                            }
                        }
                        else ShowNextWord();

                    }
                }
                if (e.KeyValue == 79)
                {
                    if (this.rtfResult.Visible)
                    {
                        if (!nextTime.ContainsKey(keys[p_key]))
                            nextTime.Add(keys[p_key], wordsToBeTested[keys[p_key]]);
                        trace.Push(new DictionaryEntry(p_key, false));
                        p_key++;
                        if (p_key == keys.Count)
                        {
                            if (nextTime.Count > 0)
                            {
                                InitNewWordsToBeTested(nextTime);
                                MessageBox.Show("Now comes a new round, hurry up!", "COURAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                ShowNextWord();
                            }
                            else
                            {
                                MessageBox.Show("Congratulations for passing the test!", "CONGRATULATIONS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                InitAll();
                            }
                        }
                        else ShowNextWord();
                    }
                }
            }
        }
        private void ShowNextWord()
        {
            this.Text = String.Format("RemGRE   {0}/{1}", p_key + 1, keys.Count);
            this.rtfResult.Visible = false;
            this.lbWord.Text = keys[p_key].ToString();
            this.rtfResult.Text = wordsToBeTested[keys[p_key]].ToString();
        }
        #region command
        public bool ConsoleJump(int n)
        {
            if (n > keys.Count || n<1) return false;
            else
            {
                trace.Push(new DictionaryEntry(p_key, true));
                p_key = n - 1;
                ShowNextWord();
                return true;
            }
        }
        public bool ConsoleClear(String word)
        {
            if (word != null)
            {
                word = word.ToUpper();
                if (nextTime.ContainsKey(word))
                {
                    nextTime.Remove(word);
                    return true;
                }
                else return false;
            }
            else
            {
                nextTime.Clear();
                return true;
            }
        }
        public Hashtable ConsoleShowMissing()
        {
            return (Hashtable)nextTime.Clone();
        }
        public bool ConsoleSave(String path,int t)
        {
            if (t == 0 && wordsToBeTested.Count == 0) return false;
            else if (t == 1 && nextTime.Count == 0) return false;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
                if (t == 0) formatter.Serialize(stream, wordsToBeTested);
                else formatter.Serialize(stream, nextTime);
                stream.Flush();
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ConsoleLoad(String path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                wordsToBeTested = (Hashtable)formatter.Deserialize(stream);
                InitNewWordsToBeTested(wordsToBeTested);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ConsoleTest(String param)
        {
            try
            {
                lists = ChoiceAnalyzer.Analyze(param);
                if (lists == null || lists.Count == 0)
                    return false;
                wordsToBeTested = new Hashtable();
                //nextTime = new Hashtable();
                for (int i = 0; i < lists.Count; i++)
                {
                    foreach (Object key in allWords[Convert.ToInt32(lists[i])].Keys)
                    {
                        if (!wordsToBeTested.ContainsKey(key))
                            wordsToBeTested.Add(key, allWords[Convert.ToInt32(lists[i])][key]);
                    }
                }
                InitNewWordsToBeTested(wordsToBeTested);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ConsoleLook(String word)
        {
            try
            {
                String url = String.Format("http://www.google.cn/dictionary?langpair=en|zh-CN&q={0}&hl=zh-CN&aq=f", word);
                if (browser == null) browser = new Browser();
                browser.Navigate(url);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
        public void InitAll()
        {
            this.trace = new Stack<DictionaryEntry>();
            flag = false;
            this.wordsToBeTested = new Hashtable();
            this.Text = "RemGRE";
            lists = new ArrayList();
            p_key = 0;
            nextTime = new Hashtable();
            keys = new ArrayList();
            this.lbWord.Text = "Welcome to RemGRE";
            this.rtfResult.Text = "Press ':' to start console for actions";
            SwitchContext(false);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            allWords = Reader.Read(Properties.Resources.vocabulary);
            this.txtConsole.Hide();
            switch_items = new ToolStripMenuItem[]{this.跳至ToolStripMenuItem, this.sHOWToolStripMenuItem, this.保存ToolStripMenuItem};
            SwitchContext(false);
            if (allWords == null)
            {
                MessageBox.Show("Sorry, vocabulary.rem is missing.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            LeaveDefault("1-10;13");
        }
        private void LeaveDefault(String text)
        {
            this.toolStripTextBox1.ForeColor = Color.Gray;
            this.toolStripTextBox1.Text = text;
        }
        private void InitNewWordsToBeTested(Hashtable words)
        {
            this.trace = new Stack<DictionaryEntry>();
            flag = true;
            SwitchContext(true);
            keys = GetKeys(words);
            wordsToBeTested = words;
            this.Text = "RemGRE 1/" + keys.Count.ToString();
            p_key = 0;
            nextTime = new Hashtable();
            ShowNextWord();
        }
        private void SwitchContext(bool b)
        {
            foreach (ToolStripMenuItem item in switch_items)
            {
                item.Enabled = b;
            }
        }
        private ArrayList GetKeys(Hashtable table)
        {
            ArrayList tmp = new ArrayList();
            foreach (Object key in table.Keys)
            {
                tmp.Add(key);
            }
            return tmp;
        }

        private void lbWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String url = String.Format("http://www.google.cn/dictionary?langpair=en|zh-CN&q={0}&hl=zh-CN&aq=f", this.lbWord.Text.ToLower());
            if (browser == null) browser = new Browser();
            browser.Navigate(url);
        }


        private void rtfResult_Enter(object sender, EventArgs e)
        {
            this.lbWord.Focus();
        }

        public void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCmd(":about");
        }

        public void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCmd(":help");
        }

        private bool ExecuteCmd(String cmd)
        {
            cmd = cmd.ToLower();
            cmd = cmd.Substring(1);
            if (cmd == "quit")
            {
                this.Close();
                return true;
            }
            else if (cmd.StartsWith("jump"))
            {
                try
                {
                    String loc = cmd.Substring(4);
                    loc = loc.Trim();
                    return this.ConsoleJump(Convert.ToInt32(loc));
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else if (cmd.StartsWith("clearall"))
            {
                return this.ConsoleClear(null);
            }
            else if (cmd.StartsWith("clear"))
            {
                String p = cmd.Substring(5);
                p = p.Trim();
                return this.ConsoleClear(p);
            }
            else if (cmd.StartsWith("show"))
            {
                try
                {
                    Point p = new Point(this.Location.X, this.Location.Y + this.Size.Height);
                    ShowMissings sm = new ShowMissings(this.ConsoleShowMissing(), p);
                    sm.ShowDialog();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else if (cmd.StartsWith("about"))
            {
                MessageBox.Show("Version 1.1\nDesigned by 葛馨阳\nE-mail:aegiryy@gmail.com", "ABOUT RemGRE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (cmd.StartsWith("help"))
            {
                MessageBox.Show("about : 查看“关于”文档（也可以通过在主窗口中右击弹出的菜单中查看）。\n\nclearall : 清除所有在“遗忘列表”中的记录项。\n\nclear [word] : 清除“遗忘列表”中的指定单词（注：[word]表示参数，只要把指定的单词替换[word]即可，譬如要清除forebone这个单词，则输入clear forebone）。\n\nquit : 退出该程序。\n\njump [number] : 把单词跳到指定位置（譬如在记忆某个共有150个单词的单元时，在75个单词位置不小心把程序关闭了，打开程序后，就可以直接跳至第75个单词处）。\n\nsave [c/m] [path] : 把指定列表（c 表示当前测试列表；m 表示当前遗忘列表）中的单词存入path所指定的文件。\n\nload [path] : 从path所指定的文件中读出单词进行测试。\n\nshow : 查看遗忘列表。\n\ntest [para] : 测试path所指定的list（共有39个list），格式如下：3;4;5 (表示第三第四第五单元），3-8；10；13 （表示三到八单元，第十单元和第十三单元）。不同的元素以分号隔开，在上例中，3-8是一个元素，10是一个元素，其中分号是英文输入模式下的分号（即半角），连字符也是英文输入模式下的。\n\nlook (word) : 查询指定单词的详细意思和例句（联网状态下）。如果不指定，则自动查询当前所测试单词的详细意思和例句。也可以通过双击主界面上的单词来查询。", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return true;
            }
            else if (cmd.StartsWith("save c"))
            {
                String p = cmd.Substring(6).Trim();
                return this.ConsoleSave(p, 0);
            }
            else if (cmd.StartsWith("save m"))
            {
                String p = cmd.Substring(6);
                p = p.Trim();
                return this.ConsoleSave(p, 1);
            }
            else if (cmd.StartsWith("load"))
            {
                String p = cmd.Substring(4);
                p = p.Trim();
                return this.ConsoleLoad(p);
            }
            else if (cmd.StartsWith("test"))
            {
                String p = cmd.Substring(4);
                p = p.Trim();
                return this.ConsoleTest(p);
            }
            else if (cmd.StartsWith("look"))
            {
                String p = cmd.Substring(4);
                p = p.Trim();
                if (p.Length == 0) return this.ConsoleLook(this.CurrentWord);
                return this.ConsoleLook(p);
            }
            else return false;
        }

        private void txtConsole_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    this.txtConsole.Hide();
                    ExecuteCmd(this.txtConsole.Text);
                    this.lbWord.Focus();
                    break;
                case Keys.Escape:
                    this.txtConsole.Hide();
                    this.lbWord.Focus();
                    break;
            }
            e.Handled = true;
        }

        private void cLEARALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCmd(":clearall");
        }

        private void sHOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCmd(":show");
        }

        private void 保存遗忘列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            Debug.WriteLine(this.saveFileDialog1.FileName == "");
        }

        private void 遗忘列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            if (this.saveFileDialog1.FileName != "")
            {
                ExecuteCmd(":save m " + this.saveFileDialog1.FileName);
            }
        }

        private void 当前列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            if (this.saveFileDialog1.FileName != "")
            {
                ExecuteCmd(":save c " + this.saveFileDialog1.FileName);
            }
        }

        private void 加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            if (File.Exists(this.openFileDialog1.FileName))
            {
                ExecuteCmd(":load " + this.openFileDialog1.FileName);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            this.toolStripTextBox1.Clear();
            this.toolStripTextBox1.ForeColor = Color.Black;
            this.toolStripTextBox1.Select(0, 0);
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                this.contextMenuStrip1.Hide();
                ExecuteCmd(":test " + this.toolStripTextBox1.Text);
                LeaveDefault("1-10;13");
                e.Handled = true;
            }
        }

        private void toolStripTextBoxJumpTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                this.contextMenuStrip1.Hide();
                ExecuteCmd(":jump " + this.toolStripTextBoxJumpTo.Text);
                this.toolStripTextBoxJumpTo.Clear();
                e.Handled = true;
            }
        }
    }
}
