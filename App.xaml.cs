namespace WorqApp
{
    public partial class App : Application
    {
        #region App Screen Height/Width .
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        #endregion
        public App()
        {
            InitializeComponent();
            MainDisplayInfo();
            MainPage = new NavigationPage(new Views.LoginPage());
        }

        void MainDisplayInfo()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            ScreenHeight = (int)mainDisplayInfo.Height;
            ScreenWidth = (int)mainDisplayInfo.Width;
        }
    }
}
