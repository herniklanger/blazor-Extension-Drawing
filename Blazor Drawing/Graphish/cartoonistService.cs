using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDrawing.Graphish
{
    public class cartoonistService
    {
        public static Texture Standrat {get;} = new Texture(0, false, 3);
        public static Texture TextStandrat {get;} = new Texture(0, true,12, Fonts.TimesNewRoman);
        string canvasId { get; }
        public List<Element> elements { get; set; }
        private JavascripsCaller js { get;set; }
        internal cartoonistService(string CanvasId, JavascripsCaller Caller)
        {
            elements = new List<Element>();
            js = Caller;
            canvasId = CanvasId;
        }
        public cartoonistService(string CanvasId, IJSRuntime Caller)
        {
            js = new JavascripsCaller(Caller);
            elements = new List<Element>();
            canvasId = CanvasId;
        }
        public cartoonistService DrawLine(int x1,int y1, int x2,int y2, Texture texture = null)
        {
            elements.Add(new Element { 
                Color = texture ?? Standrat, 
                shape = Graphish.Lines, 
                xposision = new int[2] { x1, x2 }, 
                yposision = new int[2] { y1, y2 }
            });
            return this;
        }
        public cartoonistService DrawPolygon(int[] xCor, int[] yCor, Texture texture = null)
        {
            elements.Add(new Element { 
                Color = texture??Standrat, 
                shape = Graphish.Polygon, 
                xposision = xCor, 
                yposision = yCor
            });
            return this;
        }
        public cartoonistService DrawCurkel(int x, int y, int radius, Texture texture = null)
        {
            elements.Add(new Element
            {
                Color = texture ?? Standrat,
                shape = Graphish.Circle,
                xposision = new int[3] { x, 0, radius },
                yposision = new int[2] { y, 2 }
            });
            return this;
        }
        public cartoonistService DrawCurkelSlice(int x, int y, int startRadian, int slutRadian, int radius, Texture texture = null)
        {
            elements.Add(new Element
            {
                Color = texture ?? Standrat,
                shape = Graphish.Circle,
                xposision = new int[3] { x, startRadian, radius },
                yposision = new int[2] { y, slutRadian }
            });
            return this;
        }
        public cartoonistService DrawEllips(int x, int y, int radiusX, int radiusY, Texture texture = null)
        {
            elements.Add(new Element
            {
                Color = texture ?? Standrat,
                shape = Graphish.Ellipse,
                xposision = new int[3] { x, radiusX, 0 },
                yposision = new int[3] { y, radiusY, 2 }
            });
            return this;
        }
        public cartoonistService DrawEllipsSlice(int x, int y, int radiusX, int radiusY, int startRadian, int slutRadian, Texture texture = null)
        {
            elements.Add(new Element
            {
                Color = texture ?? Standrat,
                shape = Graphish.Ellipse,
                xposision = new int[3] { x, radiusX, startRadian },
                yposision = new int[3] { y, radiusY, slutRadian }
            });
            return this;
        }
        public cartoonistService DrawText(string Text, int XLeft,int YBotto, Texture texture = null)
        {
            elements.Add(new Element
            {
                Color = texture ?? TextStandrat,
                shape = Graphish.Text,
                Text = Text,
                xposision = new int[]{ XLeft },
                yposision = new int[]{ YBotto }
            });
            return this;
        }

        /////////////////////////////////////
        
        Task drawing { get; set; }
        public void Save()
        {
            if(drawing != null && drawing.Status == TaskStatus.Running)
            {
                drawing.Wait();
            }
            drawing = js.GraphishDarw(canvasId, elements.ToArray());
            elements = new List<Element>();
        }
        public void Draw()
        {
            Save();
        }
        public void Clear()
        {
            if (drawing != null && drawing.Status == TaskStatus.Running)
            {
                drawing.Dispose();
            }
            drawing = js.GraphishClar(canvasId);
        }
    }
}
