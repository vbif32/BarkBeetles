using System;

namespace HtmlParser
{
    partial class NewsParserForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label InstructionLabel;
            System.Windows.Forms.Label SearchInstructionLabel;
            System.Windows.Forms.Label LookForLabel;
            System.Windows.Forms.Label FoundLabel;
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.toXmlButton = new System.Windows.Forms.Button();
            this.ToDatabaseButton = new System.Windows.Forms.Button();
            this.DBSearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.TitleCheckBox = new System.Windows.Forms.CheckBox();
            this.TextCheckBox = new System.Windows.Forms.CheckBox();
            this.DateCheckBox = new System.Windows.Forms.CheckBox();
            this.TitleResultsLabel = new System.Windows.Forms.Label();
            this.TextResultsLabel = new System.Windows.Forms.Label();
            this.DateResultsLabel = new System.Windows.Forms.Label();
            InstructionLabel = new System.Windows.Forms.Label();
            SearchInstructionLabel = new System.Windows.Forms.Label();
            LookForLabel = new System.Windows.Forms.Label();
            FoundLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            InstructionLabel.AutoSize = true;
            InstructionLabel.CausesValidation = false;
            InstructionLabel.Location = new System.Drawing.Point(12, 9);
            InstructionLabel.Name = "InstructionLabel";
            InstructionLabel.Size = new System.Drawing.Size(230, 13);
            InstructionLabel.TabIndex = 0;
            InstructionLabel.Text = "Введите адрес статьи или путь к html файлу";
            // 
            // SearchInstructionLabel
            // 
            SearchInstructionLabel.AutoSize = true;
            SearchInstructionLabel.CausesValidation = false;
            SearchInstructionLabel.Location = new System.Drawing.Point(15, 84);
            SearchInstructionLabel.Name = "SearchInstructionLabel";
            SearchInstructionLabel.Size = new System.Drawing.Size(290, 13);
            SearchInstructionLabel.TabIndex = 7;
            SearchInstructionLabel.Text = "Введите искомое значение и выберите область поиска";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(15, 25);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(325, 20);
            this.PathTextBox.TabIndex = 1;
            this.PathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathTextBox_KeyDown);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(347, 23);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = "Открыть...";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(15, 52);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 3;
            // 
            // toXmlButton
            // 
            this.toXmlButton.Location = new System.Drawing.Point(347, 52);
            this.toXmlButton.Name = "toXmlButton";
            this.toXmlButton.Size = new System.Drawing.Size(75, 23);
            this.toXmlButton.TabIndex = 4;
            this.toXmlButton.Text = "to XML";
            this.toXmlButton.UseVisualStyleBackColor = true;
            this.toXmlButton.Visible = false;
            this.toXmlButton.Click += new System.EventHandler(this.ToXmlButton_Click);
            // 
            // ToDatabaseButton
            // 
            this.ToDatabaseButton.Location = new System.Drawing.Point(265, 51);
            this.ToDatabaseButton.Name = "ToDatabaseButton";
            this.ToDatabaseButton.Size = new System.Drawing.Size(75, 23);
            this.ToDatabaseButton.TabIndex = 6;
            this.ToDatabaseButton.Text = "to Database";
            this.ToDatabaseButton.UseVisualStyleBackColor = true;
            this.ToDatabaseButton.Visible = false;
            this.ToDatabaseButton.Click += new System.EventHandler(this.ToDatabaseButton_Click);
            // 
            // DBSearchButton
            // 
            this.DBSearchButton.Location = new System.Drawing.Point(346, 97);
            this.DBSearchButton.Name = "DBSearchButton";
            this.DBSearchButton.Size = new System.Drawing.Size(75, 23);
            this.DBSearchButton.TabIndex = 5;
            this.DBSearchButton.Text = "Поиск";
            this.DBSearchButton.UseVisualStyleBackColor = true;
            this.DBSearchButton.Click += new System.EventHandler(this.DBSearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(15, 100);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(325, 20);
            this.SearchTextBox.TabIndex = 8;
            // 
            // TitleCheckBox
            // 
            this.TitleCheckBox.AutoSize = true;
            this.TitleCheckBox.Location = new System.Drawing.Point(15, 139);
            this.TitleCheckBox.Name = "TitleCheckBox";
            this.TitleCheckBox.Size = new System.Drawing.Size(80, 17);
            this.TitleCheckBox.TabIndex = 9;
            this.TitleCheckBox.Text = "Заголовок";
            this.TitleCheckBox.UseVisualStyleBackColor = true;
            // 
            // TextCheckBox
            // 
            this.TextCheckBox.AutoSize = true;
            this.TextCheckBox.Location = new System.Drawing.Point(15, 162);
            this.TextCheckBox.Name = "TextCheckBox";
            this.TextCheckBox.Size = new System.Drawing.Size(56, 17);
            this.TextCheckBox.TabIndex = 10;
            this.TextCheckBox.Text = "Текст";
            this.TextCheckBox.UseVisualStyleBackColor = true;
            // 
            // DateCheckBox
            // 
            this.DateCheckBox.AutoSize = true;
            this.DateCheckBox.Location = new System.Drawing.Point(15, 185);
            this.DateCheckBox.Name = "DateCheckBox";
            this.DateCheckBox.Size = new System.Drawing.Size(52, 17);
            this.DateCheckBox.TabIndex = 11;
            this.DateCheckBox.Text = "Дата";
            this.DateCheckBox.UseVisualStyleBackColor = true;
            // 
            // LookForLabel
            // 
            LookForLabel.AutoSize = true;
            LookForLabel.Location = new System.Drawing.Point(12, 123);
            LookForLabel.Name = "LookForLabel";
            LookForLabel.Size = new System.Drawing.Size(44, 13);
            LookForLabel.TabIndex = 12;
            LookForLabel.Text = "Искать";
            // 
            // FoundLabel
            // 
            FoundLabel.AutoSize = true;
            FoundLabel.Location = new System.Drawing.Point(101, 123);
            FoundLabel.Name = "FoundLabel";
            FoundLabel.Size = new System.Drawing.Size(51, 13);
            FoundLabel.TabIndex = 13;
            FoundLabel.Text = "Найдено";
            // 
            // TitleResultsLabel
            // 
            this.TitleResultsLabel.AutoSize = true;
            this.TitleResultsLabel.Location = new System.Drawing.Point(101, 143);
            this.TitleResultsLabel.Name = "TitleResultsLabel";
            this.TitleResultsLabel.Size = new System.Drawing.Size(0, 13);
            this.TitleResultsLabel.TabIndex = 14;
            // 
            // TextResultsLabel
            // 
            this.TextResultsLabel.AutoSize = true;
            this.TextResultsLabel.Location = new System.Drawing.Point(101, 166);
            this.TextResultsLabel.Name = "TextResultsLabel";
            this.TextResultsLabel.Size = new System.Drawing.Size(0, 13);
            this.TextResultsLabel.TabIndex = 15;
            // 
            // DateResultsLabel
            // 
            this.DateResultsLabel.AutoSize = true;
            this.DateResultsLabel.Location = new System.Drawing.Point(101, 189);
            this.DateResultsLabel.Name = "DateResultsLabel";
            this.DateResultsLabel.Size = new System.Drawing.Size(0, 13);
            this.DateResultsLabel.TabIndex = 16;
            // 
            // NewsParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 221);
            this.Controls.Add(this.DateResultsLabel);
            this.Controls.Add(this.TextResultsLabel);
            this.Controls.Add(this.TitleResultsLabel);
            this.Controls.Add(FoundLabel);
            this.Controls.Add(LookForLabel);
            this.Controls.Add(this.DateCheckBox);
            this.Controls.Add(this.TextCheckBox);
            this.Controls.Add(this.TitleCheckBox);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(SearchInstructionLabel);
            this.Controls.Add(this.ToDatabaseButton);
            this.Controls.Add(this.DBSearchButton);
            this.Controls.Add(this.toXmlButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(InstructionLabel);
            this.Name = "NewsParserForm";
            this.Text = "NewsParser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button toXmlButton;
        private System.Windows.Forms.Button DBSearchButton;
        private System.Windows.Forms.Button ToDatabaseButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.CheckBox TitleCheckBox;
        private System.Windows.Forms.CheckBox TextCheckBox;
        private System.Windows.Forms.CheckBox DateCheckBox;
        private System.Windows.Forms.Label TitleResultsLabel;
        private System.Windows.Forms.Label TextResultsLabel;
        private System.Windows.Forms.Label DateResultsLabel;
    }
}

