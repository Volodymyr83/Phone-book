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
   
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        Password PasswordForm = new Password();       //Вікно для введення паролю.

        public static List<Contact> contactList = new List<Contact>();  // Колекція об'єктів класа Contact, в якій містятся всі дані контактів.

        public static List<int> contactListShown = new List<int>();   // Колекція в якій містятьтя порядкові номери елементів колекції
                                                                      //contactList, які в даний момент повинні відображатися в елементі listBox1.
        public static List<string> groupList = new List<string>();    // Колекція в якій містяться групи контактів.

        public static List<int> addList = new List<int>();     // В цю колекцію поміщаються записи, які потрібно додати до списка у listBox1
                                                               //коли у формі AddContact додаються нові контакти.
        string fileRef = "telephone.csv";           // Шлях до файла з даними.
        public static string dirPhoto = "Photos";   // Папка для зберігання фотографій.
        public static int currentItem;              // Індекс поточного елемента вибранного в listBox1. 
      
       
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowWithPassword();
        }

        private void Form1_Activated(object sender, EventArgs e)    
        {
            comboBoxGroup.Items.Clear();                                    //Відображення актуальних груп контактів
            comboBoxGroup.Items.Add("Всі групи");
            comboBoxGroup.Text = Convert.ToString(comboBoxGroup.Items[0]);
            groupList.Sort();
            comboBoxGroup.Items.AddRange(groupList.ToArray());
           
            buttonAddContact.Enabled = addEnabled;                 
            for(int i = 0; i < addList.Count;)
            {
                listBox1.Items.Add(AddContactToList(addList[i]));  // Відображення у listBox1 контактів доданих у формі AddContact.
                addList.RemoveAt(i);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }

        private void ShowWithPassword()  // Визиває вікно для введенняя паролю і в залежності від результату допускає, чи не допускає
        {                                //до роботи в програмі.
            PasswordForm.ShowDialog();
            if (PasswordForm.DialogResult == DialogResult.OK)
            {
                panel1.Enabled = true;
                listBox1.Show();
                enterMenu.Enabled = false;
                fileMenu.Enabled = true;

                if (!File.Exists(@fileRef))
                    using (File.CreateText(@fileRef)) { } //Створення файла для збереження даних якщо такий не існує.
                if (!Directory.Exists(dirPhoto))
                    Directory.CreateDirectory(dirPhoto); //Створення папки для збереження фото якщо така не існує.

                string[] record;              

                var lines = File.ReadAllLines(@fileRef); // Зчитування даних із фала.
                foreach (var l in lines)
                {
                    Contact contact1 = new Contact();
                    record = l.Split(';');

                    contact1.name = ChangeLetter(record[0], false);
                    contact1.number = record[1];
                    contact1.group = ChangeLetter(record[2], false);
                    contact1.comment = ChangeLetter(record[3], false);
                    contact1.photoRef = ChangeLetter(record[4], false);
                    contact1.index = Convert.ToInt32(record[5]);

                    if(groupList.Contains(contact1.group) == false) //Створення списка існуючих груп.
                        groupList.Add(contact1.group);
                    
                    contactList.Add(contact1);
                }
               
                ShowAllList();
            }
            else
            {
                fileMenu.Enabled = false;
                panel1.Enabled = false;
                listBox1.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Збереження диних у CSV файлі.
        {
            if (panel1.Enabled)
            {
                string line;
                List<string> record = new List<string>();  // Колекція для запису даних у CSV файл.
                foreach (var cont in contactList)
                {
                    line = String.Format("{0};{1};{2};{3};{4};{5}",
                        ChangeLetter(cont.name, true),
                        cont.number,
                        ChangeLetter(cont.group, true),
                        ChangeLetter(cont.comment, true),
                        ChangeLetter(cont.photoRef, true),
                        cont.index);

                    record.Add(line);
                }
                File.WriteAllLines(@fileRef, record);
            }          
        }

        public void ShowAllList()  // Виділено частину коду в окремий метод, щоб не повторювати його декілька разів.
                                    // Визивається для відображення всіх існуючих контактів.
        {
            contactListShown.Clear();
            for (int i = 0; i < contactList.Count; i++)
            {
                contactListShown.Add(i);
            }
            ShowItems();
        }        

        private string ChangeLetter(string str1, bool direction) // Парсінг текстових даних при зчитуванні і записі у CSV файл.
        {

            char[] str2 = str1.ToCharArray();
            string str3 = String.Empty;

            if (direction == true)
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    if (str2[i] == ';')
                        str2[i] = '~';
                    str3 += str2[i];
                }
            }
            else
                for (int i = 0; i < str2.Length; i++)
                {
                    if (str2[i] == '~')
                        str2[i] = ';';
                    str3 += str2[i];
                }
            return str3;
        }

        

        public void ShowItems()  // Виводить в listBox1 всі записи колекції contactList, індекси яких містяться в 
                                  //колекції contactListShown і при цьому форматує їх у рівні колонки.
        {          
            listBox1.Items.Clear();
                     
            foreach(int index in contactListShown)
            {
                listBox1.Items.Add(AddContactToList(index));    
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;
            textBoxComment.Clear();
            pictureBox1.Image = null;
        }

        public static string AddContactToList(int ind)
        {
            string nameStr = Form1.contactList[ind].name;
            if (nameStr.Length < 20)
            {
                for (int i = 0; i < 20 - nameStr.Length; i++)
                {
                    nameStr += " ";
                }
            }
            else if (nameStr.Length > 20)
            {
                nameStr = nameStr.Remove(21);
            }
            string str = string.Format("{0,-21}|{1,-16}|{2,-12}", nameStr, Form1.contactList[ind].group, Form1.contactList[ind].number);
            return str;
        }
        
        private void button2_Click(object sender, EventArgs e) //Пошук Контакта.
        {            
            string nameToSearch = textBox3.Text.Trim();
            if(nameToSearch != string.Empty)
            {
                if (radioButton1.Checked)                         // Пошук за им'ям.
                {
                    contactListShown.Clear();
                    for (int i = 0; i < contactList.Count; i++)
                    {
                        SeekContact(i, contactList[i].name, nameToSearch);
                    }
                    ShowItems();
                    textBox3.Focus();
                }
                else if (radioButton2.Checked && IsNumber(nameToSearch)) // Пошук за номером.
                {
                    contactListShown.Clear();
                    for (int i = 0; i < contactList.Count; i++)
                    {
                        SeekContact(i, contactList[i].number, nameToSearch);
                    }
                    ShowItems();
                    textBox3.Focus();
                }
                else if(radioButton3.Checked)                      // Пошук у коментарі.
                {
                    contactListShown.Clear();
                    for (int i = 0; i < contactList.Count; i++)
                    {
                        if(contactList[i].comment != string.Empty)
                            SeekContact(i, contactList[i].comment, nameToSearch);
                    }
                    ShowItems();
                    textBox3.Focus();
                }
            }
            else        // Якщо у текстове поле не введено виразу, то будуть відображені всі контакти вказаної групи.
            {
                if (comboBoxGroup.Text == Convert.ToString(comboBoxGroup.Items[0]))
                    ShowAllList();
                else
                {
                    contactListShown.Clear();
                    for (int i = 0; i < contactList.Count; i++)
                    {
                        if (contactList[i].group == comboBoxGroup.Text)
                        {
                            contactListShown.Add(i);
                        }
                    }
                    ShowItems();
                    textBox3.Focus();
                }               
            }
            listBox1.TopIndex = 0;
        }

        private void SeekContact(int i, string text1, string text2)  // Пошук контакта за за вибраною групою.
        {
            if (CheckText(text1, text2))
            {
                if ((comboBoxGroup.Text == Convert.ToString(comboBoxGroup.Items[0])) ||
                    (comboBoxGroup.Text == contactList[i].group))
                {
                    contactListShown.Add(i);
                }    
            }
        }

        private bool CheckText(string name, string textToCheck)
        {
                if (name.ToLower().Contains(textToCheck.ToLower()) || // Будуть відображені як ті контакти, які містять введенний вираз, так і ті які містяться
                    textToCheck.ToLower().Contains(name.ToLower()))   //у введенному виразі якщо він містить більше символів ніж поле контакта. Регістр введення
                {                                                     //символів не має значення.
                return true;
                }
            return false;
        }

        private bool IsNumber(string number) // Повертає true якщо для введення використовувались лише цифри.
        {
            foreach (char charNumber in number)
            {
                if (!Char.IsDigit(charNumber))
                {
                    MessageBox.Show("Для введення номера телефону використовуйте тілки цифри.", "Невірно введений номер",
                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox3.Focus();
                    return false;
                }
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)  // Перехід до редагування контакта.
        {
            if(listBox1.SelectedIndex >= 0)
            {               
                currentItem = listBox1.SelectedIndex;

                FormEdit formEdit = new FormEdit();
                formEdit.ShowDialog();

                listBox1.Items[currentItem] = AddContactToList(contactListShown[currentItem]);
                listBox1.SelectedIndex = currentItem;                
            }
            else if(listBox1.Items.Count != 0)
            {
                MessageBox.Show("Виберіть контакт який потрібно редагувати.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                listBox1.Focus();
            }
            else
            {
                MessageBox.Show("Список порожній. Немає жодного контакта!",
                  "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        


        private void button5_Click(object sender, EventArgs e) //Видалення контакта.
        {           
            if(listBox1.SelectedIndex >= 0)
            {
                int index2 = listBox1.SelectedIndex;
                int indexSel = contactListShown[index2];
                string mess = String.Format("Ви дійсно бажаєте видалити контакт?\nІм'я: {0}\nГрупа: {1}\nНомер телефона: {2}.",
                    contactList[indexSel].name,
                    contactList[indexSel].group,
                    contactList[indexSel].number);
                DialogResult result = MessageBox.Show(mess, "Видалення контакта",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              
                if(result == DialogResult.Yes)
                {
                    string delFile = contactList[indexSel].photoRef;
                    if (delFile != string.Empty)
                    {                            
                        File.Delete(delFile);                       
                    }
                    contactList.RemoveAt(indexSel);                     
                    contactListShown.RemoveAt(index2);
                    listBox1.Items.RemoveAt(index2);

                    for (int x = index2; x < contactListShown.Count; x++)
                    {
                        contactListShown[x] -= 1;
                    }
                    if (contactListShown.Count() > index2)
                    {
                        listBox1.SelectedIndex = index2;
                    }
                    else
                    {
                        listBox1.SelectedIndex = index2 - 1;
                    }
                }
            }
            else if(listBox1.Items.Count != 0)
            {
                MessageBox.Show("Виберіть контакт який потрібно видалити.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                listBox1.Focus();
            }
            else
            {
                MessageBox.Show("Список порожній. Немає жодного контакта!",
                   "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }          
        }       

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                button2_Click(sender, e);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                button4_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowWithPassword();
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
        public static bool addEnabled = true;

        private void buttonAddContact_Click(object sender, EventArgs e) // Активація форми для додавання нового контакта.
        {
            addEnabled = false;
            buttonAddContact.Enabled = addEnabled;
            AddContact AddContact = new AddContact();
            AddContact.Show();
        }        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // У відповідних елементах форми відображаються дані
        {                                                                      //поточного контакта вибраного у ListBox1.
            if(listBox1.SelectedIndex >= 0)
            {                
                int index = contactListShown[listBox1.SelectedIndex];
                if (contactList[index].photoRef != string.Empty)
                {
                    Image img = null;
                    using (FileStream fs = new FileStream(contactList[index].photoRef, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        img = Image.FromStream(fs);
                    }
                    pictureBox1.Image = img;
                }
                else
                {
                    pictureBox1.Image = null;
                }
                textBoxComment.Text = contactList[index].comment;
            }
            else
            {
                pictureBox1.Image = null;
                textBoxComment.Text = null;
            }            
        }
               
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void exportMenuItem_Click(object sender, EventArgs e) // Експорт контактів, які містяться у актуальному списку ListBox1.
        {
            if(contactListShown.Count != 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Експорт контактів";
                saveFile.Filter = "CSV файлы (*.csv)|*.csv";
                saveFile.ShowDialog();

                string file = saveFile.FileName;
                if (file != string.Empty)
                {
                    string dir = Path.GetDirectoryName(file);
                    string folder = dir + "\\" + Path.GetFileNameWithoutExtension(file) + "_Photos";
                    
                    if (!File.Exists(file))
                    {
                        File.Delete(file);
                    }
                    if (Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true);
                    }
                    Directory.CreateDirectory(folder);

                    List<string> export = new List<string>();
                    string line;                    
                    int x = 0;
                    foreach (int index in contactListShown)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file) + "_Photos\\image" + x;
                        line = String.Format("{0};{1};{2};{3};{4};{5}",
                           ChangeLetter(contactList[index].name, true),
                           contactList[index].number,
                           ChangeLetter(contactList[index].group, true),
                           ChangeLetter(contactList[index].comment, true),
                           ChangeLetter(fileName, true),
                           x);
                        if (contactList[index].photoRef != string.Empty)
                        {
                            File.Copy(contactList[index].photoRef, folder + "\\image" + x);
                        }
                        export.Add(line);
                        x++;
                    }
                    File.WriteAllLines(@file, export);
                    MessageBox.Show("Експорт відображених контактів успішно завершено", "Експорт контактів",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Список контактів порожній", "Експорт неможливий",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }

        private void importMenuItem_Click(object sender, EventArgs e) //Імпорт контактів.
        {
            OpenFileDialog openFile = new OpenFileDialog();            
            openFile.Title = "Імпорт контактів";
            openFile.Filter = "CSV файлы (*.csv)|*.csv";
            openFile.ShowDialog();
            string file = openFile.FileName;
            if ((file != string.Empty) && File.Exists(file))
            {
                var lines = File.ReadAllLines(file);
                if(lines.Length != 0)
                {
                    int x;
                    if (contactList.Count == 0)
                        x = -1;
                    else
                        x = contactList[contactList.Count - 1].index;

                    string[] record;
                    foreach(string line in lines)
                    {
                        Contact contact = new Contact();
                        x++;
                        record = line.Split(';');
                        string imageFile = ChangeLetter(record[4], false);
                        try
                        {                            
                            File.Copy(Path.GetDirectoryName(file) + "\\" + imageFile, dirPhoto + "\\image" + x);
                            imageFile = dirPhoto + "\\image" + x;
                        }
                        catch
                        {
                            imageFile = string.Empty;
                        }
                        contact.name = ChangeLetter(record[0], false);
                        contact.number = record[1];
                        contact.group = ChangeLetter(record[2], false);
                        contact.comment = ChangeLetter(record[3], false);
                        contact.photoRef = imageFile;
                        contact.index = x;

                        if (groupList.Contains(contact.group) == false)
                            groupList.Add(contact.group);

                        contactList.Add(contact);
                        contactListShown.Add(contactList.Count - 1);
                        listBox1.Items.Add(AddContactToList(contactListShown[contactListShown.Count - 1]));
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                    MessageBox.Show("Імпорт контактів успішно завершено", "Імпорт контактів",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}