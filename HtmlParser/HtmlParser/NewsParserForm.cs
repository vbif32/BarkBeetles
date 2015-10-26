using System;
using System.Windows.Forms;
using HtmlParser.Parsers;

namespace HtmlParser
{
    public partial class NewsParserForm : Form
    {
        public NewsParserForm()
        {
            InitializeComponent();
        }

        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (ParserManager.isLinkOk(PathTextBox.Text))
                {
                    ParserManager.ChooseOperation(PathTextBox.Text);
                    toXmlButton.Visible = true;
                }
                else
                {
                    PathTextBox.Text = "Ссылка неправильная";
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (ParserManager.ChooseOperation(openFileDialog.FileName))
                {
                    StatusLabel.Text = "Файл успешно загружен";
                    toXmlButton.Visible = true;
                }
                else
                { 
                    StatusLabel.Text = "Файл не удалось распознать";
                }  
            }
            else
                StatusLabel.Text = "Ошибка при открытии файла";
        }

        private void toXmlButton_Click(object sender, EventArgs e)
        {
            if(Program.articleList.Count > 0)
            {
                ParserManager.toXml();
            }
            else
            {
                StatusLabel.Text = "Нечего конвертировать";
            }
        }
    }
}
