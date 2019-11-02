using Microsoft.ML;
using SpiceML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Taxi
    {
        public int Id { get; set; }
        public string VendorId { get; set; }

        public float RateCode { get; set; }

        public float PassengerCount { get; set; }

        public float TripTimeInSecs { get; set; }

        public float TripDistance { get; set; }

        public string PaymentType { get; set; }

        public float FareAmount { get; set; }

        public string TaxiTest()
        {
            try
            {
                MLContext mlContext = new MLContext();

                ITransformer mlModel = mlContext.Model.Load(@"MLModel.zip", out var modelInputSchema);
                var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

                var input = new ModelInput();
                // Console.WriteLine("Enter The Text :");
                input.Vendor_id = VendorId;
                input.Rate_code = RateCode;
                input.Trip_time_in_secs = TripTimeInSecs;
                input.Trip_distance = TripDistance;
                input.Payment_type = PaymentType;


                ModelOutput result = predEngine.Predict(input);
                Console.WriteLine("Result Rating=" + result.Score);
                //Console.WriteLine("Result=" + result.Score);


                return result.Score.ToString();
            }
            catch(Exception e)
            {
                return "Not Working with Ml "+ e;
            }

         
        }
    }
}
