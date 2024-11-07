using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Positive;

namespace Mandatory2DGameFramework.CompositePattern_Weapon
{
    public class ManyWeapon : IWeapon
    {
        private List<IWeapon> weapons = new List<IWeapon>();

        public int Hit { get; set; }

        public int Range { get; set; }

        public string? Name { get; set; }

        public void AttackType()
        {
            foreach (var weapon in weapons)
            {
                weapon.AttackType();
            }

        }

        public int GetDamage()
        {
            int totalDamage = 0;
            foreach (var weapon in weapons)
            {
                totalDamage += weapon.GetDamage();
            }
            return totalDamage;
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public override string ToString()
        {
            if (weapons.Count == 0)
            {
                return "No weapons";
            }

            var weaponDescriptions = new StringBuilder();
            foreach (var weapon in weapons)
            {
                weaponDescriptions.AppendLine($"Weapon: {weapon.Name}, Hit: {weapon.Hit}, Range: {weapon.Range}");
            }

            return weaponDescriptions.ToString();
        }

        public void RecieveHit(int hit)
        {
            throw new NotImplementedException();
        }

        public void RecieveHit(PositiveNumber Int)
        {
            throw new NotImplementedException();
        }
    }
}
