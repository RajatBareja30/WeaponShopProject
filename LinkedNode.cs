using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    //Name: Rajat Rajat (101153814)
    //Name: Gourav Gourav (101153817)
    //Name: Muskan Batra (101149674)
    //Name: Asim Patel (101162370)

    class LinkedNode
    {
        public Weapon wpn;
        public LinkedNode next;

        public LinkedNode(Weapon wpn)
        {
            this.wpn = wpn;
            next = null;
        }

    }
}
