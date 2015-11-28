using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MongoDB.Driver;

namespace HtmlParser
{
    public partial class NewsParserForm : Form
    {
        private static string _netPathPattern = @"^http\w?://";
        private static string _localPathPattern = @"^\w:\\";

        private MongoCursor _foundTitle;
        private MongoCursor _foundText;
        private MongoCursor _foundDate;


        public NewsParserForm()
        {
            InitializeComponent();
        }

        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                if (LooksLikeTruth(PathTextBox.Text))
                    TryParse(PathTextBox.Text);
                else
                    StatusLabel.Text = "Ссылка неправильная";
        }
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                TryParse (openFileDialog.FileName);
            else
                StatusLabel.Text = "Ошибка при открытии файла";
        }
        private void TryParse(string s)
        {
                StatusLabel.Text = Program.parserManager.TryParse(s);
        }

        private void ToXmlButton_Click(object sender, EventArgs e)
        {
            if (Program.parserManager.ArticleList?.Count > 0)
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
            }
        }
        private void ToDatabaseButton_Click(object sender, EventArgs e)
        {
            if (Program.parserManager.ArticleList?.Count > 0)
            {
                try
                {
                    StatusLabel.Text = "Статьи помещены в базу в количестве " 
                        + Program.mongoDbManager.InsertToCollection("articles", Program.parserManager.ArticleList)
                        + " из " + Program.parserManager.ArticleList.Count;
                }
                catch
                {
                    StatusLabel.Text = "Ошибка соединения с БД";
                }
            }
            else
            {
                StatusLabel.Text = "Нечего конвертировать";
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DBSearch();
            }
        }
        private void DBSearchButton_Click(object sender, EventArgs e)
        {
            DBSearch();
        }
        private void DBSearch()
        {
            TitleResultsLabel.Text = TextResultsLabel.Text = DateResultsLabel.Text = "";
            if (SearchTextBox.Text.Length > 0)
            {
                try
                {
                    if (TitleCheckBox.Checked)
                    {
                        _foundTitle = Program.mongoDbManager.Search("title", SearchTextBox.Text);
                        TitleResultsLabel.Text = _foundTitle?.Count().ToString();
                    }
                    if (TextCheckBox.Checked)
                    {
                        _foundText = Program.mongoDbManager.Search("text", SearchTextBox.Text);
                        TextResultsLabel.Text = _foundText?.Count().ToString();
                    }
                    if (DateCheckBox.Checked)
                    {
                        _foundDate = Program.mongoDbManager.DateSearch(SearchTextBox.Text);
                        DateResultsLabel.Text = _foundDate != null ? _foundDate.Count().ToString() : "0";
                    }
                    StatusLabel.Text = "Поиск прошел успешно";
                }
                catch
                {
                    StatusLabel.Text = "Ошибка при поиске, возможно не соединения с базой данных";
                }
            }
            else
            {
                StatusLabel.Text = "Введите запрос";
            }
        }

        private void DropCollectionButton_Click(object sender, EventArgs e)
        {
            DropCollection();
        }
        private void DropCollection()
        {
            try
            {
                if (Program.mongoDbManager.DropCollection("articles"))
                    StatusLabel.Text = "Коллекция успешно сброшена";
                else
                    StatusLabel.Text = "Коллекция не существовала";
            }
            catch
            {
                StatusLabel.Text = "Ошибка при работе с базой";
            }
        }

        private bool LooksLikeTruth(string link)
        {
            if (Regex.IsMatch(link, _netPathPattern) || Regex.IsMatch(link, _localPathPattern))
                return true;
            return false;
        }

        private void DeleteFoundButton_Click(object sender, EventArgs e)
        {
            DeleteFound();
        }
        private void DeleteFound()
        {
            if (_foundTitle != null || _foundText != null || _foundDate != null)
            {
                try
                {
                    if (TitleCheckBox.Checked)
                        Program.mongoDbManager.DeleteFromCollection("articles", _foundTitle.Query);

                    if (TextCheckBox.Checked)
                        Program.mongoDbManager.DeleteFromCollection("articles", _foundText.Query);

                    if (DateCheckBox.Checked)
                        Program.mongoDbManager.DeleteFromCollection("articles", _foundDate.Query);

                    StatusLabel.Text = "Удаление прошло успешно";
                }
                catch
                {
                    StatusLabel.Text = "Ошибка при поиске, возможно не соединения с базой данных";
                }
            }
            else
            {
                StatusLabel.Text = "Нечего удалять";
            }
        }

    }
}
