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

namespace Text_Editor
{
    public partial class Form1 : Form
    {
        public string While = "while";
        public bool isNew { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isNew = true;
            richTextBox1.Clear();
            Text = "Untitle";
        }

        private void OpenClicked(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                ext = ext.ToLower();
                if (ext == ".rtf")
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                }
                else
                    richTextBox1.Text = File.ReadAllText(
                        openFileDialog1.FileName);
                isNew = false;
                Text = openFileDialog1.FileName;
            }
        }

        private void SaveAsClicked(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                ext = ext.ToLower();
                if (ext == ".rtf")
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                else File.WriteAllText(
                    saveFileDialog1.FileName,
                    richTextBox1.Text);
                isNew = false;
                openFileDialog1.FileName = saveFileDialog1.FileName;
                Text = openFileDialog1.FileName;
            }
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            if (isNew) SaveAsClicked(sender, e);
            else
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                ext = ext.ToLower();
                if (ext == ".rtf")
                    richTextBox1.SaveFile(openFileDialog1.FileName);
                else
                    File.WriteAllText(
                    openFileDialog1.FileName,
                    richTextBox1.Text);
                isNew = false;
            }
        }

        private void FontClicked(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Text.");
            }
        }

        private void ForegroundClicked(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog1.Color;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Text.");
            }

        }

        private void BackgroundClicked(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionBackColor = colorDialog1.Color;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Text.");
            }
        }

        private void CutClicked(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void CopyClicked(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Copy();
            }   
        }

        private void PasteClicked(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void SelectAllClicked(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void UndoClicked(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Microsoft Windows\nVersion 1.0\n@Copy right\n\nNotepad++ is a text and C# Source Code editor for use with Microsoft Windows. " +
                "The Project's name comes from the C increment operator.\n\n\n@Created by Deoun Samnang" +"");
        }

        private void multiDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains(While))
            {
                
            }
            if (richTextBox1.Text.Contains("for"))
            {

            }
            if (richTextBox1.Text.Contains("if"))
            {

            }
            if (richTextBox1.Text.Contains("using"))
            {

            }
        }
    }
}
