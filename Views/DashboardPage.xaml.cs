using AlmacenesPorAhiMaui.ViewModels;

namespace AlmacenesPorAhiMaui.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(AppDataViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
