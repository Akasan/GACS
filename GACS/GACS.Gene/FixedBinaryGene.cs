using System;
using System.Collections.Generic;


namespace GACS.GACS.Gene
{
    /// <summary>
    /// Method list for FixedBinaryGene
    /// </summary>
    public enum FixedBinaryGeneInitializeMethod
    {
        Random = 0,
        AllZero = 1,
        AllOne = 2
    }

    public class FixedBinaryGene
    {
        /// <summary>
        /// Length of gene
        /// </summary>
        public int Length;

        /// <summary>
        /// Gene information
        /// </summary>
        private List<bool> Gene;

        public FixedBinaryGene(int length, FixedBinaryGeneInitializeMethod initializeMethod=FixedBinaryGeneInitializeMethod.Random)
        {
            Length = length;
            InitializeGenes(initializeMethod);
        }

        public FixedBinaryGene(List<bool> gene1, List<bool> gene2)
        {
            Length = gene1.Count + gene2.Count;
            Gene = gene1;
            Gene.AddRange(gene2);
        }

        public FixedBinaryGene(List<bool> gene)
        {
            Length = gene.Count;
            Gene = gene;
        }

        /// <summary>
        /// Initialize gene
        /// </summary>
        /// <param name="initializeMethod">Method for initializing</param>
        private void InitializeGenes(FixedBinaryGeneInitializeMethod initializeMethod)
        {
            Gene = new List<bool>(Length);

            switch (initializeMethod)
            {
                case FixedBinaryGeneInitializeMethod.Random:
                    Random gen = new Random();
                    for (int i = 0; i < Length; i++)
                    {
                        int prob = gen.Next(100);
                        Gene[i] = prob < 50 ? true : false;
                    }
                    break;
                case FixedBinaryGeneInitializeMethod.AllZero:
                    for (int i = 0; i < Length; i++)
                    {
                        Gene[i] = false;
                    }
                    break;
                case FixedBinaryGeneInitializeMethod.AllOne:
                    for (int i = 0; i < Length; i++)
                    {
                        Gene[i] = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Get specific position's gene
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i]
        { 
            get {
                if(this.Gene[i] == false)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Get genes as range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<bool> GetFromTo(int from, int to)
        {
            return Gene.GetRange(from, to-from);
        }

        /// <summary>
        /// Iterate each gene
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetEachGene()
        {
            foreach (bool gene in Gene)
            {
                yield return gene == false ? 0 : 1;
            }
        }
    }

    public class FixedBinaryGenes
    {
        private List<FixedBinaryGene> Genes;
        public int PopulationSize;
        public int GeneSize;

        public FixedBinaryGenes(int populationSize, int geneSize, FixedBinaryGeneInitializeMethod initializeMethod = FixedBinaryGeneInitializeMethod.Random)
        {
            PopulationSize = populationSize;
            GeneSize = geneSize;
            Initialize(initializeMethod);
        }

        private void Initialize(FixedBinaryGeneInitializeMethod initializeMethod)
        {
            Genes = new List<FixedBinaryGene>(PopulationSize);
            for(int i=0; i<PopulationSize; i++)
            {
                Genes.Add(new FixedBinaryGene(GeneSize, initializeMethod));
            }
        }

        public FixedBinaryGene this[int i]
        {
            get
            {
                return Genes[i];
            }
        }
    }
}
