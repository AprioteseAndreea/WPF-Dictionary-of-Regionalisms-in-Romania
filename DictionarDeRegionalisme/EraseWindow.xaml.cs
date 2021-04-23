using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tema1MVP
{
    /// <summary>
    /// Interaction logic for EraseWindow.xaml
    /// </summary>
    public partial class EraseWindow : Window
    {
        public EraseWindow()
        {
            InitializeComponent();
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
         List<string> words = new List<string>(Model.GetWords(Model.GetWordList()));
            if (WordErase.Text != "")
            {
                bool found = false;
                foreach (string w in words)
                {
                    if (w == WordErase.Text)
                    {
                        Model.EraseWord(WordErase.Text);
                       // MainWindow.ActualizeList();
                        ConfirmMessage.Content = "Cuvant sters cu succes!";
                        found = true;
                    }

                }
               
                if (found == false)
                {
                    ConfirmMessage.Content = "Cuvantul nu a fost gasit!";
                }


            }
            else
            {
                ConfirmMessage.Content = "Nu ati introdus niciun cuvant!";
            }
        
        }
    }
}
