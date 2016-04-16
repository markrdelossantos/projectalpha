using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PrototypeGameManager : MonoBehaviour
{
    void Start ()
    {
        SpontaenousGeneration sg = ScriptableObject.CreateInstance<SpontaenousGeneration>();
        sg.generateSpontaenously();
    }

}
