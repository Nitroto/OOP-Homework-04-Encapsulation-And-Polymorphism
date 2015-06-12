namespace TheSlum.GameObject.Items.Bonus
{
    class Pill:Bonus
    {
        private const int HealthEffect = 0;
        private const int DefenseEffect = 0;
        private const int AttackEffect = 100;
        private const int PillTimeout = 1;

        public Pill(string id)
            : base(id, HealthEffect, DefenseEffect, AttackEffect)
        {
            this.Countdown = PillTimeout;
        }
    }
}
