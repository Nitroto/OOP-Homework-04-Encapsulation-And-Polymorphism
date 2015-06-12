namespace TheSlum.GameObject.Items
{
    class Shield:Item
    {
        private const int HealthEffect = 0;
        private const int DefenseEffect = 50;
        private const int AttackEffect = 0;

        public Shield(string id)
            :base(id, HealthEffect,DefenseEffect,AttackEffect)
        {
        }
    }
}
