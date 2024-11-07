using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }


        // world objects
        private List<WorldObject> _worldObjects;
        // world creatures
        private List<ICreature> _creatures;

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<ICreature>();
        }

        public void AddCreature(ICreature creature, int x, int y)
        {
            Console.WriteLine($"Adding creature {creature.Name} to world at position {x}, {y}.");
            if (x < 0 || x >= MaxX || y < 0 || y >= MaxY)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of the world bounds.");
            }

            _creatures.Add(creature);
        }
        public void RemoveCreature(ICreature creature)
        {
            Console.WriteLine($" {creature.Name} is killed and  removed from the world.");
            _creatures.Remove(creature);
        }

        public override string ToString()
        {
            return $"A world was created with size{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}
