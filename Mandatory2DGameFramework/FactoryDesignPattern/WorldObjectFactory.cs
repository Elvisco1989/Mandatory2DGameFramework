using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.FactoryDesignPattern
{
    //public class WorldObjectFactory : IWorldObjects
   public class WorldObjectFactory
    {
       

        public  WorldObject CreateWorldObject(string type, IWeapon weapon)
        {
            switch (type.ToLower())
            {
                case "attackitem":
                    if (weapon == null)
                    {
                        throw new ArgumentNullException(nameof(weapon));
                    }
                    return new AttackItem(weapon);
                case "defenceitem":
                    return new DefenceItem(weapon);
                default:
                    throw new ArgumentException("Invalid type", nameof(type));
            }
        }

       
    }
}
