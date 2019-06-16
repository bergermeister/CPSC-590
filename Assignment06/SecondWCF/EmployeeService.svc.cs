using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SecondWCF
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
   // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
   public class EmployeeService : IEmployeeService
   {
      public List< Employee > GetAllEmployees( )
      {
         List< Employee > EList = new List< Employee >( );
         Employee e1 = new Employee{ EmployeeId = 1234, FirstName = "Bill", JobTitle = "Manager", LastName = "Baker" };
         Employee e2 = new Employee{ EmployeeId = 1235, FirstName = "Sally", JobTitle = "Vice President", LastName = "Simpson" };
         EList.Add( e1 );
         EList.Add( e2 );
         return( EList );
      }

      public bool UpdateEmployee( Employee aoEmp )
      {
         return( true );
      }
   }
}
