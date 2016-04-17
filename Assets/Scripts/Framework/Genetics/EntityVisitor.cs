using UnityEngine;
using System.Collections;

public interface EntityVisitor
{
    void visit(PrototypeEntity e);
}
