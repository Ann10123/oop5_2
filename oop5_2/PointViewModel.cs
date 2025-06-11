using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoronoiWinForms;

namespace VoronoiWinForms
{
    public class PointViewModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public bool isSelected { get; set; } = false;
        public bool isGone { get; set; } = false;
    }
}
