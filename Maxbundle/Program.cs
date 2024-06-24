using System;
using System.Collections.Generic;

namespace BundleBuilder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Available inventory
            Dictionary<string, int> inventory = new Dictionary<string, int>
            {
                {"Seat", 50},
                {"Pedal", 60},
                {"Frame", 60},
                {"Tube", 35}
            };

            // Requirements for a bike
            Dictionary<string, int> bikeRequirements = new Dictionary<string, int>
            {
                {"Seat", 1},
                {"Pedal", 2},
                {"Wheel", 2}
            };

            // Requirements for a wheel
            Dictionary<string, int> wheelRequirements = new Dictionary<string, int>
            {
                {"Frame", 1},
                {"Tube", 1}
            };

            // Calculate the maximum number of wheels that can be built
            int maxWheels = CalculateMaxBundles(wheelRequirements, inventory);
             
            inventory["Wheel"] = maxWheels;

            // Calculate the maximum number of bikes that can be built
            int maxBikes = CalculateMaxBundles(bikeRequirements, inventory);

            Console.WriteLine($"Maximum number of bikes that can be built : {maxBikes}");
        }

        public static int CalculateMaxBundles(Dictionary<string, int> requirements, Dictionary<string, int> inventory)
        {
            int maxBundles = int.MaxValue;

            foreach (var item in requirements)
            {
                string part = item.Key;
                int requiredQuantity = item.Value;

                if (!inventory.ContainsKey(part))
                {
                    return 0;
                }

                int availableQuantity = inventory[part];
                int possibleBundles = availableQuantity / requiredQuantity;

                if (possibleBundles < maxBundles)
                {
                    maxBundles = possibleBundles;
                }
            }

            return maxBundles;
        }
    }
}
