using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using CS.GO;
using System.Timers;


namespace CS.GO
{
    public class Terrorist
    {
        public bool IsDead { get; set; }
        public string Name;
        public int Health;
        public int Id;
        public string Rank;
        public static Timer BombTimer;
        

        public Terrorist(int id, string name, int health, bool isDead, string rank)
        {
            Id = id;
            Name = name;
            Health = health;
            IsDead = isDead;
            Rank = rank;
            
        }


        public  bool FindBombSite()
        {
            
            var success =  Program.IsSuccessful(10);
            if (success == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine("<Terrorist>"  + " " + "<<Failed To Find Bomb Site>>");
                 Task.Delay(2000);


                //var t = new Game();
                KillRandomCt();
            }
            else
            {
                PlantBomb();
            }
            
            return success;

        }

        public static async Task KillRandomCt()
        {

            if (Program.IsSuccessful(3))
            {

                Random rnd = new Random();
                var randomTerrorIndex = rnd.Next(0, Game.Terrorists.Count - 1);
                var randomTerrorist = Game.Terrorists[randomTerrorIndex];
                var randomIndex = rnd.Next(0, Game.CounterTerrorists.Count - 1);
                var randomCounterTerrorist = Game.CounterTerrorists[randomIndex];
                Game.Terrorists[4].KillCounterTerrorist(randomCounterTerrorist);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<Terrorist>" + " " + randomTerrorist.Name + " " + "Shoots at <Counter-Terrorist>");
                Console.WriteLine("");
                await Task.Delay(400);
                Console.Write("-");
                await Task.Delay(400);
                Console.Write("-");
                await Task.Delay(400);
                Console.Write("-");
                await Task.Delay(440);
                Console.Write(">");
                await Task.Delay(400);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"<Headshot>");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("<");
                await Task.Delay(400);
                Console.Write("-");
                await Task.Delay(400);
                Console.Write("-");
                await Task.Delay(400);
                Console.Write("-");
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("<Counter-Terrorist>" + " " + randomCounterTerrorist.Name + " ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("<Died>");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                await Task.Delay(1000);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                await Task.Delay(2500);
                Console.WriteLine("");
                Game.Terrorists[0].TerroristLookingForBombSite();

            }
            else
            {
                Random rnd = new Random();
                var randomTerrorIndex = rnd.Next(0, Game.Terrorists.Count - 1);
                var randomTerrorist = Game.Terrorists[randomTerrorIndex];
                //await Task.Delay(0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<Terrorist>" + " " + randomTerrorist.Name + " " + "<Missed>");
                Console.WriteLine("");
                await Task.Delay(2500);
                Game.PickRandom();
                await Task.Delay(3500);
                Game.Terrorists[0].TerroristLookingForBombSite();
            }

        }



        public void KillCounterTerrorist(CounterTerrorist ct)
        {
            var killCt = Program.IsSuccessful(7);

            if (killCt)
            {
                ct.IsDead = true;
            }
          
        }

        public async Task TerroristLookingForBombSite()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<Terrorist> Looking For The Bomb Site");
            await Task.Delay(2000);
            FindBombSite();
        }

        public async Task PlantBomb()
        {
          
            if (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
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
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Beep(2);
                    await Task.Delay(1000);
                    Console.WriteLine(i + " " +"<Secounds Remaining>");
                    Console.WriteLine("");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<Terrorist>" + " " + "<<Bomb Has Been Planted!>>");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;


                BombTimer = new System.Timers.Timer();








                //for (var i = 15; i > 0; i--)
                //{

                //    await Task.Delay(1000);

                //    Console.WriteLine($"{i}" + " " + "<Secounds Left>" );
                //    if (i <= 6)
                //    {
                //       Console.ForegroundColor = ConsoleColor.Red;
                //         Beep(5);

                //    }
                //    Beep(1);
                //    if (i != 1) continue;
                //    await Task.Delay(1000);
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine("<<<<Bomb Goes BOOOOOOOOOOOOOOM!>>>>");
                //    Console.WriteLine("");
                //    await Task.Delay(1000);
                //    Console.ForegroundColor = ConsoleColor.Cyan;
                //    Console.WriteLine("<Terrorist Wins!>");
                //    Console.ReadLine();


                //}



            }
        }

        public void Beep(int amount = 0)
        {
            if (amount > 0)
            {
                for (var i = 0; i < amount; i++)
                {
                     Console.Beep();
                }
            }
            else  Console.Beep();
        }
    
    }
}