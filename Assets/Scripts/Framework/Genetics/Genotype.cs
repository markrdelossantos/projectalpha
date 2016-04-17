using UnityEngine;
using System;
using System.Collections;

public abstract class Genotype : EntityVisitor
{
    public abstract bool isSameType(Genotype other);

    public abstract void visit(PrototypeEntity e);

    public abstract Genotype combineWith(Genotype other);

    public abstract string getGenotypeName();

    public abstract int getGeneId();
}
