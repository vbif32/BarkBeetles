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
            this.DropCollectionButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ParserTabPage = new System.Windows.Forms.TabPage();
            this.DatabaseSearchTabPage = new System.Windows.Forms.TabPage();
            this.DeleteFoundButton = new System.Windows.Forms.Button();
            InstructionLabel = new System.Windows.Forms.Label();
            SearchInstructionLabel = new System.Windows.Forms.Label();
            LookForLabel = new System.Windows.Forms.Label();
            FoundLabel = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.ParserTabPage.SuspendLayout();
            this.DatabaseSearchTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            InstructionLabel.AutoSize = true;
            InstructionLabel.CausesValidation = false;
            InstructionLabel.Location = new System.Drawing.Point(6, 3);
            InstructionLabel.Name = "InstructionLabel";
            InstructionLabel.Size = new System.Drawing.Size(230, 13);
            InstructionLabel.TabIndex = 0;
            InstructionLabel.Text = "Введите адрес статьи или путь к html файлу";
            // 
            // SearchInstructionLabel
            // 
            SearchInstructionLabel.AutoSize = true;
            SearchInstructionLabel.CausesValidation = false;
            SearchInstructionLabel.Location = new System.Drawing.Point(6, 3);
            SearchInstructionLabel.Name = "SearchInstructionLabel";
            SearchInstructionLabel.Size = new System.Drawing.Size(290, 13);
            SearchInstructionLabel.TabIndex = 7;
            SearchInstructionLabel.Text = "Введите искомое значение и выберите область поиска";
            // 
            // LookForLabel
            // 
            LookForLabel.AutoSize = true;
            LookForLabel.Location = new System.Drawing.Point(3, 42);
            LookForLabel.Name = "LookForLabel";
            LookForLabel.Size = new System.Drawing.Size(44, 13);
            LookForLabel.TabIndex = 12;
            LookForLabel.Text = "Искать";
            // 
            // FoundLabel
            // 
            FoundLabel.AutoSize = true;
            FoundLabel.Location = new System.Drawing.Point(92, 42);
            FoundLabel.Name = "FoundLabel";
            FoundLabel.Size = new System.Drawing.Size(51, 13);
            FoundLabel.TabIndex = 13;
            FoundLabel.Text = "Найдено";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(9, 19);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(325, 20);
            this.PathTextBox.TabIndex = 1;
            this.PathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathTextBox_KeyDown);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(341, 17);
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
            this.StatusLabel.Location = new System.Drawing.Point(9, 177);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 3;
            // 
            // toXmlButton
            // 
            this.toXmlButton.Location = new System.Drawing.Point(281, 46);
            this.toXmlButton.Name = "toXmlButton";
            this.toXmlButton.Size = new System.Drawing.Size(135, 23);
            this.toXmlButton.TabIndex = 4;
            this.toXmlButton.Text = "Положить в XML";
            this.toXmlButton.UseVisualStyleBackColor = true;
            this.toXmlButton.Click += new System.EventHandler(this.ToXmlButton_Click);
            // 
            // ToDatabaseButton
            // 
            this.ToDatabaseButton.Location = new System.Drawing.Point(140, 46);
            this.ToDatabaseButton.Name = "ToDatabaseButton";
            this.ToDatabaseButton.Size = new System.Drawing.Size(135, 23);
            this.ToDatabaseButton.TabIndex = 6;
            this.ToDatabaseButton.Text = "Положить в MongoDB";
            this.ToDatabaseButton.UseVisualStyleBackColor = true;
            this.ToDatabaseButton.Click += new System.EventHandler(this.ToDatabaseButton_Click);
            // 
            // DBSearchButton
            // 
            this.DBSearchButton.Location = new System.Drawing.Point(341, 17);
            this.DBSearchButton.Name = "DBSearchButton";
            this.DBSearchButton.Size = new System.Drawing.Size(75, 23);
            this.DBSearchButton.TabIndex = 5;
            this.DBSearchButton.Text = "Поиск";
            this.DBSearchButton.UseVisualStyleBackColor = true;
            this.DBSearchButton.Click += new System.EventHandler(this.DBSearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(9, 19);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(325, 20);
            this.SearchTextBox.TabIndex = 8;
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            // 
            // TitleCheckBox
            // 
            this.TitleCheckBox.AutoSize = true;
            this.TitleCheckBox.Location = new System.Drawing.Point(6, 58);
            this.TitleCheckBox.Name = "TitleCheckBox";
            this.TitleCheckBox.Size = new System.Drawing.Size(80, 17);
            this.TitleCheckBox.TabIndex = 9;
            this.TitleCheckBox.Text = "Заголовок";
            this.TitleCheckBox.UseVisualStyleBackColor = true;
            // 
            // TextCheckBox
            // 
            this.TextCheckBox.AutoSize = true;
            this.TextCheckBox.Location = new System.Drawing.Point(6, 81);
            this.TextCheckBox.Name = "TextCheckBox";
            this.TextCheckBox.Size = new System.Drawing.Size(56, 17);
            this.TextCheckBox.TabIndex = 10;
            this.TextCheckBox.Text = "Текст";
            this.TextCheckBox.UseVisualStyleBackColor = true;
            // 
            // DateCheckBox
            // 
            this.DateCheckBox.AutoSize = true;
            this.DateCheckBox.Location = new System.Drawing.Point(6, 104);
            this.DateCheckBox.Name = "DateCheckBox";
            this.DateCheckBox.Size = new System.Drawing.Size(52, 17);
            this.DateCheckBox.TabIndex = 11;
            this.DateCheckBox.Text = "Дата";
            this.DateCheckBox.UseVisualStyleBackColor = true;
            // 
            // TitleResultsLabel
            // 
            this.TitleResultsLabel.AutoSize = true;
            this.TitleResultsLabel.Location = new System.Drawing.Point(92, 62);
            this.TitleResultsLabel.Name = "TitleResultsLabel";
            this.TitleResultsLabel.Size = new System.Drawing.Size(0, 13);
            this.TitleResultsLabel.TabIndex = 14;
            // 
            // TextResultsLabel
            // 
            this.TextResultsLabel.AutoSize = true;
            this.TextResultsLabel.Location = new System.Drawing.Point(92, 85);
            this.TextResultsLabel.Name = "TextResultsLabel";
            this.TextResultsLabel.Size = new System.Drawing.Size(0, 13);
            this.TextResultsLabel.TabIndex = 15;
            // 
            // DateResultsLabel
            // 
            this.DateResultsLabel.AutoSize = true;
            this.DateResultsLabel.Location = new System.Drawing.Point(92, 108);
            this.DateResultsLabel.Name = "DateResultsLabel";
            this.DateResultsLabel.Size = new System.Drawing.Size(0, 13);
            this.DateResultsLabel.TabIndex = 16;
            // 
            // DropCollectionButton
            // 
            this.DropCollectionButton.Location = new System.Drawing.Point(277, 100);
            this.DropCollectionButton.Name = "DropCollectionButton";
            this.DropCollectionButton.Size = new System.Drawing.Size(135, 23);
            this.DropCollectionButton.TabIndex = 18;
            this.DropCollectionButton.Text = "Сбросить коллекцию";
            this.DropCollectionButton.UseVisualStyleBackColor = true;
            this.DropCollectionButton.Click += new System.EventHandler(this.DropCollectionButton_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ParserTabPage);
            this.MainTabControl.Controls.Add(this.DatabaseSearchTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(430, 162);
            this.MainTabControl.TabIndex = 19;
            // 
            // ParserTabPage
            // 
            this.ParserTabPage.Controls.Add(InstructionLabel);
            this.ParserTabPage.Controls.Add(this.PathTextBox);
            this.ParserTabPage.Controls.Add(this.OpenFileButton);
            this.ParserTabPage.Controls.Add(this.toXmlButton);
            this.ParserTabPage.Controls.Add(this.ToDatabaseButton);
            this.ParserTabPage.Location = new System.Drawing.Point(4, 22);
            this.ParserTabPage.Name = "ParserTabPage";
            this.ParserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ParserTabPage.Size = new System.Drawing.Size(422, 136);
            this.ParserTabPage.TabIndex = 0;
            this.ParserTabPage.Text = "Парсер";
            this.ParserTabPage.UseVisualStyleBackColor = true;
            // 
            // DatabaseSearchTabPage
            // 
            this.DatabaseSearchTabPage.Controls.Add(this.DeleteFoundButton);
            this.DatabaseSearchTabPage.Controls.Add(SearchInstructionLabel);
            this.DatabaseSearchTabPage.Controls.Add(this.DropCollectionButton);
            this.DatabaseSearchTabPage.Controls.Add(this.DateResultsLabel);
            this.DatabaseSearchTabPage.Controls.Add(this.DBSearchButton);
            this.DatabaseSearchTabPage.Controls.Add(this.TextResultsLabel);
            this.DatabaseSearchTabPage.Controls.Add(this.SearchTextBox);
            this.DatabaseSearchTabPage.Controls.Add(this.TitleResultsLabel);
            this.DatabaseSearchTabPage.Controls.Add(this.TitleCheckBox);
            this.DatabaseSearchTabPage.Controls.Add(FoundLabel);
            this.DatabaseSearchTabPage.Controls.Add(this.TextCheckBox);
            this.DatabaseSearchTabPage.Controls.Add(LookForLabel);
            this.DatabaseSearchTabPage.Controls.Add(this.DateCheckBox);
            this.DatabaseSearchTabPage.Location = new System.Drawing.Point(4, 22);
            this.DatabaseSearchTabPage.Name = "DatabaseSearchTabPage";
            this.DatabaseSearchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DatabaseSearchTabPage.Size = new System.Drawing.Size(422, 136);
            this.DatabaseSearchTabPage.TabIndex = 1;
            this.DatabaseSearchTabPage.Text = "Поиск по БД";
            this.DatabaseSearchTabPage.UseVisualStyleBackColor = true;
            // 
            // DeleteFoundButton
            // 
            this.DeleteFoundButton.Location = new System.Drawing.Point(277, 71);
            this.DeleteFoundButton.Name = "DeleteFoundButton";
            this.DeleteFoundButton.Size = new System.Drawing.Size(134, 23);
            this.DeleteFoundButton.TabIndex = 19;
            this.DeleteFoundButton.Text = "Удалить найденные";
            this.DeleteFoundButton.UseVisualStyleBackColor = true;
            this.DeleteFoundButton.Click += new System.EventHandler(this.DeleteFoundButton_Click);
            // 
            // NewsParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 199);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.StatusLabel);
            this.Name = "NewsParserForm";
            this.Text = "NewsParser";
            this.MainTabControl.ResumeLayout(false);
            this.ParserTabPage.ResumeLayout(false);
            this.ParserTabPage.PerformLayout();
            this.DatabaseSearchTabPage.ResumeLayout(false);
            this.DatabaseSearchTabPage.PerformLayout();
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
        private System.Windows.Forms.Button DropCollectionButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ParserTabPage;
        private System.Windows.Forms.TabPage DatabaseSearchTabPage;
        private System.Windows.Forms.Button DeleteFoundButton;
    }
}

