namespace GASvcLib
{
   interface IGeneticAlgorithm
   {
      void MInitializePopulation( );
      void MEvaluatePopulation( );
      void MSelectPopulation( );
      void MCrossoverPopulation( );
      void MMutatePopulation( ); 
   }
}
