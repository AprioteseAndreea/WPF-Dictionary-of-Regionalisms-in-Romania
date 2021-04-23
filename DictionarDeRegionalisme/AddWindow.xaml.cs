using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Tema1MVP
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            List<string> comboItems = new List<string>(Model.GetComboCategoryList());
            this.ComboCategory.ItemsSource = comboItems;
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (f.ShowDialog() == true)
            {

                imagePath.Text = f.FileName;
                string imageSource = f.FileName;

                WordsImage.Source = new BitmapImage(new Uri(f.FileName)); 

            }

        }
        public void addItemCombo(string item)
        {
            Model.AddComboItem(item);
            InitializeComboBox();
            
           
        }
        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Word currentWord = new Word();
            currentWord.WordName = WordBox.Text;
            currentWord.Description = DescriptionBox.Text;
            if (ComboCategory.SelectedItem != null)
            {
                currentWord.Category=ComboCategory.SelectedValue.ToString();
            }
            else
            {
                currentWord.Category=NewCategoryBox.Text;
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
            if (!Model.GetWords(Model.listWord).Contains(currentWord.WordName))
            {
                Model.AddWord(currentWord);
                ConfirmMessage.Foreground= new SolidColorBrush(Colors.Green);
                ConfirmMessage.Content = "Cuvânt adăugat cu succes!";
                
            }
            else
            {
                ConfirmMessage.Foreground = new SolidColorBrush(Colors.Red);
                ConfirmMessage.Content = "Acest cuvant există deja!";

            }
            Model.WriteInXML(Model.listWord);
            //Model.ReadFromXML();
            WordBox.Text = "";
            DescriptionBox.Text = "";
            NewCategoryBox.Text = "";
            imagePath.Text = "";
            ComboCategory.SelectedItem = null;
            WordsImage.Source = null;

            

        }

        
    }
}
