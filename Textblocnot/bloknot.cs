using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Textblocnot
{
    public class Bloknot
    {
        string nameFile;
        string box;
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

        /// <summary>
        /// Сохранение блокнота в файл
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Создает новый документ
        /// </summary>
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

        /// <summary>
        /// Открывает текстовый документ
        /// </summary>
        public bool OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.DefaultExt = "*.rtf";
            op.Filter = "Документ RTF|*.rtf|Все файлы|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {

                nameFile = op.FileName;
                fieldEdit.LoadFile(Namefile);
                fieldEdit.Modified = false;
                return true;
            }
            else return false;

        }

        /// <summary>
        /// Сохранение документа
        /// </summary>
        /// <returns></returns>
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

        public void Exit(ref bool exit)
        {
            if (fieldEdit.Modified == true)
            {
                ShowSaving(ref exit);
            }
        }


        public void ShowSavig()
        {
            DialogResult result = MessageBox.Show("Вы хотите сохранить изменения в файле?", "Блокнот", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (ASaveNoteBook() == false) return;
            }
            if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        public void ShowSaving(ref bool exit)
        {
            DialogResult result = MessageBox.Show("Вы хотите сохранить изменения в файле?", "Блокнот", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (ASaveNoteBook() == false) exit = false;
            }
            if (result == DialogResult.Cancel)
            {
                exit = true; ;
            }
        }

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="formText"></param>
        public void Save(ref string formText)
        {

            if (ASaveNoteBook() == true)
            {
                formText = nameFile + " - " + "Блокнот";
            }
        }

        /// <summary>
        /// Сохранить как 
        /// </summary>
        /// <param name="formText"></param>
        public void SaveAs(ref string formText)
        {
            nameFile = "";
            if (ASaveNoteBook() == true)
            {
                formText = nameFile + " - " + "Блокнот";
            }
        }

        public void Permutation()
        {
            if(Rows.resolution == true)
            {
                try
                {
                    string[] array = fieldEdit.Lines;
                    box = array[Rows.firstRow - 1];
                    array[Rows.firstRow - 1] = array[Rows.secondRow - 1];
                    array[Rows.secondRow - 1] = box;
                    fieldEdit.Lines = array;
                    fieldEdit.Modified = true;

                }
                catch
                {
                    MessageBox.Show("Строки не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

    public class Rows
    {
        public static int firstRow;
        public static int secondRow;
        public static bool resolution;

    }
}
