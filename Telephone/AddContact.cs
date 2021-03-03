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
    public partial class AddContact : Form  // Вікно додавання нового контакта.
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void AddContact_Load(object sender, EventArgs e)
        {
            comboBoxGroup.Items.AddRange(Form1.groupList.ToArray());
            textBoxName.Focus();
            buttonDelPhoto.Enabled = false;
        }

        private void AddContact_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.addEnabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e) // Додавання нового контакта.
        {
            Contact newContact = new Contact();

            string name = textBoxName.Text.Trim();
            string numberStr = textBoxNumber.Text.Trim();
            string group = comboBoxGroup.Text.Trim();
            string comment = textBoxComment.Text;

            if (IsUniqueName(name) && IfTilda(name, "add") && IfTilda(comment, "comment")
                && IsNumber(numberStr) && CheckGroup(group))                                     // Перевірка введених даних.
            {
                newContact.index = Form1.contactList.Count;
                newContact.name = name;
                newContact.number = numberStr;
                newContact.group = group;
                newContact.comment = comment;
                if(pictureBoxPhoto.Image != null)
                {                   
                    string refer = Form1.dirPhoto + "\\image" + newContact.index;                   
                    newContact.photoRef = refer;                    
                    Bitmap bt = new Bitmap(pictureBoxPhoto.ClientSize.Width, pictureBoxPhoto.ClientSize.Height);
                    pictureBoxPhoto.DrawToBitmap(bt, pictureBoxPhoto.ClientRectangle);
                    bt.Save(refer, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                Form1.contactList.Add(newContact);
                Form1.contactListShown.Add(Form1.contactList.Count - 1);
                Form1.addList.Add(Form1.contactList.Count - 1);

                textBoxName.Clear();
                textBoxNumber.Clear();
                textBoxComment.Clear();
                comboBoxGroup.Text = String.Empty;
                pictureBoxPhoto.Image = null;
                buttonPicture.Text = "Додати контакт";                
                textBoxName.Focus();
                buttonDelPhoto.Enabled = false;
            }
        }

        private bool IsNumber(string number) // Повертає true якщо для введення використовувались лише цифри.
        {                                         
            if (number == string.Empty)
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
            if (name1 == string.Empty)
            {
                MessageBox.Show("Ім\"я повинно містити хочаб один символ.",
                                    "Невірно введене ім\"я", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGroup.Text = comboBoxGroup.SelectedItem.ToString(); 
        }       
        
        private void buttonPicture_Click(object sender, EventArgs e)    // Додати або змінити фото.
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != string.Empty)
            {
                Image image = null;
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open,
                        FileAccess.Read, FileShare.ReadWrite))
                    {
                        image = Image.FromStream(fs);
                    }
                    pictureBoxPhoto.Image = image;
                    buttonPicture.Text = "Змінити фото";
                    buttonDelPhoto.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Невірний формат файла", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelPhoto_Click(object sender, EventArgs e)   //Видалити фото з pictureBox.
        {            
            pictureBoxPhoto.Image = null;
            buttonPicture.Text = "Додати фото";
            buttonDelPhoto.Enabled = false;
            buttonPicture.Focus();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) buttonAdd.Focus();
            if (e.KeyData == Keys.Down) textBoxNumber.Focus();
        }

        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) textBoxName.Focus();
            if (e.KeyData == Keys.Down) textBoxComment.Focus();
        }
    }
}
