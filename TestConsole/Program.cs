// See https://aka.ms/new-console-template for more information
using Mandatory2DGameFramework.CompositePattern_Weapon;
using Mandatory2DGameFramework.Decorator_Pattern_WeaponShiel;
using Mandatory2DGameFramework.Div;
using Mandatory2DGameFramework.FactoryDesignPattern;
using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.ObserverDesigPattern;
using Mandatory2DGameFramework.PossitionOnEath;
using Mandatory2DGameFramework.Wapons;
using Mandatory2DGameFramework.Wapons.AttackWeapon;
using Mandatory2DGameFramework.Wapons.DefenceWeapon;
using Mandatory2DGameFramework.worlds;

Console.WriteLine("Hello, World!");

// Create a new instance of the ConfigurationReader class
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
Console.WriteLine("READ FROM XML FILE");
var configReader = new ConfigurationReader();
configReader.ReadWorldConfiguration();
configReader.ReadCreatureConfiguration();
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
Console.WriteLine("IMPLEMENTING LOG USING SINGLETON");

// Create a new instance of the MyLogger class

//var logger = new MyLogger();
MyLogger.Instance.Start();
//logger.Start();
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

// Create a new new Weapons

//IWeapon sword = new Sword();
//sword.Name = "Sword";
//sword.Hit = 10;
//sword.Range = 2;

//IWeapon bow = new Bow();
//bow.Name = "Bow";
//bow.Hit = 15;
//bow.Range = 3;

// Implement composite Design Pattern Create a new instance of the ManyWeapon class

//ManyWeapon manyWeapon = new ManyWeapon();
//manyWeapon.AddWeapon(sword);
//manyWeapon.AddWeapon(bow);

// Innitial Position
Console.WriteLine("IMPLEMENTION POSITION USING STATE DESIGN PATTERN");

IPosition position = new GoEast();

// Using Factory Method to create Creatures 
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
Console.WriteLine("IMPLEMENTING FACTORY DESIGN PATTERN");

CreatureFactory creatureFactory =  new CreatureFactory(position);

ICreature army = creatureFactory.GetCreature("Army");
army.Name = "Rambo";

ICreature civilian = creatureFactory.GetCreature("Civilian");
civilian.Name = "John";
ICreature animal = creatureFactory.GetCreature("Animals");
animal.Name = "Lion";
ICreature enemy = creatureFactory.GetCreature("Enemy");
enemy.Name = "Enemy";

Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

// Create a new instance of the World class
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
Console.WriteLine("IMPLEMENTING WORLD CLASS");
Console.WriteLine("Creation");

World world = new World(1000, 2000);
world.AddCreature(army , 20,20);
world.AddCreature(civilian, 30, 30);
world.AddCreature(animal, 40, 40);

Console.WriteLine(world.ToString());

// Using Factory to create WorldObjects

WorldObjectFactory factory = new WorldObjectFactory();
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
IWeapon weapon = new Bow() { Name="Bow", Hit=10, Range=5};
IWeapon weapon2 = new Sword() { Name = "Sword", Hit = 15, Range = 2 };
IWeapon shield = new Amor() { Name = "Shield" };
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
//WorldObjectFactory.CreateWorldObject("AttackItem", weapon);
//WorldObjectFactory.CreateWorldObject("AttackItem", weapon2);
//WorldObjectFactory.CreateWorldObject("DefenceItem", shield);
WorldObject attackItem = factory.CreateWorldObject("AttackItem", weapon);
WorldObject attackitem = factory.CreateWorldObject("AttackItem", weapon2);
WorldObject defenceItem = factory.CreateWorldObject("DefenceItem", shield);
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
ICreature newArmy = creatureFactory.GetCreature("Army");
newArmy.Name = "Rambo";
newArmy.HitPoints = 2;
ICreature newenemy = creatureFactory.GetCreature("Enemy");
newenemy.Name = "Enemy";
newenemy.HitPoints = 3;
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
World world1 = new World(1000, 2000);
Console.WriteLine(world1);
world1.AddCreature(newArmy, 20, 20);
newArmy.Move('a');
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
ManyWeapon manyWeapon1 = new ManyWeapon();
manyWeapon1.AddWeapon(weapon);
manyWeapon1.AddWeapon(weapon2);
manyWeapon1.AddWeapon(shield);

Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

newArmy.Loot(attackItem);
//newArmy.Loot(attackitem);
//newArmy.Loot(defenceItem);
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");


//Console.WriteLine($"Army has the following weapons: {attackItem}, {defenceItem}");
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
newenemy.Loot(attackItem);
//newenemy.Loot(attackitem);
//newenemy.Loot(defenceItem);

newArmy.DisplayWeapons();



Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");



Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
Console.WriteLine("Enemy attacks Army");

if (newArmy is IFighter armyFighter && newenemy is IFighter enemyFighter)
{
    // Continue the battle until one of them is defeated
    while (!newArmy.IsDead() && !newenemy.IsDead())
    {
        // Enemy attacks Army
        Console.WriteLine($"Before attack: {newArmy.Name} HP: {newArmy.HitPoints}");
        enemyFighter.AttackCreature(newArmy);
        Console.WriteLine($"After attack: {newArmy.Name} HP: {newArmy.HitPoints}");

        // Check if Army is defeated
        if (newArmy.IsDead())
        {
            Console.WriteLine($"{newArmy.Name} has been defeated!");
            break;
        }

        // Optional: Army counter-attacks (if desired)
        Console.WriteLine($"Before counter-attack: {newenemy.Name} HP: {newenemy.HitPoints}");
        armyFighter.AttackCreature(newenemy);
        Console.WriteLine($"After counter-attack: {newenemy.Name} HP: {newenemy.HitPoints}");

        // Check if Enemy is defeated
        if (newenemy.IsDead())
        {
            Console.WriteLine($"{newenemy.Name} has been defeated!");
            break;
        }

    //    // Add a small delay for readability in the console (optional)
        System.Threading.Thread.Sleep(500); // 0.5-second delay
    }
}
else
{
    Console.WriteLine("Either the army or the enemy does not implement IFighter and cannot engage in combat.");
}

Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

DeathLogger deathLogger = new DeathLogger();
newArmy.AttachObserver(deathLogger);

GameManagement gameManagement = new GameManagement();
newArmy.AttachObserver(gameManagement);


newArmy.Move('z');
//world1.RemoveCreature(newArmy);

//civilian.Move('b');
//animal.Move('a');
Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");






Console.WriteLine($"Before attack: {newArmy.Name} HP: {newArmy.HitPoints}");




