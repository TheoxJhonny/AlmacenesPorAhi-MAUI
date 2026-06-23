using AlmacenesPorAhiMaui.ViewModels;

namespace AlmacenesPorAhiMaui.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
