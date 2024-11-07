using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Positive;
using static System.Net.Mime.MediaTypeNames;

namespace Mandatory2DGameFramework.Wapons.AttackWeapon
{
    public class Gun : IWeapon
    {
        public int Hit { get; set;  }

        public int Range { get; set; }

        public string? Name { get; set; }

        public int GetDamage()
        {
            return 3;
        }

        public void AttackType()
        {
            Console.WriteLine("Gun Attack");
        }

        public void RecieveHit(PositiveNumber Damage)
        {
            
        }
    }

}
