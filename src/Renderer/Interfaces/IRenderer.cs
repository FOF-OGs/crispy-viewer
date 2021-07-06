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

using Shared.Structs;
using System.Windows;
using System.Windows.Media;

namespace Renderer.Interfaces
{
    public interface IRenderer
    {

        /// <summary>
        /// Width of draw area
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of draw area
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Draw single pixel.
        /// Not efficient!
        /// </summary>
        /// <param name="point">2D point</param>
        /// <param name="color">Color</param>
        public void SetPixel(Point2D point, RGB color);

        /// <summary>
        /// Draw rectangle with provided color.
        /// </summary>
        /// <param name="rect">Rectangle to draw</param>
        /// <param name="color">Color</param>
        public void SetRectangle(Int32Rect rect, RGB color);

        /// <summary>
        /// Draw rectangle with given color buffer (many colors).
        /// Most effiecient way to write.
        /// </summary>
        /// <param name="rect">Rectangle</param>
        /// <param name="stride">Stride</param>
        /// <param name="buffer">Color buffer</param>
        public void SetRectangle(Int32Rect rect, int stride, byte[] buffer);

        /// <summary>
        /// Clear draw area with provided color
        /// </summary>
        /// <param name="color">Color</param>
        public void Clear(RGB color);

        /// <summary>
        /// Get ImageSource.
        /// Used by CrispyViewer to display Image in WPF control.
        /// </summary>
        /// <returns>ImageSource</returns>
        public ImageSource GetImageSource();

        /// <param name="width">Width of area to draw</param>
        /// <returns>Stride</returns>
        public int GetStride(int width);

        /// <param name="width">Stride</param>
        /// <param name="width">Height of area to draw</param>
        /// <returns>Size of color buffer</returns>
        public int GetColorBufferSize(int stride, int height);

    }
}
