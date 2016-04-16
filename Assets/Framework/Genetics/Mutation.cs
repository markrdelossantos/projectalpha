using UnityEngine;
using System.Collections;
using System;

public abstract class Mutation : EntityVisitor
{
    public abstract void visit(PrototypeEntity e);

    public abstract string getMutationName();

    public abstract int getMutationId();
}
