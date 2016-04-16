using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SpontaenousGeneration : ScriptableObject
{
    private Vector3 originPoint = new Vector3(0, 0, 0);

    private Genotype[] genePool = new Genotype[]
    {
        new CubeAppearanceGenotype(),
        new SphereAppearanceGenotype(),
        new CapsuleAppearanceGenotype()
    };

    private Mutation[] mutationPool = new Mutation[]
    {
        new GigantismMutation(),
        new DwarfismMutation()
    };

    private ColorGenotype colorGene = new ColorGenotype();

    public void generateSpontaenously()
    {
        int populationSize = 2;
        List<Entity> population = createPopulation(populationSize);
        mutate(population);
        spawnGameObjects(population);
    }

    private void spawnGameObjects(List<Entity> population)
    {
        foreach (Entity e in population)
        {
            spawn(e, originPoint);
            originPoint = new Vector3(originPoint.x + 5, 0, 0);
        }
    }

    public static void spawn(Entity e, Vector3 spawnPoint)
    {
        PrototypeEntity pe = (PrototypeEntity) e;
        GameObject go = GameObject.CreatePrimitive(pe.getAppearance());
        go.transform.position = spawnPoint;
        go.transform.localScale = pe.getSize();
        go.GetComponent<Renderer>().material = Resources.Load(pe.getColor(), typeof(Material)) as Material;
        go.tag = "Entity";
        go.AddComponent<EntityBridge>();
        go.GetComponent<EntityBridge>().setEntity(pe);
        go.AddComponent<RotationScript>();
    }

    private List<Entity> createPopulation(int populationSize)
    {
        List<Entity> entities = new List<Entity>();
        /* foreach (AppearanceGenotype gene in genePool)
         {
             PrototypeEntity pe = new PrototypeEntity();
             pe.accept(gene);
             pe.accept(colorGene);
             entities.Add(pe);
         }*/

        PrototypeEntity pe = new PrototypeEntity();
        pe.accept( new SphereAppearanceGenotype());
        pe.accept(colorGene);
        entities.Add(pe);

        colorGene = new ColorGenotype();

        PrototypeEntity pe2 = new PrototypeEntity();
        pe2.accept(new CapsuleAppearanceGenotype());
        pe2.accept(colorGene);
        entities.Add(pe2);

        return entities;
    }

    private void mutate(List<Entity> population)
    {
        foreach (Entity e in population)
        {
            float chance = UnityEngine.Random.Range(1, 100);
            if (chance > 95)
            {
                EntityVisitor mutation = mutationPool[UnityEngine.Random.Range(0, 1)];
                e.accept(mutation);
            }
        }
    }
}