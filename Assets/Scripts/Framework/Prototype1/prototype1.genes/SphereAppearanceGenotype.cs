using UnityEngine;
using System.Collections;
using System;

namespace prototype1.genes
{
    public class SphereAppearanceGenotype : AppearanceGenotype
    {
        public SphereAppearanceGenotype()
        {
            myType = PrimitiveType.Sphere;
        }

        public SphereAppearanceGenotype(PrimitiveType type, Vector3 size) : base(type, size)
        {
        }

        public override int getGeneId()
        {
            return 4;
        }

        public override string getGenotypeName()
        {
            return "Sphere Appearance";
        }
    }
}
