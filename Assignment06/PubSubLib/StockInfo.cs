using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PubSubLib
{
   [ DataContract ]
   public class StockInfo
   {
      private string   symbol;
      private double   price;
      private DateTime sTime;

      [ DataMember ]
      public string Symbol
      {
         get{ return( this.symbol ); }
         set{ this.symbol = value; }
      }

      [ DataMember ]
      public double Price
      {
         get{ return( this.price ); }
         set{ this.price = value; }
      }

      [ DataMember ]
      public DateTime STime
      {
         get{ return( this.sTime ); }
         set{ this.sTime = value; }
      }
   }
}
