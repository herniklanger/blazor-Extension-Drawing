using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDrawing.Graphish
{
    public class Texture
    {
        public string[] textureFill { get; set;}
        public string[] textureOutLine { get; set;}
        public int[] gradFill { get; set; }
        public int[] gradOutLine { get; set; }
        public bool linearFill { get; set; }
        public bool linearOutLine { get; set; }
        public int borderWidth { get; set; }
        public Texture(int collor,bool Fill,int LineWidth)
        {
            linearFill = true;
            linearOutLine = true;
            gradFill = new int[4]{ 1, 1, 0, 0 };
            gradOutLine = gradFill;
            if(Fill)
            {
                textureFill = new string[1] {'#'+ collor.ToString("X6") };
            }else
            {
                textureOutLine = new string[1] { '#' + collor.ToString("X6") };
            }
            borderWidth = LineWidth;
        }
        public Texture(int collor,bool Fill,int TextSizePix,Fonts Fonten = Fonts.Arial,string align = "Left")
        {
            linearFill = true;
            linearOutLine = true;
            gradFill = new int[4] { 1, 1, 0, 0 };
            gradOutLine = gradFill;
            if (Fill)
            {
                Console.WriteLine(TextSizePix + " px" + Font.ToString(Fonten));
                textureFill = new string[2] { TextSizePix + " px" + Font.ToString(Fonten) , '#' + collor.ToString("X6") };
                textureOutLine = new string[1] { align };
            }
            else
            {
                textureFill = new string[1] { TextSizePix + "px" + Font.ToString(Fonten) };
                textureOutLine = new string[2] { align, '#' + collor.ToString("X6") };
            }
            borderWidth = 1;
        }
    }
}
