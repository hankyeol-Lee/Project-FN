namespace GameSkill
{
    public class Skill //��ų ���ø��� ���� skill Ŭ���� ����
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Damage { get; private set; }
        public int Cost { get; private set; }
        public int Range { get; private set; }
        public string DisplayString { get; private set; }  // ������

        public Skill(string name, string description,float damage, int cost, int range,string displayString)
        {
            Name = name;
            Description = description;
            Damage = damage;
            Cost = cost;
            Range = range;
            DisplayString = displayString;
        }
    }
}

