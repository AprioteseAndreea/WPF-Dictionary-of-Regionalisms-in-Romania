using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tema1MVP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static List<string> wordsList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBox();
            Model.ReadFromXML();

        }
        private void InitializeComboBox()
        {
            List<string> comboItems = new List<string>(Model.GetComboCategoryList());
            this.CategoryBox.ItemsSource = comboItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();

        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyWindow modifyWindow = new ModifyWindow();
            modifyWindow.Show();

        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            EraseWindow eraseWindow = new EraseWindow();
            eraseWindow.Show();

        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayGameWindow gameWindow = new PlayGameWindow();
            gameWindow.Show();

        }
        private void ShowInformation(string word)
        {
            Word selectedWord = Model.SearchWord(word);
            LabelWord.Content = selectedWord.WordName;
            ImageWord.Source = new BitmapImage(new Uri(selectedWord.ImagePath));
            CategoryTextBlock.Text = selectedWord.Category;
            DescriptionTextBlock.Text = selectedWord.Description;
        }

        private void addItem(string text)
        {
            TextBlock block = new TextBlock();

            block.Text = text;

            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            block.MouseLeftButtonUp += (sender, e) =>
            {
                textBox.Text = (sender as TextBlock).Text;

            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.PeachPuff;


                LabelWord.Content = b.Text;
                ImageWord.Source = new BitmapImage(new Uri(Model.SearchImagePath(b.Text)));
                CategoryTextBlock.Text = Model.SearchImageCategory(b.Text);
                DescriptionTextBlock.Text = Model.SearchImageDescription(b.Text);


            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            resultStack.Children.Add(block);
        }
        public static List<string> ActualizeList()
        {
            wordsList = Model.GetWords(Model.GetWordList());
            return wordsList;

        }
        public static List<Word> FilterWords(string category)
        {
            List<Word> filterWords = new List<Word>();
            foreach (Word w in Model.GetWordList())
            {
                if (w.Category == category)
                {
                    filterWords.Add(w);
                }
            }
            return filterWords;

        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {

            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var allWords = ActualizeList();
            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            resultStack.Children.Clear();

            if (CategoryBox.SelectedItem == null)
            {
                foreach (var obj in Model.GetWordList())
                {
                    if (obj.WordName.ToLower().StartsWith(query.ToLower()))
                    {
                        string item = CategoryBox.Text;

                        addItem(obj.WordName);
                        found = true;


                    }

                }
            }
            else
            {
                var filterWords = FilterWords(CategoryBox.SelectedItem.ToString());
                foreach (var obj in filterWords)
                {
                    if (obj.WordName.ToLower().StartsWith(query.ToLower()))
                    {
                        string item = CategoryBox.Text;
                        addItem(obj.WordName);
                        found = true;

                    }

                }

            }


            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }


        private void CategoryBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            InitializeComboBox();
        }
    }


}

