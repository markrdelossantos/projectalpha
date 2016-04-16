using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PrototypeEntity : Entity
{
    private PrimitiveType myAppearance;
    private Vector3 mySize;
    private string myColor;

    private List<Mutation> myMutations;
    private List<Genotype> myGenotypes;

    public PrototypeEntity()
    {
        myMutations = new List<Mutation>();
        myGenotypes = new List<Genotype>();
    }

    public PrototypeEntity(List<Genotype> genes, List<Mutation> mutations)
    {
        myMutations = mutations;
        myGenotypes = genes;
    }

    public void accept(EntityVisitor ev)
    {
        ev.visit(this);
    }

    public void setAppearance(PrimitiveType pt)
    {
        myAppearance = pt;
    }

    public PrimitiveType getAppearance()
    {
        return myAppearance;
    }

    public void setSize(Vector3 s)
    {
        mySize = s;
    }

    public Vector3 getSize()
    {
        return mySize;
    }

    public void setColor(String c)
    {
        myColor = c;
    }

    public String getColor()
    {
        return myColor;
    }

    public void addGenotype(Genotype gene)
    {
        myGenotypes.Add(gene);
    }

    public void addMutation(Mutation mutation)
    {
        myMutations.Add(mutation);
    }

    public List<Mutation> getMutations()
    {
        return myMutations;
    }

    public List<Genotype> getGenes()
    {
        return myGenotypes;
    }
}