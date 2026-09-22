namespace Garvart.Classes
{
    public class PersoInfo
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Glasses { get; set; }
        public int Money { get; set; }
        public float Dmage {  get; set; }
        public PersoInfo(string Name, int Health, int Armor, int Level, int Glasses, int Money, float Dmage)
        {
            this.Name = Name;
            this.Health = Health;
            this.Armor = Armor;
            this.Level = Level;
            this.Glasses = Glasses;
            this.Money = Money;
            this.Dmage = Dmage;
        }
    }
    
}
