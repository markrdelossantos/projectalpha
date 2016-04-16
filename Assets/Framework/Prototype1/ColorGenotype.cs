using UnityEngine;
using System.Collections;
using System;

public class ColorGenotype : Genotype
{
    private string myColor;

    private string[] colorSpace = new string[]
    {
        "HighlightableBlue", "HighlightableRed", "HighlightableYellow"
    };

    public ColorGenotype() {
        myColor = colorSpace[UnityEngine.Random.Range(0, 3)];
    }

    public ColorGenotype(string color)
    {
        myColor = color;
    }

    public override int getGeneId()
    {
        return 2;
    }

    public string getColor()
    {
        return myColor;
    }

    public override string getGenotypeName()
    {
        return "Color";
    }

    public override void visit(PrototypeEntity e)
    {
        e.setColor(myColor);
        e.addGenotype(this);
    }

    protected override Genotype combineWithDispatch(Genotype other)
    {
        ColorGenotype otherColorGenotype = (ColorGenotype)other;
        float randomNumber = UnityEngine.Random.Range(1, 2);
        return randomNumber == 2 ? new ColorGenotype(otherColorGenotype.getColor()) : new ColorGenotype(myColor);
    }
}
