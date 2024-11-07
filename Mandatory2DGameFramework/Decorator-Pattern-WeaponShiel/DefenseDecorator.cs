using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.Decorator_Pattern_WeaponShiel
{
    public abstract class DefenseDecorator : IFighter
    {
        protected IFighter creature;

        public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected DefenseDecorator(IFighter creature)
        {
            this.creature = creature;
        }

        //public virtual int Hit(int damage)
        //{
        //    return creature.Hit(damage);
        //}

        //public virtual void RecieveHit(int hit)
        //{
        //    creature.RecieveHit(hit);
        //}

        //public virtual int GetHitPoints()
        //{
        //    return creature.GetHitPoints();
        //}

        //public virtual void AttackCreature(IFighter creature)
        //{
        //    this.creature.AttackCreature(creature);
        //}

        public void Loot(WorldObject obj)
        {
            throw new NotImplementedException();
        }

        public void Move(char input)
        {
            throw new NotImplementedException();
        }

        public void AttackCreature(ICreature creature)
        {
            throw new NotImplementedException();
        }

        //public void Hit()
        //{
        //    throw new NotImplementedException();
        //}

        //public int Hit(int damage, ICreature creature)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
