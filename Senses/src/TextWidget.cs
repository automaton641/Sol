using System;
using System.Drawing;
namespace Senses
{
    public class TextWidget : Widget
    {
        internal Bitmap textImage;
        internal string text;
        public string Text
        {
            set 
            {
                if (!text.Equals(value))
                {
                    text = value;
                    UpDateTextImage(); 
                    window?.Repaint();
                }
            }
            get {return text;}
        }
        public TextWidget(string text, Theme theme) : base(theme)
        {
            this.text = text;
            UpDateTextImage();
        }
        internal void UpDateTextImage()
        {
            SColor foreground = theme.Foreground;
            Color systemForeground = Color.FromArgb(foreground.Red, foreground.Green, foreground.Blue);
            Color systemBackground = Color.FromArgb(0,0,0,0);
            textImage = DrawText(text, theme.Font, systemForeground, systemBackground);
        }
        internal override void Draw(PixelDrawer pixelDrawer)
        {
            base.Draw(pixelDrawer);
            int x0 = position.x + size.width / 2 - textImage.Width / 2;
            int y0 = position.y + size.height / 2 - textImage.Height / 2; 
            Color systemColor;
            SColor color;
            for (int y = 0; y < textImage.Height; y++)
            {
                for (int x = 0; x < textImage.Width; x++)
                {
                    systemColor = textImage.GetPixel(x,y);
                    if (systemColor.A > 0)
                    {
                        color = new SColor(systemColor.R, systemColor.G, systemColor.B);
                        pixelDrawer.DrawPixel(x0 + x, y0 + y, color);
                    }
                    //Console.WriteLine("pixel {0}, {1} = {2}", x, y, textImage.GetPixel(x,y));
                } 
            }

        }
        internal Bitmap DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Bitmap img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int) textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);
            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
    }
}
