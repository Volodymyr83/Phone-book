using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Telephone
{
    public partial class FormEdit : Form       // Вікно редагування контакта.
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        Contact currentContact = new Contact();

        string fotoRef;             // Шлях до файла з фото.
        bool fotoChanged = false;   // Змінна показує чи змінювалось фото.
        Image image = null;

        private void FormEdit_Load(object sender, EventArgs e)
        {           
            currentContact = Form1.contactList[Form1.contactListShown[Form1.currentItem]];
            textBoxName.Text = currentContact.name;
            textBoxNumber.Text = currentContact.number;
            textBoxComment.Text = currentContact.comment;
            comboBoxGroup.Text = currentContact.group;
            comboBoxGroup.Items.AddRange(Form1.groupList.ToArray());
          
            fotoRef = currentContact.photoRef;
            if (fotoRef != string.Empty)        // Завантаження фото у pictureBox.
            {
                using(FileStream fs = new FileStream(fotoRef, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    image = Image.FromStream(fs);
                }
                pictureBoxPhoto.Image = image;
                buttonPicture.Text = "Змінити фото";
            }
            else
            {
                buttonDelPhoto.Enabled = false;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)    // Збереження відредагованого контакта.
        {           
            string name = textBoxName.Text.Trim();
            string numberStr = textBoxNumber.Text.Trim();
            string group = comboBoxGroup.Text.Trim();
            string comment = textBoxComment.Text;

            if (IsUniqueName(name) && IfTilda(name, "add") && IfTilda(comment, "comment")
                && IsNumber(numberStr) && CheckGroup(group))                                     // Перевірка введених даних.
            {                
                currentContact.name = name;
                currentContact.number = numberStr;
                currentContact.group = group;
                currentContact.comment = comment;
                currentContact.photoRef = fotoRef;
                if(fotoChanged)
                {
                    if (pictureBoxPhoto.Image != null)
                    {
                        if (fotoRef != string.Empty)
                        {
                            Bitmap bt = new Bitmap(pictureBoxPhoto.ClientSize.Width, pictureBoxPhoto.ClientSize.Height);
                            pictureBoxPhoto.DrawToBitmap(bt, pictureBoxPhoto.ClientRectangle);
                            bt.Save(fotoRef, System.Drawing.Imaging.ImageFormat.Jpeg);                          
                        }
                        else
                        {
                            string refer = Form1.dirPhoto + "\\image" + currentContact.index;
                            currentContact.photoRef = refer;                            
                            Bitmap bt = new Bitmap(pictureBoxPhoto.ClientSize.Width, pictureBoxPhoto.ClientSize.Height);
                            pictureBoxPhoto.DrawToBitmap(bt, pictureBoxPhoto.ClientRectangle);
                            bt.Save(refer, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        
                    }
                    else
                    {
                        if(fotoRef != string.Empty)
                        {
                            File.Delete(fotoRef);
                            currentContact.photoRef = string.Empty;
                        }                        
                    }
                } 
                Form1.contactList[Form1.contactListShown[Form1.currentItem]] = currentContact;
                DialogResult = DialogResult.OK;
            }
        }       

        private bool IsNumber(string number) // Повертає true якщо для введення використовувались лише цифри.
        {                                          
            if (number == "")
            {
                MessageBox.Show("Невведно жодної цифри", "Невірно введений номер",
                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxNumber.Focus();
                return false;
            }
            else
            {
                foreach (char charNumber in number)
                {
                    if (!Char.IsDigit(charNumber))
                    {
                        MessageBox.Show("Для введення номера телефону використовуйте тілки цифри.", "Невірно введений номер",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxNumber.Focus();
                        return false;
                    }
                }
                return true;
            }
        }

        private bool IsUniqueName(string name1) // Повертає true якщо кількість введених символів не менша 1.                                                         
        {
            if (name1 == "")
            {
                MessageBox.Show("Ім\"я повинно містити хочаб один символ.",
                                    "Невірно введене ім'я", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxName.Focus();
                return false;
            }
            return true;
        }

        private bool IfTilda(string name1, string b)    // Повертає true якщо для введення не використовувався символ '~'.
        {
            if (name1.Contains("~"))
            {
                MessageBox.Show("Не дозволяється використовувати для введення символ '~'",
                   "Недозволений символ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (b == "add") textBoxName.Focus();
                if (b == "comment") textBoxComment.Focus();
                return false;
            }
            return true;
        }

        private bool CheckGroup(string gr)   // Повертає true якщо введена група існувала або ж була створена.
        {
            if (!comboBoxGroup.Items.Contains(gr))
            {
                string message = string.Format("Бажаєте створити нову групу \"{0}\"?", gr);
                DialogResult result = MessageBox.Show(message, "Нова група", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    comboBoxGroup.Items.Add(gr);
                    Form1.groupList.Add(gr);
                    return true;
                }
                else
                {
                    comboBoxGroup.Focus();
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

       
        private void buttonPicture_Click(object sender, EventArgs e) // Змінити або додати фото.
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != string.Empty)
            {               
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open,
                        FileAccess.Read, FileShare.ReadWrite))
                    {
                        image = Image.FromStream(fs);
                    }
                    pictureBoxPhoto.Image = image;
                    buttonPicture.Text = "Змінити фото";
                    fotoChanged = true;
                    buttonDelPhoto.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Невірний формат файла", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) // Вихід з режиму редагування.
        {
            DialogResult = DialogResult.Cancel;
        }
              
        private void buttonDelPhoto_Click(object sender, EventArgs e) // Видалення фото з pictureBox.
        {
            pictureBoxPhoto.Image = null;
            buttonPicture.Text = "Додати фото";
            fotoChanged = true;
            buttonDelPhoto.Enabled = false;
            buttonPicture.Focus();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) buttonSave.Focus();
            if (e.KeyData == Keys.Down) textBoxNumber.Focus();
        }

        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) textBoxName.Focus();
            if (e.KeyData == Keys.Down) textBoxComment.Focus();
        }
    }
}
