using Mandatory2DGameFramework.Interface;
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
    public class Civilian : ICreature

    {
        IPosition Position;

        public Civilian(IPosition position)
        {
            Position = position;
        }

        public string? Name { get; set; }
        public int HitPoints { get; set; }

        public void AttachObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void DetachObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void DisplayWeapons()
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public void Loot(WorldObject obj)
        {
            throw new NotImplementedException();
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
            Console.WriteLine($"The Civilians are running  towards the  {currentDirection}");
        }

        public void RecieveHit(int hit)
        {
            throw new NotImplementedException();
        }

        public void RecieveHit(PositiveNumber Int)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}}}";
        }
    }

}

