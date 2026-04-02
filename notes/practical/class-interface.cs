using System;

namespace TypesLab
{
    // ==========================================
    // 1. THE INTERFACE (The "Contract")
    // ==========================================
    // It defines "What" an object can do, not "How" it does it.
    // Interfaces are the key to Decoupling and Unit Testing.
    public interface ITrackable
    {
        void UpdateLocation(GPSLocation newLoc);
        string GetStatus();
    }

    // ==========================================
    // 2. THE STRUCT (The "Value Type")
    // ==========================================
    // Best for small, simple data that doesn't change (Immutable).
    // Structs live on the STACK (fast), Classes live on the HEAP (slower).
    public struct GPSLocation
    {
        public double Latitude { get; }
        public double Longitude { get; }

        // Structs should usually be "readonly" to prevent bugs
        public GPSLocation(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        public override string ToString() => $"({Latitude}, {Longitude})";
    }

    // ==========================================
    // 3. THE CLASS (The "Reference Type")
    // ==========================================
    // Best for complex objects with "Identity" and "Behavior."
    // Supports Inheritance and can implement multiple Interfaces.
    public class Drone : ITrackable
    {
        public string Model { get; set; }
        private GPSLocation _currentLocation;

        public Drone(string model) => Model = model;

        // Implementation of the Interface contract
        public void UpdateLocation(GPSLocation newLoc)
        {
            _currentLocation = newLoc;
            Console.WriteLine($"[Drone {Model}] Moving to {newLoc}");
        }

        public string GetStatus() => $"Drone {Model} is hovering at {_currentLocation}";
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            // Using the Struct (Value Type)
            GPSLocation startPos = new GPSLocation(40.7128, -74.0060);
            
            // Using the Class (Reference Type) via the Interface
            ITrackable myDrone = new Drone("Phantom-X");
            
            myDrone.UpdateLocation(startPos);
            Console.WriteLine(myDrone.GetStatus());
        }
    }
}