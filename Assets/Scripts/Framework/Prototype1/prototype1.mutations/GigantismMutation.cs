using UnityEngine;
using System.Collections;
using System;

namespace prototype1.mutations
{
    public class GigantismMutation : Mutation
    {
        public override int getMutationId()
        {
            return 1;
        }

        public override string getMutationName()
        {
            return "Gigantism";
        }

        public override void visit(PrototypeEntity e)
        {
            Vector3 currentSize = e.getSize();
            e.setSize(new Vector3(currentSize.x * 2.5f, currentSize.y * 2.5f, currentSize.z * 2.5f));
            e.addMutation(this);
        }
    }
}