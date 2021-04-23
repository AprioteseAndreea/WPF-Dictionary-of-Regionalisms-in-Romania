using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1MVP
{
    public class Category
    {
        string category;
        Category()
        {
            this.category = "UNKNOWN CATEGORY";
        }
        Category(string category)
        {
            this.category = category;
        }
        public void setCategory(string category)
        {
            this.category = category;
        }
        public string getCategory()
        {
            return this.category;
        }
    }
}
