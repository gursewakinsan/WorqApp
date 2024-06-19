namespace WorqApp.Controls
{
    /* public class CustomBusyIndicator : SfBusyIndicator
     {
         public CustomBusyIndicator()
         {
             Title = "Loading...";
             AnimationType = AnimationType.DoubleCircle;
             DurationFactor = 0.5;
             FontSize = 16;
             IndicatorColor = Color.FromArgb("#FFFFFF");
             SizeFactor = 0.5;
             TextColor = Color.FromArgb("#FFFFFF");
             TitleSpacing = 20;
             HorizontalOptions = LayoutOptions.Center;
             VerticalOptions = LayoutOptions.Center;
         }
     }*/

    public class CustomBusyIndicator : ActivityIndicator
    {
        public CustomBusyIndicator()
        {
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
        }
        public Color IndicatorColor { get; set; }
        public Color TextColor { get; set; }
    }
}
