using System.Windows.Input;
using AlmacenesPorAhiMaui.Views;

namespace AlmacenesPorAhiMaui.ViewModels;

public class LoginViewModel : BaseViewModel
{
    string _usuario = "admin";
    string _password = "1234";
    string _mensaje = "Usuario de prueba: admin / 1234";

    public LoginViewModel(AppDataViewModel data)
    {
        IngresarCommand = new Command(async () => await Ingresar(data));
    }

    public string Usuario { get => _usuario; set => SetProperty(ref _usuario, value); }
    public string Password { get => _password; set => SetProperty(ref _password, value); }
    public string Mensaje { get => _mensaje; set => SetProperty(ref _mensaje, value); }
    public ICommand IngresarCommand { get; }

    async Task Ingresar(AppDataViewModel data)
    {
        if (Usuario == "admin" && Password == "1234")
        {
            var page = new NavigationPage(new DashboardPage(data));
            if (Application.Current?.Windows.Count > 0)
                Application.Current.Windows[0].Page = page;
            return;
        }
        Mensaje = "Credenciales incorrectas.";
        await Task.CompletedTask;
    }
}
