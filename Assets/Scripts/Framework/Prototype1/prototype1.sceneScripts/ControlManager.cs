using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using GeneticsCore;

public class ControlManager : MonoBehaviour
{
    private List<GameObject> gos = new List<GameObject>();
    private Vector3 spawnpoint = new Vector3(5, 0);

    public void Update()
    {
        bool leftClick = Input.GetMouseButtonDown(0);
        bool rightClick = Input.GetMouseButtonDown(1);

        if (leftClick || rightClick)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                GameObject other = hit.collider.gameObject;
                if (leftClick)
                    handleLeftClick(other);
                else
                    handleRightClick(other);
            }
        }
    }

    private void handleRightClick(GameObject other)
    {
        Destroy(other);
    }

    private void handleLeftClick(GameObject other)
    {       
        if (other.CompareTag("Entity") && gos.Count <= 1 && !gos.Contains(other))
        {
            other.GetComponent<Renderer>().material.SetFloat("_Outline", .005f);
            gos.Add(other);
        }
        else if (gos.Contains(other))
        {
            other.GetComponent<Renderer>().material.SetFloat("_Outline", 0f);
            gos.Remove(other);
        }

        if (gos.Count == 2)
        {
            EntityBridge eb1 = gos[0].GetComponent<EntityBridge>();
            EntityBridge eb2 = gos[1].GetComponent<EntityBridge>();

            PrototypeEntity e = eb1.getEntity() as PrototypeEntity;
            PrototypeEntity e2 = eb2.getEntity() as PrototypeEntity;

            spawnpoint = new Vector3(spawnpoint.x + 5, 0);
            Entity newEntity = MateEngine.mate(e, e2);
            SpontaenousGeneration.spawn(newEntity, spawnpoint);

        }

    }
}

