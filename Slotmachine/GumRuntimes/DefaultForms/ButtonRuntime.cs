using FlatRedBall.Gui;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Slotmachine.GumRuntimes.DefaultForms
{
    public partial class ButtonRuntime
    {
        partial void CustomInitialize () 
        {
            this.Click += HandleCLick;
        }
        private void HandleCLick(IWindow window)
        {
            Slotmachine.Passonclass.ButtonClicked = true;
        }
          
    }
}