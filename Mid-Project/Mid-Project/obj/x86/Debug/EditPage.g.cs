﻿#pragma checksum "C:\Users\Kariko\Desktop\Mid-Project\Mid-Project\EditPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "03877D2A0EEA038E2A92E21B08B11475"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mid_Project
{
    partial class EditPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element1 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    #line 16 "..\..\..\EditPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element1).Click += this.share_click;
                    #line default
                }
                break;
            case 2:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 4:
                {
                    this.name = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.num = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.group = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7:
                {
                    this.save = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 49 "..\..\..\EditPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.save).Click += this.save_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.abtnOpenCamera = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 39 "..\..\..\EditPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.abtnOpenCamera).Click += this.Camera_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.select = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 40 "..\..\..\EditPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.select).Click += this.selectClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

