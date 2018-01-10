//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GUIforNeuron
{
    struct Answer
    {
        public double white;
        public double grey;
        public double darkGrey;
        public double liteGrey;
        public double black;
        public double color;

        public double Amount()
        {
            return white + grey + darkGrey + liteGrey + black + color;
        }
    }

    struct SmartAnswer
    {
        public bool sin;
        public bool cos;
        public bool tan;
        public bool ctan;
        public bool exp;
        public bool lg;
        public bool ln;
    }
    struct Point
    {
        public double white;
        public double grey;
        public double black;
        public double color;
        public double radius;
        public double smalRadius;
        public double bigRadius;
    }
}