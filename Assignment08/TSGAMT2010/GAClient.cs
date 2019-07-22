namespace TSGAMT2010
{
   using System;

   class GAClient : GA.IGASvcCallback, IDisposable
   {
      GA.GASvcClient voProxy = null;
      
      public void MExecute( double[ , ] aoDistMat, int aiNumThreads )
      {
         try
         {
            this.voProxy = new GA.GASvcClient( new System.ServiceModel.InstanceContext( this ), "GASVC" );
            this.voProxy.MExecute(
         }
         catch( Exception koEx )
         {
            throw koEx;
         }
      }

      public void MUpdateResult( GA.GAMember aoRes )
      {
         
      }

      public void Dispose( )
      {
         if( this.voProxy != null )
         {
            this.voProxy.Close( );
         }
      }
   }
}
