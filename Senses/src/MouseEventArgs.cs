using System;

namespace Senses
{
    public class MouseEventArgs : EventArgs
    {
        internal Button button;
        internal SButtonState state;
        public MouseEventArgs(Button button, SButtonState state)
        {
            this.button = button;
            this.state = state;
        }
    }
}