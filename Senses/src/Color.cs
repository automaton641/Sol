using System;

namespace Senses
{
    public class SColor
    {
        internal uint color;
        internal byte[] bytes;
        public SColor(uint color)
        {
            this.color= color;
            bytes = BitConverter.GetBytes(color);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
        }
        public SColor(byte red, byte green, byte blue)
        {
            bytes = new byte[4]{0xff, red, green, blue};
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            this.color = BitConverter.ToUInt32(bytes, 0);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
        }
        public byte Alpha
        {
            get{ return bytes[0]; }
        }
        public byte Red
        {
            get{ return bytes[1]; }
        }
        public byte Green
        {
            get{ return bytes[2]; }
        }
        public byte Blue
        {
            get{ return bytes[3]; }
        }
        public override string ToString()
        {
            return "Color " + color.ToString("x") +
                "Color " + Alpha + " " + Red + " " + Green + " " + Blue;

        }
    }
}
