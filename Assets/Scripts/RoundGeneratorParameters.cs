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

        public static void Generate()
        {
            char[,] Round = new char[RoundHeight, RoundWidth];

            RoundGeneratorEngine.PopulateArray();
            RoundGeneratorEngine.DrawArray();


            //მიწა
            RoundGeneratorEngine.GenerateGrounds(new GeneratorModel()
            {
                Go = 'g',
                Count = 3,
                Y = RoundHeight - 1
            });

            
            #region კლდე
            //კლდე 1
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'l',
                Count = 5,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });

            //კლდე 2
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'i',
                Count = 5,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });


            //კლდე 3
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 't',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });


            //კლდე 4
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'h',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });



            //კლდე 5
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'm',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });
            #endregion


            //ჟანგბადი
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'n',
                Count = 40,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });


            //ქვა 1
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 30,
                Y = RoundHeight - 5,
                MinDistanceWithNeighbor = 0,

                ParentRowExclude = RoundHeight - 2,
                ParentRowExcludeIndex = new List<char>() { 'l', 'i', 't' }
            });

            //ქვა 2
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'q',
                Count = 20,
                Y = RoundHeight - 8,
                MinDistanceWithNeighbor = 0,

                ParentRowExclude = RoundHeight - 2,
                ParentRowExcludeIndex = new List<char>() { 'l', 'i', 't' }
            });

            #region Enemy
            //Enemy2
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'p',
                Count = 5,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 0,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
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
                Y = RoundHeight - 6,
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
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });



            //Enemy6 - ჟელე
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'b',
                Count = 6,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });
            #endregion


            //რკინა
            RoundGeneratorEngine.GenerateObjects(new GeneratorModel()
            {
                Go = 'k',
                Count = 3,
                Y = RoundHeight - 2,
                MinDistanceWithNeighbor = 3,
                ParentRowExclude = RoundHeight - 1,
                ParentRowExcludeIndex = new List<char>() { 'o' }
            });


            RoundGeneratorEngine.DrawArray();
        }
    }
}
