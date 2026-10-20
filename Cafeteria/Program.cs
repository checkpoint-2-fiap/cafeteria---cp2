using System.Globalization;
using Cafeteria.Telas;

namespace Cafeteria;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Para o R$ e as datas aparecerem no formato brasileiro
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        ApplicationConfiguration.Initialize();

        // Abre a splash primeiro e, quando ela fechar, abre o menu
        var splash = new SplashForm();
        splash.ShowDialog();

        Application.Run(new MenuForm());
    }
}
