using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    //Name: Rajat Rajat (101153814)
    //Name: Gourav Gourav (101153817)
    //Name: Muskan Batra (101149674)
    //Name: Asim Patel (101162370)

    class BST_weapon
    {
        public Node root;

        public BST_weapon()
        {
            root = null;
        }

        public void insertWeapon(Weapon w)
        {
           root = insertWorker(root, w);
        }

        public Node insertWorker(Node curr, Weapon w)
        {
            if(curr == null)
            {
                return new Node(w);

            }
            if(String.Compare(w.weaponName,curr.data.weaponName) < 0)
            {
                curr.left = insertWorker(curr.left, w);
               
            }
            if(String.Compare(w.weaponName, curr.data.weaponName) > 0)
            {
                curr.right = insertWorker(curr.right, w);
                
            }
            return curr;
        }

        public Weapon search(string wpnName)
        {
            return searchWorker(root, wpnName);
        }

        public Weapon searchWorker(Node curr, string wpnName)
        {
            if (curr != null)
            {
                if (curr.data.weaponName == wpnName) return curr.data;
                if (String.Compare(wpnName, curr.data.weaponName) < 0) return searchWorker(curr.left, wpnName);
                if (String.Compare(wpnName, curr.data.weaponName) > 0) return searchWorker(curr.right, wpnName);
            }
            return null;
        }

        public void inOrder()
        {
            if (root == null)
            {
                Console.WriteLine("No weapons in the Shop.");
                return;
            }
            inOrderTrav(root);
        }

        private void inOrderTrav(Node curr)
        {
            if (curr == null) return;
            inOrderTrav(curr.left);
            Console.WriteLine("{0} ", curr.data.toString());
            inOrderTrav(curr.right);
        }

        public void deleteNode(Weapon wpn)
        {
            root = deleteWorker(root, wpn);
        }
        private Node deleteWorker(Node curr,Weapon wpn)
        {
            if (curr == null) return curr;
            if (String.Compare(wpn.weaponName, curr.data.weaponName) < 0) curr.left = deleteWorker(curr.left, wpn);
            if (String.Compare(wpn.weaponName, curr.data.weaponName) > 0) curr.right = deleteWorker(curr.right, wpn);

            if (curr.data.weaponName == wpn.weaponName)
            {
                if (curr.left == null) return curr.right;
                if (curr.right == null) return curr.left;
                
                Node successor = curr.right;
                while (successor.left != null)
                    successor = successor.left;
                curr.data = successor.data; 
                curr.right = deleteWorker(curr.right, successor.data);
            }
            return curr;
        }

    }
}
