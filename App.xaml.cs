using AlmacenesPorAhiMaui.Views;

namespace AlmacenesPorAhiMaui;

public partial class App : Application
{
    public App(LoginPage loginPage)
    {
        InitializeComponent();
        _loginPage = loginPage;
    }

    private readonly LoginPage _loginPage;

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(_loginPage));
    }
}
