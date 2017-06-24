using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Mid_Project.ViewModels
{
    class Telview
    {
        private ObservableCollection<Models.Tel> allTels = new ObservableCollection<Models.Tel>();

        public ObservableCollection<Models.Tel> Alltel { get { return this.allTels; } }

        private Models.Tel selectTel = default(Models.Tel);

        public Models.Tel SelectTel { get { return selectTel; } set { this.selectTel = value; } }

        private Models.Tel updateTel = default(Models.Tel);
        public Models.Tel UpdateTel { get { return updateTel; } set { this.updateTel = value; } }

        public Telview(object sender)
        {
            Image img = sender as Image;

            //this.allTels.Add(new Models.Tel("陈布丁", "18819253733", "智障队友", new BitmapImage(new Uri("ms-appx://Todos/Assets/p1.jpg"))));
            //this.allTels.Add(new Models.Tel("陆大白", "15626477044", "智障队友", new BitmapImage(new Uri("ms-appx://Todos/Assets/p2.jpg"))));
            //this.allTels.Add(new Models.Tel("圆滚滚", "18819253733", "智障队友", new BitmapImage(new Uri("ms-appx://Todos/Assets/p3.jpg"))));
            //this.allTels.Add(new Models.Tel("不知名师姐", "15626477044", "智障队友", new BitmapImage(new Uri("ms-appx://Todos/Assets/p4.jpg"))));
            int i;
            string s1, s2, s3, s4;
            for (i = 1; i <= 200; i++)
            {
                using (var statement = App.conn.Prepare("SELECT Name, Number, Group_By, head FROM Tels WHERE Id = ?"))
                {
                    statement.Bind(1, i);
                    if (SQLiteResult.DONE != statement.Step())
                    {
                        s1 = (string)statement[0];
                        s2 = (string)statement[1];
                        s3 = (string)statement[2];
                        s4 = (string)statement[3];
                        this.allTels.Add(new Models.Tel(s1, s2, s3, new BitmapImage(new Uri(s4))));
                    }
                }
            }

        }

        public void AddTel(string name, string num, string group, ImageSource src)
        {
            this.allTels.Add(new Models.Tel(name, num, group, src));
        }


        public void Remove()
        {
            this.allTels.Remove(selectTel);
            this.selectTel = null;
        }

        public void GetUpdateItem()
        {
            if (this.allTels != null)
            {
                this.updateTel = this.allTels.Last();
            }
        }

    }
}
