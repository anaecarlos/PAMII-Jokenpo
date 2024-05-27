using Jokenpô.Mvvm.ViewModels;
using System;
using System.ComponentModel;

namespace Jokenpô.Mvvm.Views
{
    public partial class JogoView : ContentPage
    {
        public JogoView()
        {
            InitializeComponent();
            BindingContext = new JogoViewModels();
        }
    }
}
