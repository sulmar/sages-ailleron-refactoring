using System;
using System.Collections.Generic;

namespace StatePattern
{
    // Abstract State
    public abstract class LightSwitchState
    {
        protected LightSwitch lightSwitch;

        public LightSwitchState(LightSwitch lightSwitch)
        {
            this.lightSwitch = lightSwitch;
        }

        // Handle
        public abstract void Push();

        // Handle
        public abstract bool CanPush();
     
    }

    // Concrete State A
    public class Off  : LightSwitchState
    {
        public Off(LightSwitch lightSwitch)
           : base(lightSwitch)
        {            
        }        

        public override bool CanPush()
        {
            return true;
        }

        public override void Push()
        {
            if (CanPush())
            {
                Console.WriteLine("załącz przekaźnik");

                lightSwitch.SetState(new On(lightSwitch));
            }

            throw new InvalidOperationException();
        }
    }

    // Concrete State B
    public class On : LightSwitchState
    {
        public On(LightSwitch lightSwitch) : base(lightSwitch)
        {
        }

        public override bool CanPush()
        {
            return true;
        }

        public override void Push()
        {
            Console.WriteLine("wyłącz przekaźnik");

            lightSwitch.SetState(new Off(lightSwitch));
        }
    }


    public class LightSwitch
    {
        public LightSwitchState State { get; private set; }

        public void SetState(LightSwitchState state)
        {
            this.State = state;
        }

        public LightSwitch()
        {
            State = new Off(this);
        }

        public void Push()
        {
            State.Push();
        }
        
    }

   

}
