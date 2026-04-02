using System;
using System.Collections.Generic;

namespace DelegateLab
{
    // ==========================================
    // 1. THE BASICS: Custom Delegates
    // ==========================================
    // Think of this as defining a "Shape" of a method.
    // This delegate can point to any method that takes a string and returns nothing.
    public delegate void LogHandler(string message);

    // ==========================================
    // 2. THE MODERN WAY: Func and Action
    // ==========================================
    /* Action<T>: Always returns void.
       Func<T, TResult>: Always returns something.
       No need to define custom delegates anymore!
    */

    public class VideoEncoder
    {
        // ==========================================
        // 3. THE EVENT PATTERN (Senior Level)
        // ==========================================
        
        // Step 1: Define a class to hold event data
        public class VideoEventArgs : EventArgs
        {
            public string Title { get; set; }
        }

        // Step 2: Define the Event (The "Broadcast")
        // Using EventHandler<T> is the standard .NET pattern.
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(string title)
        {
            Console.WriteLine($"Encoding {title}...");
            System.Threading.Thread.Sleep(1000); // Simulate work

            // Step 3: Raise the event (Publish)
            // The ?. checks if anyone is actually "Listening" (Subscribed)
            VideoEncoded?.Invoke(this, new VideoEventArgs { Title = title });
        }
    }

    // ==========================================
    // 4. THE IMPLEMENTATION (Putting it all together)
    // ==========================================
    class Program
    {
        static void Main()
        {
            // --- DELEGATE EXAMPLES ---
            
            // Multicast Delegate (One "number" calls two "people")
            LogHandler logger = MethodA;
            logger += MethodB; // Subscribe another method
            logger("Calling Delegates!"); 

            // Action: Simple callback, no return value
            Action<int> printNumber = (n) => Console.WriteLine($"Number: {n}");
            printNumber(42);

            // Func: Takes two ints, returns a string
            Func<int, int, string> mathFormatter = (x, y) => $"Result: {x + y}";
            Console.WriteLine(mathFormatter(10, 5));

            // --- EVENT EXAMPLES ---

            var encoder = new VideoEncoder();
            
            // Subscribing to the Event (Turning on the Radio)
            encoder.VideoEncoded += OnVideoEncoded; 
            encoder.VideoEncoded += (s, e) => Console.WriteLine($"Anonymous: {e.Title} is done.");

            encoder.Encode("Matrix Resurrections");
        }

        // Logic for Event Subscriber
        static void OnVideoEncoded(object source, VideoEncoder.VideoEventArgs e)
        {
            Console.WriteLine($"Subscriber 1: Sending notification for {e.Title}...");
        }

        static void MethodA(string msg) => Console.WriteLine($"A: {msg}");
        static void MethodB(string msg) => Console.WriteLine($"B: {msg}");
    }
}