#pragma checksum "..\..\ItemUploadWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D396A5F559DC7CEADD9F1116F9EF5BE31C5925E452FFEDC96020D13F5246F680"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Furniture_Store;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Furniture_Store {
    
    
    /// <summary>
    /// ItemUploadWindow
    /// </summary>
    public partial class ItemUploadWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\ItemUploadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Item_Name;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\ItemUploadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ItemType;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\ItemUploadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Item_Cost;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\ItemUploadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ItemImage;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\ItemUploadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Amount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Furniture_Store;component/itemuploadwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ItemUploadWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\ItemUploadWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddItem_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Item_Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\ItemUploadWindow.xaml"
            this.Item_Name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ItemType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 67 "..\..\ItemUploadWindow.xaml"
            this.ItemType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_Selected);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Item_Cost = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\ItemUploadWindow.xaml"
            this.Item_Cost.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 131 "..\..\ItemUploadWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChooseImage_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ItemImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.Amount = ((System.Windows.Controls.TextBox)(target));
            
            #line 141 "..\..\ItemUploadWindow.xaml"
            this.Amount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Amount_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

