using System; // 'using' used to import namespaces
using System.Threading.Tasks;

namespace ArchitectureDemo // 'namespace' organizes code
{
    // 'abstract' class: Cannot be instantiated. It's a "half-finished" blueprint.
    public abstract class Hardware
    {
        // 'readonly': Can be set here or in the constructor, then never again.
        public readonly string SerialNumber;
        
        // 'const': Must be set at compile time. Hard-coded forever.
        public const string Manufacturer = "TechCorp";

        // 'static': Belongs to the class itself, not an object.
        public static int GlobalDeviceCount = 0;

        public Hardware(string sn) 
        {
            SerialNumber = sn;
            GlobalDeviceCount++;
        }

        // 'virtual': Subclasses ARE ALLOWED to change this.
        public virtual void Boot() => Console.WriteLine("System booting...");

        // 'abstract' method: Subclasses MUST implement this.
        public abstract void RunDiagnostics();
    }

    // 'sealed': This class cannot be inherited from. It's the end of the line.
    public sealed class Laptop : Hardware
    {
        public Laptop(string sn) : base(sn) { } // 'base' refers to the parent constructor

        // 'override': Replaces the 'virtual' or 'abstract' method from the parent.
        public override void RunDiagnostics() => Console.WriteLine("Laptop diagnostics clear.");

        // 'new': Method Hiding. This isn't an override; it's a brand new method 
        // that happens to have the same name as a parent method.
        public new void Boot() => Console.WriteLine("Laptop splash screen appearing...");

        // 'async' and 'await': Handling tasks without freezing the program.
        public async Task DownloadUpdateAsync()
        {
            Console.WriteLine("Update started...");
            await Task.Delay(1000); // Simulates work
            Console.WriteLine("Update complete.");
        }
    }

    // 'partial': This is just part of the class. The rest could be in another file.
    public partial class Debugger 
    {
        public void Log(object input) // 'object' can hold anything
        {
            // 'is' and 'as': Type checking and safe casting
            if (input is string text) 
            {
                Console.WriteLine($"String detected: {text}");
            }

            string possibleString = input as string; // Returns null if cast fails
        }
    }

    class Program
    {
        static async Task Main()
        {
            // 'new' used to create an object
            Laptop myLaptop = new Laptop("SN-5542");

            // 'this': used inside classes to refer to the current instance (implied here)
            myLaptop.RunDiagnostics();

            // Demonstration of 'using' for resource cleanup (IDisposable)
            using (var resource = new System.IO.StringReader("Hello!"))
            {
                Console.WriteLine(resource.ReadToEnd());
            } // 'resource' is disposed (cleaned up) automatically here.

            await myLaptop.DownloadUpdateAsync();
        }
    }
}