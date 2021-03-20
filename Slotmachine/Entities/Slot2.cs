using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace Slotmachine.Entities
{
    public partial class Slot2
    {
        double time = 3;
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {
            if (CurrentState == VariableState.ROLLING)
            {
                time -= TimeManager.SecondDifference;
            }
            if (time <= 0)
            {
                SpriteInstanceCurrentChainName = null;
                VariableState[] states = new VariableState[5] { VariableState.FRB_iconshowing, VariableState.adiamondshowing, VariableState.abariguessshowing, VariableState.somethingshowing, VariableState.Veilstone_Corner_Moon_StoneShowing };
                var goyoucandoitNOT = FlatRedBallServices.Random.In(states);
                Passonclass.slot2er = goyoucandoitNOT.Name;
                InterpolateToState(goyoucandoitNOT, 0);
                time = 3;
            }

        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
