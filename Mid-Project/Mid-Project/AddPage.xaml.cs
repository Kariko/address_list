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
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.Capture;
using Windows.ApplicationModel.DataTransfer;
using System.Threading.Tasks;

namespace Mid_Project
{
    //添加联系人的页面
    public sealed partial class AddPage : Page
    {
        public AddPage()
        {
            this.InitializeComponent();
            name.Text = "";
            num.Text = "";
            group.Text = "";

            BitmapImage bit = new BitmapImage();
            bit.UriSource = new Uri(image.BaseUri, "/Assets/userIcon2.png");
            image.Source = bit;
        }
        public static string filepath;
        public static string filename = "userIcon2.png";
        public static string destpath;

        private ViewModels.Telview ViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = ((ViewModels.Telview)e.Parameter);
            if (ViewModel.SelectTel != null)
            {
                name.Text = ViewModel.SelectTel.name;
                num.Text = ViewModel.SelectTel.num;
                group.Text = ViewModel.SelectTel.group;
                image.Source = ViewModel.SelectTel.src;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || name.Text.Trim() == string.Empty || num.Text == "" || num.Text.Trim() == string.Empty)
            {
                var n = new MessageDialog("信息输入有误!").ShowAsync();
            }
            else
            {
                ViewModel.AddTel(name.Text, num.Text, group.Text, image.Source);
                Frame.Navigate(typeof(ContactsPage), ViewModel);
                if (ViewModel.SelectTel != null) ViewModel.Remove();
                ViewModel.SelectTel = null;

                var db = App.conn;
                using (var item = db.Prepare("INSERT INTO Tels (Name, Number, Group_By, head) VALUES(?, ?, ?, ?)"))
                {
                    item.Bind(1, name.Text);
                    item.Bind(2, num.Text);
                    item.Bind(3, group.Text);
                    string temp = "ms-appx://Todos/Assets/" + filename;
                    item.Bind(4, temp);
                    item.Step();
                }
                var n = new MessageDialog("信息已经成功保存至通讯录！").ShowAsync();
            }
        }

        private void cancel_click(object sender, RoutedEventArgs e) //清空输入的内容
        {
            name.Text = "";
            num.Text = "";
            group.Text = "";

            BitmapImage bit = new BitmapImage();
            bit.UriSource = new Uri(image.BaseUri, "/Assets/userIcon2.png");
            image.Source = bit;
        }

        public async void selectClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail; // 缩图
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jepg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync(); //只能选择一个文件

            if (file != null)
            {
                filepath = file.Path;
                filename = file.Name;
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                BitmapImage img = new BitmapImage();
                img.SetSource(stream); //设置图片的源头
                this.image.Source = img;  // 改变xaml中image的图片
            }
        }

        private async void Camera_Click(object sender, RoutedEventArgs e) //调用摄像头
        {
            var cameraCaptureUI = new CameraCaptureUI();
            cameraCaptureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            cameraCaptureUI.PhotoSettings.AllowCropping = true;
            cameraCaptureUI.PhotoSettings.CroppedSizeInPixels = new Size(150, 150);

            StorageFile photo = await cameraCaptureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
                return;

            BitmapImage bitmapImage = new BitmapImage();
            using (IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read))
            {
                bitmapImage.SetSource(stream);
            }
            this.image.Source = bitmapImage;
            filename = photo.Name;
        }
        
        private void share_click(object sender, RoutedEventArgs e)
        {
            //共享代码
            dynamic d = e.OriginalSource;
            ViewModel.SelectTel = (Models.Tel)(d.DataContext);
            DataTransferManager.ShowShareUI();
        }
    }
}