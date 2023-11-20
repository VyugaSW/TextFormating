using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFormating.Models
{
    public class Position
    {
        public int StartPose { get; set; }
        public int EndPose { get; set; }

        public Position()
        {
            StartPose = 0;
            EndPose = 0;
        }
    }
}
