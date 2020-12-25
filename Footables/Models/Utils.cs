using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footables.Models
{
    public class Utils
    {
        public static List<double> getCotes(int domicile, int exterieur)
        {
            Utils cotes = new Utils();

            double win = cotes.Win(domicile, exterieur);
            double draw = cotes.Draw(domicile, exterieur);
            double defeat = cotes.Win(exterieur, domicile);

            return new List<double>() { win, draw, defeat };
        }
        private double Win(int first, int second)
        {
            double cote = 0;

            switch (first - second)
            {
                case -9:
                    cote = 3;
                    break;

                case -8:
                    cote = 2.88;
                    break;

                case -7:
                    cote = 2.75;
                    break;

                case -6:
                    cote = 2.62;
                    break;

                case -5:
                    cote = 2.5;
                    break;

                case -4:
                    cote = 2.4;
                    break;

                case -3:
                    cote = 2.3;
                    break;

                case -2:
                    cote = 2.2;
                    break;

                case -1:
                    cote = 2.1;
                    break;

                case 0:
                    cote = 2;
                    break;

                case 1:
                    cote = 1.9;
                    break;

                case 2:
                    cote = 1.8;
                    break;

                case 3:
                    cote = 1.7;
                    break;

                case 4:
                    cote = 1.6;
                    break;

                case 5:
                    cote = 1.5;
                    break;

                case 6:
                    cote = 1.4;
                    break;

                case 7:
                    cote = 1.3;
                    break;

                case 8:
                    cote = 1.2;
                    break;

                case 9:
                    cote = 1.1;
                    break;
            }

            return cote;
        }

        private double Draw(int first, int second)
        {
            double cote = 0;

            switch (first - second)
            {
                case -9:
                    cote = 3;
                    break;

                case -8:
                    cote = 2.75;
                    break;

                case -7:
                    cote = 2.5;
                    break;

                case -6:
                    cote = 2.25;
                    break;

                case -5:
                    cote = 2;
                    break;

                case -4:
                    cote = 1.82;
                    break;

                case -3:
                    cote = 1.64;
                    break;

                case -2:
                    cote = 1.46;
                    break;

                case -1:
                    cote = 1.28;
                    break;

                case 0:
                    cote = 1.1;
                    break;

                case 1:
                    cote = 1.28;
                    break;

                case 2:
                    cote = 1.46;
                    break;

                case 3:
                    cote = 1.64;
                    break;

                case 4:
                    cote = 1.82;
                    break;

                case 5:
                    cote = 2;
                    break;

                case 6:
                    cote = 2.25;
                    break;

                case 7:
                    cote = 2.5;
                    break;

                case 8:
                    cote = 2.75;
                    break;

                case 9:
                    cote = 3;
                    break;
            }

            return cote;
        }
    }
}