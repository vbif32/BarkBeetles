using System;
using System.Windows.Forms;
using HtmlParser.Parsers;
using System.Text.RegularExpressions;

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
                if (looksLikeTruth(PathTextBox.Text))
                {
                    if (isLinkOk(PathTextBox.Text))
                    {
                        StatusLabel.Text = "Известный источник";
                        ParserManager.JustDoIt(PathTextBox.Text);
                        toXmlButton.Visible = true;
                    }
                    else
                    {
                        StatusLabel.Text = "Ссылка неправильная";
                    }
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
                if (isLinkOk(openFileDialog.FileName))
                {
                    StatusLabel.Text = "Известный источник";
                    ParserManager.JustDoIt(PathTextBox.Text);
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

        private bool looksLikeTruth(string link)
        {
            if (Regex.IsMatch(link, @"^http\w?://") || Regex.IsMatch(link, @"^\w:\\"))
                return true;
            return false;
        }

        private bool isLinkOk(string link)
        {
            if (Regex.IsMatch(link, @"^http\w?://"))
                return ParserManager.IsSiteKnown(link);
            else if (Regex.IsMatch(link, @"^\w:\\"))
                return ParserManager.IsFileSourceKnown(link);
            return false;
        }
    }
}
