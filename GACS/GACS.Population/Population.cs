using System;
using System.Collections.Generic;
using GACS.GACS.Gene;


namespace GACS.GACS.Population
{
    public class Indivisual {
        public dynamic Gene;

        public Indivisual(int populationSize, int geneLength, GeneList gene)
        {
            switch (gene)
            {
                case GACS.Gene.GeneList.FixedBinaryGene:
                    Gene = new FixedBinaryGenes(populationSize, geneLength);
                    break;
            }
        }
    }

    public class Population
    {
        public int PopulationSize;
        public List<Indivisual> Indivisual;

        public Population(int populationSize, GeneList gene)
        {
            PopulationSize = populationSize;
            InitializePopulation(gene);
        }

        private void InitializePopulation(GeneList gene)
        {
            this.Indivisual = new List<Indivisual>();
            for (int i=0; i< PopulationSize; i++)
            {
                this.Indivisual.Add(new Indivisual(PopulationSize, 10, gene));
            }
        }

        public Indivisual this[int i]
        {
            get { return this.Indivisual[i]; }
        }
    }
}
