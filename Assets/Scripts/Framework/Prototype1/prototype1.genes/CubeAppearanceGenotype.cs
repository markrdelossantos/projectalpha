using UnityEngine;
using System.Collections;
using System;

namespace prototype1.genes
{
    public class CubeAppearanceGenotype : AppearanceGenotype
    {
        public CubeAppearanceGenotype()
        {
            myType = PrimitiveType.Cube;
        }

        public CubeAppearanceGenotype(PrimitiveType type, Vector3 size) : base(type, size)
        {
        }

        public override int getGeneId()
        {
            return 3;
        }

        public override string getGenotypeName()
        {
            return "Cube Appearance";
        }
    }
}