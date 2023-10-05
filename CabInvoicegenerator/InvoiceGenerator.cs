using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoicegenerator
{
    public class InvoiceGenerator
    {
        public RideType rideType;
        private RideRepository RideRepository;

        //Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.RideRepository = new RideRepository();
            try
            {
                //If the Ride Type is Premium then Rates for Premium else for Normal  
                if (rideType.Equals(RideType.Premium))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.Normal))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }

            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid ride type");
            }
        }

        //Function to Calculate Fare
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                //Calculating Total Fare
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Distance, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Time, "Invalid time");

                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

    }
    

}
