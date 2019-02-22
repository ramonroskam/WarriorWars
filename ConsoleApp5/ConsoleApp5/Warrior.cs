using System;
using System.Diagnostics.Eventing.Reader;

namespace WarriorWars
{
    internal class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 20;
        private const int BAD_GUY_STARTING_HEALTH = 20;

        private readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
        }

        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            enemy.health -= damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.colorfulWrilteLine($"{enemy.name} is dead! {name} is victorious!", ConsoleColor.Cyan);
            }
            else
            {
                Console.WriteLine($"{name} Attacked {enemy.name} {damage}.Damage was inflicted, remaining health of {enemy} is {enemy.health}");
            }
        }
    }
}