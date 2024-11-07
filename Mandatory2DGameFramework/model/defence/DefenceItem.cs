using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Positive;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem:WorldObject
    {
        //public string Name { get; set; }
        public int ReduceHitPoint { get; set; }
       public IWeapon weapon { get; set; }


        public DefenceItem(IWeapon weapon)
        {
            Name = weapon.Name;
            ReduceHitPoint = 0;
            this.weapon = weapon;

        }

        public void RecieveHit(PositiveNumber Int)
        {
            weapon.RecieveHit(Int);
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
