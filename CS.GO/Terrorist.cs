using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace CS.GO
{
    public class Terrorist
    {
        public bool IsDead { get; set; }
        public string Name;
        public int Health;
        public int Id;
        public string Rank;
        

        public Terrorist(int id, string name, int health, bool isDead, string rank)
        {
            Id = id;
            Name = name;
            Health = health;
            IsDead = isDead;
            Rank = rank;
        }


        public static async Task<bool> FindBombSite()
        {
            
            var success =  Program.IsSuccessful(3);
            if (success == false)
            {
               var colorHeadShot = Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<Terrorist>"  + " " + "<<Failed To Find Bomb Site>>");
                await Task.Delay(2000);

                Console.WriteLine(@"   
                               ______                        ____                 
                              / ________ _____ ___  ___     / __ \_   _____  _____
                             / / __/ __ `/ __ `__ \/ _ \   / / / | | / / _ \/ ___/
                            / /_/ / /_/ / / / / / /  __/  / /_/ /| |/ /  __/ /    
                            \____/\__,_/_/ /_/ /_/\___/   \____/ |___/\___/_/     
                                                                                  
                                ");
                Console.ReadLine();



                
            }
            else
            {
                await PlantBomb();
            }
            
            return success;

        }



        public void KillCounterTerrorist(CounterTerrorist ct)
        {
            var killCt = Program.IsSuccessful(7);

            if (killCt)
            {
                ct.IsDead = true;
            }
            else
            {
                //System.Console.WriteLine("<Terrorist> missed");
            }
        }


        public static async Task PlantBomb()
        {
          
            if (true)
            {
                var colorHeadShot = Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<Terrorist>" + " " + "<Bomb Site A Found>");
                Console.WriteLine("");
                await Task.Delay(3000);

                Console.WriteLine("<Terrorist>" + " " + "<Locating Bomb Spot>");
                Console.WriteLine("");
                await Task.Delay(2500);
                Console.WriteLine("<Terrorist>" + " " + "<Bomb Spot Found>");
                Console.WriteLine("");
                await Task.Delay(1500);
                Console.WriteLine("<Terrorist>" + " " + "<Bomb Is Being Planted>");
                Console.WriteLine("");

                for (var i = 5; i > 0; i--)
                {
                    colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;
                    await Beep(2);
 
                    await Task.Delay(1000);
                    Console.WriteLine(i + " " +"<Secounds Remaining>");
                    Console.WriteLine("");
                }

                colorHeadShot = Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<Terrorist>" + " " + "<<Bomb Has Been Planted!>>");
                Console.WriteLine("");
                colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;

                for (var i = 15; i > 0; i--)
                {
                    
                    await Task.Delay(1000);
                    
                    Console.WriteLine($"{i}" + " " + "<Secounds Left>" );
                    if (i <= 6)
                    {
                        colorHeadShot = Console.ForegroundColor = ConsoleColor.Red;
                        await Beep(5);
                    
                    }
                    await Beep(1);
                    if (i != 1) continue;
                    await Task.Delay(1000);
                    colorHeadShot = Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<<<<Bomb Goes BOOOOOOOOOOOOOOM!>>>>");
                    Console.WriteLine("");
                    await Task.Delay(1000);
                    colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("<Terrorist Wins!>");

                    Console.ReadLine();

               
                }
                
            }
        }

        private static async Task Beep(int amount = 0)
        {
            if (amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                     Console.Beep();
                }
            }
            else  Console.Beep();
        }
    }
}