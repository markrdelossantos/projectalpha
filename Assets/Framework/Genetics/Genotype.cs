using UnityEngine;
using System;
using System.Collections;

public abstract class Genotype : EntityVisitor
{

    public abstract void visit(PrototypeEntity e);

    public Genotype combineWith(Genotype other)
    {
       // if (!this.GetType().IsAssignableFrom(other.GetType()) || !(this is AppearanceGenotype && other is AppearanceGenotype))
       // {
       //     throw new System.NotSupportedException();
       // }
        return combineWithDispatch(other);
    }

    protected abstract Genotype combineWithDispatch(Genotype other);

    public abstract string getGenotypeName();

    public abstract int getGeneId();
}
