#pragma checksum "..\..\RegistrationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B6A7A136A01367793E5D83D75FFBFBBB5EC0752C37A1450CF978CB10E65C729E"
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
    /// RegistrationWindow
    /// </summary>
    public partial class RegistrationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Address;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phone;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EMail;
        
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
            System.Uri resourceLocater = new System.Uri("/Furniture_Store;component/registrationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistrationWindow.xaml"
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
            this.ErrorMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Login = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\RegistrationWindow.xaml"
            this.Login.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Login_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            
            #line 61 "..\..\RegistrationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Register_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\RegistrationWindow.xaml"
            this.UserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 68 "..\..\RegistrationWindow.xaml"
            this.UserName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Address = ((System.Windows.Controls.TextBox)(target));
            
            #line 111 "..\..\RegistrationWindow.xaml"
            this.Address.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Phone = ((System.Windows.Controls.TextBox)(target));
            
            #line 156 "..\..\RegistrationWindow.xaml"
            this.Phone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Phone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EMail = ((System.Windows.Controls.TextBox)(target));
            
            #line 199 "..\..\RegistrationWindow.xaml"
            this.EMail.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.EMail_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

