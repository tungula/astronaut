using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Objects
{
    public class GeneratorModel
    {
        public char Go { get; set; }
        public int MinDistanceWithNeighbor { get; set; }
        public int Y { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// მშობელი Row, ითვალისწინებს მის მნიშვნელობებს. Random -ის გენერაციაში შედის ეს მნიშვნელობები, სხვები არა
        /// </summary>
        public int? ParentRowInclude { get; set; }


        public int? ParentRowExclude { get; set; }
        /// <summary>
        /// რომელი ნომრები ამოაგდოს
        /// </summary>
        public List<char> ParentRowExcludeIndex { get; set; }
    }
}
