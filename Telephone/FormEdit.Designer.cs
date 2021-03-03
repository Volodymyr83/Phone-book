namespace Telephone
{
    partial class FormEdit
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
            this.buttonPicture = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.buttonDelPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPicture
            // 
            this.buttonPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPicture.Location = new System.Drawing.Point(411, 314);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(159, 36);
            this.buttonPicture.TabIndex = 19;
            this.buttonPicture.Text = "Додати фото";
            this.buttonPicture.UseVisualStyleBackColor = true;
            this.buttonPicture.Click += new System.EventHandler(this.buttonPicture_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(397, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Група";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(204, 339);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(153, 36);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Скасувати";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(22, 339);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(161, 36);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Зберегти зміни";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(401, 36);
            this.comboBoxGroup.MaxLength = 15;
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(194, 32);
            this.comboBoxGroup.TabIndex = 13;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new System.Drawing.Point(22, 117);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComment.Size = new System.Drawing.Size(335, 198);
            this.textBoxComment.TabIndex = 15;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumber.Location = new System.Drawing.Point(103, 60);
            this.textBoxNumber.MaxLength = 12;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(254, 29);
            this.textBoxNumber.TabIndex = 12;
            this.textBoxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNumber_KeyDown);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(103, 13);
            this.textBoxName.MaxLength = 20;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(254, 29);
            this.textBoxName.TabIndex = 11;
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Номер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ім\'я";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.Enabled = false;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(389, 117);
            this.pictureBoxPhoto.MaximumSize = new System.Drawing.Size(194, 182);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(194, 182);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 14;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // buttonDelPhoto
            // 
            this.buttonDelPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelPhoto.Location = new System.Drawing.Point(411, 366);
            this.buttonDelPhoto.Name = "buttonDelPhoto";
            this.buttonDelPhoto.Size = new System.Drawing.Size(159, 36);
            this.buttonDelPhoto.TabIndex = 20;
            this.buttonDelPhoto.Text = "Видалити фото";
            this.buttonDelPhoto.UseVisualStyleBackColor = true;
            this.buttonDelPhoto.Click += new System.EventHandler(this.buttonDelPhoto_Click);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(612, 420);
            this.Controls.Add(this.buttonDelPhoto);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагування контакта";
            this.Load += new System.EventHandler(this.FormEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPicture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelPhoto;
    }
}