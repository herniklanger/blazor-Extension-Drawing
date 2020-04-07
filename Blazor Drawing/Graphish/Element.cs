using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDrawing.Graphish
{
    public class Element
    {
        public Texture Color { get; set; }
        public Graphish shape { get; set; }
        public string Text { get; set; }
        public int[] xposision { get; set; }
        public int[] yposision { get; set; }
    }
    public enum Graphish:int
    {
        Circle, Ellipse, Lines, Polygon, Text
    }
}
