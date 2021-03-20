using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;



namespace Slotmachine.Screens
{
    public partial class GameScreen
    {

        void CustomInitialize()
        {
            //var test = Slotmachine.Factories.ANIMATIONROLLINGFactory.CreateNew();

        }

        void CustomActivity(bool firstTimeCalled)
        {
            ButtonChecker();

        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void ButtonChecker()
        {
            if (Passonclass.ButtonClicked == true)
            {
                Rollingstones();
                Passonclass.ButtonClicked = false;
            }
        }
        void Rollingstones() //i couldnt resist
        {
            Slot1Instance.InterpolateToState(Slotmachine.Entities.Slot1.VariableState.ROLLING, 1);
            Slot2Instance.InterpolateToState(Slotmachine.Entities.Slot2.VariableState.ROLLING, 1);
            Slot3Instance.InterpolateToState(Slotmachine.Entities.Slot3.VariableState.ROLLING, 1);
            //Console.WriteLine("SUCCES");
        }
    }
}
