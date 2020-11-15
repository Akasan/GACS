using System;
using System.Collections.Generic;
using GACS.GACS.Gene;


namespace GACS.GACS.CrossOver
{
    public class FixedBinaryCrossOver
    {
        /// <summary>
        /// Execute single-point crossover.
        /// </summary>
        /// <param name="parentGene1">parent gene</param>
        /// <param name="parentGene2">another parent gene</param>
        public static void SingleCrossOver(ref FixedBinaryGene parentGene1, ref FixedBinaryGene parentGene2)
        {
            Random rdn = new Random();
            List<bool> gene1First, gene1Second, gene2First, gene2Second;
            int crossPoint = rdn.Next(parentGene1.Length);
            gene1First = parentGene1.GetFromTo(0, crossPoint);
            gene1Second = parentGene1.GetFromTo(crossPoint, parentGene1.Length);
            gene2First = parentGene2.GetFromTo(0, crossPoint);
            gene2Second = parentGene2.GetFromTo(crossPoint, parentGene2.Length);

            parentGene1 = new FixedBinaryGene(gene1First, gene2Second);
            parentGene2 = new FixedBinaryGene(gene2First, gene1Second);
        }

        public static void MultipleCrossOver(ref FixedBinaryGene parentGene1, ref FixedBinaryGene parentGene2, int pointNum=1)
        {
            if(pointNum == 1)
            {
                SingleCrossOver(ref parentGene1, ref parentGene2);
            }
            else
            {
                Random rdn = new Random();
                List<int> crossPoint = new List<int>();
                List<bool> result1 = new List<bool>();
                List<bool> result2 = new List<bool>();
                int lastValue = 0;
                int lastPoint = 0;
                int i;

                for (i = 0; i < pointNum; i++)
                {
                    if (i == 0)
                    {
                        lastValue = rdn.Next(parentGene1.Length - pointNum);
                        crossPoint.Add(lastValue);

                    }
                    else
                    {
                        lastValue = rdn.Next(lastValue, parentGene1.Length - pointNum + i);
                        crossPoint.Add(lastValue);
                    }
                }

                for (i = 0; i < pointNum; i++)
                {
                    if (i % 2 == 0)
                    {
                        result1.AddRange(parentGene1.GetFromTo(lastPoint, crossPoint[i]));
                        result2.AddRange(parentGene2.GetFromTo(lastPoint, crossPoint[i]));
                    }
                    else
                    {
                        result1.AddRange(parentGene2.GetFromTo(lastPoint, crossPoint[i]));
                        result2.AddRange(parentGene1.GetFromTo(lastPoint, crossPoint[i]));
                    }
                    lastPoint = crossPoint[i];
                }

                parentGene1 = new FixedBinaryGene(result1);
                parentGene2 = new FixedBinaryGene(result2);
            }
        }
    }
}
