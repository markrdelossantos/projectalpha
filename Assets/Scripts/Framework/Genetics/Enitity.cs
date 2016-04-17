using UnityEngine;
using System.Collections;

namespace GeneticsCore
{
    public interface Entity
    {
        void accept(EntityVisitor ev);
    }
}
