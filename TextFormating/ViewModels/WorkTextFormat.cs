using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using TextFormating.Models;

namespace TextFormating.ViewModels
{
    public class WorkTextFormat
    {
        public TextFormat TextFormat { get; set; }
        public Position Position { get; set; }
        public SettingsFormat SettingsFormat { get; set; }

        public WorkTextFormat()
        {
            TextFormat = new TextFormat();
            Position = new Position();
            SettingsFormat = new SettingsFormat();
        }

        private Run CreateNewRun(string name)
        {
            return new Run(name)
            {
                FontStyle = SettingsFormat.Style,
                FontSize = SettingsFormat.FontSize,
                FontWeight = SettingsFormat.Weight,
                Foreground = SettingsFormat.Color,
                TextDecorations = SettingsFormat.Decorations
            };
        }

        public Run AddRun(char run)
        {
            TextFormat.TextInRuns.Add(CreateNewRun(run.ToString()));
            return TextFormat.TextInRuns.Last();
        }

        public Run RemoveRun()
        {
            Run LastRun = TextFormat.TextInRuns.Last();
            TextFormat.TextInRuns.Remove(LastRun);
            return LastRun;
        }

        public void Formating()
        {
            for (int i = Position.StartPose; i <= Position.EndPose; i++)
                TextFormat.TextInRuns[i] = CreateNewRun(TextFormat.TextInRuns[i].Text);

        }
    }
}
