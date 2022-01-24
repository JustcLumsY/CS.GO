using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS.GO
{
    public class CounterTerrorist
    {
        public bool IsDead { get; set; }
        public string Name;
        public int Health;
        public int Id;
        public string Rank;
       

        private List<CounterTerrorist> _counterTerroristTeam = new List<CounterTerrorist>();

        public CounterTerrorist(int id, string name, int health, bool isDead, string rank)
        {
            Id = id;
            Name = name;
            Health = health;
            IsDead = isDead;
            Rank = rank;
        }


        public async Task DefuseBomb()
        {
            Console.WriteLine("<5Sec remaning>>");
             await Task.Delay(1000);
            Console.WriteLine("<4Sec remaning>");
             await Task.Delay(1000);
            Console.WriteLine("<3Sec remaning>");
             await Task.Delay(1000);
            Console.WriteLine("<2Sec remaning>");
             await Task.Delay(1000);
            Console.WriteLine("<1Sec remaning>");
             await Task.Delay(1000);
            Console.WriteLine("<Bomb has been defused!>");
        }
        
        public async Task KillTerrorist(Terrorist terrorist)
        {
          

            var result = Program.IsSuccessful(5);
            if (result)
            {
                terrorist.IsDead = true;
            Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("<Counter-Terrorist>" + " " + Game.CounterTerrorists[4].Name + " " + "Shoots at Enemy");
                Console.WriteLine("");
                await Task.Delay(600);
                Console.Write("-");
                 await Task.Delay(600);
                Console.Write("-");
                 await Task.Delay(600);
                Console.Write("-");
                 await Task.Delay(600);
                Console.Write(">");
                 await Task.Delay(600);
               Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"<Headshot>");
              Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("<");
                 await Task.Delay(600);
                Console.Write("-");
                 await Task.Delay(600);
                Console.Write("-");
                 await Task.Delay(600);
                Console.Write("-");
                Console.Write(" ");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Cyan;

                 await Task.Delay(1000);
               Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");

              
                Random rnd = new Random();

                var randomIndex = rnd.Next(0,Game.Terrorists.Count - 1);
                var randomTerrorist = Game.Terrorists[randomIndex];

                System.Console.WriteLine("<Terrorist>" + " |" + randomTerrorist.Name + "| " + "<Died>");
               Console.ForegroundColor = ConsoleColor.Cyan;
                 await Task.Delay(2500);
                System.Console.WriteLine(" ");
            }
            else
            {
               
                
            }
        }
          
    }
}