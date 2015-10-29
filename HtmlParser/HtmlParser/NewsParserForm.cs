using System;
using System.Windows.Forms;
using HtmlParser.Parsers;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

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
                    UpdateStatusLabel = Program.parserManager.TryParse(PathTextBox.Text);
                    toXmlButton.Visible = true;
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
                UpdateStatusLabel = Program.parserManager.TryParse(openFileDialog.FileName);
                toXmlButton.Visible = true;
            }
            else
                StatusLabel.Text = "Ошибка при открытии файла";
        }

        private void ToXmlButton_Click(object sender, EventArgs e)
        {
            if(Program.articleList.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "report.xml";
                saveFileDialog.Filter = "XML-данные|*.xml";
                saveFileDialog.Title = "Сохранение файла";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    ParserManager.ToXml(saveFileDialog.OpenFile());
                    StatusLabel.Text = "XML-файл готов";
                }
            }
            else
            {
                StatusLabel.Text = "Нечего конвертировать";
                toXmlButton.Visible = false;
            }
        }

        private bool LooksLikeTruth(string link)
        {
            if (Regex.IsMatch(link, _netPathPattern) || Regex.IsMatch(link, _localPathPattern))
                return true;
            return false;
        }

        public string UpdateStatusLabel
        {
            set { StatusLabel.Text = value; }
        }

    }
}
