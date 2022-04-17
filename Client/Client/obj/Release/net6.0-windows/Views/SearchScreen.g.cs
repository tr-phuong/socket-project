﻿#pragma checksum "..\..\..\..\Views\SearchScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C39DA3CCBA5652BEACBCC518446E6F91011E2CE6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client.Utils;
using Client.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Client.Views {
    
    
    /// <summary>
    /// SearchScreen
    /// </summary>
    public partial class SearchScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid homeProduct;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label contentBack;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addProductButton;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productsListView;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxPaging;
        
        #line default
        #line hidden
        
        
        #line 327 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar status;
        
        #line default
        #line hidden
        
        
        #line 328 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusLabel;
        
        #line default
        #line hidden
        
        
        #line 336 "..\..\..\..\Views\SearchScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/views/searchscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\SearchScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.homeProduct = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.contentBack = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.addProductButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 174 "..\..\..\..\Views\SearchScreen.xaml"
            this.searchTextBox.SelectionChanged += new System.Windows.RoutedEventHandler(this.searchTextBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.productsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 199 "..\..\..\..\Views\SearchScreen.xaml"
            this.productsListView.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.productsListView_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBoxPaging = ((System.Windows.Controls.ComboBox)(target));
            
            #line 304 "..\..\..\..\Views\SearchScreen.xaml"
            this.comboBoxPaging.DropDownOpened += new System.EventHandler(this.ComboProductTypes_DropDownOpened);
            
            #line default
            #line hidden
            
            #line 305 "..\..\..\..\Views\SearchScreen.xaml"
            this.comboBoxPaging.DropDownClosed += new System.EventHandler(this.ComboProductTypes_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.status = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 8:
            this.statusLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.progressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

