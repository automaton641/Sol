namespace Senses
{
    public class Size
    {
        internal int width;
        internal int height;
        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Size(Size size, double proportion, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                width = (int)(size.width * proportion);
                height = size.height;
            }
            else
            {
                height = (int)(size.height * proportion);
                width = size.width;
            }
        }
        public void Update(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void Update(Size size)
        {
            width = size.width;
            height = size.height;
        }
        public override string ToString()
        {
            return "Size " + width + " " + height;
        }
    }
}
