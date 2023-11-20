using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using TextFormating.Models;


namespace TextFormating.Models
{
    public class TextFormat
    {
        public List<Run> TextInRuns { get; set; }

        public TextFormat()
        { 
            TextInRuns = new List<Run>();
        }
    }
}
