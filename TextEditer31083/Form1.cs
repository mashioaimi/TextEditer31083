using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditer31083
{
    public partial class Form1 : Form
    {
        //現在編集中のファイル名
        private string fileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //アプリケーション終了
            Application.Exit();
        }

        //開く
        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //[開く] ダイアログを表示
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
            {
                FileSave(ofdFileOpen.FileName);
            }
        }


        //ファイル名を指定しデータを保存
        private void FileSave(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8")))
            {
                sw.WriteLine(rtTextArea.Text);
                Text = Path.GetFileName(fileName);
            }
        }

        //名前を付けて保存
        private void SaveNameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //[名前を付けて保存]ダイアログを表示
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                FileSave(sfdFileSave.FileName);
            }
        }

        //新規作成
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Text = "";
            Text = "無題";
        }

        //上書き保存
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fileName != "")
            {
                FileSave(fileName);

            } else
            {
                SaveNameToolStripMenuItem_Click_1(sender, e);
            }
        }

        //元に戻す
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Undo();
        }

        //やり直し
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Redo();
        }

        //切り取り
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Cut();
        }

        //コピー
        private void CopyCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Copy();
        }

        //貼り付け
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Paste();
        }

        //削除
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.SelectedText = "";
        }

        //マスク
        private void rtTextArea_TextChanged(object sender, EventArgs e)
        {
            if (rtTextArea.CanUndo)
            {
                UndoToolStripMenuItem.Enabled = true;
            }
            else
            {
                UndoToolStripMenuItem.Enabled = false;
            }

            if (rtTextArea.CanRedo)
            {
                RedoToolStripMenuItem.Enabled = true;
            }
            else
            {
                RedoToolStripMenuItem.Enabled = false;
            }
            if (rtTextArea.SelectedText == "")
            {
                CutToolStripMenuItem.Enabled = false;
                CopyCToolStripMenuItem.Enabled = false;
                DeleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                CutToolStripMenuItem.Enabled = true;
                CopyCToolStripMenuItem.Enabled = true;
                DeleteToolStripMenuItem.Enabled = true;
            }
            if (Clipboard.ContainsText() == true)
            {
                PasteToolStripMenuItem.Enabled = true;
            } 
            else
            {
                PasteToolStripMenuItem.Enabled = false;
            }
        }

        //色
        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                rtTextArea.SelectionColor = cdColor.Color;
            }
        }

        //フォント
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                rtTextArea.SelectionFont = fdFont.Font;
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea_TextChanged(sender, e);
        }
    }
}
