namespace GameSkill
{
    public class Skill //스킬 템플릿을 담을 skill 클래스 정의
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Damage { get; private set; }
        public int Cost { get; private set; }
        public int Range { get; private set; }
        public string DisplayString { get; private set; }  // 설명문구

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

