using Mandatory2DGameFramework.Positive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interface
{
    public interface IWeapon
    {
        int Hit { get; set; }
        int Range { get; set; }
        string? Name { get; set; }

       
        int GetDamage();
        void AttackType();

        public void RecieveHit(PositiveNumber Int);
    }
}
