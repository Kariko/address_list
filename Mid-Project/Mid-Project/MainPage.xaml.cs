using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using NotificationsExtensions.Tiles;
using Windows.UI.Notifications;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Mid_Project
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    /// 主页面
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        ViewModels.Telview ViewModel { get; set; }

        private void enterbutton_Click(object sender, RoutedEventArgs e)
        {
            
            string telText = "Tel";
            string nameText = "With One Heart";
            string detailText = "Phone number";
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() {
                                    Text = telText,
                                    Style = TileTextStyle.Subtitle
                                },
                                new TileText()
                                {
                                    Text = nameText,
                                    Style = TileTextStyle.CaptionSubtle
                                },
                                new TileText()
                                {
                                    Text = detailText,
                                    Style = TileTextStyle.BaseSubtle
                                }
                            }
                        }
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() {
                                    Text = telText,
                                    Style = TileTextStyle.Subtitle
                                },
                                new TileText()
                                {
                                    Text = nameText,
                                    Style = TileTextStyle.CaptionSubtle
                                },
                                new TileText()
                                {
                                    Text = detailText,
                                    Style = TileTextStyle.BaseSubtle
                                }
                            }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new TileText() {
                                    Text = telText,
                                    Style = TileTextStyle.Subtitle
                                },
                                new TileText()
                                {
                                    Text = nameText,
                                    Style = TileTextStyle.CaptionSubtle
                                },
                                new TileText()
                                {
                                    Text = detailText,
                                    Style = TileTextStyle.BaseSubtle
                                }
                            }
                        }
                    },
                }
            };
            var notification = new TileNotification(content.GetXml());
            var updator = TileUpdateManager.CreateTileUpdaterForApplication();
            updator.Update(notification);
            Frame.Navigate(typeof(ContactsPage), "");
        }

    }
}
