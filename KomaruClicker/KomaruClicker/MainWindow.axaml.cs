using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace KomaruClicker;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var komaruButton = this.FindControl<Border>("KomaruButton");
        var komaruImage = this.FindControl<Image>("KomaruImage");
        var clicksText = this.FindControl<TextBlock>("ClicksText");
        clicksText.Text = Convert.ToString(Program.clicks);

        komaruButton.PointerPressed += (s, e) =>
        {
            Program.Click();
            clicksText.Text = Convert.ToString(Program.clicks);
            Console.WriteLine($"Button pressed! Current clicks: {Program.clicks}");

            komaruImage.Width = 370;
            komaruImage.Height = 770;

            GameData.Save();
        };

        komaruButton.PointerReleased += (s, e) =>
        {
            komaruImage.Width = 400;
            komaruImage.Height = 800;
        };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}