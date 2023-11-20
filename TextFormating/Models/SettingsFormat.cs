using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace TextFormating.Models
{
    public class SettingsFormat : INotifyPropertyChanged
    {
        private int _fontSize;
        private FontWeight _weight;
        private FontStyle _style;
        private TextDecorationCollection _decorations;
        private SolidColorBrush _color;

        public int FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FontSize)));
            }
        }
        public FontWeight Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Weight)));
            }
        }
        public FontStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Style)));
            }
        }
        public TextDecorationCollection Decorations
        {
            get => _decorations;
            set
            {
                _decorations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Decorations)));
            }
        }
        public SolidColorBrush Color
        {
            get => _color;
            set
            {
                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsFormat()
        {
            FontSize = 25;
            Weight = FontWeights.Normal;
            Style = FontStyles.Normal;
            Decorations = new TextDecorationCollection();
            Color = Brushes.Black;
        }
    }
}
