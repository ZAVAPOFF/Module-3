using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public abstract class Figures
    {
        public abstract double CalculateArea();
    }

    public delegate double CalculateAreaDelegate();

    public class AreaCalculator
    {
        public static double CalculateArea(Figures figure)
        {
            CalculateAreaDelegate calculateAreaDelegate = figure.CalculateArea;
            return calculateAreaDelegate();
        }
    }

}
