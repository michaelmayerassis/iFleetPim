﻿#pragma checksum "..\..\..\Views\CadSeguro.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15CF803D5E41CD05BDA0B876F43CBFDC65382147A5674D034ABEEE4D8C40010D"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using CurrencyTextBoxControl;
using FrotaVeiculoPim.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace FrotaVeiculoPim.Views {
    
    
    /// <summary>
    /// CadSeguro
    /// </summary>
    public partial class CadSeguro : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPlaca;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlano;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSeguradora;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpData;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtApolice;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalvar;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views\CadSeguro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CurrencyTextBoxControl.CurrencyTextBox txtValor;
        
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
            System.Uri resourceLocater = new System.Uri("/FrotaVeiculoPim;component/views/cadseguro.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CadSeguro.xaml"
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
            this.cbPlaca = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtPlano = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtSeguradora = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dpData = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.txtApolice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSalvar = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Views\CadSeguro.xaml"
            this.btnSalvar.Click += new System.Windows.RoutedEventHandler(this.BtnSalvar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtValor = ((CurrencyTextBoxControl.CurrencyTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

