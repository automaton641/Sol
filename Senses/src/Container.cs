using System.Collections.Generic;
using System;

namespace Senses
{
    public class Container : Widget
    {
        internal double growAdder;
        internal Orientation orientation;
        List<Widget> widgets;
        public Container(Orientation orientation, Theme theme) : base(theme)
        {
            Build(orientation);
        }
        private void Build(Orientation orientation)
        {
            this.orientation = orientation;
            widgets = new List<Widget>();
            growAdder = 0;
        }
        internal override void Arrange(Size size, Position position) 
        {
            base.Arrange(size, position);
            //Console.WriteLine(this.size);
            List<Size> sizes = new List<Size>();
            int width, height, adder = 0;
            //Console.WriteLine("growAdder {0}", growAdder);
            foreach (Widget widget in widgets)
            {
                //Console.WriteLine("growRatio {0}", widget.growRatio);
                if (orientation == Orientation.Vertical)
                {
                    height = (int)(((double)size.height) * widget.growRatio / growAdder);
                    width = size.width;
                    adder += height;
                    sizes.Add(new Size(width, height));
                }
                else
                {
                    width = (int)(((double)size.width) * widget.growRatio / growAdder);
                    height = size.height;
                    adder += width;
                    sizes.Add(new Size(width, height));
                }
            }
            int compensator;
            if (orientation == Orientation.Vertical) {
                compensator = size.height - adder;
            } else {
                compensator = size.width - adder;
            }
            //Console.WriteLine("compensator {0}", compensator);
            int index = 0;
            for (index = 0; index < compensator; index++)
            {
                if (orientation == Orientation.Vertical) {
                    sizes[index].height++;
                } else {
                    sizes[index].width++;
                }
            }
            adder = 0;
            index = 0;
            foreach (Widget widget in widgets)
            {
                if (orientation == Orientation.Vertical) {
                    widget.Arrange(sizes[index], new Position(position.x, position.y + adder));
                    adder += sizes[index].height;
                } else {
                    widget.Arrange(sizes[index], new Position(position.x + adder, position.y));
                    adder += sizes[index].width;                    
                }
                index++;
            }
        }
        public void Revalidate() {
            Arrange(size, position);
            window?.Repaint();
        }
        internal override void Draw(PixelDrawer pixelDrawer)
        {
            base.Draw(pixelDrawer);
            foreach (Widget widget in widgets)
            {
                widget.Draw(pixelDrawer);
            }
        }
        public void Add(Widget widget)
        {
            growAdder += widget.growRatio;
            widget.window = window;
            widgets.Add(widget);
            Revalidate();
        }
    }
}
