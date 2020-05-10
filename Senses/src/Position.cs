namespace Senses
{
    public class Position
    {
        internal int x;
        internal int y;
        public Position()
        {

        }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position(Position position)
        {
            this.x = position.x;
            this.y = position.y;
        }
        public Position(Position position, int offset, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                this.x = position.x + offset;
                this.y = position.y;
            }
            else
            {
                this.x = position.x;
                this.y = position.y + offset;
            }
        }
        public void Update(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Update(Position position)
        {
            x = position.x;
            y = position.y;
        }
        public override string ToString()
        {
            return "Position " + x + " " + y;
        }
    }
}
