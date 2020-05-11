using System;
using System.Collections.Generic;

namespace Senses
{
    public class SMouseState
    {
        public Dictionary<Button, SButtonState> dictionary;
        public SMouseState()
        {
            dictionary = new Dictionary<Button, SButtonState>();
            dictionary.Add(Button.LeftMouse, SButtonState.Released);
            dictionary.Add(Button.RightMouse, SButtonState.Released);
        }
    }    
}