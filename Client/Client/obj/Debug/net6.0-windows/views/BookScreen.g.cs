﻿#pragma checksum "..\..\..\..\Views\BookScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55E296CA160549B412F37D40CD1C349FB334D98E"
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
    /// BookScreen
    /// </summary>
    public partial class BookScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid bookScreen;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddToListProduct;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listRooms;
        
        #line default
        #line hidden
        
        
        #line 370 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hotelNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 384 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox typeRoomTextBox;
        
        #line default
        #line hidden
        
        
        #line 397 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rateRoomTextBox;
        
        #line default
        #line hidden
        
        
        #line 410 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox noteRoomTextBox;
        
        #line default
        #line hidden
        
        
        #line 421 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateBookDatePicker;
        
        #line default
        #line hidden
        
        
        #line 434 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker leavingDateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 452 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock sumTotalOfRoom;
        
        #line default
        #line hidden
        
        
        #line 460 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btncancel;
        
        #line default
        #line hidden
        
        
        #line 482 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBar;
        
        #line default
        #line hidden
        
        
        #line 498 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 512 "..\..\..\..\Views\BookScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNewRoom;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/views/bookscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\BookScreen.xaml"
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
            this.bookScreen = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 33 "..\..\..\..\Views\BookScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backWard_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnAddToListProduct = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.listRooms = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.hotelNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 367 "..\..\..\..\Views\BookScreen.xaml"
            this.hotelNameTextBox.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.selectRoom_MouseUp);
            
            #line default
            #line hidden
            
            #line 368 "..\..\..\..\Views\BookScreen.xaml"
            this.hotelNameTextBox.SelectionChanged += new System.Windows.RoutedEventHandler(this.hotelNameTextBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.typeRoomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.rateRoomTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 395 "..\..\..\..\Views\BookScreen.xaml"
            this.rateRoomTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 399 "..\..\..\..\Views\BookScreen.xaml"
            this.rateRoomTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rateRoomTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.noteRoomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.dateBookDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 423 "..\..\..\..\Views\BookScreen.xaml"
            this.dateBookDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dateBookDatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.leavingDateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 436 "..\..\..\..\Views\BookScreen.xaml"
            this.leavingDateDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.leavingDateDatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.sumTotalOfRoom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.btncancel = ((System.Windows.Controls.Button)(target));
            
            #line 474 "..\..\..\..\Views\BookScreen.xaml"
            this.btncancel.Click += new System.Windows.RoutedEventHandler(this.btncancel_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.ProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 16:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 497 "..\..\..\..\Views\BookScreen.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btnAddNewRoom = ((System.Windows.Controls.Button)(target));
            
            #line 511 "..\..\..\..\Views\BookScreen.xaml"
            this.btnAddNewRoom.Click += new System.Windows.RoutedEventHandler(this.BtnAddNewRoom_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 530 "..\..\..\..\Views\BookScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backWard_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 325 "..\..\..\..\Views\BookScreen.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.cannelRoom_MouseUp);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

