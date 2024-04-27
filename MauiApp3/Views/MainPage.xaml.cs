using System.Reflection;

namespace MauiApp3.Views
{
    public partial class MainPage : ContentPage
    {
        private int _count = 0;

        public MainPage()
        {
            InitializeComponent();
            var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
            VersionLabel.Text = $".NET MAUI ver. {version?[..version.IndexOf('+')]}";
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            String message;

            if (MyDatePicker.Date.Year + 18 < now.Year ||
                MyDatePicker.Date.Year + 18 == now.Year && MyDatePicker.Date.Month < now.Month ||
                MyDatePicker.Date.Year + 18 == now.Year && MyDatePicker.Date.Month == now.Month && MyDatePicker.Date.Day < now.Day) 
            {
                message = "You may purchase alcohol";
            }
            else
            {
                int yearDif = (MyDatePicker.Date.Year + 18) - now.Year;
                int monthDif = (MyDatePicker.Date.Month) - now.Month;

                message = $"You may purchase alcohol in {yearDif} years and {monthDif} months";
            }
            
            CounterLabel.Text = message;
            SemanticScreenReader.Announce(CounterLabel.Text);
        }
    }
}