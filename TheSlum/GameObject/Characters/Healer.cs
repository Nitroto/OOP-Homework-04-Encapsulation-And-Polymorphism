using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSlum.GameObject.Characters
{
    using Interfaces;
    using System.Text;
    using Items;

    class Healer : Character, IHeal
    {
        private const int InitialHealth = 75;
        private const int InitialDefense = 50;
        private const int InitialHealing = 60;
        private const int InitialRange = 6;

        private int healingPoints;

        public Healer(string id, int x, int y, Team team)
             : base(id, x, y, InitialHealth, InitialDefense, team, InitialRange)
        {
            this.HealingPoints = InitialHealing;
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("healingPoints", "Healing points cannot be negative!");
                }
                this.healingPoints=value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character taget = targetsList
                .Where(x => x.IsAlive)
                .Where(x => x.Team == this.Team)
                .Where(x => x != this)
                .OrderByDescending(x => x.HealthPoints)
                .LastOrDefault();
            return taget;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("-- {0}, Healing: {1}", base.ToString(), this.HealingPoints));
            return output.ToString();
        }
    }
}
