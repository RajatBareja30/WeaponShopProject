using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    //Name: Rajat Rajat (101153814)
    //Name: Gourav Gourav (101153817)
    //Name: Muskan Batra (101149674)
    //Name: Asim Patel (101162370)

    class Weapon
    {
        public string weaponName;
        public int range;
        public int damage;
        public double weight;
        public double cost;
        public double count;

        public Weapon(string name, int rang, int dam, double wgt, double cost)
        {
            weaponName = name;
            damage = dam;
            range = rang;
            weight = wgt;
            this.cost = cost;
            
        }


        public string toString()
        {
            string s;
            s = "Weapn Name: " + weaponName + ", Damage: " + damage + ", Range: " + range + ", Weight: " + weight + ", Cost: " + cost;
            return s;
        }
    }
}
