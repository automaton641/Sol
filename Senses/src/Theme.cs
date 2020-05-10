using System;
using System.Drawing;
using System.Drawing.Text;
namespace Senses
{
    public class Theme
    {
        private SColor background;
        private SColor foreground;
        private Font font;
        PrivateFontCollection fontCollection;
        public Theme(SColor background, SColor foreground, Font font)
        {
            Build(background, foreground, font);
        }
        public Theme()
        {
            SColor background = new SColor(0xff000000);
            SColor foreground = new SColor(0xffffffff);
            fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("resources/fonts/JetBrainsMono-1.0.3/ttf/JetBrainsMono-ExtraBold.ttf");
            Build(background, foreground, new Font(fontCollection.Families[0], 16));
        }
        private void Build(SColor background, SColor foreground, Font font)
        {
            this.background = background;
            this.foreground = foreground;
            this.font = font;
        }
        public Font Font
        {
            get{ return font; }
        }
        public SColor Foreground
        {
            get{ return foreground; }
        }
        public SColor Background
        {
            get{ return background; }
        }
    }
}
