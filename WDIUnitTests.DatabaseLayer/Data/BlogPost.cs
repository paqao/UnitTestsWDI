using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.DatabaseLayer.Data
{
    public class BlogPost : DataModel
    {
        public BlogPost()
        {

        }

        public BlogPost(string id, string name, string content)
        {
            Id = id;
            Name = name;
            Content = content;
        }
        public string Name { get; init; }
        public string Content { get; set; }
    }
}
