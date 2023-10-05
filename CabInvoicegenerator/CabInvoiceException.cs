using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoicegenerator
{
    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            Invalid_Ride_Type,
            Invalid_Distance,
            Invalid_Time,
            Null_Rides,
            Invalid_User_ID
        }
        public ExceptionType type;
        public CabInvoiceException(ExceptionType type,string messege):base(messege)
        {
            this.type = type;
        }


    }
}
