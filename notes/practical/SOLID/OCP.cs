using System;
using System.Collections.Generic;

namespace OCPLab
{
    // ==========================================
    // 1. THE BAD PRACTICE (Violates OCP)
    // ==========================================
    // This class is "Open for Modification." 
    // If we add "SMS", we have to edit this file. If we add "Slack", we edit it again.
    public class BadNotificationManager
    {
        public void Send(string message, string type)
        {
            if (type == "Email")
            {
                Console.WriteLine($"Sending Email: {message}");
            }
            else if (type == "SMS")
            {
                Console.WriteLine($"Sending SMS: {message}");
            }
            // Logic for 'WhatsApp' would go here... and 'Slack'... and 'Push'...
        }
    }

    // ==========================================
    // 2. THE GOOD PRACTICE (The OCP Way)
    // ==========================================

    // THE INTERFACE: This is the "Socket"
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    // THE EXTENSIONS: These are the "Plugs"
    public class EmailService : IMessageService
    {
        public void SendMessage(string message) => Console.WriteLine($"[Email] {message}");
    }

    public class SmsService : IMessageService
    {
        public void SendMessage(string message) => Console.WriteLine($"[SMS] {message}");
    }

    // NEW FEATURE: We added WhatsApp without touching Email or SMS code!
    public class WhatsAppService : IMessageService
    {
        public void SendMessage(string message) => Console.WriteLine($"[WhatsApp] {message}");
    }

    // THE MANAGER: This class is now "CLOSED"
    // It doesn't care WHAT the service is, as long as it has a SendMessage method.
    public class NotificationController
    {
        public void NotifyAll(IEnumerable<IMessageService> services, string message)
        {
            foreach (var service in services)
            {
                service.SendMessage(message);
            }
        }
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Running Bad Practice ---");
            var bad = new BadNotificationManager();
            bad.Send("Hello!", "Email");
            bad.Send("Hi!", "SMS");

            Console.WriteLine("\n--- Running Good Practice (OCP) ---");
            
            // We can mix and match any services we want
            var activeServices = new List<IMessageService>
            {
                new EmailService(),
                new SmsService(),
                new WhatsAppService() // Added easily!
            };

            var controller = new NotificationController();
            controller.NotifyAll(activeServices, "System Update at 12:00 PM");
        }
    }
}