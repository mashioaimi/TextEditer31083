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
            }
        }

        //名前を付けて保存
        private void SaveNameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //[名前を付けて保存]ダイアログを表示
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(rtTextArea.Text);
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
