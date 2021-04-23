using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Tema1MVP
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        public ModifyWindow()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            List<string> comboItems = new List<string>(Model.GetComboCategoryList());
            this.ComboCategory.ItemsSource = comboItems;
        }
        public void addItemCombo(string item)
        {
            Model.AddComboItem(item);
            InitializeComboBox();


        }
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Word currentWord = new Word();
            currentWord.WordName = WordBox.Text;
            currentWord.Description = DescriptionBox.Text;
            if (ComboCategory.SelectedItem != null)
            {
                currentWord.Category = ComboCategory.SelectedValue.ToString();
            }
            else
            {
                currentWord.Category = NewCategoryBox.Text;
            }
            currentWord.ImagePath = imagePath.Text;
            if (ComboCategory.SelectedItem == null)
            {
                if (!Model.ExistCategory(NewCategoryBox.Text))
                {
                    addItemCombo(NewCategoryBox.Text);
                }
                else
                {
                    ConfirmMessage.Content = "Aceasta categorie exista deja!";
                }
            }
            Model.ModifyWord(currentWord);

            ConfirmMessage.Content = "Cuvânt modificat cu succes!";

            WordBox.Text = "";
            DescriptionBox.Text = "";
            NewCategoryBox.Text = "";
            imagePath.Text = "";
            ComboCategory.SelectedItem = null;
            WordsImage.Source = null;

        }


    

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string word = WordBox.Text;
            if (Model.GetWords(Model.listWord).Contains(word))
            {
                WordsImage.Source = new BitmapImage(new Uri(Model.SearchImagePath(word)));
                ComboCategory.SelectedItem = Model.SearchImageCategory(word);
                DescriptionBox.Text = Model.SearchImageDescription(word);
                imagePath.Text = Model.SearchImagePath(word);
            }
            

        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (f.ShowDialog() == true)
            {

                imagePath.Text = f.FileName;
                string imageSource = f.FileName;

                WordsImage.Source = new BitmapImage(new Uri(f.FileName));

                // File.Move(imageSource, @"C:/Users/PC HOME/source/repos/Tema1MVP/Resources");

                // WordsImage.Source = new BitmapImage(new Uri(imageSource));

                // File.Copy(f.FileName, @"C:\Users\PC HOME\source\repos\Tema1MVP\Resources");


            }
        }
    }
}
