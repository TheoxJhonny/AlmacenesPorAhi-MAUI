using Microsoft.Extensions.DependencyInjection;
using AlmacenesPorAhiMaui.ViewModels;
using AlmacenesPorAhiMaui.Views;

namespace AlmacenesPorAhiMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.Services.AddSingleton<AppDataViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddSingleton<DashboardPage>();
        return builder.Build();
    }
}
