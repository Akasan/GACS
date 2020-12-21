using System;
using System.Collections.Generic;
using GACS.GACS.Gene;


namespace GACS.GACS.Population
{
    public class Indivisual {
        public dynamic Gene;

        public Indivisual(int populationSize, int geneLength, EGene gene)
        {
            switch (gene)
            {
                case GACS.Gene.EGene.FixedBinaryGene:
                    Gene = new FixedBinaryGene(geneLength);
                    break;
            }
        }
    }

    public class Population
    {
        public int PopulationSize;
        public List<Indivisual> Indivisual;

        public Population(int populationSize, EGene gene, int geneLength)
        {
            PopulationSize = populationSize;
            InitializePopulation(gene, geneLength);
        }

        private void InitializePopulation(EGene gene, int geneLength)
        {
            this.Indivisual = new List<Indivisual>();

            for (int i=0; i< PopulationSize; i++)
            {
                this.Indivisual.Add(new Indivisual(PopulationSize, geneLength, gene));
            }
        }

        public Indivisual this[int i]
        {
            get { return this.Indivisual[i]; }
        }
    }
}
