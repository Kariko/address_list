using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Mid_Project.Models
{
    class Tel
    {
        public Tel(string na, string nu,  string g, ImageSource s)
        {
            this.num = nu;
            this.name = na;
            this.group = g;
            this.id = Guid.NewGuid().ToString();
            //this.messages = t + "："+ d + "                     Due Date：" + date;
            src = s;
        }

        private string id;
        public string num { get; set; }
        public string name { get; set; }
        public string group { get; set; }
       // public DateTime  { get; set; }
        //public bool? completed { get; set; }

        public ImageSource src;

        //private string messages;
        //public string Messages { get { return messages; } set { messages = title + ":" + details + "   "; } }
    }
}
