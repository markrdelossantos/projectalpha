using UnityEngine;
using System.Collections;
using System;

public class DwarfismMutation: Mutation
{
    public override int getMutationId()
    {
        return 2;
    }

    public override string getMutationName()
    {
        return "Dwarfism";
    }

    public override void visit(PrototypeEntity e)
    {
        Vector3 currentSize = e.getSize();
        e.setSize(new Vector3(currentSize.x * .3f, currentSize.y * .3f, currentSize.z * .3f));
        e.addMutation(this);
    }
}
