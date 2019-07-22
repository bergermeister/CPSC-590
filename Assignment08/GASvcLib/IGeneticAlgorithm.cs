namespace GASvcLib
{
   interface IGeneticAlgorithm
   {
      void InitializePopulation( );
      void EvaluatePopulation( );
      void SelectPopulation( );
      void CrossoverPopulation( );
      void MutatePopulation( ); 
   }
}
