using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Positive;

namespace Mandatory2DGameFramework.Wapons.AttackWeapon
{
    public class Bow : IWeapon
    {
        public int Hit { get; set; }

        public int Range { get; set; }

        public string? Name { get; set; } 

        public void AttackType()
        {
            Console.WriteLine("Bow Attack");

        }

        public int GetDamage()
        {
            return 2;
        }

        public void RecieveHit(PositiveNumber number)
        {
            
        }
    }
}
