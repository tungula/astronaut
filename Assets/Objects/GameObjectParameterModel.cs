using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Objects
{
    public class GameObjectParameterModel
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public GameObject Go { get; set; }
        public float HeightCorrection { get; set; }
    }
}
