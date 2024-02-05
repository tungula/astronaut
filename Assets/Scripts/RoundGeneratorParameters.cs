using Assets.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class RoundGeneratorParameters
    {
        public const int RoundHeight = 10;
        public const int RoundWidth = 500;
        public static char[,] Round = new char[RoundHeight, RoundWidth];
        public static char[,] RoundStaticObjects = new char[RoundHeight, RoundWidth];
        public static Dictionary<char, GameObjectParameterModel> Objects = new Dictionary<char, GameObjectParameterModel>();
        public static Dictionary<char, GameObjectParameterModel> StaticObjects = new Dictionary<char, GameObjectParameterModel>();
        public static int GroundMinDistance = 2;
        public static int GroundMaxDistance = 5;
        public static char EmptySymbol = '.';
        public static char NotAllowedSymbol = ',';

        public static void Generate()
        {
            Round = new char[RoundHeight, RoundWidth];
            RoundStaticObjects = new char[RoundHeight, RoundWidth];

            RoundGeneratorEngine.PopulateArray();
            RoundGeneratorEngine.DrawArray();


            GenerateGround();

            GenerateMountains();

            GeneratesRockes();

            GeneratesOxygen();

            GeneratesStones();

            GeneratesEnemy();

            GeneratesIron();

            GeneratePlanets();

            RoundGeneratorEngine.DrawArray();
        }

        public static void GenerateGround()
        {
            //მიწა
            RoundGeneratorEngine.GenerateGrounds(new GeneratorModel()
            {
                Go = 'g',
                Count = 3,
                Y = RoundHeight - 1
            });
        }

        public static void GeneratesIron()
        {
            //რკინა
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'k',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });
        }

        public static void GeneratesEnemy()
        {
            //Enemy2
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'p',
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });


            //Enemy3 დაფრინავს
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'u',
                Y = RoundHeight - 5,
                MinDistanceWithNeighbor = 3,
            });

            //Enemy4 დაფრინავს ცეცხლიანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'j',
                Y = RoundHeight - 5,
                MinDistanceWithNeighbor = 3,
            });


            //Enemy4 დაფრინავს ცეცხლიანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'j',
                Y = RoundHeight - 8,
                MinDistanceWithNeighbor = 3,
            });

            //Enemy5 - ობობა
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'a',
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });



            //Enemy6 - ჟელე
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'b',
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });


            //Enemy5 - ობობა stone-ზე
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'a',
                Count = 2,
                Y = RoundHeight - 6,
                MinDistanceWithNeighbor = 3,

                ParentRowInclude = RoundHeight - 5,
                //ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });
        }

        public static void GeneratesOxygen()
        {
            //ჟანგბადი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'n',
                Count = 40,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });

        }

        public static void GeneratesRockes()
        {
            //კლდე 1
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'l',
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol },

                ParentRowExcludeStatics = RoundHeight - 2,
                ParentRowExcludeIndexStatics = new List<char>() { 'i','-' },
            });

            //კლდე 2
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'i',
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol },

                ParentRowExcludeStatics = RoundHeight - 2,
                ParentRowExcludeIndexStatics = new List<char>() { 'i', '-' },
            });


            //კლდე 3
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 't',
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol },

                ParentRowExcludeStatics = RoundHeight - 2,
                ParentRowExcludeIndexStatics = new List<char>() { 'i', '-' },
            });


            //კლდე 4
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'h',
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol },

                ParentRowExcludeStatics = RoundHeight - 2,
                ParentRowExcludeIndexStatics = new List<char>() { 'i', '-' },
            });



            ////კლდე 5
            //RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            //{
            //    Go = 'm',
            //    Count = 3,
            //    Y = RoundHeight - 2,
            //    MinDistanceWithNeighbor = 0,
            //    ParentRowExclude = RoundHeight - 4,
            //    ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            //});
        }

        public static void GeneratesStones()
        {
            //ქვა 5-იანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 10,
                Y = RoundHeight - 4,
                MinDistanceWithNeighbor = 0,
                CopyCount = 4
            });

            //ქვა 3-იანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 5,
                Y = RoundHeight - 4,
                MinDistanceWithNeighbor = 0,
                CopyCount = 2
            });

            //ქვა 1-იანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 20,
                Y = RoundHeight - 4,
                MinDistanceWithNeighbor = 0,
                CopyCount = 1
            });

            //ქვა 2-ე სართული
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'z',
                Count = 50,
                Y = RoundHeight - 7,
                MinDistanceWithNeighbor = 0,

                ParentRowInclude = RoundHeight - 4,
                ParentRowIncludeNeighbor = 3
            });
        }

        public static void GeneratePlanets()
        {
            int pos = RoundWidth / 8;

            RoundStaticObjects[1, 1 * pos] = 'a';
            RoundStaticObjects[1, 2 * pos] = 'b';
            RoundStaticObjects[1, 3 * pos] = 'c';
            RoundStaticObjects[1, 4 * pos] = 'd';
            RoundStaticObjects[1, 5 * pos] = 'e';
            RoundStaticObjects[1, 6 * pos] = 'f';
            RoundStaticObjects[1, 7 * pos] = 'g';
            RoundStaticObjects[1, 8 * pos] = 'h';

        }

        public static void GenerateMountains()
        {
            RoundGeneratorEngine.GenerateStaticObjects(new GeneratorModel()
            {
                Go = 'i',
                Count = 10,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });

            RoundGeneratorEngine.GenerateStaticObjects(new GeneratorModel()
            {
                Go = 'j',
                Count = 10,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });

            RoundGeneratorEngine.GenerateStaticObjects(new GeneratorModel()
            {
                Go = 'k',
                Count = 10,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 10,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });
        }
    }
}
