using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Decorator_Pattern_WeaponShiel;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Positive;

namespace Mandatory2DGameFramework.Wapons.DefenceWeapon
{
    //public class Amor : DefenseDecorator

         public class Amor : IWeapon
    {
       

        public int Hit { get; set; }
        public int Range { get; set; }
        public string? Name { get; set; }

        public void AttackType()
        {
            throw new NotImplementedException();
        }

        public int GetDamage()
        {
            return 5;
        }

        public void RecieveHit(PositiveNumber positiveNumber)
        {
            

           
        }


    }

}
