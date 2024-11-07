using Mandatory2DGameFramework.CompositePattern_Weapon;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Positive;
using Mandatory2DGameFramework.PossitionOnEath;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Enemy : ICreature, IFighter
    {

        IPosition Position;
        public string Name { get; set; }
        public int HitPoints { get; set; }

        private IWeapon weapon;

        private ManyWeapon manyWeapon = new ManyWeapon();

        // Consider how many attack/defense weapons are allowed
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }
      

        public Enemy()
        {
            Name = string.Empty;
            HitPoints = 0;
            Attack = null;
            Defence = null;
            this.weapon = weapon;
        }

        public Enemy(IPosition position)
        {
            Position = position;
        }

        public void Loot(WorldObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (obj is AttackItem attackItem)
            {
                manyWeapon.AddWeapon(attackItem.weapon);
                Attack = new AttackItem(manyWeapon);
                Console.WriteLine($"{Name} has looted {attackItem.Name}");


            }
            else if (obj is DefenceItem defenceItem)
            {
                manyWeapon.AddWeapon(defenceItem.weapon);
                Defence = defenceItem;


                Console.WriteLine($"The Army has picked up {defenceItem.Name}");
            }
            else
            {
                throw new ArgumentException("Invalid object type");
            }
        }

        public void Move(char input)
        {
            if (Position == null)
            {
                throw new InvalidOperationException("Position is not initialized.");
            }

            Position = Position.GetPosition(input);

            if (Position == null)
            {
                throw new InvalidOperationException("GetPosition returned null.");
            }

            Position currentDirection = Position.GetOutPut(input);
            Console.WriteLine($"{Name} is now facing {currentDirection}");
        }

        public void DisplayWeapons()
        {
            Console.WriteLine($" {Name}  has looted the following weapons: {manyWeapon}");
        }


        public void RecieveHit(PositiveNumber Damage)
        {
            // Null check for Damage
            if (Damage == null)
            {
                Console.WriteLine("Error: Damage cannot be null.");
                return; // Exit early if Damage is null
            }

            // Now that we know Damage is not null, we can safely access Damage.Number
            int Damageint = Damage.Number;

            if (Defence != null)
            {
                // Use Defence's RecieveHit method with the PositiveNumber object
                Defence.RecieveHit(Damage);
            }
            else
            {
                // Access Damageint to get the integer damage amount
                Console.WriteLine($"Received {Damageint} damage, no defense item equipped.");

                // Reduce HitPoint using Damageint (the integer value of Damage)
                HitPoints = Math.Max(0, HitPoints - Damageint);

                // Output the remaining HP
                Console.WriteLine($"{Name} now has {HitPoints} HP left.");
            }




        }

        public bool IsDead()
        {
            if (HitPoints <= 0)
            {
                Console.WriteLine($"{Name} is dead");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AttackCreature(ICreature creature)
        {
            if (creature == null)
            {
                throw new ArgumentNullException(nameof(creature), "Target creature cannot be null.");
            }

            if (IsDead())
            {
                Console.WriteLine($"{Name} is dead and cannot attack.");
                return;
            }

            int damage;

            // Check if there's an AttackItem with a weapon
            if (Attack != null && Attack.weapon != null)
            {
                // Assume AttackItem or weapon has a method to get attack power or damage
                damage = Attack.weapon.GetDamage(); // Replace with the actual method to get damage
                Console.WriteLine($"{Name} attacks {creature} with {Attack.weapon.Name}, dealing {damage} damage.");
            }
            else
            {
                // Default damage if no weapon or Attack item is set
                damage = 10; // Arbitrary default damage
                Console.WriteLine($"{Name} attacks {creature} with bare hands, dealing {damage} damage.");
            }

            // Convert damage to PositiveNumber
            PositiveNumber damagePositive = new PositiveNumber(damage);

            // Apply damage to the creature
            creature.RecieveHit(damagePositive);

            // Check if the creature is dead
            if (creature.IsDead())
            {
                Console.WriteLine($"{creature} is dead.");
            }
        }

        public void AttachObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void DetachObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }
    }
}
