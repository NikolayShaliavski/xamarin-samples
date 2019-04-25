using Utils.LogLib;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Log
{
    public partial class App : Application
    {
        private static Logger logger;
        public static Logger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = Logger.GetInstance();
                }
                return logger;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new LogEntryPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
