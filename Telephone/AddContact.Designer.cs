namespace Telephone
{
    partial class AddContact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPicture = new System.Windows.Forms.Button();
            this.buttonDelPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ім\'я";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Номер";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(102, 16);
            this.textBoxName.MaxLength = 20;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(254, 29);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumber.Location = new System.Drawing.Point(102, 63);
            this.textBoxNumber.MaxLength = 12;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(254, 29);
            this.textBoxNumber.TabIndex = 2;
            this.textBoxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNumber_KeyDown);
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new System.Drawing.Point(21, 120);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComment.Size = new System.Drawing.Size(335, 198);
            this.textBoxComment.TabIndex = 4;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.Enabled = false;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(400, 120);
            this.pictureBoxPhoto.MaximumSize = new System.Drawing.Size(194, 182);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(194, 182);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 3;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(400, 39);
            this.comboBoxGroup.MaxLength = 15;
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(194, 32);
            this.comboBoxGroup.TabIndex = 3;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(21, 342);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(161, 36);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Додати контакт";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(203, 342);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(153, 36);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Відмінити";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(396, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Група";
            // 
            // buttonPicture
            // 
            this.buttonPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPicture.Location = new System.Drawing.Point(417, 318);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(159, 36);
            this.buttonPicture.TabIndex = 8;
            this.buttonPicture.Text = "Додати фото";
            this.buttonPicture.UseVisualStyleBackColor = true;
            this.buttonPicture.Click += new System.EventHandler(this.buttonPicture_Click);
            // 
            // buttonDelPhoto
            // 
            this.buttonDelPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelPhoto.Location = new System.Drawing.Point(417, 367);
            this.buttonDelPhoto.Name = "buttonDelPhoto";
            this.buttonDelPhoto.Size = new System.Drawing.Size(159, 36);
            this.buttonDelPhoto.TabIndex = 21;
            this.buttonDelPhoto.Text = "Видалити фото";
            this.buttonDelPhoto.UseVisualStyleBackColor = true;
            this.buttonDelPhoto.Click += new System.EventHandler(this.buttonDelPhoto_Click);
            // 
            // AddContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(615, 418);
            this.Controls.Add(this.buttonDelPhoto);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddContact";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Додавання нового контакта";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddContact_FormClosed);
            this.Load += new System.EventHandler(this.AddContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPicture;
        private System.Windows.Forms.Button buttonDelPhoto;
    }
}