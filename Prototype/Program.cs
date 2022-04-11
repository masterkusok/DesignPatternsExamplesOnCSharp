using System;
class Enemy
{
    public string Name;
    public string Race;
    public string Class;
    private Weapon _weapon;
    public Enemy(string name, string race, string enemyClass, int damage = 0)
    {
        _weapon = new Weapon(damage);
        this.Name = name;
        this.Race = race;
        this.Class = enemyClass;
    }
    public int GetDamage()
    {
        return _weapon.Damage;
    }
    public object ShallowClone()
    {
        return MemberwiseClone();
    }
    public object DeepClone()
    {
        Enemy clone = (Enemy) this.MemberwiseClone();
        clone._weapon = new Weapon(_weapon.Damage);
        return clone;
    }
}
class Weapon
{
    public int Damage;
    public Weapon(int damage)
    {
        Damage = damage;
    }
}

class Program
{
    static void Main()
    {
        Enemy ork = new Enemy(name: "George", race: "Ork",
            enemyClass: "Archer", damage: 40);
        PrintEnemyInfo(ork);

        Console.WriteLine("Creating army of 10 clones");
        CreateArmy(ork);
    }
    static void PrintEnemyInfo(Enemy enemy)
    {
        Console.WriteLine($"Prototype created:\n name - {enemy.Name}, race - {enemy.Race}" +
            $"class - {enemy.Class}, damage - {enemy.GetDamage()} \n");
    }
    static void CreateArmy(Enemy prototype)
    {
        for (int i = 0; i < 10; i++)
        {
            Enemy clone = (Enemy)prototype.DeepClone();
            clone.Name += $" {i+1}";
            PrintEnemyInfo(clone);
        }
    }
}