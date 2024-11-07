using Mandatory2DGameFramework.Positive;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interface
{
    public interface ICreature
    {
        
        public string Name { get; set; }

        public int HitPoints { get; set; }

        public void Move(char input);

        public void Loot(WorldObject obj);

        public void DisplayWeapons();

        public void RecieveHit(PositiveNumber Int);

        public bool IsDead();

        void AttachObserver(IObserver observer);
        void DetachObserver(IObserver observer);








    }
}
