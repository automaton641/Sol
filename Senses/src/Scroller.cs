using System;

namespace Senses
{
    public class Scroller : Widget
    {
        internal Widget widget;
        internal ScrollBar horizontalScrollBar;
        internal ScrollBar verticalScrollBar;
        internal Size constrainedSize;

        public Scroller(Widget widget, Theme theme) : base(theme)
        {
            Widget = widget;
            horizontalScrollBar = new ScrollBar(theme, Orientation.Horizontal);
            verticalScrollBar = new ScrollBar(theme, Orientation.Vertical);
            constrainedSize = new Size();
        }
        public Widget Widget
        {
            set
            {
                widget = value;
                widget.Arrange(new Size(size.width - 16, size.height - 16),position);
            }
        }
        internal override void Arrange(Size size, Position position)
        {
            base.Arrange(size, position);
            constrainedSize.Update(this.size.width - 16, this.size.height -16);
            widget.Arrange(constrainedSize, position);
            if (widget.DesiredSize.width < constrainedSize.width)
            {
                horizontalScrollBar.viewProportion = 1.0;                
            }
            else
            {
                horizontalScrollBar.viewProportion = (double)(constrainedSize.width) / (double)(widget.DesiredSize.width);                
            }
            //Console.WriteLine("horizontalScrollBar.viewProportion {0}", horizontalScrollBar.viewProportion);
            if (widget.DesiredSize.height < constrainedSize.height)
            {
                verticalScrollBar.viewProportion = 1.0;                
            }
            else
            {
                verticalScrollBar.viewProportion = (double)(constrainedSize.height) / (double)(widget.DesiredSize.height);   
            }
            //Console.WriteLine("verticalScrollBar.viewProportion {0}", verticalScrollBar.viewProportion);
            horizontalScrollBar.Arrange(new Size(constrainedSize.width, 16),
                new Position(this.position.x, this.position.y+constrainedSize.height));
            verticalScrollBar.Arrange(new Size(16, constrainedSize.height),
                new Position(this.position.x + constrainedSize.width, this.position.y));
            //Console.WriteLine("horizontalScrollBar.maxValue {0}", horizontalScrollBar.maxValue);
            HorizontalValue = horizontalScrollBar.maxValue / 2;
        }
        internal override void Draw(PixelDrawer pixelDrawer)
        {
            base.Draw(pixelDrawer);
            horizontalScrollBar.Draw(pixelDrawer);
            verticalScrollBar.Draw(pixelDrawer);
            pixelDrawer.DrawRectangle(new Position(position.x + constrainedSize.width, position.y + constrainedSize.height), new Size(16, 16), theme.Foreground);
            pixelDrawer.constrainedPosition = position;
            pixelDrawer.constrainedSize = constrainedSize;
            widget.Draw(pixelDrawer);
            pixelDrawer.constrainedPosition = null;
            pixelDrawer.constrainedSize = null;
        }
        public int HorizontalValue
        {
            set
            {
                Console.WriteLine("horizontalScrollBar.maxValue {0}", horizontalScrollBar.maxValue);
                if (value < 0)
                {
                    horizontalScrollBar.scrollPosition.x = horizontalScrollBar.position.x;                   
                }
                else if (value > horizontalScrollBar.maxValue)
                {
                     horizontalScrollBar.scrollPosition.x = horizontalScrollBar.position.x + horizontalScrollBar.maxValue;
                }
                else
                {
                    horizontalScrollBar.scrollPosition.x = horizontalScrollBar.position.x + value;
                }
                widget.position.Update(position.x - HorizontalValue + horizontalScrollBar.position.x, widget.position.y);
            }
            get {return horizontalScrollBar.scrollPosition.x;}
        }
    }
}