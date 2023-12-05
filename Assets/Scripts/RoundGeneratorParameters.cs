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
        public const int RoundWidth = 150;
        public static char[,] Round = new char[RoundHeight, RoundWidth];
        public static Dictionary<char, GameObjectParameterModel> Objects = new Dictionary<char, GameObjectParameterModel>();
        public static int GroundMinDistance = 2;
        public static int GroundMaxDistance = 5;
        public static char EmptySymbol = '.';
        public static char NotAllowedSymbol = ',';

        public static void Generate()
        {
            char[,] Round = new char[RoundHeight, RoundWidth];

            RoundGeneratorEngine.PopulateArray();
            RoundGeneratorEngine.DrawArray();


            GenerateGround();

            GeneratesRockes();

            GeneratesOxygen();

            GeneratesStones();

            GeneratesEnemy();

            GeneratesIron();

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
                Count = 5,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });


            //Enemy3 დაფრინავს
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'u',
                Count = 3,
                Y = RoundHeight - 4,
                MinDistanceWithNeighbor = 3,
            });

            //Enemy4 დაფრინავს ცეცხლიანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'j',
                Count = 3,
                Y = RoundHeight - 4,
                MinDistanceWithNeighbor = 3,
            });


            //Enemy4 დაფრინავს ცეცხლიანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'j',
                Count = 3,
                Y = RoundHeight - 7,
                MinDistanceWithNeighbor = 3,
            });

            //Enemy5 - ობობა
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'a',
                Count = 6,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });



            //Enemy6 - ჟელე
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'b',
                Count = 6,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });


            //Enemy5 - ობობა stone-ზე
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'a',
                Count = 6,
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
                Count = 5,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });

            //კლდე 2
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'i',
                Count = 5,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });


            //კლდე 3
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 't',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });


            //კლდე 4
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'h',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });



            //კლდე 5
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'm',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { EmptySymbol }
            });
        }

        public static void GeneratesStones()
        {
            //ქვა 5-იანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 4,
                Y = RoundHeight - 5,
                MinDistanceWithNeighbor = 0,
                CopyCount = 4
            });

            //ქვა 3-იანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 3,
                Y = RoundHeight - 5,
                MinDistanceWithNeighbor = 0,
                CopyCount = 2
            });

            //ქვა 1-იანი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 10,
                Y = RoundHeight - 5,
                MinDistanceWithNeighbor = 0,
                CopyCount = 1
            });

            //ქვა 2-ე სართული
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 20,
                Y = RoundHeight - 8,
                MinDistanceWithNeighbor = 0,

                ParentRowInclude = RoundHeight - 5,
                ParentRowIncludeNeighbor = 3


                //ParentRowExclude = RoundHeight - 5,
                //ParentRowExcludeIndex = new List<char>() { 'q' }
            });
        }
    }
}
