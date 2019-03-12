using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace GravityChallenger.Global
{
    public class Input
    {
        // FIELDS 
        private TouchCollection inputTouch;

        // PROPERTIES

        // CONSTRUCTORS
        public Input()
        {
        }
        

        // UPDATE & DRAW 
        public void Update()
        {
            this.inputTouch = TouchPanel.GetState();
        }

        public void Draw()
        {
        }

        // METHODS

        public bool IsPressed()
        {
            foreach (var touch in this.inputTouch)
            {
                // You're looking for when they finish a drag, so only check
                // released touches.
                if (touch.State != TouchLocationState.Released)
                    return false;

                TouchLocation prevLoc;

                // Sometimes TryGetPreviousLocation can fail. Bail out early if this happened
                // or if the last state didn't move
                if (!touch.TryGetPreviousLocation(out prevLoc) || prevLoc.State != TouchLocationState.Moved)
                    return false;


                // get your delta
                var delta = touch.Position - prevLoc.Position;

                /* don't do something if the user drags 1 pixel.
                if (delta.LengthSquared() < 1)
                    return false; */ 

                Console.WriteLine("Touchscreen is pressed!");
                return true;
                
            }

            return false;
        }


        public Vector2 GetPosition()
        {
            if (inputTouch.Count > 0)
            {
                // Only Fire Select Once it's been released
                // if (inputTouch[0].State == TouchLocationState.Moved || inputTouch[0].State == TouchLocationState.Pressed)
                if (inputTouch[0].State == TouchLocationState.Pressed)
                {
                    Console.WriteLine("\n{0}\n", inputTouch[0].Position);
                }

                return inputTouch[0].Position;
            }

            return new Vector2(0, 0);
        }
    }
}