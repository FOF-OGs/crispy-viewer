/*
 * ===========================================================
 * CrispyViewer by FOF OGs
 * Sandro Sobczyński <sandro.sobczynski@gmail.com>
 * Licenced under Apache License 2.0
 * ===========================================================
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” 
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
 * THE POSSIBILITY OF SUCH DAMAGE.
 */

using Renderer.Interfaces;
using Shared.Structs;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Renderer
{
    public class MainRenderer : IRenderer
    {

        public MainRenderer(double width, double height)
        {
            var palette = new BitmapPalette(new List<Color> { Color.FromRgb(255, 255, 255) });
            _bitmap = new((int)width, (int)height, 100, 100, PixelFormats.Rgb24, palette);
        }

        // Vars

        public int Width { get => (int)_bitmap.Width; }
        public int Height { get => (int)_bitmap.Height; }
        private readonly WriteableBitmap _bitmap;
        private int _bpp { get => (_bitmap.Format.BitsPerPixel + 7) / 8; }


        // Funcs

        public void SetPixel(Point2D point, RGB color)
        {
            var rect = new Int32Rect(point.X, point.Y, 1, 1);
            SetRectangle(rect, color);
        }

        public void SetRectangle(Int32Rect rect, RGB color)
        {
            var stride = GetStride(rect.Width);
            var size = GetColorBufferSize(stride, rect.Height);
            var buffer = new byte[size];
            var idx = 0;
            for (int i = 0; i < rect.Width; i++)
                for (int j = 0; j < rect.Height; j++)
                {
                    buffer[idx++] = color.R;
                    buffer[idx++] = color.G;
                    buffer[idx++] = color.B;
                }
            SetRectangle(rect, stride, buffer);
        }

        public void SetRectangle(Int32Rect rect, int stride, byte[] buffer)
        {
            _bitmap.WritePixels(new Int32Rect(0, 0, rect.Width, rect.Height), buffer, stride, rect.X, rect.Y);
        }

        public ImageSource GetImageSource() { return _bitmap; }

        public void Clear(RGB color) { SetRectangle(new Int32Rect(0, 0, Width, Height), color); }

        public int GetStride(int width) { return _bpp * width; }

        public int GetColorBufferSize(int stride, int height) { return stride * height; }

    }
}
