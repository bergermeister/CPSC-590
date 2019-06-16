using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLib
{
   [ DataContract ]
   public class ComputeResult
   {
      private double   result;
      private DateTime resultTime;
      private string   clientID;

      [ DataMember ]
      public double Result
      {
         get{ return( result ); }
         set{ result = value; }
      }

      [ DataMember ]
      public DateTime ResultTime
      {
         get{ return( resultTime ); }
         set{ resultTime = value; }
      }

      [ DataMember ]
      public string ClientID
      {
         get{ return( clientID ); }
         set{ clientID = value; }
      }
   }
}
