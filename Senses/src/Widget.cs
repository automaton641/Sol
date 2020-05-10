namespace Senses
{
    public class Widget
    {
        internal Window window;
        internal Position position;
        internal Size size;
        internal double growRatio;
        internal Theme theme;
        public Widget(Theme theme) 
        {
            Build(0, 0, 1, 1, theme);
        }
        public Widget(int x, int y, int width, int height, Theme theme)
        {
            Build(x, y, width, height, theme);
        }
        private void Build(int x, int y, int width, int height, Theme theme)
        {
            this.theme = theme;
            growRatio = 1.0;
            position = new Position(x, y);
            size = new Size(width, height);
        }
        internal virtual void Arrange(Size size, Position position) 
        {
            this.size.Update(size);
            this.position.Update(position);
        }

        internal virtual void Draw(PixelDrawer pixelDrawer)
        {
            pixelDrawer.DrawRectangle(position, size, theme.Background);
        }
    }
}
