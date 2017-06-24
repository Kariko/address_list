using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using SQLitePCL;
using Windows.ApplicationModel.DataTransfer;
using System.Text;
using Windows.Media.SpeechRecognition;

namespace Mid_Project
{
    //联系人页面
    public sealed partial class ContactsPage : Page
    {
        public ContactsPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ViewModels.Telview(image);
        }

        ViewModels.Telview ViewModel { get; set; }
        Models.Tel tel;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter.GetType() == typeof(ViewModels.Telview))
            {
                this.ViewModel = (ViewModels.Telview)(e.Parameter);
            }

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPage), ViewModel);
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            var a = sender as FrameworkElement;
            var b = a.DataContext;
            ListViewItem item = this.TelListView.ContainerFromItem(b) as ListViewItem;
            tel = (Models.Tel)item.Content;
            ViewModel.SelectTel = tel;
            ViewModel.Remove();

            var db = App.conn;
            using (var statement = db.Prepare("DELETE FROM Tels WHERE Number = ?"))
            {
                statement.Bind(1, tel.num);

                statement.Step();
            }
            ViewModel.SelectTel = null;
        }

        public async void query_Click(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //数据库查询代码
            if (text.Text.Trim() == string.Empty || text.Text == "")
            {
                var j = new MessageDialog("请输入查询内容！").ShowAsync();
                return;
            }

            string q = "%" + text.Text + "%";
            using (var statement = App.conn.Prepare("SELECT Name, Number, Group_By, head FROM Tels WHERE Number LIKE ? OR Name LIKE ? OR Group_By LIKE ?"))
            {
                statement.Bind(1, q);
                statement.Bind(2, q);
                statement.Bind(3, q);
                string s1 = "";
                string s2 = "";
                string s3 = "";
                string s4 = "";

                string os = "";
                while (statement.Step() != SQLiteResult.DONE)
                {
                    s1 = (string)statement[0];
                    s2 = (string)statement[1];
                    s3 = (string)statement[2];
                    s4 = (string)statement[3];
                    os += "name: " + statement[0] + "; number: " + statement[1] + "; group: " + statement[2] + "\n";

                    if (os != "")
                    {
                        ContentDialog dialog = new ContentDialog()
                        {
                            Title = "      " + s1,
                            Content = new content(s2, s3, s4),
                            SecondaryButtonText = "关闭",
                            FullSizeDesired = true,
                        };

                        await dialog.ShowAsync();
                    }
                }

                if (os == "")
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "     错误",
                        Content = new content1(text.Text),
                        SecondaryButtonText = "关闭",
                        FullSizeDesired = true,
                    };
                    await dialog.ShowAsync();
                }
            }
        }
        private void Tel_Clicked(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectTel = (Models.Tel)(e.ClickedItem);
            Frame.Navigate(typeof(EditPage), ViewModel);
        }
    }
 }