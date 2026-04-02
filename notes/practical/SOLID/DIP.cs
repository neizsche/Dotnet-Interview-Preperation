using System;

namespace DIPLab
{
    // ==========================================
    // 1. THE BAD PRACTICE (Hard Dependency)
    // ==========================================
    // This violates DIP because the 'Notification' class (High-level)
    // is TIGHTLY COUPLED to 'EmailService' (Low-level).
    public class EmailService
    {
        public void SendEmail(string message) => Console.WriteLine($"Email sent: {message}");
    }

    public class BadNotification
    {
        private readonly EmailService _emailService;

        public BadNotification()
        {
            // VIOLATION: We are 'new-ing' up the dependency inside the constructor.
            // If we want to send an SMS instead, we have to rewrite this class.
            _emailService = new EmailService();
        }

        public void Send(string message) => _emailService.SendEmail(message);
    }

    // ==========================================
    // 2. THE GOOD PRACTICE (Dependency Inversion)
    // ==========================================
    
    // THE ABSTRACTION: Neither side knows the details of the other.
    public interface IMessageService
    {
        void Send(string message);
    }

    // THE LOW-LEVEL DETAILS: They implement the abstraction.
    public class BetterEmailService : IMessageService
    {
        public void Send(string message) => Console.WriteLine($"[DIP Email] {message}");
    }

    public class SmsService : IMessageService
    {
        public void Send(string message) => Console.WriteLine($"[DIP SMS] {message}");
    }

    // THE HIGH-LEVEL MODULE: It depends ONLY on the abstraction.
    public class Notification
    {
        private readonly IMessageService _service;

        // Dependency Injection: We "inject" the tool from the outside.
        // This class doesn't care IF it's Email, SMS, or Carrier Pigeon.
        public Notification(IMessageService service)
        {
            _service = service;
        }

        public void Act(string message) => _service.Send(message);
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Running Bad Practice (Tight Coupling) ---");
            var badNote = new BadNotification();
            badNote.Send("Hello via hard-coded Email!");

            Console.WriteLine("\n--- Running Good Practice (DIP/Injection) ---");
            
            // We decide which "detail" to use at the TOP level (Main)
            IMessageService email = new BetterEmailService();
            IMessageService sms = new SmsService();

            var note1 = new Notification(email);
            note1.Act("Alert: Server is down!");

            var note2 = new Notification(sms);
            note2.Act("Alert: Battery low!");
        }
    }
}