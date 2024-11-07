using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject
    {
        //public string  Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }
        public IWeapon weapon { get; set; }

        //public AttackItem()
        //{
        //    Name = string.Empty;
        //    Hit = 0;
        //    Range = 0;
        //}

        public AttackItem(IWeapon weapon)
        {
            this.weapon = weapon;
            Name = weapon.Name;
            //Hit = weapon.Hit;
            //Range = weapon.Range;
            Lootable = true;
            Removeable = true;
        }

        //public override string ToString()
        //{
        //    return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        //}

        public void Use()
        {
            Console.WriteLine($"Using weapon: {weapon.Name}, dealing {weapon.Hit} damage, with range {weapon.Range}");
        }


    }
}
