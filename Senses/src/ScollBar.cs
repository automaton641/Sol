using System;

namespace Senses
{
    public class ScrollBar : Widget
    {
        internal int maxValue;
        internal Orientation orientation;
        internal double viewProportion;
        internal double positionProportion;
        internal Position scrollPosition;
        internal Size scrollSize;
        public ScrollBar(Theme theme, Orientation orientation) : base(theme)
        {
            viewProportion = 1.0;
            this.orientation = orientation;
            positionProportion = 0.0;
        }
        internal override void Arrange(Size size, Position position)
        {
            base.Arrange(size, position);
            scrollPosition = new Position(this.position);
            if (orientation == Orientation.Vertical)
            {
                scrollSize = new Size(this.size.width, (int)(this.size.height*viewProportion));
                maxValue = this.size.height - scrollSize.height;
            }
            else
            {
                scrollSize = new Size((int)(this.size.width*viewProportion), this.size.height);
                maxValue = this.size.width - scrollSize.width;
            }
        }
        internal override void Draw(PixelDrawer pixelDrawer)
        {
            base.Draw(pixelDrawer);
            //Console.WriteLine("scrollPosition {0}", scrollPosition);
            pixelDrawer.DrawRectangle(scrollPosition, scrollSize, theme.Foreground);
        }
    }
}