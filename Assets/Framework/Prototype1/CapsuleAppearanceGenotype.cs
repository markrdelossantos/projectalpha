using UnityEngine;
using System.Collections;
using System;

public class CapsuleAppearanceGenotype : AppearanceGenotype
{
    public CapsuleAppearanceGenotype()
    {
        myType = PrimitiveType.Capsule;
    }

    public CapsuleAppearanceGenotype(PrimitiveType type, Vector3 size) : base(type, size)
    {
    }

    public override int getGeneId()
    {
        return 1;
    }

    public override string getGenotypeName()
    {
        return "Capsule Appearance";
    }
}
