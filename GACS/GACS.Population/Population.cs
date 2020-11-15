using System;
using System.Collections.Generic;


namespace GACS
{
    public class Indivisual {
    }

    public class Population
    {
        public int PopulationSize;
        public List<Indivisual> Indivisual;

        public Population(int populationSize)
        {
            PopulationSize = populationSize;
            InitializePopulation();
        }

        private void InitializePopulation()
        {
            this.Indivisual = new List<Indivisual>();
            for (int i=0; i< PopulationSize; i++)
            {
                this.Indivisual.Add(new Indivisual());
            }
        }

        public Indivisual this[int i]
        {
            get { return this.Indivisual[i]; }
        }
    }
}
