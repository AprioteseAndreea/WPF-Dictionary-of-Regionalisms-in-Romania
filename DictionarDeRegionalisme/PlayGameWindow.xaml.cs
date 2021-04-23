using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Tema1MVP
{
    /// <summary>
    /// Interaction logic for PlayGameWindow.xaml
    /// </summary>
    public partial class PlayGameWindow : Window
    {
        private static List<Word> randomWords;
        private int contor=0;
        private int correctAnswers = 0;
        private int incorrectAnswers = 0;
        public PlayGameWindow()
        {
            InitializeComponent();
            ChooseWords();
        }
        private void DisplayQuestion(int index)
        {
            
            contor++;
            if (contor >= 6)
            {
                
                Image.Source = null;
                AnswerText.Text = "Jocul s-a terminat!";
                NextButton.Source = null;
                LabelComplete.Content = "";
                AnswerText = null;
                categoryBox.Text = "";
            }
            else
            {
                RoundBlock.Text = (contor).ToString();
                AnswerText.Text = "";
                Image.Source = new BitmapImage(new Uri(randomWords.ElementAt(index).ImagePath));
                categoryBox.Text = randomWords.ElementAt(index).Category;
            }
            
            
        }
        private void ChooseWords()
        {
            var rand = new Random();
            randomWords = new List<Word>();
            List<Word> allWords = new List<Word>(Model.GetWordList());
            for(int i = 0; i < 6; i++)
            {
              
                int randNumber = rand.Next(allWords.Capacity);
                randomWords.Add(Model.listWord.ElementAt(randNumber));
            }
            DisplayQuestion(contor);


        }
        private void nextbutton_Click(object sender, RoutedEventArgs e)
        {
          
                if (AnswerText.Text == randomWords.ElementAt(contor-1).WordName)
                {
                    correctAnswers++;
                    CorrectBlock.Text = (correctAnswers).ToString();
                    DisplayQuestion(contor);
                }
                else
                {
                    incorrectAnswers++;
                    IncorrectBlock.Text = (incorrectAnswers).ToString();
                    MessageBox.Show("Raspunsul corect este: " + randomWords.ElementAt(contor-1).WordName);

                     DisplayQuestion(contor);
                }
               
           

        }

        
    }
}
