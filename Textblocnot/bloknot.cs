using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textblocnot
{
    class bloknot
    {
        string nameFile;
        RichTextBox fieldEdit;
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


    }
}
