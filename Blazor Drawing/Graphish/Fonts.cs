using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDrawing.Graphish
{
    public enum Fonts
    {
        Arial,
        Roboto,
        TimesNewRoman,
        Times,
        CourierNew,
        Courier,
        Verdana,
        Georgia,
        Palatino,
        Garamond,
        Bookman,
        ComicSansMs,
        Candara,
        ArialBlack,
        Impact
    }
    public static class Font
    {
        public static string ToString(Fonts fonts)
        {
            string s = fonts.ToString();
            s = s.Replace("A", " a");
            s = s.Replace("B", " b");
            s = s.Replace("C", " c");
            s = s.Replace("D", " d");
            s = s.Replace("E", " e");
            s = s.Replace("F", " f");
            s = s.Replace("G", " g");
            s = s.Replace("H", " h");
            s = s.Replace("I", " i");
            s = s.Replace("J", " j");
            s = s.Replace("K", " k");
            s = s.Replace("L", " l");
            s = s.Replace("M", " m");
            s = s.Replace("N", " n");
            s = s.Replace("O", " o");
            s = s.Replace("P", " p");
            s = s.Replace("Q", " q");
            s = s.Replace("R", " r");
            s = s.Replace("S", " s");
            s = s.Replace("T", " t");
            s = s.Replace("U", " u");
            s = s.Replace("V", " v");
            s = s.Replace("W", " w");
            s = s.Replace("X", " x");
            s = s.Replace("Y", " y");
            s = s.Replace("Z", " z");
            return s;
        }
    }
}
