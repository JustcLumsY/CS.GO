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

        private List<CounterTerrorist> counterTerroristTeam = new List<CounterTerrorist>();

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
        //De har også en metode KillTerrorist(Terrorist terrorist) IsSuccessful(5) for å finne en random fra terroristlaget og drepe han.
        public void KillTerrorist(Terrorist terrorist)
        {
            var result = Program.IsSuccessful(5);
            if (result)
            {
                terrorist.IsDead = true;
            }
            else
            {
               
                
            }
        }
    }
}