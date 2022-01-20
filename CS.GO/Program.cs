using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CS.GO
{
    internal class Program
    {
        private static List<Terrorist> Terrorists = new();
        private static List<CounterTerrorist> CounterTerrorists = new();

        static async Task Main(string[] args)
        {
            await StartGame();
            //PickRandom();
            //Console.WriteLine("TERRORIST");
            //Terrorists.ForEach(x => Console.WriteLine("Hp" + "|" + x.Health + "|" + " " + x.Name + " - " + x.Rank));
            //Console.WriteLine("");
            //Console.WriteLine("COUNTER-TERRORIST");
            //CounterTerrorists.ForEach(x => Console.WriteLine("Hp" + "|" + x.Health + "|" + " " + x.Name + " - " + x.Rank));

            //return;

        }

        public static async Task StartGame()
        {
           
            AddSoldiers();
            MainMenu();
            var userInput = Console.ReadLine();
            while (true)
            {
         


                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("<Round One In 5 Secounds>");
                        for (int i = 2; i > 0 - 1; i--)
                        {
                            await Task.Delay(1000);
                            Console.WriteLine(i + " " + "- <Secounds Remaining>");

                            if (i < 1)
                            {
                                Console.Clear();
                                //await Task.Delay(1000);
                                PickRandom();
                                await Task.Delay(10000);
                                RandomCt();
                                await Task.Delay(10000);
                                var colorHeadShot = Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("<Terrorist> Looking For The Bomb Site");
                                await Task.Delay(2000);
                                await Terrorist.FindBombSite();
                            }
                        }

                        break;

                    case "2":
                        Console.WriteLine("<<|TERRORIST|>>");
                        Console.WriteLine("---------------------");
                        Terrorists.ForEach(x => Console.WriteLine("Hp" + "|" + x.Health + "|" + " " + x.Name + " - " + x.Rank));
                   
                        break;
                    case "3":
                        Console.WriteLine("<<|COUNTER-TERRORIST|>>");
                        Console.WriteLine("---------------------");
                        CounterTerrorists.ForEach(x => Console.WriteLine("Hp" + "|" + x.Health + "|" + " " + x.Name + " - " + x.Rank));
                        break;

                    case "4":
                        Settings();
                        break;

                    case "5":
                        Console.WriteLine("<<|Press Enter to Exit|>>");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;

                    default:
                        
                        break;

                }
                userInput = Console.ReadLine(); 
                Console.Clear();
                MainMenu();
            }
        }

        //private static void PlayGame(CounterTerrorist ct)
        //{
        //    Terrorist.KillCounterTerrorist(ct);
        //}

        private static void Settings()
        {
            Console.WriteLine("<<|Settings|>>");
            Console.WriteLine("");
            Console.WriteLine("1 - <|Sound Settings|>");
            Console.WriteLine("2 - <|Video Settings|>");
        }

        public static async Task MainMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
______________________________________________________________
|    __ __ _ ____               _____ __       _ __          |
|   / //_/(_/ / /____  _____   / ___// /______(_/ /_____     |
|  / ,<  / / / __/ _ \/ ___/   \__ \/ __/ ___/ / //_/ _ \    |
| / /| |/ / / /_/  __/ /      ___/ / /_/ /  / / ,< /  __/    |
|/_/ |_/_/_/\__/\___/_/      /____/\__/_/  /_/_/|_|\___/     |
|____________________________________________________________|                            
");

            await Task.Delay(1500);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("<<Game Options>>");
            Console.WriteLine("");
            Console.WriteLine("1 - <|Play|>");
            Console.WriteLine("2 - <|Terrorists|>");
            Console.WriteLine("3 - <|Counter-Terrorist|>");
            Console.WriteLine("4 - <|Settings|>");
            Console.WriteLine("5 - <|Exit|>");
            Console.WriteLine("");
        }

        public static void AddSoldiers()
        {
          
            Terrorists.AddRange(new List<Terrorist>()
            {
           
                new (1, "Reshala",  100, false, "BadAss"),
                new (2, "Gluhar", 100, false, "OneShotWonder"),
                new (3, "Sanitar",  100, false, "Medic"),
                new (4, "Killa",    100, false, "YouDie"),
                new (5, "Tagilla",     100, false, "Doink"),
            });

            CounterTerrorists.AddRange(new List<CounterTerrorist>()
            {
                new (1, "Tom", 100, false, "Police Trainee"),
                new (2, "Dennis", 100, false, "Officer II"),
                new (3, "Ray",  100, false, "Officer III"),
                new (4, "Jack",  100, false, "Deputy Officer"),
                new (5, "Lars", 100, false, "Sheriff"),
            });
        }

        public static async Task RandomCt()
        {
            Random rnd = new Random();
            var randomIndex = rnd.Next(0, CounterTerrorists.Count - 1);
            var randomCounterTerrorist = CounterTerrorists[randomIndex];
            Terrorists[4].KillCounterTerrorist(randomCounterTerrorist);
            var colorHeadShot = Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<Terrorist>" + " " + Terrorists[4].Name + " " + "Shoots at Enemy");
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

            colorHeadShot = Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"<Headshot>");
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("<");
            await Task.Delay(600);
            Console.Write("-");
            await Task.Delay(600);
            Console.Write("-");
            await Task.Delay(600);
            Console.Write("-");
            Console.Write(" ");
            Console.WriteLine(" ");
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;

            await Task.Delay(1000);
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            System.Console.WriteLine("<Counter-Terrorist>" + " |" + randomCounterTerrorist.Name + "| " + "<Died>");
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;
            await Task.Delay(2500);
            System.Console.WriteLine("");
        }

        public static async Task PickRandom()
        {
            
            Random rnd = new Random();
            var randomIndex = rnd.Next(0, Terrorists.Count - 1);
            var randomTerrorist = Terrorists[randomIndex];
            CounterTerrorists[4].KillTerrorist(randomTerrorist);
            var colorHeadShot = Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("<Counter-Terrorist>" + " " +CounterTerrorists[4].Name + " " + "Shoots at Enemy");
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
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"<Headshot>");
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("<");
            await Task.Delay(600);
            Console.Write("-");
            await Task.Delay(600);
            Console.Write("-");
            await Task.Delay(600);
            Console.Write("-");
            Console.Write(" ");
            Console.WriteLine(" ");
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;

            await Task.Delay(1000);
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            System.Console.WriteLine("<Terrorist>" + " |" + randomTerrorist.Name + "| " + "<Died>");
            colorHeadShot = Console.ForegroundColor = ConsoleColor.Cyan;
            await Task.Delay(2500);
            System.Console.WriteLine(" ");
        }

        public static bool IsSuccessful(int maxValue)

        {
            Random rnd = new Random();
            return rnd.Next(0, maxValue) == 2;
        }
    }
}
