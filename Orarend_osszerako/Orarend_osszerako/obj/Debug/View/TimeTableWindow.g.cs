﻿#pragma checksum "..\..\..\View\TimeTableWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC3DD7F28A4F2E011A7F1D25AADF3EA9E5A50DDC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Orarend_osszerako;
using Orarend_osszerako.ViewModel;
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


namespace Orarend_osszerako {
    
    
    /// <summary>
    /// TimeTableWindow
    /// </summary>
    public partial class TimeTableWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\View\TimeTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button orarend;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\TimeTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button beallitasok;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\View\TimeTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button profil;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\TimeTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logout;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\TimeTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Main;
        
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
            System.Uri resourceLocater = new System.Uri("/Orarend_osszerako;component/view/timetablewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\TimeTableWindow.xaml"
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
            this.orarend = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\View\TimeTableWindow.xaml"
            this.orarend.Click += new System.Windows.RoutedEventHandler(this.orarend_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.beallitasok = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\View\TimeTableWindow.xaml"
            this.beallitasok.Click += new System.Windows.RoutedEventHandler(this.beallitasok_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.profil = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\View\TimeTableWindow.xaml"
            this.profil.Click += new System.Windows.RoutedEventHandler(this.profil_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.logout = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\View\TimeTableWindow.xaml"
            this.logout.Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Main = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

