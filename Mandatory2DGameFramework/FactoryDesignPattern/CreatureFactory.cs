using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.PossitionOnEath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.FactoryDesignPattern
{
    public class CreatureFactory 
    {
        private IPosition _position;

        public CreatureFactory(IPosition position)
        {
            _position = position;
        }

        public  ICreature GetCreature(string creatureType)
        {
            switch (creatureType)
            {
                case "Civilian":
                    Console.WriteLine("Civilian created");
                    return new Civilian(_position);
                case "Army":
                    Console.WriteLine("Army created ");
                    return new Army(_position);
                case "Animals":
                    Console.WriteLine("Animals created");
                    return new Animals(_position);
                case "Enemy":
                    Console.WriteLine("Enemy created");
                    return new Enemy(_position);
                default:
                    return null;
            }
        }

       
    }
}
