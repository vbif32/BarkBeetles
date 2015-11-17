using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HtmlParser
{
    public partial class NewsParserForm : Form
    {
        private static string _netPathPattern = @"^http\w?://";
        private static string _localPathPattern = @"^\w:\\";



        public NewsParserForm()
        {
            InitializeComponent();
        }

        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (LooksLikeTruth(PathTextBox.Text))
                {
                    StatusLabel.Text = Program.parserManager.TryParse(PathTextBox.Text);
                    toXmlButton.Visible = true;
                    DBSearchButton.Visible = true;
                }
                else
                {
                    StatusLabel.Text = "Ссылка неправильная";
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StatusLabel.Text = Program.parserManager.TryParse(openFileDialog.FileName);
                toXmlButton.Visible = true;
                DBSearchButton.Visible = true;
            }
            else
                StatusLabel.Text = "Ошибка при открытии файла";
        }

        private void ToXmlButton_Click(object sender, EventArgs e)
        {
            if (Program.parserManager.ArticleList.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "report.xml";
                saveFileDialog.Filter = "XML-данные|*.xml";
                saveFileDialog.Title = "Сохранение файла";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Program.parserManager.ToXml(saveFileDialog.OpenFile());
                    StatusLabel.Text = "XML-файл готов";
                }
            }
            else
            {
                StatusLabel.Text = "Нечего конвертировать";
                toXmlButton.Visible = false;
                DBSearchButton.Visible = false;
            }
        }

        private void toDatabaseButton_Click(object sender, EventArgs e)
        {
            if (Program.parserManager.ArticleList.Count > 0)
            {
                try
                {

                    Program.parserManager.ToDatabase();
                    StatusLabel.Text = "Статьи помещены в базу в количестве " + Program.parserManager.ArticleList.Count;
                }
                catch
                {
                    StatusLabel.Text = "Ошибка соединения с БД";
                }
            }
            else
            {
                StatusLabel.Text = "Нечего конвертировать";
                toXmlButton.Visible = false;
                DBSearchButton.Visible = false;
            }
        }

        private void DBSearchButton_Click(object sender, EventArgs e)
        {

        }

        private bool LooksLikeTruth(string link)
        {
            if (Regex.IsMatch(link, _netPathPattern) || Regex.IsMatch(link, _localPathPattern))
                return true;
            return false;
        }

    }
}
