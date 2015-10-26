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
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.toXmlButton = new System.Windows.Forms.Button();
            InstructionLabel = new System.Windows.Forms.Label();
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
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(15, 25);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(227, 20);
            this.PathTextBox.TabIndex = 1;
            this.PathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathTextBox_KeyDown);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(249, 21);
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
            this.StatusLabel.Size = new System.Drawing.Size(19, 13);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "<>";
            this.StatusLabel.Visible = false;
            // 
            // toXmlButton
            // 
            this.toXmlButton.Location = new System.Drawing.Point(249, 50);
            this.toXmlButton.Name = "toXmlButton";
            this.toXmlButton.Size = new System.Drawing.Size(75, 23);
            this.toXmlButton.TabIndex = 4;
            this.toXmlButton.Text = "toXML";
            this.toXmlButton.UseVisualStyleBackColor = true;
            this.toXmlButton.Visible = false;
            this.toXmlButton.Click += new System.EventHandler(this.toXmlButton_Click);
            // 
            // NewsParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 82);
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
    }
}

