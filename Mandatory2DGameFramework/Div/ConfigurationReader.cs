using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Mandatory2DGameFramework.Div
{
    /// <summary>
    /// This class reads the configuration from an XML file
    /// </summary>
    public class ConfigurationReader
    {
        private XDocument xmlDoc;

        public ConfigurationReader()
        {
            //Load the XML document in the constructor

            /// <summary>
            ///  This is the path to the XML file
            /// </summary>
            xmlDoc = XDocument.Load(@"C:\Users\Bruger\Downloads\Mandatory2DGameFramework\Mandatory2DGameFramework\Mandatory2DGameFramework\Div\XMLFile1.xml");
        }

        public void ReadWorldConfiguration()
        {
            // Extract the World element and get MaxX and MaxY values
            XElement world = xmlDoc.Element("GameConfiguration").Element("World");
            int maxX = int.Parse(world.Element("MaxX").Value);
            int maxY = int.Parse(world.Element("MaxY").Value);
            Console.WriteLine($"World Size: {maxX}x{maxY}");
        }

        public void ReadCreatureConfiguration()
        {
            // Load the XML document (assuming 'xmlDoc' is loaded somewhere in your code)
            XElement root = xmlDoc.Element("GameConfiguration");

            // Extract the "Creatures" element and iterate through all "Creature" elements
            IEnumerable<XElement> creatures = root.Element("Creatures").Elements("Creature");

            foreach (XElement creature in creatures)
            {
                string creatureName = creature.Element("Name").Value;
                Console.WriteLine($"Creature Name: {creatureName}");

                int hitPoints = int.Parse(creature.Element("Hitpoints").Value);
                Console.WriteLine($"Creature HitPoints: {hitPoints}");

                // Read all AttackItems for the creature
                IEnumerable<XElement> attackItems = creature.Elements("AttackItem");
                foreach (XElement attackItem in attackItems)
                {
                    string attackName = attackItem.Element("Name").Value;
                    int attackHit = int.Parse(attackItem.Element("Hit").Value);
                    int attackRange = int.Parse(attackItem.Element("Range").Value);
                    Console.WriteLine($"Attack Item: {attackName}, Hit: {attackHit}, Range: {attackRange}");
                }

                // Read the DefenceItem for the creature (if exists)
                XElement defenceItem = creature.Element("DefenceItem");
                if (defenceItem != null)
                {
                    string defenceName = defenceItem.Element("Name").Value;
                    int defenceValue = int.Parse(defenceItem.Element("Defence").Value);
                    Console.WriteLine($"Defence Item: {defenceName}, Defence: {defenceValue}");
                }

                Console.WriteLine(); // For better output formatting
            }
        }





    }
}
