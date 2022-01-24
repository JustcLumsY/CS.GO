using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CS.GO;


namespace CS.GO
{
    
    public class Game
    {
        public static List<Terrorist> Terrorists = new();
        public static List<CounterTerrorist> CounterTerrorists = new();
        public Game()
        {
           StartGame();

        }
        public static void DrawMainMenu()
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
        public static async Task StartGame()
        {
            AddSoldiers();
            DrawMainMenu();

            var userInput = Console.ReadLine();
            
            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("<Round One Begins>");
                        for (var i = 2; i > 0 - 1; i--)
                        {
                            await Task.Delay(1000);
                            Console.WriteLine(i + " " + "- <Secounds Remaining>");
                            if (i >= 1) continue;
                            Console.Clear();
                            await Task.Delay(1000);

                             PickRandom();

                             await Task.Delay(2000);
                      

                             Terrorist.KillRandomCt();

                             await Task.Delay(2000);
                        }
                        break;

                    case "2":
                        PrintTeamList();
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
                        Environment.Exit(0);
                        break;

                    default:
                        break;

                }
                userInput = Console.ReadLine();
                Console.Clear();
                 DrawMainMenu();
            }

            // ReSharper disable once FunctionNeverReturns

        }
       
        public static async Task PickRandom()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("<Counter-Terrorist> Spotted a <Terrorist>");
            Console.WriteLine("");
            await Task.Delay(1000);
            if (Program.IsSuccessful(3))
            {
                Random rnd = new Random();
                var randomCt = rnd.Next(0, CounterTerrorists.Count - 1);
                var randomIndex = rnd.Next(0, Terrorists.Count - 1);
                var randomTerrorist = Terrorists[randomIndex];
                 CounterTerrorists[randomCt].KillTerrorist(randomTerrorist);
                Console.WriteLine("<Counter-Terrorist>" + " " + "<Terrorist>" + randomTerrorist.Name + " " + "<Died>");
                await Task.Delay(2000);

            }

            else
            {
                Random rnd = new Random();
                var randomIndex = rnd.Next(0, CounterTerrorists.Count - 1);
                var randomCounterTerrorist = CounterTerrorists[randomIndex];

                //Random rnd = new Random();
                //var randomCt = rnd.Next(0, CounterTerrorists.Count - 1);
                //var randomCounterTerrorist = CounterTerrorists[randomCt];
                Console.WriteLine("<Counter-Terrorist>" + " " + randomCounterTerrorist.Name+ " " + "<Missed>");
                Console.WriteLine("");
                await Task.Delay(2000);
            }
        }
        public static void PrintTeamList()
        {
            Console.WriteLine("<<|TERRORIST|>>");
            Console.WriteLine("---------------------");
            Terrorists.ForEach(x => Console.WriteLine("Hp" + "|" + x.Health + "|" + " " + x.Name + " - " + x.Rank));
        }
        //private static void PlayGame(CounterTerrorist ct)
        //{
        //    Terrorist.KillCounterTerrorist(ct);
        //}

        public static void Settings()
        {
            Console.WriteLine("<<|Settings|>>");
            Console.WriteLine("");
            Console.WriteLine("1 - <|Sound Settings|>");
            Console.WriteLine("2 - <|Video Settings|>");
        }
    }
}