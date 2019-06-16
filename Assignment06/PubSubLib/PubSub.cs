using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace PubSubLib
{
   public class PubSub : ILongCompute
   {
      private ComputeResult cr = new ComputeResult( );
      private object        voLock = new object( );

      public void Compute( int a, int b, string clientId )
      {
         Thread.Sleep( 5000 ); 
         lock( voLock )
         {
            cr.Result = 45.667 + a + b;
            cr.ResultTime = DateTime.Now;
            cr.ClientID = clientId;

            IComputeCallback callBackChannel = OperationContext.
                                               Current.
                                               GetCallbackChannel< IComputeCallback >( );
            if( ( ( ICommunicationObject )callBackChannel ).State == CommunicationState.Opened )
               callBackChannel.OnComputeResult( cr );
         }

         Thread.Sleep( 5000 );
         lock( voLock )
         {
            cr.Result = cr.Result + a + b;
            cr.ResultTime = DateTime.Now;
            cr.ClientID = clientId;

            IComputeCallback callBackChannel = OperationContext.
                                               Current.
                                               GetCallbackChannel< IComputeCallback >( );
            if( ( ( ICommunicationObject )callBackChannel ).State == CommunicationState.Opened )
               callBackChannel.OnComputeResult( cr );
         }
      }
   }
}
