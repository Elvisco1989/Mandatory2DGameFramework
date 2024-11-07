using Mandatory2DGameFramework.CompositePattern_Weapon;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Positive;
using Mandatory2DGameFramework.PossitionOnEath;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;

namespace Mandatory2DGameFramework.model.Cretures
{
    /// <summary>
    /// Represents an Army creature that can fight, move, and manage its inventory of weapons and defense items.
    /// Implements ICreature and IFighter interfaces.
    /// </summary>
    public class Army : ICreature, IFighter
    {
        /// <summary>
        /// The current position of the Army on the map.
        /// </summary>
        private IPosition Position;

        /// <summary>
        /// The name of the Army.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current hit points (HP) of the Army. If HP reaches zero, the Army is considered dead.
        /// </summary>
        public int HitPoints { get; set; }

        /// <summary>
        /// The main weapon the Army uses for attacking.
        /// </summary>
        private IWeapon weapon;

        /// <summary>
        /// A collection of multiple weapons that the Army can carry.
        /// </summary>
        private ManyWeapon manyWeapon = new ManyWeapon();

        /// <summary>
        /// Attack item equipped by the Army.
        /// </summary>
        public AttackItem? Attack { get; set; }

        /// <summary>
        /// Defense item equipped by the Army.
        /// </summary>
        public DefenceItem? Defence { get; set; }

        /// <summary>
        /// List of observers interested in the Army's death events.
        /// </summary>
        private readonly List<IObserver> _observers = new List<IObserver>();

        /// <summary>
        /// Initializes a new instance of the Army class with default values.
        /// </summary>
        public Army()
        {
            Name = string.Empty;
            HitPoints = 100;
            Attack = null;
            Defence = null;
            this.weapon = weapon;
        }

        /// <summary>
        /// Initializes a new instance of the Army class with a specified position.
        /// </summary>
        /// <param name="position">The initial position of the Army.</param>
        public Army(IPosition position)
        {
            Position = position;
        }

        /// <summary>
        /// Allows the Army to loot a specified WorldObject and add it to its inventory.
        /// </summary>
        /// <param name="obj">The WorldObject to be looted.</param>
        public void Loot(WorldObject obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

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

        /// <summary>
        /// Moves the Army to a new position based on the input character.
        /// </summary>
        /// <param name="input">The character input to determine the new position.</param>
        public void Move(char input)
        {
            if (Position == null) throw new InvalidOperationException("Position is not initialized.");

            Position = Position.GetPosition(input);
            if (Position == null) throw new InvalidOperationException("GetPosition returned null.");

            Position currentDirection = Position.GetOutPut(input);
            Console.WriteLine($"{Name} is now facing {currentDirection}");
        }

        /// <summary>
        /// Displays all weapons currently looted by the Army.
        /// </summary>
        public void DisplayWeapons()
        {
            Console.WriteLine($"{Name} has looted the following weapons: {manyWeapon}");
        }

        /// <summary>
        /// Returns a string representation of the Army's hit points and weapons.
        /// </summary>
        /// <returns>A string with the Army's HP and weapons.</returns>
        public override string ToString()
        {
            return $"Army with {HitPoints} HP and weapons: {manyWeapon.ToString()}";
        }

        /// <summary>
        /// Processes the Army receiving a hit, reducing HP based on the amount of damage.
        /// If Defence is equipped, it uses the Defence item to absorb part of the hit.
        /// </summary>
        /// <param name="Damage">The amount of damage as a PositiveNumber.</param>
        public void RecieveHit(PositiveNumber Damage)
        {
            if (Damage == null)
            {
                Console.WriteLine("Error: Damage cannot be null.");
                return;
            }

            int Damageint = Damage.Number;
            if (Defence != null)
            {
                Defence.RecieveHit(Damage);
            }
            else
            {
                Console.WriteLine($"Received {Damageint} damage, no defense item equipped.");
                HitPoints -= Damageint;
                Console.WriteLine($"{Name} now has {HitPoints} HP left.");
            }
        }

        /// <summary>
        /// Attacks another creature, dealing damage based on the equipped weapon or default damage.
        /// </summary>
        /// <param name="creature">The creature to be attacked.</param>
        public void AttackCreature(ICreature creature)
        {
            if (creature == null) throw new ArgumentNullException(nameof(creature), "Target creature cannot be null.");

            if (IsDead())
            {
                Console.WriteLine($"{Name} is dead and cannot attack.");
                return;
            }

            int damage;
            if (Attack != null && Attack.weapon != null)
            {
                damage = Attack.weapon.GetDamage();
                Console.WriteLine($"{Name} attacks {creature} with {Attack.weapon.Name}, dealing {damage} damage.");
            }
            else
            {
                damage = 10;
                Console.WriteLine($"{Name} attacks {creature} with bare hands, dealing {damage} damage.");
            }

            PositiveNumber damagePositive = new PositiveNumber(damage);
            creature.RecieveHit(damagePositive);

            if (creature.IsDead())
            {
                Console.WriteLine($"{creature} is dead.");
            }
        }

        /// <summary>
        /// Attaches an observer to the Army, allowing it to receive notifications on death.
        /// </summary>
        /// <param name="observer">The observer to be added.</param>
        public void AttachObserver(IObserver observer)
        {
            if (observer != null && !_observers.Contains(observer))
                _observers.Add(observer);
        }

        /// <summary>
        /// Detaches an observer from the Army.
        /// </summary>
        /// <param name="observer">The observer to be removed.</param>
        public void DetachObserver(IObserver observer)
        {
            if (observer != null)
                _observers.Remove(observer);
        }

        /// <summary>
        /// Notifies all attached observers of the Army's death.
        /// </summary>
        private void NotifyDeath()
        {
            foreach (var observer in _observers)
            {
                observer.OnCreatureDeath(this);
            }
        }

        /// <summary>
        /// Checks if the Army is dead based on its HitPoints. If dead, notifies all observers.
        /// </summary>
        /// <returns>True if the Army is dead, otherwise false.</returns>
        public bool IsDead()
        {
            bool isDead = HitPoints <= 0;
            if (isDead)
            {
                Console.WriteLine($"{Name} is dead.");
                NotifyDeath();
            }
            return isDead;
        }
    }
}
