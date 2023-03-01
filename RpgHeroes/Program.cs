using RpgHeroes.Classes;
using RpgHeroes.Enums;
using RpgHeroes.Items;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Mage Gandalf = new("Gandalf");
        //Gandalf.Display();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Gandalf.LevelUp();
        Weapon GoldStaff = new("Gold staff",WeaponType.Staff, 5, 10);
        Armor GenericLegs = new("Generic Legs",ArmorType.Cloth, 3, slot.Legs,1,4,2);
        Armor GenericHelm = new("Generic helm", ArmorType.Cloth, 3, slot.Head,0,0,8);
        Armor GenericHelm2 = new("Generic helm", ArmorType.Cloth, 3, slot.Head, 0, 0, 55);
        Armor GenericChest = new("Generic chest", ArmorType.Cloth, 3, slot.Body,3,3,1);
        Gandalf.Equip(GoldStaff);
        //Gandalf.Equip(GenericLegs);
        Gandalf.Equip(GenericHelm);
        Gandalf.Equip(GenericHelm2);
        //Gandalf.Equip(GenericChest);
        Console.WriteLine(Gandalf.Display());
        //Console.WriteLine(Gandalf.TotalAttributes());
        Console.WriteLine(Gandalf.Damage());
        Console.WriteLine("Hello, World!".GetType());
        Console.WriteLine(GoldStaff.Name.GetType());
    }
}