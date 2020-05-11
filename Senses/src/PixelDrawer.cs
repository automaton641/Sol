namespace Senses
{
    public class PixelDrawer
    {
        internal Size size;
        internal Position position;
        internal Size constrainedSize;
        internal Position constrainedPosition;
        internal uint[] pixels;
        public PixelDrawer(uint[] pixels, int width, int height)
        {
            this.pixels = pixels;
            size = new Size(width, height);
            position = new Position();
        }
        public void Fill(SColor color)
        {
            DrawRectangle(position, size, color);
        }
        public void DrawPixel(int x, int y, SColor color)
        {
            if (x < 0|| y < 0 || x >= size.width || y >= size.height)
            {
                return;
            }
            if (constrainedPosition != null && constrainedSize != null)
            {
                if (x < constrainedPosition.x || y < constrainedPosition.y ||
                    x >= constrainedPosition.x + constrainedSize.width || y >= constrainedPosition.y + constrainedSize.height)
                {
                    return;
                }
            }
            int index = y * size.width + x;
            pixels[index] = color.color;
        }
        public void DrawRectangle(Position position, Size size, SColor color)
        {
            int y0 = position.y;
            int y1 = y0 + size.height;
            int x0 = position.x;
            int x1 = x0 + size.width;
            for (int y = y0; y < y1; y++)
            {
                for (int x = x0; x < x1; x++)
                {
                    DrawPixel(x, y, color);
                }  
            }
        }
    }
}
