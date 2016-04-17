using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using GeneticsCore;

public static class MateEngine
{
    public static Entity mate(Entity a, Entity b)
    {
        PrototypeEntity peA = (PrototypeEntity) a;
        PrototypeEntity peB = (PrototypeEntity) b;
        List<Genotype> aGenes = new List<Genotype>(peA.getGenes());
        List<Genotype> bGenes = new List<Genotype>(peB.getGenes());

        Entity e = new PrototypeEntity();

        // iterate over genes of peA check peB for possible valalues combination
        foreach (Genotype gene in aGenes)
        {
            foreach( Genotype gene2 in bGenes)
            {
                if (gene.isSameType(gene2)) {
                    Genotype newGenotype = gene.combineWith(gene2);
                    newGenotype.visit((PrototypeEntity)e);
                }
            }
        }
        return e;
    }
}
