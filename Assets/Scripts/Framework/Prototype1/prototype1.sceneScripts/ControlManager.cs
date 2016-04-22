using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using GeneticsCore;

public class ControlManager : MonoBehaviour
{
    private List<GameObject> selectedGameObjects = new List<GameObject>();
    private float yLevel = 5f;
    private float xDistance = 5f;

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
        if (other.CompareTag("Entity") && selectedGameObjects.Count <= 1 && !selectedGameObjects.Contains(other))
        {
            other.GetComponent<Renderer>().material.SetFloat("_Outline", .005f);
            selectedGameObjects.Add(other);
        }
        else if (selectedGameObjects.Contains(other))
        {
            other.GetComponent<Renderer>().material.SetFloat("_Outline", 0f);
            selectedGameObjects.Remove(other);
        }

        if (selectedGameObjects.Count == 2)
        {
            EntityBridge eb1 = selectedGameObjects[0].GetComponent<EntityBridge>();
            EntityBridge eb2 = selectedGameObjects[1].GetComponent<EntityBridge>();

            PrototypeEntity e = eb1.getEntity() as PrototypeEntity;
            PrototypeEntity e2 = eb2.getEntity() as PrototypeEntity;

            Vector3 spawnPoint = new Vector3(
                getMid(selectedGameObjects[0].transform.localPosition.x, selectedGameObjects[1].transform.localPosition.x), 
                selectedGameObjects[0].transform.localPosition.y - yLevel);

            Entity newEntity = MateEngine.mate(e, e2);
            SpontaenousGeneration.spawn(newEntity, spawnPoint);

        }

    }

    private float getMid(float a, float b)
    {
        return (a + b) / 2;
    }
}

