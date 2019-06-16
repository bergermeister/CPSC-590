using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SecondWCF
{
   [DataContract]
   public class Employee
   {
      [DataMember]
      public long EmployeeId{ get; set; }

      [DataMember]
      public string FirstName{ get; set; }

      [DataMember]
      public string LastName{ get; set; }

      [DataMember]
      public string JobTitle{ get; set; }
   }
}