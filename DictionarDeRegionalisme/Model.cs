using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tema1MVP
{
    class Model
    {
        public static List<Word> listWord = new List<Word>();
        private static List<string> comboItems = new List<string> {"Graiul ardelenesc",
                "Graiul bucovinean",
                "Graiul bănățean",
                "Graiul crișean",
                "Graiul dobrogean",
                "Graiul maramureșean",
                "Graiul muntenesc",
                "Graiul moldovenesc",
                "Graiul oltenesc" };
        public static void AddWord(Word word)
        {
            listWord.Add(word);
        }

        public static void ReadFromXML()
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Users\PC HOME\source\repos\Tema1MVP\Resources\WordsXML2.xml"))
            {
                Word currentWord = new Word();
                while (reader.Read())
                {


                    if (reader.IsStartElement())
                    {

                        switch (reader.Name.ToString())
                        {
                            case "name":
                                currentWord.WordName = reader.ReadString();
                                break;
                            case "description":
                                currentWord.Description = reader.ReadString();
                                break;
                            case "category":
                                currentWord.Category = reader.ReadString();
                                break;
                            case "path":
                                {
                                    currentWord.ImagePath = reader.ReadString();
                                    AddWord(currentWord);
                                    currentWord = new Word();
                                    break;
                                }
                        }

                    }


                }
            }

        }
        public static void WriteWordData(XmlWriter writer, string name, string description, string category, string path)
        {
            writer.WriteStartElement("word");
            writer.WriteElementString("name", name);
            writer.WriteElementString("description", description);
            writer.WriteElementString("category", category);
            writer.WriteElementString("path", path);
            writer.WriteEndElement();
        }
        public static void WriteInXML(List<Word> listWord)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(@"C:\Users\PC HOME\source\repos\Tema1MVP\Resources\WordsXML2.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("words");

            foreach (Word w in listWord)
            {

                WriteWordData(xmlWriter, w.WordName, w.Description, w.Category, w.ImagePath);
                
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();

        }
        public static void ModifyWord(Word word)
        {
            foreach (Word w in listWord)
            {
                if (w.WordName == word.WordName)
                {
                    w.Description = word.Description;
                    w.Category = word.Category;
                    w.ImagePath = word.ImagePath;
                    break;

                }


            }

        }
        public static void EraseWord(string word)
        {
            Word currentWord = new Word();
            foreach (Word w in listWord)
            {
                if (w.WordName == word)
                {
                    currentWord = w;
                    listWord.Remove(currentWord);
                    break;

                }


            }

        }
        public static Word SearchWord(string word)
        {
            Word aux = new Word();
            foreach (Word w in listWord)
            {
                if (w.WordName == word)
                {

                    aux = w;

                }

            }
            return aux;

        }
        public static string SearchImagePath(string word)
        {
            string path = null;
            foreach (Word w in listWord)
            {
                if (w.WordName == word)
                {

                    path = w.ImagePath;

                }

            }
            return path;

        }
        public static string SearchImageCategory(string word)
        {
            string category = null;
            foreach (Word w in listWord)
            {
                if (w.WordName == word)
                {

                    category = w.Category;

                }

            }
            return category;

        }
        public static string SearchImageDescription(string word)
        {
            string description = null;
            foreach (Word w in listWord)
            {
                if (w.WordName == word)
                {

                    description = w.Description;

                }

            }
            return description;

        }
        static public List<string> GetWords(List<Word> all)
        {
            List<string> data = new List<string>();
            List<Word> allwords = new List<Word>(all);
            foreach (Word w in allwords)
            {
                string currentWord = w.WordName;
                data.Add(currentWord);
            }
            return data;
        }
        public static void AddComboItem(string item)
        {
            comboItems.Add(item);

        }
        public static List<Word> GetWordList()
        {
            return listWord;
        }
        public static List<string> GetComboCategoryList()
        {
            return comboItems;
        }


        public static bool ExistCategory(string category)
        {
            foreach (string s in comboItems)
            {
                if (s == category) return true;
            }
            return false;
        }
        public static void AddCategory(string category)
        {
            comboItems.Add(category);
        }


    }
}