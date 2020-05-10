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
        }
        public SColor(byte red, byte green, byte blue)
        {
            bytes = new byte[4]{0xff, red, green, blue};
            this.color = BitConverter.ToUInt32(bytes, 0);
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
        
    }
}
