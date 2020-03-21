using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    //Name: Rajat Rajat (101153814)
    //Name: Gourav Gourav (101153817)
    //Name: Muskan Batra (101149674)
    //Name: Asim Patel (101162370)

    class Backpack
    {
        public double maxWeight;
        public double presentWeight;
        LinkedNode head;


        public Backpack(double maxWgt)
        {

            maxWeight = maxWgt;
            presentWeight = 0;
            head = null;

        }

        
        public void add(Weapon wpn)
        {
            
            
                LinkedNode newNode = new LinkedNode(wpn);
                if (head == null)
                {
                    head = newNode;
                    return;
                }
                LinkedNode curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = newNode;

                presentWeight = presentWeight + wpn.weight;
               

            
        }

        
        public void printWeapons()
        {
            LinkedNode curr = head;
            while (curr!= null)
            {
                Console.WriteLine(curr.wpn.toString());
                curr = curr.next;
            }
        }
    }
}
