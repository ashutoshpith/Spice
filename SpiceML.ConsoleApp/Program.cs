// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using SpiceML.Model;

namespace SpiceML.ConsoleApp
{
    class Program
    {
        //Dataset to use for predictions 
        private const string DATA_FILEPATH = @"H:\MlDataSet\taxi-fare-train.csv";

        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);

            // Make a single prediction on the sample data and print results
            ModelOutput predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Fare_amount with predicted Fare_amount from sample data...\n\n");
            Console.WriteLine($"vendor_id: {sampleData.Vendor_id}");
            Console.WriteLine($"rate_code: {sampleData.Rate_code}");
            Console.WriteLine($"passenger_count: {sampleData.Passenger_count}");
            Console.WriteLine($"trip_time_in_secs: {sampleData.Trip_time_in_secs}");
            Console.WriteLine($"trip_distance: {sampleData.Trip_distance}");
            Console.WriteLine($"payment_type: {sampleData.Payment_type}");
            Console.WriteLine($"\n\nActual Fare_amount: {sampleData.Fare_amount} \nPredicted Fare_amount: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }

        // Change this code to create your own sample data
        #region CreateSingleDataSample
        // Method to load single row of dataset to try a single prediction
        private static ModelInput CreateSingleDataSample(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }
        #endregion
    }
}
