using UnityEngine;
using System.Collections;
using System;

namespace prototype1.genes
{
    public abstract class AppearanceGenotype : Genotype
    {
        protected PrimitiveType myType;
        protected Vector3 mySize = new Vector3(1, 1, 1);

        private Vector3 sizeIncrement = new Vector3(0f, 0f, 0f);

        public AppearanceGenotype() { }

        public AppearanceGenotype(PrimitiveType type, Vector3 size)
        {
            myType = type;
            mySize = size;
        }

        public override void visit(PrototypeEntity e)
        {
            e.setAppearance(getAppearance());
            e.setSize(getSize());
            e.addGenotype(this);
        }

        public override bool isSameType(Genotype other)
        {
            return other is AppearanceGenotype;
        }

        public override Genotype combineWith(Genotype gene)
        {
       
            AppearanceGenotype other = gene as AppearanceGenotype;

            // get average size of both genes and add a little bit
            Vector3 newSize = getAverageSize(getSize(), other.getSize()) + sizeIncrement;
            Debug.Log("New Size is" + newSize);
            PrimitiveType newType = myType;

            int randomNumber = UnityEngine.Random.Range(0, 100);
            Debug.Log("Random number is " + randomNumber);
            if (randomNumber > 50)
            {
                newType = other.getAppearance();
            }

            if (PrimitiveType.Capsule.GetType().IsAssignableFrom(newType.GetType()))
            {
                return new CapsuleAppearanceGenotype(newType, newSize);
            }

            else if (PrimitiveType.Sphere.GetType().IsAssignableFrom(newType.GetType()))
            {
                return new SphereAppearanceGenotype(newType, newSize);
            }
            else
            {
                return new CubeAppearanceGenotype(newType, newSize);
            }
        }

        protected Vector3 getAverageSize(Vector3 v1, Vector3 v2)
        {
            return new Vector3(((v1.x + v2.x) / 2), ((v1.y + v2.y) / 2), ((v1.z + v2.z) / 2));
        }

        public PrimitiveType getAppearance()
        {
            return myType;
        }

        public Vector3 getSize()
        {
            return mySize;
        }
    }
}