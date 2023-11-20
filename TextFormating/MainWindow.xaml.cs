using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TextFormating.Models;
using TextFormating.ViewModels;

namespace TextFormating
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WorkTextFormat WorkText { get; set; }

        List<SolidColorBrush> colorsList = new List<SolidColorBrush>
        {
            Brushes.Black, Brushes.Red,
            Brushes.Green, Brushes.Yellow,
            Brushes.Blue, Brushes.Violet
        };

        public MainWindow()
        {
            InitializeComponent();
            WorkText = new WorkTextFormat();
        }

        private void UpdateText(object sender, TextChangedEventArgs e) 
        {
            if(transpTextBox.Text.Length >= WorkText.TextFormat.TextInRuns.Count)
                mainTextBlock.Inlines.Add(WorkText.AddRun(transpTextBox.Text.Last()));
            else
                mainTextBlock.Inlines.Remove(WorkText.RemoveRun());
        }
        private void ColorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            colorMenuItem.Background = (sender as MenuItem).Background;
            WorkText.SettingsFormat.Color = colorsList.Find(x => x == (sender as MenuItem).Background);
            ApplyFormating();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if ((sender as TextBox).Name == "startIndexTextBox")
                    WorkText.Position.StartPose = Convert.ToInt32((sender as TextBox).Text);

                else if ((sender as TextBox).Name == "endIndexTextBox")
                    WorkText.Position.EndPose = Convert.ToInt32((sender as TextBox).Text);

                else if ((sender as TextBox).Name == "fontSizeTextBox")
                    WorkText.SettingsFormat.FontSize = Convert.ToInt32((sender as TextBox).Text);

                ApplyFormating();
            }
            catch (Exception)
            {
                (sender as TextBox).Text = null;
            }
        }
        private void TextBlockFormat_LeftMouseButtonDown(object sender, RoutedEventArgs e)
        {
            switch((sender as TextBlock).Name)
            {
                case "TextBlockBold":
                    ToBold();
                    break;
                case "TextBlockItalic":
                    ToItalic();
                    break;
                case "TextBlockUnderline":
                    ToUnderLine();
                    break;
                case "TextBlockClear":
                    Clear();
                    break;
            }

            ApplyFormating();
        }
        
        private void ToBold()
        {
            if (WorkText.SettingsFormat.Weight == FontWeights.Bold)
                WorkText.SettingsFormat.Weight = FontWeights.Normal;
            else
                WorkText.SettingsFormat.Weight = FontWeights.Bold;
        }
        private void ToItalic()
        {
            if (WorkText.SettingsFormat.Style == FontStyles.Italic)
                WorkText.SettingsFormat.Style = FontStyles.Normal;
            else
                WorkText.SettingsFormat.Style = FontStyles.Italic;
        }
        private void ToUnderLine()
        {
            if (WorkText.SettingsFormat.Decorations == TextDecorations.Underline)
                WorkText.SettingsFormat.Decorations = null;
            else
                WorkText.SettingsFormat.Decorations = TextDecorations.Underline;
        }
        private void Clear()
        {
            WorkText.SettingsFormat.Weight = FontWeights.Normal;
            WorkText.SettingsFormat.Style = FontStyles.Normal;
            WorkText.SettingsFormat.Decorations = null;
            WorkText.SettingsFormat.Color = Brushes.Black;
        }
        private void ApplyFormating()
        {
            WorkText.Formating();
            mainTextBlock.Inlines.Clear();
            mainTextBlock.Inlines.AddRange(WorkText.TextFormat.TextInRuns);
        }
    }
}
