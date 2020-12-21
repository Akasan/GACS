# Example
``` cs
using System;
using GACS.GACS.Population;
using GACS.GACS.Gene;

namespace Test{
    class Program{
        static void Main(string[] args)
        {
            // Create population with 10 indivisuals.
            // Gene type is Binary and the length of gene is 20.
            Population population = new Population(10, EGene.FixedBinaryGene, 20);
            
            // Print Gene of Indivisual 0
            for(int i=0; i<20; i++){
                Console.WriteLine(population.Indivisual[0].Gene[i]);
            }
        }
    }
}
```
