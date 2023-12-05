using Assets.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class RoundGeneratorEngine
    {
        static public void GenerateObjects(GeneratorModel model)
        {
            int width = RoundGeneratorParameters.Objects[model.Go].Width;
            if (model.CopyCount.HasValue) width = width * model.CopyCount.Value;

            List<int> availableValues = GenerateAvailableIndexesArray(model.Y, width, true, model.ParentRowIncludeNeighbor);

            if (model.ParentRowInclude.HasValue)
                availableValues = GenerateAvailableIndexesArray(model.ParentRowInclude.Value, width, false, model.ParentRowIncludeNeighbor);

            if (model.ParentRowExclude.HasValue)
                availableValues = GenerateAvailableIndexesArray2(availableValues, model.ParentRowExclude.Value, model.ParentRowExcludeIndex, width);


            for (int i = 0; i < model.Count; i++)
            {
                if (availableValues.Count == 0) break;

                availableValues = ChooseAvailable(availableValues, width, model.Go, model.Y, model.MinDistanceWithNeighbor, !model.CopyCount.HasValue);
            }

            //DrawArray();
        }

        static public void GenerateGrounds(GeneratorModel model)
        {
            int width = RoundGeneratorParameters.Objects[model.Go].Width;

            var n = 0;
            while (n < RoundGeneratorParameters.RoundWidth)
            {
                Random r = new Random();
                int random = r.Next(RoundGeneratorParameters.GroundMinDistance, RoundGeneratorParameters.GroundMaxDistance);

                for (int i = 0; i < width; i++)
                {
                    if (n + i >= RoundGeneratorParameters.RoundWidth) break;

                    if (i == 0)
                        RoundGeneratorParameters.Round[model.Y, n + i] = model.Go;
                    else
                        RoundGeneratorParameters.Round[model.Y, n + i] = '-';
                }

                n += width;

                n += random;
            }
        }

        static List<int> GenerateAvailableIndexesArray(int rowIndex, int width, bool exclude, int? parentRowIncludeNeighbor)
        {
            List<int> availableIndexes = new List<int>();

            List<char> row = Enumerable.Range(0, RoundGeneratorParameters.Round.GetLength(1))
                 .Select(x => RoundGeneratorParameters.Round[rowIndex, x])
                 .ToList();

            for (int i = 0; i < RoundGeneratorParameters.RoundWidth; i++)
            {
                if (exclude)
                {
                    if (row[i] == RoundGeneratorParameters.EmptySymbol) availableIndexes.Add(i);
                }
                else
                {
                    if (
                        (row[i] != RoundGeneratorParameters.EmptySymbol && row[i] != RoundGeneratorParameters.NotAllowedSymbol)
                        || (IsValid(row, i, parentRowIncludeNeighbor))
                       )
                        availableIndexes.Add(i);
                }
            }

            availableIndexes = RemoveValuesDepentOfWidth(availableIndexes, width);

            return availableIndexes;
        }

        static bool IsValid(List<char> row, int index, int? parentRowIncludeNeighbor)
        {
            if (!parentRowIncludeNeighbor.HasValue) return false;

            for (int i = 0; i < parentRowIncludeNeighbor; i++)
            {
                if (index - i < 0) break;

                if (row[index - i] != RoundGeneratorParameters.EmptySymbol && row[index - i] != RoundGeneratorParameters.NotAllowedSymbol)
                    return true;
            }
            return false;
        }

        static List<int> GenerateAvailableIndexesArray2(List<int> indexes, int rowIndex, List<char> parentRowExcludeIndex, int width)
        {
            List<int> availableIndexes = new List<int>();

            List<char> row = Enumerable.Range(0, RoundGeneratorParameters.Round.GetLength(1))
                   .Select(x => RoundGeneratorParameters.Round[rowIndex, x])
                   .ToList();

            for (int i = 0; i < indexes.Count; i++)
            {
                if (!parentRowExcludeIndex.Contains(row[indexes[i]]))
                {
                    availableIndexes.Add(indexes[i]);
                }
            }

            availableIndexes = RemoveValuesDepentOfWidth(availableIndexes, width);

            return availableIndexes;
        }

        static List<int> RemoveValuesDepentOfWidth(List<int> indexes, int width)
        {
            //იმ საწყისი  ინდექსების დატოვება რომლებიც არის დაშვებული
            List<int> indexesResult = new List<int>();

            for (int i = 0; i < indexes.Count; i++)
            {
                bool valid = true;
                for (int j = 0; j < width - 1; j++)
                {
                    if ((i + j + 1) >= indexes.Count || indexes[i + j + 1] - indexes[i + j] != 1) valid = false;
                }
                if (valid) indexesResult.Add(indexes[i]);
            }


            return indexesResult;
        }

        static List<int> ChooseAvailable(List<int> indexes, int width, char go, int y, int neibg, bool fillWithV /*TODO*/)
        {
            Random r = new Random();
            int index = r.Next(0, indexes.Count);

            int value = indexes[index];

            for (int i = 0; i < width; i++)
            {
                indexes.TryRemove(value + i);
                indexes.TryRemove(value - i);

                if (fillWithV) { if (i != 0) go = '-'; }
                RoundGeneratorParameters.Round[y, value + i] = go;
            }

            for (int i = 0; i < neibg; i++)
            {
                indexes.TryRemove(value + (width + i));
                indexes.TryRemove(value - (width + i));
            }

            return indexes;
        }

        public static void PopulateArray()
        {
            for (int i = 0; i < RoundGeneratorParameters.RoundHeight; i++)
            {
                for (int j = 0; j < RoundGeneratorParameters.RoundWidth; j++)
                {
                    //თავიდანვე რომ არ ჩანდეს
                    char symbol = RoundGeneratorParameters.EmptySymbol;

                    if (i < RoundGeneratorParameters.RoundHeight - 1 && j < 15)
                        symbol = RoundGeneratorParameters.NotAllowedSymbol;

                    RoundGeneratorParameters.Round[i, j] = symbol;
                }
            }
        }

        public static void DrawArray()
        {
            Console.Clear();

            for (int i = 0; i < RoundGeneratorParameters.RoundHeight; i++)
            {
                for (int j = 0; j < RoundGeneratorParameters.RoundWidth; j++)
                {
                    Console.Write(RoundGeneratorParameters.Round[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
