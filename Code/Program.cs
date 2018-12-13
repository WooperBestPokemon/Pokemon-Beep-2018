using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
//catch = ((3 * totalHP - 2 * currentHP) * rate * bonusBall) / (3 * totalHP);


namespace Pokemon_Beep
{
    class Program
    {
        public struct Player
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string color { get; set; }
            public double Money { get; set; }
            public Pokemon Pokemon1 { get; set; }
            public Pokemon Pokemon2 { get; set; }
            public Pokemon Pokemon3 { get; set; }

            public Player(string _Name, string _Gender, string _color, double _Money, Pokemon _Pokemon1, Pokemon _Pokemon2, Pokemon _Pokemon3) : this()
            {
                Name = _Name;
                Gender = _Gender;
                Money = _Money;
                Pokemon1 = _Pokemon1;
                Pokemon2 = _Pokemon2;
                Pokemon3 = _Pokemon3;
                color = _color;

            }
        }
        public struct Pokemon
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public double HP { get; set; }
            public double currentHP { get; set; }
            public double Attack { get; set; }
            public double Def { get; set; }
            public double Speed { get; set; }
            public Moves mov1 { get; set; }
            public Moves mov2 { get; set; }
            public Moves mov3 { get; set; }
            public Moves mov4 { get; set; }
            public bool Poisoned { get; set; }
            public bool Asleep { get; set; }



