using UnityEngine;
using System.Collections;

public interface Entity
{
    void accept(EntityVisitor ev);
}
