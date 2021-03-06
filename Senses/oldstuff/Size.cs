namespace SensesOld
{
    public class Size
    {
        private int width;
        private int height;
        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Size(Size size, double proportion, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                width = (int)(size.Width * proportion);
                height = size.Height;
            }
            else
            {
                height = (int)(size.Height * proportion);
                width = size.Width;
            }
        }
        
        public int Width
        {
            get {return width;}
            set {width = value;}
        }
        public int Height
        {
            get {return height;}
            set {height = value;}
        }
    }
}
