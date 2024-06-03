using System;

namespace DnDCampaign
{
    
    public abstract class Entity
    {
        
        public string Name { get; set; }
        public int Level { get; set; }

       
        protected int Health { get; set; }
        protected int Mana { get; set; }
        protected int Experience { get; set; }

        
        public Entity(string name, int level)
        {
            Name = name;
            Level = level;
            Health = 100 + (level - 1) * 10;
            Mana = 50 + (level - 1) * 5;
            Experience = (level - 1) * 1000;
        }

        
        public abstract void DisplayInfo();

        
        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} experience points!");

            
            while (Experience >= Level * 1000)
            {
                LevelUp();
            }
        }

        
        protected void LevelUp()
        {
            Level++;
            Health += 10;
            Mana += 5;
            Console.WriteLine($"{Name} leveled up! Now at level {Level}.");
        }
    }

    
    public class Character : Entity
    {
        public string Class { get; set; }

        public Character(string name, string characterClass, int level = 1) : base(name, level)
        {
            Class = characterClass;
        }

        
        public override void DisplayInfo()
        {
            Console.WriteLine($"Character Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Experience: {Experience}");
        }
    }

    
    public class Monster : Entity
    {
        public string Type { get; set; }

        public Monster(string name, string type, int level = 1) : base(name, level)
        {
            Type = type;
        }

        
        public override void DisplayInfo()
        {
            Console.WriteLine($"Monster Name: {Name}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Experience: {Experience}");
        }
    }

    
    public class NPC : Entity
    {
        public string Role { get; set; }

        public NPC(string name, string role, int level = 1) : base(name, level)
        {
            Role = role;
        }

        
        public override void DisplayInfo()
        {
            Console.WriteLine($"NPC Name: {Name}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Experience: {Experience}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Character char1 = new Character("Aragorn", "Ranger", 5);
            Monster mon1 = new Monster("Goblin", "Beast", 2);
            NPC npc1 = new NPC("Innkeeper", "Service", 1);

            
            char1.DisplayInfo();
            mon1.DisplayInfo();
            npc1.DisplayInfo();

            
            char1.GainExperience(2000);
            char1.DisplayInfo();
        }
    }
}
