using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace PubSubLib
{
   [ ServiceBehavior( InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple ) ]
   public class PubSub : ILongCompute, IStocks, IPriceChange
   {
      private static Dictionary< IStocksCallback, StockInfo > SubscriberList = new Dictionary< IStocksCallback, StockInfo >( );
      private ComputeResult                  cr = new ComputeResult( );
      private object                         voLock = new object( );

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
   
      public bool SubscribeToStockPrice( string stocksym, double triggerPrice )
      {
         try
         {
            IStocksCallback callbackChannel = OperationContext.Current.GetCallbackChannel< IStocksCallback >( );
            if( SubscriberList.ContainsKey( callbackChannel ) == false )
            {
               SubscriberList.Add( callbackChannel, new StockInfo(){ Symbol = stocksym,
                                                                     Price = triggerPrice,
                                                                     STime = DateTime.Now } );
            }
         }
         catch( Exception ex )
         {
            throw new FaultException( ex.Message, new FaultCode( "Subscription Error" ) );
         }

         return( true );
      }

      public bool UnsubscribeToStockPrice( string stocksym )
      {
         try
         {
            IStocksCallback callbackChannel = OperationContext.Current.GetCallbackChannel< IStocksCallback >( );
            if( SubscriberList.ContainsKey( callbackChannel ) == true )
            {
               SubscriberList.Remove( callbackChannel );
            }
         }
         catch( Exception ex )
         {
            throw new FaultException( ex.Message, new FaultCode( "Unsubcription Error" ) );
         }

         return( true );
      }

      public bool ChangeStockPrice( string symbol, double newprice )
      {
         try
         {
            // trigger call to the subscribers
            foreach( KeyValuePair< IStocksCallback, StockInfo > Pair in SubscriberList )
            {
               IStocksCallback icbChannel = Pair.Key;
               if( ( symbol == Pair.Value.Symbol ) && ( newprice > Pair.Value.Price ) )
               {
                  StockInfo si = new StockInfo( );
                  si.Price = newprice;
                  si.Symbol = symbol;
                  si.STime = DateTime.Now;
                  if( ( ( ICommunicationObject )icbChannel ).State == CommunicationState.Opened )
                  {
                     icbChannel.OnPriceChange( si );
                  }
               }
            }
         }
         catch( Exception ex )
         {
            throw new FaultException( ex.Message, new FaultCode( "Change Price Error" ) );
         }

         return( true );
      }
   }
}
