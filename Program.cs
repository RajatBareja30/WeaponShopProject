using System;

namespace WeaponShopAssign2
{
    //Name: Rajat Rajat (101153814)
    //Name: Gourav Gourav (101153817)
    //Name: Muskan Batra (101149674)
    //Name: Asim Patel (101162370)

    class Program
    {
        private static BST_weapon WeaponTree;

        private static Player player;

        private static Backpack bag;

        public static void addWeapon(BST_weapon WeaponTree)
        {
            Console.WriteLine("***********WELCOME TO THE WEAPON ADDING MENU*********");
            string weaponName;
            int weaponRange;
            int weaponDamage;
            double weaponWeight;
            double weaponCost;
            Console.Write("Please enter the NAME of the Weapon: ");
            weaponName = Console.ReadLine();
            Console.Write("Please enter the RANGE of the Weapon: ");
            weaponRange = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the DAMAGE of the Weapon: ");
            weaponDamage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the WEIGHT of the Weapon (in pounds): ");
            weaponWeight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter the COST of the Weapon: ");
            weaponCost = Convert.ToDouble(Console.ReadLine());
            
            Weapon weapon1 = new Weapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost);
            try
            {
                WeaponTree.insertWeapon(weapon1);
                Console.WriteLine("CONGTATULATIONS!!!! You have added the weapon Successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("There is some problem adding the weapon!!");
            }


        }


        private static void deleteWeapon(BST_weapon WeaponTree)
        {
            
            if (WeaponTree.root == null)
            {
                Console.WriteLine("There are no Weapons in the shop!!");
                return;
            }
            WeaponTree.inOrder();
            string WeaponName;
            Console.Write("Please enter the weapon name you want to delete: ");
            WeaponName = Console.ReadLine();
            Weapon weapon1 = WeaponTree.search(WeaponName);
            if (weapon1 != null)
            {
                WeaponTree.deleteNode(weapon1);
                Console.WriteLine("Weapon " + WeaponName+ " has been deleted from the shop.");
            }
            else Console.WriteLine("Weapon " + WeaponName+ " could not be found in the shop.");
        }

        public static void buyWeapon(Player player, BST_weapon WeaponTree,Backpack bag)
        {
            
            Console.WriteLine("WELCOME TO THE SHOWROOM!!!!");
            WeaponTree.inOrder();
            Console.WriteLine(player.name + " has " + player.money + " money left.");
            if (WeaponTree.root == null)
            {
                Console.WriteLine("SORRY!!!!There are no weapons in the shop.");
                return;
            }
            Console.Write("Please enter a Weapon Name to buy: ");
            string WeaponName;
            WeaponName = Console.ReadLine();
            Weapon w = WeaponTree.search(WeaponName);
            if (w != null)
            {
                if (w.cost > player.money )
                {
                    Console.WriteLine("Your balance: $"+player.money+" _______weapon Cost: $"+w.cost);
                    Console.WriteLine("you do not have enough money to buy " + w.weaponName);

                }
                else if(w.weight > bag.maxWeight - bag.presentWeight)
                {
                    Console.WriteLine("your Bag Weight: "+bag.presentWeight+" _______weapon weight: "+w.weight);
                    Console.WriteLine("You do not have enough space in your backpack for " + w.weaponName);
                }
                else
                {
                    player.buy(w);
                    Console.WriteLine("CONGRATULATIONS!!! You have "+w.weaponName+" in your backpack");
                    Console.WriteLine("Your Balance: " + player.money);
                }
            }
            else
            {
                Console.WriteLine(" SORRY!!!! " + WeaponName + " not found!! **");
            }
        }

        
        private static void showWeapons(BST_weapon WeaponTree)
        {
            WeaponTree.inOrder();
        }

        
        private static void showBackpack(Player player, Backpack bag)
        {
            player.printBackpack(bag);
        }

        // show player details
        private static void showPlayer(Player player, Backpack bag)
        {
            player.playerDetails(bag);
        }

        private static int showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) Add Items to the shop.");
            Console.WriteLine("2) Delete Items from the shop.");
            Console.WriteLine("3) Show Weapons in the shop.");
            Console.WriteLine("4) Buy from the Shop.");
            Console.WriteLine("5) View Backpack.");
            Console.WriteLine("6) View Player.");
            Console.WriteLine("7) Exit.");

            while (true)
            {
                Console.Write("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 1 || choice > 7)
                    Console.WriteLine("Invalid Input. Try again.");
                else return choice;
            }
        }


        static void Main(string[] args)
        {
            string playerName;
            Console.Write("Please enter the Player name: ");
            playerName = Console.ReadLine();
            Console.Write("The amount " + playerName + " has: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("How puch weight you want your bag to carry?(in pounds)");
            double Maxweight = Convert.ToDouble(Console.ReadLine());
            Backpack bag = new Backpack(Maxweight);
            Player player = new Player(playerName, amount,bag);
            BST_weapon weaponTree = new BST_weapon();
            Boolean exit = false;
            while (!exit)
            {
                int opt = showMenu();
                switch (opt)
                {
                    case 1: addWeapon(weaponTree); break;
                    case 2: deleteWeapon(weaponTree); break;
                    case 3: showWeapons(weaponTree); break;
                    case 4: buyWeapon(player,weaponTree,bag); break;
                    case 5: showBackpack(player, bag); break;
                    case 6: showPlayer(player,bag); break;
                    default: exit = true; break;
                }
            }

            Console.ReadKey();
        }
    }
}
