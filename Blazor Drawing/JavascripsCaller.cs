using Microsoft.JSInterop;
using BlazorDrawing.Graphish;
using System.Threading.Tasks;

namespace BlazorDrawing
{
    internal class JavascripsCaller
    {
        public IJSRuntime JSRuntime { get; set; }
        public JavascripsCaller(IJSRuntime js)
        {
            JSRuntime = js;
        }
        public async Task GraphishDarw(string canvasId, Element[] grapgish)
        {
            //string canvasId = CanvasId;
            //Element[] grapgish = Grapgish;
            await JSRuntime.InvokeVoidAsync("GrapgishExtension.DrawImage", canvasId, grapgish);
        }
        public async Task GraphishClar(string canvasId)
        {
            //string canvasId = CanvasId;
            //Element[] grapgish = Grapgish;
            await JSRuntime.InvokeVoidAsync("GrapgishExtension.ClearImage", canvasId);
        }
    }
}
