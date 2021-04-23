using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1MVP
{
    public class Word
    {
        private string word;
        public String WordName
        {
            get
            {
                return word;
            }
            set
            {
               word = value;
            }
        }
        private string description;
        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        private string category;
        public String Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
        private string imagePath;
       public String ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
            }
        }
       public Word()
        {
            this.word = "UNKNOWN_WORD";
            this.description = "UNKNOWN_WORD";
            this.category = null;
            this.imagePath = "UNKNOWN_WORD";

        }
        public Word(string word, string description, string category, string imagePath)
        {
            this.word = word;
            this.description = description;
            this.category = category;
            this.imagePath = null;
        }
       
    }
}
