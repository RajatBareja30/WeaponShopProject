using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    //Name: Rajat Rajat (101153814)
    //Name: Gourav Gourav (101153817)
    //Name: Muskan Batra (101149674)
    //Name: Asim Patel (101162370)
    
    class Player
    {
        public string name;
        public Backpack bp;
        public int numItems;
        public double money;

        
        public Player(string n, double m, Backpack b)
        {
            name = n;
            money = m;
            numItems = 0;
            bp = b;
            
        }

        public void buy(Weapon wpn)
        {

                bp.add(wpn);
                numItems++;
                withdraw(wpn.cost);
                Console.WriteLine(wpn.weaponName + " bought...");
           

        }

        public void withdraw(double amt)
        {
            money = money - amt;
        }

        public bool inventoryFull()
        {
            bool full = false;
            if (numItems == 10) full = true;
            return full;
        }


        public void printBackpack(Backpack bp1)
        {
            Console.WriteLine(name+ " has " + numItems + " weapons in his backpack.");
            bp1.printWeapons();
            Console.WriteLine();
        }

        public void playerDetails(Backpack bp1)
        {
            Console.WriteLine("Player Name: " + name + ", Player balance: $" + money + ", Player backpack count: " + numItems);
            Console.WriteLine("Player Backpack: ");
            bp1.printWeapons();
        }

    }
}
