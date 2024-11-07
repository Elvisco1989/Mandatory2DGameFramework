using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Positive;

namespace Mandatory2DGameFramework.Wapons.AttackWeapon
{
    public class Sword : IWeapon
    {
        public int Hit { get; set; }

        public int Range { get; set; }

        public string? Name { get; set; } 

        public int GetDamage()
        {
            return 1;
        }

        public void AttackType()
        {
            Console.WriteLine("Sword Attack");
        }

        public void RecieveHit(PositiveNumber positiveNumber)
        {
            
        }
    }

}
