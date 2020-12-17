using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            // TODO: Check this
            if (this.BulletsCount >= 10)
            {
                this.BulletsCount -= 10;
                return 10;
            }

            return 0;
        }
    }
}
