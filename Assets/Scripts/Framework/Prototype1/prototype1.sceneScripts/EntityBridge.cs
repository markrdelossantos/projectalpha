using UnityEngine;
using System.Collections;
using GeneticsCore;

public class EntityBridge : MonoBehaviour {

    private PrototypeEntity myEntity;

    public void setEntity(PrototypeEntity e)
    {
        myEntity = e;
    }

    public Entity getEntity()
    {
        return myEntity;
    }
}
