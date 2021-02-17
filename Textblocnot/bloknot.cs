using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Textblocnot
{
    class Bloknot
    {
        string nameFile;
        RichTextBox fieldEdit;
        public string Namefile
        {
            get { return nameFile; }
        }

        public Bloknot(RichTextBox fieldEdit)
        {
            nameFile = "";
            this.fieldEdit = fieldEdit;
        }

        public bool ASaveNoteBook()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.DefaultExt = "rtf";
            sd.Filter = "Текстовый файл (*.rtf)|*.rtf|Все файлы(*.*)|*.*";
            if (nameFile == "")
            {
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    nameFile = sd.FileName;
                }
                else return false;
            }
            fieldEdit.SaveFile(nameFile);
            fieldEdit.Modified = false;
            return true;
        }
        public void Create()
        {
            if (fieldEdit.Modified == true)
            {
                DialogResult result;
                result = MessageBox.Show("Вы хотите сохранить изменения в файле?",
                    "Блокнот", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (ASaveNoteBook() == false) return;
                }
                if (result == DialogResult.Cancel) return;
            }
            fieldEdit.Clear();
            nameFile = "";
            fieldEdit.Modified = false;
        }

        public void OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.DefaultExt = "*.rtf";
            op.Filter = "Документ RTF|*.rtf|Все файлы|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(op.FileName);
                nameFile = op.FileName;
                fieldEdit.Text = file.ReadLine();
                file.Close();
            }

        }

        public bool SaveFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "*.rtf";
            save.Filter = "Текстовый файл (*.rtf)|*.rtf|Все файлы(*.*)|*.*";
            save.Title = "Сохранить";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.WriteLine(fieldEdit.Text);
                writer.Close();
            }
            fieldEdit.Modified = false;
            return true;
        }

    }
}
