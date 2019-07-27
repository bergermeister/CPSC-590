namespace GAWebServant
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
