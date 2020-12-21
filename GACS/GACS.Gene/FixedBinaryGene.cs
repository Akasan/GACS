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
        private List<int> Gene;

        public FixedBinaryGene(int length, FixedBinaryGeneInitializeMethod initializeMethod=FixedBinaryGeneInitializeMethod.Random)
        {
            Length = length;
            InitializeGenes(initializeMethod);
        }

        public FixedBinaryGene(List<int> gene1, List<int> gene2)
        {
            Length = gene1.Count + gene2.Count;
            Gene = gene1;
            Gene.AddRange(gene2);
        }

        public FixedBinaryGene(List<int> gene)
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
            Gene = new List<int>();

            switch (initializeMethod)
            {
                case FixedBinaryGeneInitializeMethod.Random:
                    Random gen = new Random();
                    for (int i = 0; i < Length; i++)
                    {
                        int prob = gen.Next(100);
                        Gene.Add(prob < 50 ? 1 : 0);
                    }
                    break;
                case FixedBinaryGeneInitializeMethod.AllZero:
                    for (int i = 0; i < Length; i++)
                    {
                        Gene.Add(0);
                    }
                    break;
                case FixedBinaryGeneInitializeMethod.AllOne:
                    for (int i = 0; i < Length; i++)
                    {
                        Gene.Add(1);
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
                return Gene[i];
            }
        }

        /// <summary>
        /// Get genes as range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<int> GetFromTo(int from, int to)
        {
            return Gene.GetRange(from, to-from);
        }

        /// <summary>
        /// Iterate each gene
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetEachGene()
        {
            foreach (int gene in Gene)
            {
                yield return gene;
            }
        }
    }
}