            public Pokemon(string _Name, string _Type, double _HP, double _currentHP, double _Attack, double _Def, double _Speed, Moves _mov1, Moves _mov2, Moves _mov3, Moves _mov4, bool _Poisoned, bool _Asleep) : this()
            {
                Name = _Name;
                Type = _Type;
                HP = _HP;
                currentHP = _currentHP;
                Attack = _Attack;
                Def = _Def;
                Speed = _Speed;
                mov1 = _mov1;
                mov2 = _mov2;
                mov3 = _mov3;
                mov4 = _mov4;
                Poisoned = _Poisoned;
                Asleep = _Asleep;

            }

        }
        public struct Moves
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Attack { get; set; }
            public bool Status { get; set; }
            public int Effect { get; set; }

            public Moves(string _Name, string _Type, int _Attack, bool _Status, int _Effect) : this()
            {
                Name = _Name;
                Type = _Type;
                Attack = _Attack;
                Status = _Status;
                Effect = _Effect;

            }
        }

        static void Main(string[] args)
        {
            SoundPlayer player = new SoundPlayer();

            bool gender = false;
            bool ending = false;
            bool devMode = false;
            bool Tprof = false;
            bool pkm1 = false;
            bool pkm2 = false;
            bool pkm3 = false;
            bool battleOver = false;
            bool validTurn = true;
            bool game = false;
            string Gender = "";
            string Name = "Normies";
            string lowerName = "";
            int choice = 0;
            int totalPkm = 0;
            Random rand = new Random();
            ConsoleKeyInfo keyinfo;

            double totalDamage = 0;
            int posJX = 35;
            int posJY = 11;
            int oldposJX = 35;
            int oldposJY = 11;
            int World = 1;
            int Map = 1;

            int wildPkm = 0;
            int wildSong = 0;
            int randomWild = 0;
            Moves[] tabSelectedMoves = new Moves[2];

            Pokemon[] tabPokemon = new Pokemon[17];
            Moves[] tabMoves = new Moves[25];
            tabMoves[0] = new Moves("Flame Charge", "Fire", 50, false, 0);
            tabMoves[1] = new Moves("Bite", "Normal", 40, false, 0);
            tabMoves[2] = new Moves("Breakfast", "Fire", 0, true, 3);
            tabMoves[3] = new Moves("Growl", "Normal", 0, true, 8);
            tabMoves[4] = new Moves("Water Gun", "Water", 40, false, 0);
            tabMoves[5] = new Moves("Thundershock", "Electric", 40, false, 0);
            tabMoves[6] = new Moves("Quick Attack", "Normal", 40, false, 0);
            tabMoves[7] = new Moves("Tail Whip", "Normal", 0, true, 6);
            tabMoves[8] = new Moves("Rock Smash", "Rock", 40, false, 0);
            tabMoves[9] = new Moves("Chatter", "Flying", 60, false, 0);
            tabMoves[10] = new Moves("Sing", "Normal", 0, true, 5);
            tabMoves[11] = new Moves("Feather Dance", "Flying", 0, true, 7);
            tabMoves[12] = new Moves("Roost", "Flying", 0, true, 3);
            tabMoves[13] = new Moves("Icy Wind", "Ice", 55, false, 0);
            tabMoves[14] = new Moves("Rock Throw", "Rock", 50, false, 0);
            tabMoves[15] = new Moves("Defence Curl", "Normal", 0, true, 4);
            tabMoves[16] = new Moves("Metronome", "Normal", 0, true, 420);
            tabMoves[17] = new Moves("Tackle", "Normal", 40, false, 0);
            tabMoves[18] = new Moves("Grass Knot", "Grass", 50, false, 0);
            tabMoves[19] = new Moves("Growth", "Grass", 0, true, 9);
            tabMoves[20] = new Moves("Synthesis", "Grass", 0, true, 3);
            tabMoves[21] = new Moves("Acid", "Normal", 40, false, 0);
            tabMoves[22] = new Moves("String Shot", "Grass", 0, true, 2);
            tabMoves[23] = new Moves("Poison Sting", "Normal", 0, true, 1);
            tabMoves[24] = new Moves("Confusion", "Normal", 40, false, 0);
            //Starteur
            tabPokemon[0] = new Pokemon("Roselia","Grass", 50, 50, 100, 45, 65, tabMoves[19], tabMoves[20], tabMoves[18], tabMoves[23], false, false);
            tabPokemon[1] = new Pokemon("Psyduck","Water", 50, 50, 65, 50, 55, tabMoves[4], tabMoves[24], tabMoves[7], tabMoves[17], false, false);
            tabPokemon[2] = new Pokemon("Bacub","Fire", 90, 90, 50, 60, 40, tabMoves[0], tabMoves[1], tabMoves[2], tabMoves[3], false, false);
            //route1
            tabPokemon[3] = new Pokemon("Weedle", "Grass", 40, 40, 35, 30, 50, tabMoves[22], tabMoves[21], tabMoves[17], tabMoves[23], false, false);
            tabPokemon[4] = new Pokemon("Oddish", "Grass", 45, 45, 60, 65, 30, tabMoves[18], tabMoves[19], tabMoves[20], tabMoves[21], false, false);
            tabPokemon[5] = new Pokemon("Zigzagoon", "Normal", 38, 38, 30, 41, 60, tabMoves[17], tabMoves[3], tabMoves[8], tabMoves[18], false, false);
            tabPokemon[6] = new Pokemon("Blobbos", "Ice", 42, 42, 17, 36, 15, tabMoves[13], tabMoves[14], tabMoves[15], tabMoves[16], false, false);
            tabPokemon[7] = new Pokemon("Chatot", "Normal", 40, 40, 45, 40, 56, tabMoves[9], tabMoves[10], tabMoves[11], tabMoves[12], false, false);
            tabPokemon[8] = new Pokemon("Pikachu", "Electric", 35,35, 55, 50, 90, tabMoves[5], tabMoves[6], tabMoves[7], tabMoves[8], false, false);
            //route2
            /*
            tabPokemon[9] = new Pokemon("Dwebble", "Rock", 50, 45, 85, 55);
            tabPokemon[10] = new Pokemon("Cubone", "Rock", 50, 50, 65, 35);
            tabPokemon[11] = new Pokemon("Sandile", "Rock", 50, 72, 35, 65);
            tabPokemon[12] = new Pokemon("Trapinch", "Rock", 45, 100, 45, 10);
            tabPokemon[13] = new Pokemon("Sandshrew", "Rock", 50, 75, 85, 40);
            //Special
            tabPokemon[14] = new Pokemon("Goato", "C#", 100, 100, 100, 100);
            tabPokemon[15] = new Pokemon("", "", 0, 0, 0, 0);
            */
            tabPokemon[16] = new Pokemon("MissingNo.", "Bird", 33, 33, 136, 6, 29, tabMoves[0], tabMoves[0], tabMoves[0], tabMoves[0], false, false);

            Pokemon[] tabWildPokemon = new Pokemon[1];
            Pokemon[] tabBattle = new Pokemon[2];
            tabWildPokemon[0] = tabPokemon[16];

            Player[] tabPlayer = new Player[1];
            tabPlayer[0] = new Player("", "", "", 0, tabPokemon[16], tabPokemon[16], tabPokemon[16]);

            Moves[] tabBattleMoves = new Moves[2];


            string[,] tabHitboxCity1 = new string[121, 37];
            string[,] tabHitboxHome = new string[121, 37];
            string[,] tabHitboxNPC = new string[121, 37];
            string[,] tabHitboxLab = new string[121, 37];
            string[,] tabHitboxRoute1 = new string[139, 37];
            Console.CursorVisible = false;

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------Actual Game------------------------------
            Console.SetWindowSize(120, 30);
            intro();
            menu();
            profMaple();
            creeHitoxCity1();
            

            while (ending == false)
            {
                switch (World)
                {
                    //VILLE-------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    case 1:
                        player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "City1.wav";
                        player.Play();
                        while (World == 1)
                        {
                            //M^PXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                            switch (Map)
                            {
                                case 0:
                                    Console.Clear();
                                    Map0();
                                    NPCCity1();
                                    MPlayer();
                                    while (Map == 0 && World == 1)
                                    {
                                        movPlayer();
                                        Console.Clear();
                                        hitboxChecker();
                                        Map0();
                                        NPCCity1();                                        
                                        MPlayer();
                                        housechecker1();                                     
                                    }

                                    break;
                                case 1:
                                    posJX = posJX + 39;
                                    posJY = posJY + 12;
                                    Console.Clear();
                                    Home();
                                    NPCCity1();
                                    MPlayer();
                                    while (Map == 1)
                                    {
                                        movPlayer();
                                        Console.Clear();
                                        hitboxChecker();
                                        Home();
                                        NPCCity1();
                                        MPlayer();
                                        exitcheckerCity1();

                                    }

                                    break;
                                case 2:
                                    posJX = 53;
                                    posJY = 23;
                                    Console.Clear();
                                    HouseNPC();
                                    NPCCity1();
                                    MPlayer();
                                    while (Map == 2)
                                    {
                                        movPlayer();
                                        Console.Clear();
                                        hitboxChecker();
                                        HouseNPC();
                                        NPCCity1();
                                        MPlayer();
                                        exitcheckerCity1();

                                    }
                                    break;
                                case 3:
                                    posJX = 53;
                                    posJY = 23;
                                    Console.Clear();
                                    HouseNPC();
                                    NPCCity1();
                                    MPlayer();
                                    while (Map == 3)
                                    {
                                        movPlayer();
                                        Console.Clear();
                                        hitboxChecker();
                                        HouseNPC();
                                        NPCCity1();
                                        MPlayer();
                                        exitcheckerCity1();

                                    }
                                    break;
                                case 4:

                                    posJX = 61;
                                    posJY = 25;
                                    Console.Clear();
                                    player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Lab.wav";
                                    player.Play();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();
                                    while (Map == 4)
                                    {
                                        movPlayer();
                                        Console.Clear();
                                        hitboxChecker();
                                        Lab();
                                        NPCCity1();
                                        MPlayer();
                                        exitcheckerCity1();
                                    }
                                    
                                    break;
                            }
                        }



                        break;
                    case 2:
                        player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "route1.wav";
                        player.Play();                       
                        
                        while (World == 2)
                        {
                            //ROUTE 1                      
                            Console.Clear();
                            route1();
                            MPlayer();
                            while (World == 2)
                            {
                                movPlayer();
                                Console.Clear();
                                hitboxChecker();
                                route1();
                                MPlayer();
                                exitcheckerRoute1();
                            }
                        }
                        break;
                    case 3:
                        break;
                }               
            }










            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------Void-----------------------------------
            void exitcheckerRoute1()
            {
                if (posJX == 0)
                {
                    Console.SetCursorPosition(85, 18);
                    Console.WriteLine(" _________________________________");
                    Console.SetCursorPosition(85, 19);
                    Console.WriteLine("| Press Space to enter Pewdy City |");
                    Console.SetCursorPosition(85, 20);
                    Console.WriteLine("|_________________________________|");
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        World = 1;
                        posJX = 119;
                        posJY = posJY + 4;
                    }
                    else
                    {
                        Console.Clear();
                        posJX = 1;
                    }

                    route1();                   
                    MPlayer();
                }
            }
            //HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH           
            void NPCCity1()
            {
                switch (Map)
                {
                    case 0:
                        if (totalPkm == 0)
                        {

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.SetCursorPosition(115, 19);
                            Console.WriteLine("O");
                            if (posJX == 116)
                            {
                                MPlayer();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(63, 15);
                                Console.WriteLine(" _______________________________________________");
                                Console.SetCursorPosition(63, 16);
                                Console.WriteLine("|My mommy says it's dangerous to leave the city |");
                                Console.SetCursorPosition(63, 17);
                                Console.WriteLine("|without a Pokemon :( That is why I won't allow |");
                                Console.SetCursorPosition(63, 18);
                                Console.WriteLine("|you to get outside >:3 !  MOUAHAHAHA           |");
                                Console.SetCursorPosition(63, 19);
                                Console.WriteLine("|_______________________________________________|");
                                Console.ReadKey(true);
                                posJX--;
                                Console.Clear();
                                Map0();
                                NPCCity1();
                                MPlayer();
                            }
                        }
                        else if (totalPkm == 1 && game == false)
                        {

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.SetCursorPosition(115, 19);
                            Console.WriteLine("O");
                            if (posJX == 116)
                            {
                                MPlayer();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(63, 15);
                                Console.WriteLine(" _______________________________________________");
                                Console.SetCursorPosition(63, 16);
                                Console.WriteLine("|Sorry, but you need to pay for the day 1 DLC,  |");
                                Console.SetCursorPosition(63, 17);
                                Console.WriteLine("|which include the Route 1 ! #UbisoftMontreal   |");
                                Console.SetCursorPosition(63, 18);
                                Console.WriteLine("|_______________________________________________|");
                                Console.ReadKey(true);
                                posJX--;
                                Console.Clear();
                                Map0();
                                NPCCity1();
                                MPlayer();
                            }
                        }
                        else
                            {
                                Console.SetCursorPosition(79, 11);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("O");
                                if ((posJX == 79 && posJY == 11))
                                {
                                    oldPlace();
                                    MPlayer();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.SetCursorPosition(74, 6);
                                    Console.WriteLine("_____________________________________________");
                                    Console.SetCursorPosition(73, 7);
                                    Console.WriteLine("|Even if the devs of this game are too lazy to|");
                                    Console.SetCursorPosition(73, 8);
                                    Console.WriteLine("|make me a cute sprite, Imma still cute ^^    |");
                                    Console.SetCursorPosition(73, 9);
                                    Console.WriteLine("|_____________________________________________|");
                                }

                            }
                        Console.SetCursorPosition(29, 27);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("O");
                        if ((posJX == 29 && posJY == 27))
                        {
                            oldPlace();
                            MPlayer();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition(25, 22);
                            Console.WriteLine(" _________________________________________________________");
                            Console.SetCursorPosition(25, 23);
                            Console.WriteLine("|Kon'ichiwa! watashi is called Kuroda Yoshihiro, ichi day,|");
                            Console.SetCursorPosition(25, 24);
                            Console.WriteLine("|i will be the saikyono trainer of this sekai !  （・ｗ・）    |");
                            Console.SetCursorPosition(25, 25);
                            Console.WriteLine("|_________________________________________________________|");
                        }
                        Console.SetCursorPosition(98, 16);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("O");
                        if ((posJX == 98 && posJY == 16))
                        {
                            oldPlace();
                            MPlayer();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if(tabPlayer[0].Gender == "Attack Helicopter")
                            {
                                Console.SetCursorPosition(23, 13);
                                Console.WriteLine(" _______________________________________________________________________");
                                Console.SetCursorPosition(23, 14);
                                Console.WriteLine("|my surgery to install rotary blades, 30 mm cannons and AMG-114 Hellfire|");
                                Console.SetCursorPosition(23, 15);
                                Console.WriteLine("|missiles on my body is next week what about you ?                      |");
                                Console.SetCursorPosition(23, 16);
                                Console.WriteLine("|_______________________________________________________________________|");
                            }
                            else
                            {
                                Console.SetCursorPosition(75, 12);
                                Console.WriteLine(" ____________________________________________");
                                Console.SetCursorPosition(75, 13);
                                Console.WriteLine("|You'll never understand me you filthy normie|");
                                Console.SetCursorPosition(75, 14);
                                Console.WriteLine("|____________________________________________|");
                            }

                        }
                        

                        break;
                    case 1:
                        Console.SetCursorPosition(49, 17);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("@");
                        if ((posJX == 49 && posJY == 17))
                        {
                            if(Gender == "Boy")
                            {
                                oldPlace();
                                MPlayer();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(" _____________________________________________");
                                Console.SetCursorPosition(25, 12);
                                Console.WriteLine("|Happy birthday honey :) The professor said   |");
                                Console.SetCursorPosition(25, 13);
                                Console.WriteLine("|he had a surprise for you ;P you should meet |");
                                Console.SetCursorPosition(25, 14);
                                Console.WriteLine("|him at his lab ^-^                           |");
                                Console.SetCursorPosition(25, 15);
                                Console.WriteLine("|_____________________________________________|");
                            }
                            else if(Gender == "Girl")
                            {
                                oldPlace();
                                MPlayer();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(25, 11);
                                Console.WriteLine(" _____________________________________________");
                                Console.SetCursorPosition(25, 12);
                                Console.WriteLine("|Happy birthday cutie ^^ ! The professor said |");
                                Console.SetCursorPosition(25, 13);
                                Console.WriteLine("|He had a surprise for you ;P you should meet |");
                                Console.SetCursorPosition(25, 14);
                                Console.WriteLine("|him at his lab ^-^ !                         |");
                                Console.SetCursorPosition(25, 15);
                                Console.WriteLine("|_____________________________________________|");
                            }
                            else
                            {
                                oldPlace();
                                MPlayer();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(25, 11);
                                Console.WriteLine(" ________________________________________________");
                                Console.SetCursorPosition(25, 12);
                                Console.WriteLine("|Happy birthday my child ^^ ! The professor said |");
                                Console.SetCursorPosition(25, 13);
                                Console.WriteLine("|He had a surprise for you ;P you should meet    |");
                                Console.SetCursorPosition(25, 14);
                                Console.WriteLine("|him at his lab ^-^ !                            |");
                                Console.SetCursorPosition(25, 15);
                                Console.WriteLine("|________________________________________________|");
                            }
                            
                        }
                        if ((posJX == 74 && posJY == 22))
                        {

                            oldPlace();
                            MPlayer();
                            Console.SetCursorPosition(40, 26);
                            Console.WriteLine(" ________________________________________________________");
                            Console.SetCursorPosition(40, 27);
                            Console.WriteLine("| You are playing Smash melee on the gamecube ...        |");
                            Console.SetCursorPosition(40, 28);
                            Console.WriteLine("| Okey, it's time to go !                                |");
                            Console.SetCursorPosition(40, 29);
                            Console.WriteLine("|________________________________________________________|");
                        }
                            break;
                    case 2:
                        break;
                    case 3:
                        Console.SetCursorPosition(52, 17);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("O");
                        if ((posJX == 52 && posJY == 17))
                        {
                            oldPlace();
                            MPlayer();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(25, 12);
                            Console.WriteLine(" __________________________________________");
                            Console.SetCursorPosition(25, 13);
                            Console.WriteLine("|honey you oil smell so good today and your|");
                            Console.SetCursorPosition(25, 14);
                            Console.WriteLine("|tail rotor look so good !                 |");
                            Console.SetCursorPosition(25, 15);
                            Console.WriteLine("|__________________________________________|");
                        }
                        Console.SetCursorPosition(50, 17);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("O");
                        if ((posJX == 50 && posJY == 17))
                        {
                            oldPlace();
                            MPlayer();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(25, 12);
                            Console.WriteLine(" _________________________________________________________");
                            Console.SetCursorPosition(25, 13);
                            Console.WriteLine("|ohh that sooo sweet, let's go fly above oilfield together|");
                            Console.SetCursorPosition(25, 14);
                            Console.WriteLine("|once this heliphobe get the fuck out of our house        |");
                            Console.SetCursorPosition(25, 15);
                            Console.WriteLine("|_________________________________________________________|");
                        }
                        break;
                    case 4:
                        Console.SetCursorPosition(61, 18);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("@");
                        if ((posJX == 61 && posJY == 18))
                        {
                            oldPlace();
                            MPlayer();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if(totalPkm == 0 && Tprof == false)
                            {
                                Tprof = true;
                                switch (tabPlayer[0].Gender)
                                {
                                    case "Boy":
                                        Console.SetCursorPosition(25, 11);
                                        Console.WriteLine(" __________________________________________________________________________________");
                                        Console.SetCursorPosition(25, 12);
                                        Console.WriteLine("|Welcome young boy, I want you to go and gather info on the pokemon of this region.|");
                                        Console.SetCursorPosition(25, 13);
                                        Console.WriteLine("|It's not like it is hard or anything there's like 15 pokemons.                    |");
                                        Console.SetCursorPosition(25, 14);
                                        Console.WriteLine("|Anyway so choose a pokemon and get out.                                           |");
                                        Console.SetCursorPosition(25, 15);
                                        Console.WriteLine("|__________________________________________________________________________________|");
                                        break;
                                    case "Girl":
                                        Console.SetCursorPosition(25, 11);
                                        Console.WriteLine(" __________________________________________________________________________________");
                                        Console.SetCursorPosition(25, 12);
                                        Console.WriteLine("|Welcome young girl, I want you to go and gather info on the pokemon of this region.|");
                                        Console.SetCursorPosition(25, 13);
                                        Console.WriteLine("|It's not like it is hard or anything there's like 15 pokemons.                    |");
                                        Console.SetCursorPosition(25, 14);
                                        Console.WriteLine("|Anyway so choose a pokemon and get out.                                           |");
                                        Console.SetCursorPosition(25, 15);
                                        Console.WriteLine("|__________________________________________________________________________________|");
                                        break;
                                    case "SWJ":
                                        Console.SetCursorPosition(25, 11);
                                        Console.WriteLine(" _________________________________________________________________________________________");
                                        Console.SetCursorPosition(25, 12);
                                        Console.WriteLine("|Welcome young none binary person who piss off every white male on earth!  of this region.|");
                                        Console.SetCursorPosition(25, 13);
                                        Console.WriteLine("|I want you to go and gather info on the pokemon, It's not like it is hard or anything    |");
                                        Console.SetCursorPosition(25, 14);
                                        Console.WriteLine("|there's like 15 pokemons.. Anyway so choose a pokemon and get out.                       |");
                                        Console.SetCursorPosition(25, 15);
                                        Console.WriteLine("|_________________________________________________________________________________________|");
                                        break;
                                    default:
                                        Console.SetCursorPosition(25, 11);
                                        Console.WriteLine(" __________________________________________________________________________________");
                                        Console.SetCursorPosition(25, 12);
                                        Console.WriteLine("|Welcome young kid, I want you to go and gather info on the pokemon of this region.|");
                                        Console.SetCursorPosition(25, 13);
                                        Console.WriteLine("|It's not like it is hard or anything there's like 15 pokemons.                    |");
                                        Console.SetCursorPosition(25, 14);
                                        Console.WriteLine("|Anyway so choose a pokemon and get out.                                           |");
                                        Console.SetCursorPosition(25, 15);
                                        Console.WriteLine("|__________________________________________________________________________________|");
                                        break;

                                }
                                
                            }
                            else if (totalPkm == 0 && Tprof == true)
                            {
                                Console.SetCursorPosition(47, 13);
                                Console.WriteLine(" _____________________________");
                                Console.SetCursorPosition(47, 14);
                                Console.WriteLine("|Go ahead, choose a pokemon ! |");
                                Console.SetCursorPosition(47, 15);
                                Console.WriteLine("|_____________________________|");
                            }
                            else
                            {
                                Console.SetCursorPosition(32, 13);
                                Console.WriteLine(" ___________________________________________________________");
                                Console.SetCursorPosition(32, 14);
                                Console.WriteLine("|Now that you have a pokemon get out of my lab i'm occupied |");
                                Console.SetCursorPosition(32, 15);
                                Console.WriteLine("|___________________________________________________________|");
                            }
                            
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        if(pkm1 == false)
                        {
                            Console.SetCursorPosition(69, 16);
                            Console.WriteLine("¤");
                        }
                        if(pkm2 == false)
                        {
                            Console.SetCursorPosition(72, 16);
                            Console.WriteLine("¤");
                        }
                        if (pkm3 == false)
                        {
                            Console.SetCursorPosition(75, 16);
                            Console.WriteLine("¤");
                        }
                        if(posJX == 69 && posJY == 17)
                        {
                            oldPlace();
                            MPlayer();
                            if(totalPkm == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.SetCursorPosition(47, 10);
                                Console.WriteLine(" ____________________________________________________");
                                Console.SetCursorPosition(47, 11);
                                Console.Write("|So, you want a Roselia ? It's a");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" grass ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("type Pokémon. |");
                                Console.SetCursorPosition(47, 12);
                                Console.WriteLine("|It may looks small, but don't worry, it can fight   |");
                                Console.SetCursorPosition(47, 13);
                                Console.WriteLine("|(Press Space to choose this Pokémon)                |");
                                Console.SetCursorPosition(47, 14);
                                Console.WriteLine("|____________________________________________________|");
                                keyinfo = Console.ReadKey(true);
                                if (keyinfo.Key == ConsoleKey.Spacebar)
                                {
                                    pkm1 = true;
                                    tabPlayer[0].Pokemon1 = tabPokemon[0];
                                    totalPkm++;
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();

                                }
                                else
                                {
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();
                                }
                            }
                            
                        }
                        if(posJX == 69 && posJY == 17)
                        {
                            oldPlace();
                            MPlayer();
                            if(totalPkm == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.SetCursorPosition(47, 10);
                                Console.WriteLine(" ____________________________________________________");
                                Console.SetCursorPosition(47, 11);
                                Console.Write("|So, you want a Roselia ? It's a");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" grass ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("type Pokémon. |");
                                Console.SetCursorPosition(47, 12);
                                Console.WriteLine("|It may looks small, but don't worry, it can fight   |");
                                Console.SetCursorPosition(47, 13);
                                Console.WriteLine("|(Press Space to choose this Pokémon)                |");
                                Console.SetCursorPosition(47, 14);
                                Console.WriteLine("|____________________________________________________|");
                                keyinfo = Console.ReadKey(true);
                                if (keyinfo.Key == ConsoleKey.Spacebar)
                                {
                                    pkm1 = true;
                                    tabPlayer[0].Pokemon1 = tabPokemon[0];
                                    totalPkm++;
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();

                                }
                                else
                                {
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();
                                }
                            }
                            
                        }
                        if (posJX == 72 && posJY == 17)
                        {
                            oldPlace();
                            MPlayer();
                            if (totalPkm == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.SetCursorPosition(47, 10);
                                Console.WriteLine(" ____________________________________________________");
                                Console.SetCursorPosition(47, 11);
                                Console.Write("|So, you want a Psyduck ? It's a");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(" water ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("type Pokémon. |");
                                Console.SetCursorPosition(47, 12);
                                Console.WriteLine("|It may looks stupid and dump, but it can fight      |");
                                Console.SetCursorPosition(47, 13);
                                Console.WriteLine("|(Press Space to choose this Pokémon)                |");
                                Console.SetCursorPosition(47, 14);
                                Console.WriteLine("|____________________________________________________|");
                                keyinfo = Console.ReadKey(true);
                                if (keyinfo.Key == ConsoleKey.Spacebar)
                                {
                                    pkm2 = true;
                                    tabPlayer[0].Pokemon1 = tabPokemon[1];
                                    totalPkm++;
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();

                                }
                                else
                                {
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();
                                }
                            }

                        }
                        if (posJX == 75 && posJY == 17)
                        {
                            oldPlace();
                            MPlayer();
                            if (totalPkm == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.SetCursorPosition(47, 10);
                                Console.WriteLine(" ____________________________________________________");
                                Console.SetCursorPosition(47, 11);
                                Console.Write("|So, you want a Bacub ? It's a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" fire ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("type Pokémon.    |");
                                Console.SetCursorPosition(47, 12);
                                Console.WriteLine("|It may looks yummy and delicious, but it ain't food!|");
                                Console.SetCursorPosition(47, 13);
                                Console.WriteLine("|(Press Space to choose this Pokémon)                |");
                                Console.SetCursorPosition(47, 14);
                                Console.WriteLine("|____________________________________________________|");
                                keyinfo = Console.ReadKey(true);
                                if (keyinfo.Key == ConsoleKey.Spacebar)
                                {
                                    pkm3 = true;
                                    tabPlayer[0].Pokemon1 = tabPokemon[2];
                                    totalPkm++;
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();

                                }
                                else
                                {
                                    Console.Clear();
                                    Lab();
                                    NPCCity1();
                                    MPlayer();
                                }
                            }

                        }
                        break;
                }
                //NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNCITY1NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
                
                
                
            }
            //BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB---------------------------------------------AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            void wildEncounter()
            {
                wildPkm = rand.Next(0, 101);
                switch (World)
                {
                    case 2:
                        if(wildPkm == 0)
                        {
                            //Blobbos 1%
                            tabWildPokemon[0] = tabPokemon[6];
                        }
                        else if(wildPkm > 0 && wildPkm <= 10)
                        {
                            //Chatot 9%
                            tabWildPokemon[0] = tabPokemon[7];
                        }
                        else if(wildPkm > 10 && wildPkm <= 20)
                        {
                            //Pikachu 10 %
                            tabWildPokemon[0] = tabPokemon[8];
                        }
                        else if (wildPkm > 20 && wildPkm <= 50)
                        {
                            //Weedle 30 %
                            tabWildPokemon[0] = tabPokemon[3];
                        }
                        else if (wildPkm > 50 && wildPkm <= 75)
                        {
                            //Odish 25 %
                            tabWildPokemon[0] = tabPokemon[4];
                        }
                        else if (wildPkm > 75 && wildPkm <= 100)
                        {
                            //Zigzagoon 25 %
                            tabWildPokemon[0] = tabPokemon[5];
                        }
                        wildSong = rand.Next(1, 4);
                        if(wildSong == 1)
                        {
                            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Wild1.wav";
                            player.Play();
                        }
                        else if(wildSong == 2)
                        {
                            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Wild2.wav";
                            player.Play();
                        }
                        else
                        {
                            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Wild3.wav";
                            player.Play();
                        }

                        battleAnimation();
                        tabBattle[0] = tabPlayer[0].Pokemon1;
                        tabBattle[1] = tabWildPokemon[0];
                        break;
                }
            }
            void battleAnimation()
            {
                switch (World)
                {
                    case 1:
                        break;
                    case 2:
                        blink();
                        blink();
                        blink();                       
                        break;
                }
            }
            void wildBattle()
            {
                wildEncounter();
                battleScreen();
                pkmInfo();
                while(battleOver == false)
                {
                    battleScreen();
                    pkmInfo();
                    attackChoice();
                    attackChoiceBot();
                    trueBattle();
                    Console.Clear();                    
                }

            }
            void trueBattle()
            {
                if(tabBattle[0].Speed > tabBattle[1].Speed)
                {
                    //Si ta vitesse est plus grande
                    if(tabBattleMoves[0].Effect == 0)
                    {
                        totalDamage = (((2 * 1 + 10) / 250) * (tabBattle[0].Attack / tabBattle[0].Def)) + 2;
                    }
                }
                else if(tabBattle[0].Speed == tabBattle[1].Speed)
                {
                    //si égale
                }
                else
                {
                    //si l'autre est plus vite
                }
            }
            void attackChoiceBot()
            {
                choice = rand.Next(1, 5);
                switch (choice)
                {
                    case 1:
                        tabBattleMoves[1] = tabBattle[1].mov1;
                        break;
                    case 2:
                        tabBattleMoves[1] = tabBattle[1].mov2;
                        break;
                    case 3:
                        tabBattleMoves[1] = tabBattle[1].mov3;
                        break;
                    case 4:
                        tabBattleMoves[1] = tabBattle[1].mov4;
                        break;
                }
            }
            void attackChoice()
            {
                while(validTurn == true)
                {
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.S)
                    {
                        tabBattleMoves[0] = tabBattle[0].mov2;
                        validTurn = true;
                    }
                    else if (keyinfo.Key == ConsoleKey.A)
                    {
                        tabBattleMoves[0] = tabBattle[0].mov1;
                        validTurn = true;
                    }
                    else if (keyinfo.Key == ConsoleKey.W)
                    {
                        tabBattleMoves[0] = tabBattle[0].mov3;
                        validTurn = true;
                    }
                    else if (keyinfo.Key == ConsoleKey.D)
                    {
                        tabBattleMoves[0] = tabBattle[0].mov4;
                        validTurn = true;
                    }
                    else
                    {
                        validTurn = false;
                    }
                }
                                
            }
            void blink()
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                System.Threading.Thread.Sleep(100);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(100);
                Console.Clear();
            }
            void effectChecker()
            {
                switch (tabSelectedMoves[0].Effect)
                {
                    case 1:
                        //Poison
                        break;
                }
            }
            void resetStats()
            {

            }
            void pkmInfo()
            {
                //Name
                Console.SetCursorPosition(5, 6);
                Console.WriteLine(tabBattle[1].Name);
                Console.SetCursorPosition(77, 19);
                Console.WriteLine(tabBattle[0].Name);
                //HP
                Console.SetCursorPosition(25,9);
                Console.WriteLine(tabBattle[1].currentHP + "/" + tabBattle[1].HP);
                Console.SetCursorPosition(94, 22);
                Console.WriteLine(tabBattle[0].currentHP + "/" + tabBattle[0].HP);

                //text Box
                Console.SetCursorPosition(9, 30);
                Console.WriteLine("What will " + tabBattle[0].Name + " do ?");

                Console.SetCursorPosition(70, 29);
                Console.WriteLine("A - " + tabBattle[0].mov1.Name + "   " + tabBattle[0].mov1.Type);
                Console.SetCursorPosition(70, 31);
                Console.WriteLine("S - " + tabBattle[0].mov2.Name + "   " + tabBattle[0].mov2.Type);
                Console.SetCursorPosition(70, 33);
                Console.WriteLine("W - " + tabBattle[0].mov3.Name + "   " + tabBattle[0].mov3.Type);
                Console.SetCursorPosition(70, 35);
                Console.WriteLine("D - " + tabBattle[0].mov4.Name + "   " + tabBattle[0].mov4.Type);
            }
            //BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB---------------------------------------------AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            void exitcheckerCity1()
            {
                switch (Map)
                {
                    case 1:
                        if ((posJX == 53 && posJY == 24) || (posJX == 52 && posJY == 24) || (posJX == 54 && posJY == 24))
                        {
                            Console.SetCursorPosition(41, 25);
                            Console.WriteLine(" _____________________");
                            Console.SetCursorPosition(41, 26);
                            Console.WriteLine("| Press Space to Exit |");
                            Console.SetCursorPosition(41, 27);
                            Console.WriteLine("|_____________________|");
                            keyinfo = Console.ReadKey(true);
                            if (keyinfo.Key == ConsoleKey.Spacebar)
                            {
                                Map = 0;
                                posJX = 14;
                                posJY = 12;
                            }
                            else
                            {
                                Console.Clear();
                                posJY--;
                            }
                            Home();
                            NPCCity1();
                            MPlayer();
                        }
                        break;
                    case 2:
                        if ((posJX == 53 && posJY == 24) || (posJX == 52 && posJY == 24) || (posJX == 54 && posJY == 24))
                        {
                            Console.SetCursorPosition(41, 25);
                            Console.WriteLine(" _____________________");
                            Console.SetCursorPosition(41, 26);
                            Console.WriteLine("| Press Space to Exit |");
                            Console.SetCursorPosition(41, 27);
                            Console.WriteLine("|_____________________|");
                            keyinfo = Console.ReadKey(true);
                            if (keyinfo.Key == ConsoleKey.Spacebar)
                            {
                                Map = 0;
                                posJX = 62;
                                posJY = 12;
                            }
                            else
                            {
                                Console.Clear();
                                posJY--;
                            }
                            HouseNPC();
                            NPCCity1();
                            MPlayer();
                        }
                        break;
                    case 3:
                        if ((posJX == 53 && posJY == 24) || (posJX == 52 && posJY == 24) || (posJX == 54 && posJY == 24))
                        {
                            Console.SetCursorPosition(41, 25);
                            Console.WriteLine(" _____________________");
                            Console.SetCursorPosition(41, 26);
                            Console.WriteLine("| Press Space to Exit |");
                            Console.SetCursorPosition(41, 27);
                            Console.WriteLine("|_____________________|");
                            keyinfo = Console.ReadKey(true);
                            if (keyinfo.Key == ConsoleKey.Spacebar)
                            {
                                Map = 0;
                                posJX = 77;
                                posJY = 27;
                            }
                            else
                            {
                                Console.Clear();
                                posJY--;
                            }
                            HouseNPC();
                            NPCCity1();
                            MPlayer();
                        }
                        break;
                    case 4:
                        if ((posJX == 61 && posJY == 26) || (posJX == 60 && posJY == 26) || (posJX == 62 && posJY == 26))
                        {
                            Console.SetCursorPosition(49, 27);
                            Console.WriteLine(" _____________________");
                            Console.SetCursorPosition(49, 28);
                            Console.WriteLine("| Press Space to Exit |");
                            Console.SetCursorPosition(49, 29);
                            Console.WriteLine("|_____________________|");
                            keyinfo = Console.ReadKey(true);
                            if (keyinfo.Key == ConsoleKey.Spacebar)
                            {
                                Map = 0;
                                posJX = 47;
                                posJY = 27;
                                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "City1.wav";
                                player.Play();
                            }
                            else
                            {
                                Console.Clear();
                                posJY--;
                            }
                            Lab();
                            NPCCity1();
                            MPlayer();
                        }
                        break;
                }
            }
            void housechecker1()
            {
                if (posJX == 14 && posJY == 11)
                {
                    Console.SetCursorPosition(16, 8);
                    Console.WriteLine(" ______________________");
                    Console.SetCursorPosition(16, 9);
                    Console.WriteLine("| Press Space to enter |");
                    Console.SetCursorPosition(16, 10);
                    Console.WriteLine("|______________________|");
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        Map = 1;
                    }
                    else
                    {
                        Console.Clear();
                        posJY = 12;
                    }

                    Map0();
                    NPCCity1();
                    MPlayer();
                }
                if (posJX == 62 && posJY == 11)
                {
                    Console.SetCursorPosition(64, 8);
                    Console.WriteLine(" ______________________");
                    Console.SetCursorPosition(64, 9);
                    Console.WriteLine("| Press Space to enter |");
                    Console.SetCursorPosition(64, 10);
                    Console.WriteLine("|______________________|");
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        Map = 2;
                    }
                    else
                    {
                        Console.Clear();
                        posJY = 12;
                    }

                    Map0();
                    NPCCity1();
                    MPlayer();
                }
                if (posJX == 47 && posJY == 26)
                {
                    Console.SetCursorPosition(49, 23);
                    Console.WriteLine(" ______________________");
                    Console.SetCursorPosition(49, 24);
                    Console.WriteLine("| Press Space to enter |");
                    Console.SetCursorPosition(49, 25);
                    Console.WriteLine("|______________________|");
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        Map = 4;
                    }
                    else
                    {
                        Console.Clear();
                        posJY = 27;
                    }                  
                    Map0();
                    NPCCity1();
                    MPlayer();
                }
                if (posJX == 77 && posJY == 26)
                {
                    Console.SetCursorPosition(79, 23);
                    Console.WriteLine(" ______________________");
                    Console.SetCursorPosition(79, 24);
                    Console.WriteLine("| Press Space to enter |");
                    Console.SetCursorPosition(79, 25);
                    Console.WriteLine("|______________________|");
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        Map = 3;
                    }
                    else
                    {
                        Console.Clear();
                        posJY = 27;
                    }

                    Map0();
                    NPCCity1();
                    MPlayer();
                }
                if (posJX == 120)
                {
                    Console.SetCursorPosition(85, 18);
                    Console.WriteLine(" ______________________________");
                    Console.SetCursorPosition(85, 19);
                    Console.WriteLine("| Press Space to enter route 1 |");
                    Console.SetCursorPosition(85, 20);
                    Console.WriteLine("|______________________________|");
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        World = 2;
                        posJY = posJY - 4;
                        posJX = 1;
                    }
                    else
                    {
                        Console.Clear();
                        posJX = 119;
                    }

                    Map0();
                    NPCCity1();
                    MPlayer();
                }
            }
            void MPlayer()
            {
                if(devMode == false)
                {
                    Console.SetCursorPosition(posJX, posJY);
                    playerColor();
                    Console.Write("■");
                    oldposJX = posJX;
                    oldposJY = posJY;
                }
                else
                {
                    Console.SetCursorPosition(posJX, posJY);
                    playerColor();
                    Console.Write("■" + "(" + posJX + ", " + posJY + ")");
                    oldposJX = posJX;
                    oldposJY = posJY;
                }
                
            }
            void oldPlace()
            {
                posJX = oldposJX;
                posJY = oldposJY;
            }
            void playerColor()
            {
                switch (tabPlayer[0].Gender)
                {
                    case "Boy":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Girl":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Attack Helicopter":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "SJW":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            void profMaple()
            {
                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Prof.wav";
                player.Play();               
                Console.ForegroundColor = ConsoleColor.Black;
                prof();
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                prof();
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Gray;
                prof();
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                prof();
                System.Threading.Thread.Sleep(500);
                proftext();
                Console.SetCursorPosition(1, 26);
                Console.WriteLine("Welcome to the world of Pokemon ! My name is Professor Maple");
                Console.SetCursorPosition(1, 27);
                Console.WriteLine("but everyone calls me the Professor.");
                pressK();
                pressClear();
                proftext();
                Console.SetCursorPosition(1, 26);
                Console.WriteLine("This world is \"widely\" inahited by creatures known as Pokémon");
                Console.SetCursorPosition(1, 27);
                Console.WriteLine("Here is a Blobbos for exemple !");
                System.Threading.Thread.Sleep(300);
                blobbos();
                Console.Beep(700, 600);
                Console.Beep(500, 400);
                pressK();
                pressClear();
                proftext();
                blobbos();
                Console.SetCursorPosition(1, 26);
                Console.WriteLine("We humans live alongside Pokémon as friends");
                Console.SetCursorPosition(1, 27);
                Console.WriteLine("Now, why you don't tell me a little about yourself ?");
                pressK();
                pressClear();

                while (gender == false)
                {
                    proftext();
                    blobbos();
                    Console.SetCursorPosition(1, 25);
                    Console.WriteLine("Are you a....");
                    Console.SetCursorPosition(1, 26);
                    Console.WriteLine("1. Boy       3. Attack Helicopter");
                    Console.SetCursorPosition(1, 27);
                    Console.WriteLine("2. Girl      4. WTF ? There is more than 3 genders you fucking White Male !");
                    Console.SetCursorPosition(1, 28);
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Gender = "Boy";
                            break;
                        case 2:
                            Gender = "Girl";
                            break;
                        case 3:
                            Gender = "Attack Helicopter";
                            break;
                        case 4:
                            Gender = "SJW";
                            break;
                        default:
                            Gender = "Neutral";
                            break;
                    }
                    Console.Clear();
                    proftext();
                    blobbos();
                    Console.SetCursorPosition(1, 25);
                    Console.WriteLine("So, you are a " + Gender + " ?");
                    Console.SetCursorPosition(1, 26);
                    Console.WriteLine("1. Yes");
                    Console.SetCursorPosition(1, 27);
                    Console.WriteLine("2. No");
                    Console.SetCursorPosition(1, 28);
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > 2)
                    {
                        choice = 2;
                    }
                    if (choice == 1)
                    {
                        gender = true;
                    }
                    else
                    {
                        gender = false;
                    }
                    Console.Clear();
                }
                proftext();
                blobbos();
                Console.SetCursorPosition(1, 26);
                Console.WriteLine("Please, tell me your name...");
                Console.SetCursorPosition(1, 28);
                Name = Convert.ToString(Console.ReadLine());
                Console.Clear();

                if (Name.Length > 9)
                {
                    while (Name.Length > 9)
                    {
                        Console.Clear();
                        proftext();
                        blobbos();
                        Console.SetCursorPosition(1, 26);
                        Console.WriteLine("Sorry, but your name can't have more than 9 Characters...");
                        Console.SetCursorPosition(1, 27);
                        Console.WriteLine("Please, re-enter your name.");
                        Console.SetCursorPosition(1, 28);
                        Name = Convert.ToString(Console.ReadLine());
                    }

                }

                Console.Clear();
                proftext();
                blobbos();

                Console.SetCursorPosition(1, 26);
                Console.WriteLine(Name + ", are you ready ? your very own adventure will start soon ! ");
                Console.SetCursorPosition(1, 27);
                Console.WriteLine("See you later !");
                tabPlayer[0].Gender = Gender;
                tabPlayer[0].Name = Name;
                lowerName = tabPlayer[0].Name.ToLower();
                tabPlayer[0].Money = 1000;
                pressK();
                pressClear();
                creeHitoxCity1();

            }
            void movPlayer()
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key == ConsoleKey.S)
                {
                    posJY += 1;
                }
                else if (keyinfo.Key == ConsoleKey.A)
                {
                    posJX -= 1;
                }
                else if (keyinfo.Key == ConsoleKey.W)
                {
                    posJY -= 1;
                }
                else if (keyinfo.Key == ConsoleKey.D)
                {
                    posJX += 1;
                }
                else if (keyinfo.Key == ConsoleKey.K)
                {
                    if (devMode == true)
                    {
                        devMode = false;
                    }
                    else
                    {
                        devMode = true;
                    }
                }
            }

            //---------------------------------------Hit Box-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            void creeHitoxCity1()
            {
                //Contour
                for (int i = 0; i < 121; i++)
                {
                    tabHitboxCity1[i, 3] = "0";
                }
                for (int i = 0; i < 37; i++)
                {
                    tabHitboxCity1[5, i] = "0";
                }
                for (int i = 0; i < 20; i++)
                {
                    tabHitboxCity1[114, i] = "0";
                }
                for (int i = 0; i < 121; i++)
                {
                    tabHitboxCity1[i, 32] = "0";
                }
                for (int i = 115; i < 121; i++)
                {
                    tabHitboxCity1[i, 19] = "0";
                }
                for (int i = 114; i < 121; i++)
                {
                    tabHitboxCity1[i, 24] = "0";
                }
                for (int i = 24; i < 37; i++)
                {
                    tabHitboxCity1[114, i] = "0";
                }
                //House-------------------------
                //Lab
                for (int i = 39; i < 47; i++)
                {
                    tabHitboxCity1[i, 26] = "0";
                }
                for (int i = 48; i < 56; i++)
                {
                    tabHitboxCity1[i, 26] = "0";
                }
                for (int i = 39; i < 56; i++)
                {
                    tabHitboxCity1[i, 22] = "0";
                }
                for (int i = 22; i < 26; i++)
                {
                    tabHitboxCity1[39, i] = "0";
                }
                for (int i = 22; i < 26; i++)
                {
                    tabHitboxCity1[55, i] = "0";
                }
                //Player Home
                for (int i = 8; i < 12; i++)
                {
                    tabHitboxCity1[10, i] = "0";
                }
                
                tabHitboxCity1[9, 7] = "0";
                
                for (int i = 10; i < 30; i++)
                {
                    tabHitboxCity1[i, 6] = "0";
                }
                for (int i = 7; i < 12; i++)
                {
                    tabHitboxCity1[30, i] = "0";
                }
                for (int i = 15; i < 31; i++)
                {
                    tabHitboxCity1[i, 11] = "0";
                }
                for (int i = 10; i < 14; i++)
                {
                    tabHitboxCity1[i, 11] = "0";
                }
                tabHitboxCity1[23, 5] = "0";
                tabHitboxCity1[24, 5] = "0";
                //NPC house 1
                for (int i = 8; i < 12; i++)
                {
                    tabHitboxCity1[56, i] = "0";
                }
                for (int i = 8; i < 12; i++)
                {
                    tabHitboxCity1[77, i] = "0";
                }
                for (int i = 57; i < 77; i++)
                {
                    tabHitboxCity1[i, 7] = "0";
                }
                for (int i = 63; i < 78; i++)
                {
                    tabHitboxCity1[i, 11] = "0";
                }
                for (int i = 56; i < 62; i++)
                {
                    tabHitboxCity1[i, 11] = "0";
                }
                for (int i = 69; i < 73; i++)
                {
                    tabHitboxCity1[i, 6] = "0";
                }
                //NPC house 2
                for (int i = 72; i < 90; i++)
                {
                    tabHitboxCity1[i, 22] = "0";
                }
                for (int i = 78; i < 91; i++)
                {
                    tabHitboxCity1[i, 26] = "0";
                }
                for (int i = 71; i < 77; i++)
                {
                    tabHitboxCity1[i, 26] = "0";
                }
                for (int i = 23; i < 27; i++)
                {
                    tabHitboxCity1[71, i] = "0";
                }
                for (int i = 23; i < 27; i++)
                {
                    tabHitboxCity1[90, i] = "0";
                }
                //Lake
                if(lowerName != "jesus")
                {
                    for (int i = 18; i < 25; i++)
                    {
                        tabHitboxCity1[34, i] = "0";
                    }
                    for (int i = 18; i < 25; i++)
                    {
                        tabHitboxCity1[7, i] = "0";
                    }
                    for (int i = 7; i < 35; i++)
                    {
                        tabHitboxCity1[i, 24] = "0";
                    }
                    for (int i = 7; i < 35; i++)
                    {
                        tabHitboxCity1[i, 18] = "0";
                    }
                }
                    
                
                //------------------HitBoxes Intérieur Maison------------------------------------------
                //Player Home
                for (int i = 45; i < 78; i++)
                {
                    tabHitboxHome[i, 25] = "0";
                }
                for (int i = 45; i < 78; i++)
                {
                    tabHitboxHome[i, 13] = "0";
                }
                for (int i = 13; i < 25; i++)
                {
                    tabHitboxHome[45, i] = "0";
                }
                for (int i = 14; i < 25; i++)
                {
                    tabHitboxHome[78, i] = "0";
                }
                tabHitboxHome[50, 14] = "0";
                tabHitboxHome[51, 14] = "0";
                tabHitboxHome[52, 14] = "0";
                tabHitboxHome[63, 21] = "0";
                tabHitboxHome[57, 21] = "0";
                tabHitboxHome[73, 22] = "0";
                tabHitboxHome[75, 22] = "0";
                for (int i = 56; i < 65; i++)
                {
                    tabHitboxHome[i, 18] = "0";
                }
                for (int i = 56; i < 65; i++)
                {
                    tabHitboxHome[i, 19] = "0";
                }
                for (int i = 56; i < 65; i++)
                {
                    tabHitboxHome[i, 20] = "0";
                }
                for (int i = 72; i < 77; i++)
                {
                    tabHitboxHome[i, 20] = "0";
                }
                for (int i = 72; i < 77; i++)
                {
                    tabHitboxHome[i, 21] = "0";
                }
                //NPC house
                for (int i = 46; i < 78; i++)
                {
                    tabHitboxNPC[i, 25] = "0";
                }
                for (int i = 46; i < 78; i++)
                {
                    tabHitboxNPC[i, 13] = "0";
                }
                for (int i = 13; i < 25; i++)
                {
                    tabHitboxNPC[78, i] = "0";
                }
                for (int i = 13; i < 25; i++)
                {
                    tabHitboxNPC[45, i] = "0";
                }
                tabHitboxNPC[73, 14] = "0";
                tabHitboxNPC[73, 15] = "0";
                tabHitboxNPC[73, 16] = "0";
                tabHitboxNPC[60, 21] = "0";
                tabHitboxNPC[66, 21] = "0";
                for (int i = 59; i < 68; i++)
                {
                    tabHitboxNPC[i, 18] = "0";
                }
                for (int i = 59; i < 68; i++)
                {
                    tabHitboxNPC[i, 19] = "0";
                }
                for (int i = 59; i < 68; i++)
                {
                    tabHitboxNPC[i, 20] = "0";
                }
                //Lab
                tabHitboxLab[68, 18] = "0";
                tabHitboxLab[76, 18] = "0";
                tabHitboxLab[73, 17] = "0";
                tabHitboxLab[74, 17] = "0";
                tabHitboxLab[70, 17] = "0";
                tabHitboxLab[71, 17] = "0";
                tabHitboxLab[67, 17] = "0";
                tabHitboxLab[68, 17] = "0";
                tabHitboxLab[76, 17] = "0";
                tabHitboxLab[77, 17] = "0";
                for (int i = 67; i < 78; i++)
                {
                    tabHitboxLab[i, 16] = "0";
                }
                for (int i = 41; i < 81; i++)
                {
                    tabHitboxLab[i, 27] = "0";
                }
                for (int i = 41; i < 81; i++)
                {
                    tabHitboxLab[i, 13] = "0";
                }
                for (int i = 13; i < 27; i++)
                {
                    tabHitboxLab[81 , i] = "0";
                }
                for (int i = 13; i < 27; i++)
                {
                    tabHitboxLab[40, i] = "0";
                }
                for (int i = 42; i < 51; i++)
                {
                    tabHitboxLab[i, 25] = "0";
                }
                for (int i = 43; i < 50; i++)
                {
                    tabHitboxLab[i, 24] = "0";
                }
                for (int i = 43; i < 50; i++)
                {
                    tabHitboxLab[i, 23] = "0";
                }
                for (int i = 43; i < 50; i++)
                {
                    tabHitboxLab[i, 22] = "0";
                }
                for (int i = 43; i < 50; i++)
                {
                    tabHitboxLab[i, 21] = "0";
                }
                for (int i = 44; i < 49; i++)
                {
                    tabHitboxLab[i, 20] = "0";
                }
                tabHitboxLab[71, 22] = "0";
                tabHitboxLab[71, 23] = "0";
                for (int i = 71; i < 81; i++)
                {
                    tabHitboxLab[i, 24] = "0";
                }
                for (int i = 71; i < 81; i++)
                {
                    tabHitboxLab[i, 21] = "0";
                }
                for (int i = 42; i < 52; i++)
                {
                    tabHitboxLab[i, 14] = "0";
                }
                for (int i = 42; i < 52; i++)
                {
                    tabHitboxLab[i, 15] = "0";
                }
                for (int i = 42; i < 52; i++)
                {
                    tabHitboxLab[i, 16] = "0";
                }

                //Route 1

                //arbres
                
                for (int i = 0; i < 7; i++)
                {
                    tabHitboxRoute1[i, 20] = "0";
                }
                for (int i = 7; i < 132; i++)
                {
                    tabHitboxRoute1[i, 32] = "0";
                }
                for (int i = 133; i < 139; i++)
                {
                    tabHitboxRoute1[i, 20] = "0";
                }
                for (int i = 20; i < 32; i++)
                {
                    tabHitboxRoute1[132, i] = "0";
                }
                for (int i = 21; i < 33; i++)
                {
                    tabHitboxRoute1[5, i] = "0";
                }
                for (int i = 3; i < 15; i++)
                {
                    tabHitboxRoute1[5, i] = "0";
                }
                for (int i = 4; i < 16; i++)
                {
                    tabHitboxRoute1[132, i] = "0";
                }
                for (int i = 4; i < 8; i++)
                {
                    tabHitboxRoute1[108, i] = "0";
                }
                for (int i = 4; i < 7; i++)
                {
                    tabHitboxRoute1[113, i] = "0";
                }
                for (int i = 18; i < 25; i++)
                {
                    tabHitboxRoute1[114, i] = "0";
                }
                for (int i = 4; i < 11; i++)
                {
                    tabHitboxRoute1[54, i] = "0";
                }
                for (int i = 4; i < 11; i++)
                {
                    tabHitboxRoute1[65, i] = "0";
                }
                for (int i = 18; i < 24; i++)
                {
                    tabHitboxRoute1[109, i] = "0";
                }
                for (int i = 6; i < 133; i++)
                {
                    tabHitboxRoute1[i, 3] = "0";
                }
                for (int i = 6; i < 133; i++)
                {
                    tabHitboxRoute1[i, 3] = "0";
                }
                for (int i = 0; i < 6; i++)
                {
                    tabHitboxRoute1[i, 15] = "0";
                }
                for (int i = 133; i < 139; i++)
                {
                    tabHitboxRoute1[i, 15] = "0";
                }
                for (int i = 109; i < 114; i++)
                {
                    tabHitboxRoute1[i, 7] = "0";
                }
                for (int i = 109; i < 115; i++)
                {
                    tabHitboxRoute1[i, 17] = "0";
                }
                for (int i = 109; i < 114; i++)
                {
                    tabHitboxRoute1[i, 24] = "0";
                }
                for (int i = 54; i < 66; i++)
                {
                    tabHitboxRoute1[i, 11] = "0";
                }
                tabHitboxRoute1[6, 20] = "";
                tabHitboxRoute1[6, 32] = "0";
                //ramp
                for (int i = 4; i < 13; i++)
                {
                    tabHitboxRoute1[29, i] = "2";
                }
                for (int i = 19; i < 32; i++)
                {
                    tabHitboxRoute1[29, i] = "2";
                }
                for (int i = 20; i < 32; i++)
                {
                    tabHitboxRoute1[59, i] = "2";
                }
                for (int i = 24; i < 32; i++)
                {
                    tabHitboxRoute1[84, i] = "2";
                }
                for (int i = 10; i < 18; i++)
                {
                    tabHitboxRoute1[84, i] = "2";
                }
                for (int i = 4; i < 7; i++)
                {
                    tabHitboxRoute1[84, i] = "2";
                }
                for (int i = 8; i < 17; i++)
                {
                    tabHitboxRoute1[110, i] = "2";
                }
                //Grass
                for (int j = 12; j < 20; j++)
                {
                    for (int i = 51; i < 69; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int j = 25; j < 32; j++)
                {
                    for (int i = 104; i < 119; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int j = 4; j < 13; j++)
                {
                    for (int i = 17; i < 29; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int j = 13; j < 20; j++)
                {
                    for (int i = 23; i < 29; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int j = 23; j < 29; j++)
                {
                    for (int i = 17; i < 23; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int j = 25; j < 32; j++)
                {
                    for (int i = 23; i < 29; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int j = 5; j < 11; j++)
                {
                    for (int i = 120; i < 132; i++)
                    {
                        tabHitboxRoute1[i, j] = "1";
                    }
                }
                for (int i = 120; i < 126; i++)
                {
                    tabHitboxRoute1[i, 4] = "1";
                }
                for (int i = 126; i < 132; i++)
                {
                    tabHitboxRoute1[i, 11] = "1";
                }

            }
            void hitboxChecker()
            {
                switch (World)
                {
                    case 1:
                        switch (Map)
                        {
                            case 0:
                                //city
                                if (tabHitboxCity1[posJX, posJY] == "0")
                                {
                                    oldPlacePlayer();
                                }
                                break;
                            case 1:
                                //home
                                if (tabHitboxHome[posJX, posJY] == "0")
                                {
                                    oldPlacePlayer();
                                }
                                break;
                            case 2:
                                if (tabHitboxNPC[posJX, posJY] == "0")
                                {
                                    oldPlacePlayer();
                                }
                                break;
                            case 3:
                                if (tabHitboxNPC[posJX, posJY] == "0")
                                {
                                    oldPlacePlayer();
                                }
                                break;
                            case 4:
                                if (tabHitboxLab[posJX, posJY] == "0")
                                {
                                    oldPlacePlayer();
                                }
                                break;
                        }
                        break;
                    case 2:
                        if (tabHitboxRoute1[posJX, posJY] == "0")
                        {
                            oldPlacePlayer();
                        }
                        else if(tabHitboxRoute1[posJX, posJY] == "2")
                        {
                            if(oldposJX > posJX)
                            {
                                posJX--;
                            }
                            else
                            {
                                oldPlacePlayer();
                            }
                        }
                        else if(tabHitboxRoute1[posJX, posJY] == "1")
                        {
                            randomWild = rand.Next(0, 101);
                            if(randomWild <= 7)
                            {
                                wildBattle();
                                Console.ReadKey();
                            }
                        }
                        break;
                }
                              
            }

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------Small Void-------------------------------

            void proftext()
            {
                prof();
                text();
            }
            void pressClear()
            {
                Console.ReadKey();
                Console.Clear();
            }
            void oldPlacePlayer()
            {
                posJX = oldposJX;
                posJY = oldposJY;
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------Static Void----------------------------
        static void intro()
        {
            int total = 0;
            SoundPlayer player = new SoundPlayer();

            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Intro.wav";
            player.Play();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(28, 8);
            Console.WriteLine("██████╗  ██████╗ ██╗  ██╗███████╗███╗   ███╗ ██████╗ ███╗   ██╗");
            Console.SetCursorPosition(28, 9);
            Console.WriteLine("██╔══██╗██╔═══██╗██║ ██╔╝██╔════╝████╗ ████║██╔═══██╗████╗  ██║");
            Console.SetCursorPosition(28, 10);
            Console.WriteLine("██████╔╝██║   ██║█████╔╝ █████╗  ██╔████╔██║██║   ██║██╔██╗ ██║");
            Console.SetCursorPosition(28, 11);
            Console.WriteLine("██╔═══╝ ██║   ██║██╔═██╗ ██╔══╝  ██║╚██╔╝██║██║   ██║██║╚██╗██║");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine("██║     ╚██████╔╝██║  ██╗███████╗██║ ╚═╝ ██║╚██████╔╝██║ ╚████║");
            Console.SetCursorPosition(28, 13);
            Console.WriteLine("╚═╝      ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝");

            Console.SetCursorPosition(34, 15);
            Console.WriteLine("█▀▀▄ █▀▀ █▀▀ █▀▀█   ▀█ █▀ █▀▀ █▀▀█ █▀▀  ▀  █▀▀█ █▀▀▄");
            Console.SetCursorPosition(34, 16);
            Console.WriteLine("█▀▀▄ █▀▀ █▀▀ █  █    █▄█  █▀▀ █▄▄▀ ▀▀█  █  █  █ █  █");
            Console.SetCursorPosition(34, 17);
            Console.WriteLine("▀▀▀  ▀▀▀ ▀▀▀ █▀▀▀     ▀   ▀▀▀ ▀ ▀▀ ▀▀▀  ▀  ▀▀▀▀ ▀  ▀");

            Console.SetCursorPosition(1, 30);
            Console.WriteLine("@Copyright By Arwing and IcyCrobat");

            System.Threading.Thread.Sleep(12102);

            while (total != 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(47, 19);
                Console.WriteLine("Press a key to start a game");
                Console.SetCursorPosition(0, 31);
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(47, 19);
                Console.WriteLine("Press a key to start a game");
                Console.SetCursorPosition(0, 31);
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(47, 19);
                Console.WriteLine("Press a key to start a game");
                Console.SetCursorPosition(0, 31);
                System.Threading.Thread.Sleep(500);
                total++;
            }

            Console.SetCursorPosition(0, 31);
            Console.ReadKey();


        }
        static void menu()
        {
            SoundPlayer player = new SoundPlayer();

            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Menu.wav";
            player.Play();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(1, 5);
            Console.WriteLine("This is a patch of grass. You may encounter wild");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("Pokemon while walking on those, so watch out !");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(53, 4);
            Console.WriteLine("wwwwwwww");
            Console.SetCursorPosition(53, 5);
            Console.WriteLine("wwwwwwww");
            Console.SetCursorPosition(53, 6);
            Console.WriteLine("wwwwwwww");
            Console.SetCursorPosition(53, 7);
            Console.WriteLine("wwwwwwww");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 0);
            Console.WriteLine("Control Guide");
            Console.SetCursorPosition(48, 27);
            Console.WriteLine("Press a key to continue...");
            Console.SetCursorPosition(1, 12);
            Console.WriteLine("Use ASWD to move around");
            Console.SetCursorPosition(89, 4);
            Console.WriteLine("Sprites");

            Console.SetCursorPosition(78, 6);
            Console.WriteLine("Your character :");
            Console.SetCursorPosition(78, 8);
            Console.WriteLine("Normal NPC :");
            Console.SetCursorPosition(78, 10);
            Console.WriteLine("Trainer NPC :");
            Console.SetCursorPosition(78, 12);
            Console.WriteLine("Gym Leader :");
            Console.SetCursorPosition(78, 14);
            Console.WriteLine("Item :");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(97, 6);
            Console.WriteLine("■");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(97, 10);
            Console.WriteLine("Ô");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(97, 8);
            Console.WriteLine("O");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(97, 12);
            Console.WriteLine("@");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(97, 14);
            Console.WriteLine("*");

            Console.SetCursorPosition(0, 29);
            Console.ReadKey();
            Console.Clear();


        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------Ascii Art---------------------------------------------
        static void pressK()
        {
            Console.SetCursorPosition(92, 27);
            Console.WriteLine("(Press a key to continue)");
        }
        static void prof()
        {
            Console.SetCursorPosition(48, 1);
            Console.WriteLine("       \\\\\\\\\\\\\\\\\\");
            Console.SetCursorPosition(48, 2);
            Console.WriteLine("      (| O   O |)     ...");
            Console.SetCursorPosition(48, 3);
            Console.WriteLine("       \\   u   /      ||||");
            Console.SetCursorPosition(48, 4);
            Console.WriteLine("       _\\__-__/_    (\\|  |");
            Console.SetCursorPosition(48, 5);
            Console.WriteLine("     /` / \\V/ \\ `\\   \\ )/");
            Console.SetCursorPosition(48, 5);
            Console.WriteLine("    /   \\  v  /   \\  /_/");
            Console.SetCursorPosition(48, 6);
            Console.WriteLine("   /  |  \\ | /     \\/ /");
            Console.SetCursorPosition(48, 7);
            Console.WriteLine("  /  /|   `|'   |\\   /");
            Console.SetCursorPosition(48, 8);
            Console.WriteLine("  \\  \\|    |.   | \\_/");
            Console.SetCursorPosition(48, 9);
            Console.WriteLine("   \\  \\    |.   |");
            Console.SetCursorPosition(48, 10);
            Console.WriteLine("    \\_/\\   |.   |");
            Console.SetCursorPosition(48, 11);
            Console.WriteLine("      \\_/  |    |");
            Console.SetCursorPosition(48, 12);
            Console.WriteLine("      ',__.'.__,'");
            Console.SetCursorPosition(48, 13);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 14);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 15);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 16);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 17);
            Console.WriteLine("       | _ | _ |");
            Console.SetCursorPosition(48, 18);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 19);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 20);
            Console.WriteLine("       |   |   |");
            Console.SetCursorPosition(48, 21);
            Console.WriteLine("       |___|___|");
            Console.SetCursorPosition(48, 22);
            Console.WriteLine("       /  / \\  \\ ");
            Console.SetCursorPosition(48, 23);
            Console.WriteLine("      (__/   \\__)");
        }
        static void blobbos()
        {
            Console.SetCursorPosition(25, 16);
            Console.WriteLine("                  \\ ");
            Console.SetCursorPosition(25, 17);
            Console.WriteLine("                  |\\");
            Console.SetCursorPosition(25, 18);
            Console.WriteLine("          _______/  |");
            Console.SetCursorPosition(25, 19);
            Console.WriteLine("      .-''          '-.");
            Console.SetCursorPosition(25, 20);
            Console.WriteLine("     / ^  ^           \\");
            Console.SetCursorPosition(25, 21);
            Console.WriteLine("    |  () ()          |");
            Console.SetCursorPosition(25, 22);
            Console.WriteLine("    \\    0           /");
            Console.SetCursorPosition(25, 23);
            Console.WriteLine("      '-._________..-'");
        }
        static void text()
        {
            Console.SetCursorPosition(0, 24);
            Console.WriteLine(" _____________________________________________________________________________________________________________________ ");
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("|                                                                                                                     |");
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("|                                                                                                                     |");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("|                                                                                                                     |");
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("|_____________________________________________________________________________________________________________________|");
        }
        static void Map0()
        {

            Console.SetWindowSize(121, 37);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()");
            Console.WriteLine(" (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  ) ");
            Console.WriteLine("(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)");
            Console.WriteLine("  )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )( ");
            Console.WriteLine("  ()                                                                                                                ()");
            Console.WriteLine(" (  )                                                                                                              (  )");
            Console.WriteLine("(____)                                                                                                            (____)");
            Console.WriteLine("  )(                                                                                                                )( ");
            Console.WriteLine("  ()                                                                                                                ()");
            Console.WriteLine(" (  )                                                                                                              (  )");
            Console.WriteLine("(____)                                                                                                            (____)");
            Console.WriteLine("  )(                                                                                                                )( ");
            Console.WriteLine("  ()                                                                                                                ()");
            Console.WriteLine(" (  )                                                                                                              (  )");
            Console.WriteLine("(____)                                                                                                            (____)");
            Console.WriteLine("  )(                                                                                                                )( ");
            Console.WriteLine("  ()                                                                                                                ()");
            Console.WriteLine(" (  )                                                                                                              (  )");
            Console.WriteLine("(____)                                                                                                            (____)");
            Console.WriteLine("  )(                                                                                                                )( ");
            Console.WriteLine("  ()  ");
            Console.WriteLine(" (  )");
            Console.WriteLine("(____)");
            Console.WriteLine("  )( ");
            Console.WriteLine("  ()                                                                                                                ()");
            Console.WriteLine(" (  )                                                                                                              (  )");
            Console.WriteLine("(____)                                                                                                            (____)");
            Console.WriteLine("  )(                                                                                                                )( ");
            Console.WriteLine("  ()                                                                                                                ()");
            Console.WriteLine(" (  )                                                                                                              (  )");
            Console.WriteLine("(____)                                                                                                            (____)");
            Console.WriteLine("  )(                                                                                                                )( ");
            Console.WriteLine("  ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()  ");
            Console.WriteLine(" (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )");
            Console.WriteLine("(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)");
            Console.WriteLine("  )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(9, 5);
            Console.WriteLine("  ____________/\\____");
            Console.SetCursorPosition(9, 6);
            Console.WriteLine(" /           /  \\   \\");
            Console.SetCursorPosition(9, 7);
            Console.WriteLine("/___________/_[]_\\___\\");
            Console.SetCursorPosition(9, 8);
            Console.WriteLine(" |         /      \\  |");
            Console.SetCursorPosition(9, 9);
            Console.WriteLine(" |   _      [][]     |");
            Console.SetCursorPosition(9, 10);
            Console.WriteLine(" |  /o\\     [][]     |");
            Console.SetCursorPosition(9, 11);
            Console.WriteLine(" |__|_|______________|");

            Console.SetCursorPosition(55, 5);
            Console.WriteLine("               __ ");
            Console.SetCursorPosition(55, 6);
            Console.WriteLine("   ___________:  :___");
            Console.SetCursorPosition(55, 7);
            Console.WriteLine("  /           :  :   \\");
            Console.SetCursorPosition(55, 8);
            Console.WriteLine(" /____________________\\");
            Console.SetCursorPosition(55, 9);
            Console.WriteLine(" |     _       [][]   |");
            Console.SetCursorPosition(55, 10);
            Console.WriteLine(" |    /o\\      [][]   |");
            Console.SetCursorPosition(55, 11);
            Console.WriteLine(" |____|_|_____________|  ");


            Console.SetCursorPosition(39, 21);
            Console.WriteLine(" _______________");
            Console.SetCursorPosition(39, 22);
            Console.WriteLine("|               |");
            Console.SetCursorPosition(39, 23);
            Console.WriteLine("|_______________|");
            Console.SetCursorPosition(39, 24);
            Console.WriteLine("|      LAB      | ");
            Console.SetCursorPosition(39, 25);
            Console.WriteLine("| [][] /o\\ [][] |");
            Console.SetCursorPosition(39, 26);
            Console.WriteLine("|______|_|______| ");


            Console.SetCursorPosition(70, 21);
            Console.WriteLine("   ________________");
            Console.SetCursorPosition(70, 22);
            Console.WriteLine("  /                \\");
            Console.SetCursorPosition(70, 23);
            Console.WriteLine(" /__________________\\");
            Console.SetCursorPosition(70, 24);
            Console.WriteLine(" |     _     [][]   |");
            Console.SetCursorPosition(70, 25);
            Console.WriteLine(" |    /o\\    [][]   |");
            Console.SetCursorPosition(70, 26);
            Console.WriteLine(" |____|_|___________|  ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(37, 27);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(37, 28);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(37, 29);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

            Console.SetCursorPosition(10, 12);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(10, 14);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

            Console.SetCursorPosition(103, 21);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(103, 22);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(103, 23);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░");

            Console.SetCursorPosition(103, 12);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 13);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 14);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 15);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 16);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 17);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 18);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 19);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 20);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 21);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 22);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 23);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 24);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 25);
            Console.WriteLine("░░░░░");
            Console.SetCursorPosition(103, 26);
            Console.WriteLine("░░░░░");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(6, 17);
            Console.WriteLine(" ____________________________");
            Console.SetCursorPosition(6, 18);
            Console.Write("|");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("|");
            Console.SetCursorPosition(6, 19);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("|");
            Console.SetCursorPosition(6, 20);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("|");
            Console.SetCursorPosition(6, 21);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");
            Console.SetCursorPosition(6, 22);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");
            Console.SetCursorPosition(6, 23);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");
            Console.SetCursorPosition(6, 24);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("████████████████████████████");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");
        }
        static void Home()
        {
            Console.SetWindowSize(121, 37);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(45, 10);
            Console.WriteLine(" ________________________________");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 12);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 13);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("|________________________________|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 15);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 16);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 17);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 18);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 19);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 20);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 21);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 23);
            Console.WriteLine("|      ___                       |");
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("|_____|___|______________________|");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(49, 12);
            Console.WriteLine("'-.-.");
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("'|'.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(50, 14);
            Console.WriteLine("[_]");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(73, 15);
            Console.WriteLine("____");
            Console.SetCursorPosition(72, 16);
            Console.WriteLine("||__||");
            Console.SetCursorPosition(72, 17);
            Console.WriteLine("|    |");
            Console.SetCursorPosition(72, 18);
            Console.WriteLine("|____|");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(52, 16);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");
            Console.SetCursorPosition(52, 17);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");
            Console.SetCursorPosition(52, 18);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");
            Console.SetCursorPosition(52, 19);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");
            Console.SetCursorPosition(52, 20);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");
            Console.SetCursorPosition(52, 21);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");
            Console.SetCursorPosition(52, 22);
            Console.WriteLine("|░░░░░░░░░░░░░░░░|");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(56, 18);
            Console.WriteLine("|¯¯¯¯¯¯¯|");
            Console.SetCursorPosition(56, 19);
            Console.WriteLine("|     o |");
            Console.SetCursorPosition(56, 20);
            Console.WriteLine("|_______|");
            Console.SetCursorPosition(57, 21);
            Console.WriteLine("|");
            Console.SetCursorPosition(63, 21);
            Console.WriteLine("|");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(72, 11);
            Console.WriteLine("_");
            Console.SetCursorPosition(71, 12);
            Console.WriteLine(":_:");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(73, 19);
            Console.WriteLine("___");
            Console.SetCursorPosition(72, 20);
            Console.WriteLine("|   |");
            Console.SetCursorPosition(72, 21);
            Console.WriteLine("|___|");            
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(73, 22);
            Console.WriteLine("|_|");         
        }
        static void Lab()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(40, 10);
            Console.WriteLine(" ________________________________________");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("|________________________________________|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 20);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 23);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("|                                        |");
            Console.SetCursorPosition(40, 25);
            Console.WriteLine("|                   ___                  |");
            Console.SetCursorPosition(40, 26);
            Console.WriteLine("|__________________|___|_________________|");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(68, 15);
            Console.WriteLine("_________");
            Console.SetCursorPosition(67, 16);
            Console.WriteLine("|         |");
            Console.SetCursorPosition(67, 17);
            Console.WriteLine("|_________|");
            Console.SetCursorPosition(68, 18);
            Console.WriteLine("|");
            Console.SetCursorPosition(76, 18);
            Console.WriteLine("|");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(44, 20);
            Console.WriteLine(".'''.");
            Console.SetCursorPosition(43, 21);
            Console.WriteLine("|  O  |");
            Console.SetCursorPosition(43, 22);
            Console.WriteLine("\\'---'/");
            Console.SetCursorPosition(43, 23);
            Console.WriteLine("|     |");
            Console.SetCursorPosition(43, 24);
            Console.WriteLine("|_____|");
            Console.SetCursorPosition(42, 25);
            Console.WriteLine("(|_____|)");


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(72, 20);
            Console.WriteLine("________");
            Console.SetCursorPosition(71, 21);
            Console.WriteLine("|________|");
            Console.SetCursorPosition(71, 22);
            Console.WriteLine("|        |");
            Console.SetCursorPosition(71, 23);
            Console.WriteLine("|        |");
            Console.SetCursorPosition(71, 24);
            Console.WriteLine("|________|");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(72, 22);
            Console.WriteLine("########");
            Console.SetCursorPosition(72, 23);
            Console.WriteLine("########");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(43, 13);
            Console.WriteLine("__");
            Console.SetCursorPosition(42, 14);
            Console.WriteLine("|  |__ __");
            Console.SetCursorPosition(42, 15);
            Console.WriteLine("|__|  |  |");
            Console.SetCursorPosition(42, 16);
            Console.WriteLine("|__|__|__|");



        }
        static void HouseNPC()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(45, 10);
            Console.WriteLine(" ________________________________");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 12);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 13);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("|________________________________|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 15);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 16);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 17);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 18);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 19);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 20);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 21);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("|                                |");
            Console.SetCursorPosition(45, 23);
            Console.WriteLine("|      ___                       |");
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("|_____|___|______________________|");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(49, 15);
            Console.WriteLine("_____");
            Console.SetCursorPosition(47, 16);
            Console.WriteLine("o|__|__|o");
            Console.SetCursorPosition(47, 17);
            Console.WriteLine("||__|__||");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(60, 17);
            Console.WriteLine("_______");
            Console.SetCursorPosition(59, 18);
            Console.WriteLine("|       |");
            Console.SetCursorPosition(59, 19);
            Console.WriteLine("|       |");
            Console.SetCursorPosition(59, 20);
            Console.WriteLine("|_______|");
            Console.SetCursorPosition(60, 21);
            Console.WriteLine("|");
            Console.SetCursorPosition(66, 21);
            Console.WriteLine("|");

            Console.SetCursorPosition(73, 12);
            Console.WriteLine("_");
            Console.SetCursorPosition(72, 13);
            Console.WriteLine("/_\\");
            Console.SetCursorPosition(73, 14);
            Console.WriteLine("|");
            Console.SetCursorPosition(73, 15);
            Console.WriteLine("|");
            Console.SetCursorPosition(72, 16);
            Console.WriteLine("_|_");
        }
        // ROUTE 1------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        static void route1()
        {
            Console.SetWindowSize(139, 37);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    () ");
            Console.WriteLine(" (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )");
            Console.WriteLine("(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)");
            Console.WriteLine("  )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )( ");
            Console.WriteLine("  ()                                                    ()    ()                                              ()                      ()");
            Console.WriteLine(" (  )                                                  (  )  (  )                                            (  )                    (  )");
            Console.WriteLine("(____)                                                (____)(____)                                          (____)                  (____)");
            Console.WriteLine("  )(                                                    )(    )(                                              )(                      )( ");
            Console.WriteLine("  ()                                                    ()    ()                                                                      ()");
            Console.WriteLine(" (  )                                                  (  )  (  )                                                                    (  )");
            Console.WriteLine("(____)                                                (____)(____)                                                                  (____)");
            Console.WriteLine("  )(                                                    )(    )(                                                                      )( ");
            Console.WriteLine("  ()                                                                                                                                  ()");
            Console.WriteLine(" (  )                                                                                                                                (  )");
            Console.WriteLine("(____)                                                                                                                              (____)");
            Console.WriteLine("  )(                                                                                                                                  )( ");
            Console.WriteLine("                                                                                                                                         ");
            Console.WriteLine("                                                                                                               ()                         ");
            Console.WriteLine("                                                                                                              (  )                        ");
            Console.WriteLine("                                                                                                             (____)                       ");
            Console.WriteLine("  ()                                                                                                           )(                     ()");
            Console.WriteLine(" (  )                                                                                                          ()                    (  )");
            Console.WriteLine("(____)                                                                                                        (  )                  (____)");
            Console.WriteLine("  )(                                                                                                         (____)                   )( ");
            Console.WriteLine("  ()                                                                                                           )(                     ()");
            Console.WriteLine(" (  )                                                                                                                                (  )");
            Console.WriteLine("(____)                                                                                                                              (____)");
            Console.WriteLine("  )(                                                                                                                                  )( ");
            Console.WriteLine("  ()                                                                                                                                  ()");
            Console.WriteLine(" (  )                                                                                                                                (  )");
            Console.WriteLine("(____)                                                                                                                              (____)");
            Console.WriteLine("  )(                                                                                                                                  )( ");
            Console.WriteLine("  ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()    ()");
            Console.WriteLine(" (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )  (  )");
            Console.WriteLine("(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)(____)");
            Console.WriteLine("  )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(    )(");

            //Grass
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(104, 25);
            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.SetCursorPosition(104, 26);
            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.SetCursorPosition(104, 27);
            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.SetCursorPosition(104, 28);
            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.SetCursorPosition(104, 29);
            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.SetCursorPosition(104, 30);
            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.SetCursorPosition(104, 31);
            Console.WriteLine("wwwwwwwwwwwwwwww");

            Console.SetCursorPosition(51, 12);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 13);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 14);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 15);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 16);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 17);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 18);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");
            Console.SetCursorPosition(51, 19);
            Console.WriteLine("wwwwwwwwwwwwwwwwww");

            Console.SetCursorPosition(17, 28);
            Console.WriteLine("wwwwwwwwwwwww");
            Console.SetCursorPosition(17, 27);
            Console.WriteLine("wwwwwwwwwwwww");
            Console.SetCursorPosition(17, 26);
            Console.WriteLine("wwwwwwwwwwwww");
            Console.SetCursorPosition(17, 25);
            Console.WriteLine("wwwwwwwwwwwww");
            Console.SetCursorPosition(23, 29);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 30);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 31);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(17, 24);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(17, 23);
            Console.WriteLine("wwwwww");


            Console.SetCursorPosition(17, 4);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 5);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 6);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 7);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 8);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 9);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 10);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 11);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(17, 12);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(23, 13);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 14);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 15);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 16);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 17);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 18);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(23, 19);           
            Console.WriteLine("wwwwww");

            Console.SetCursorPosition(120, 4);
            Console.WriteLine("wwwwww");
            Console.SetCursorPosition(120, 5);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(120, 6);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(120, 7);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(120, 8);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(120, 9);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(120, 10);
            Console.WriteLine("wwwwwwwwwwww");
            Console.SetCursorPosition(126, 11);
            Console.WriteLine("wwwwww");
            //Jump ledge
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(110, 8);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 9);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 10);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 11);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 12);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 13);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 14);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 15);
            Console.WriteLine("▌");
            Console.SetCursorPosition(110, 16);
            Console.WriteLine("▌");

            Console.SetCursorPosition(84, 4);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 5);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 6);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 10);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 11);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 12);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 13);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 14);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 15);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 16);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 17);
            Console.WriteLine("▌");

            Console.SetCursorPosition(84, 24);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 25);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 26);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 27);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 28);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 29);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 30);
            Console.WriteLine("▌");
            Console.SetCursorPosition(84, 31);
            Console.WriteLine("▌");

            Console.SetCursorPosition(59, 20);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 21);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 22);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 23);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 24);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 25);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 26);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 27);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 28);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 29);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 30);
            Console.WriteLine("▌");
            Console.SetCursorPosition(59, 31);
            Console.WriteLine("▌");


            Console.SetCursorPosition(29, 4);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 5);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 6);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 7);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 8);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 9);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 10);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 11);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 12);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 19);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 20);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 21);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 22);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 23);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 24);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 25);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 26);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 27);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 28);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 29);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 30);
            Console.WriteLine("▌");
            Console.SetCursorPosition(29, 31);
            Console.WriteLine("▌");
        }
        static void battleScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetWindowSize(121, 37);
            
            Console.SetCursorPosition(0, 27);
            Console.WriteLine(" _______________________________________________________________________________________________________________________ ");
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 29);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 30);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 33);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 34);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 35);
            Console.WriteLine("|                                                                                                                       |");
            Console.SetCursorPosition(0, 36);
            Console.WriteLine("|_______________________________________________________________________________________________________________________|");

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("________________________________________________________");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("                                                       /");
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("                                                      /");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("                                                     /");
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("                                                    /");
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("                                                   /");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("                                                  /");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("_________________________________________________/");

            Console.SetCursorPosition(64, 17);
            Console.WriteLine("       __________________________________________________");
            Console.SetCursorPosition(64, 18);
            Console.WriteLine("      /");
            Console.SetCursorPosition(64, 19);
            Console.WriteLine("     /");
            Console.SetCursorPosition(64, 20);
            Console.WriteLine("    /");
            Console.SetCursorPosition(64, 21);
            Console.WriteLine("   /");
            Console.SetCursorPosition(64, 22);
            Console.WriteLine("  /");
            Console.SetCursorPosition(64, 23);
            Console.WriteLine(" /");
            Console.SetCursorPosition(64, 24);
            Console.WriteLine("/_______________________________________________________");

            Console.SetCursorPosition(80, 8);
            Console.WriteLine("    .-'''-.");
            Console.SetCursorPosition(80, 9);
            Console.WriteLine("  .'       '.");
            Console.SetCursorPosition(80, 10);
            Console.WriteLine("  |===( )===|");
            Console.SetCursorPosition(80, 11);
            Console.WriteLine("  '.       .'");
            Console.SetCursorPosition(80, 12);
            Console.WriteLine("    '-...-'");
            

            Console.SetCursorPosition(15, 21);
            Console.WriteLine("        ___");
            Console.SetCursorPosition(15, 22);
            Console.WriteLine("    .-''   ''-.");
            Console.SetCursorPosition(15, 23);
            Console.WriteLine("  .'           '.");
            Console.SetCursorPosition(15, 24);
            Console.WriteLine(" /               \\");
            Console.SetCursorPosition(15, 25);
            Console.WriteLine("|-----------------|");
            Console.SetCursorPosition(15, 26);
            Console.WriteLine("|-----------------|");
            Console.ReadKey();
        }
    }
}
 