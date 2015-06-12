using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSlum.GameObject.Characters
{
    using Interfaces;
    using System.Text;
    using TheSlum.GameObject.Items;

    class Warrior : Character, IAttack
    {
        private const int InitialHealth = 200;
        private const int InitialDefense = 100;
        private const int InitialAttack = 150;
        private const int InitialRange = 2;

        private int attackPoints;

        public Warrior(string id, int x, int y, Team team)
             : base(id, x, y, InitialHealth, InitialDefense, team, InitialRange)
        {
            this.AttackPoints = InitialAttack;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("attackPoints", "Attack points cannot be negative!");
                }
                this.attackPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character taget = targetsList
                .Where(x => x.IsAlive)
                .First(x => x.Team != this.Team);
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
            output.Append(string.Format("-- {0}, Attack: {1}", base.ToString(), this.AttackPoints));
            return output.ToString();
        }
        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }
        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }
    }
}
