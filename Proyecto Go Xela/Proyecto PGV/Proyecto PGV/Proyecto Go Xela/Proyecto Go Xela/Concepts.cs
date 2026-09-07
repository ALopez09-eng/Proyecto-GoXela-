using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Proyecto_Go_Xela
{
    // EXCEPCIONES PERSONALIZADAS
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class DuplicateCodeException : ValidationException
    {
        public DuplicateCodeException(string message) : base(message) { }
    }

    // USO DE ESTRUCTURAS
    public struct Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Street) ? City : $"{Street}, {City}";
    }

    // ENCAPSULAMIENTO
    public class SecureClient
    {
        private string _name;
        private string _phone;

        public int Id { get; private set; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ValidationException("Nombre de cliente obligatorio.");
                _name = value.Trim();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ValidationException("Teléfono obligatorio.");
                _phone = value.Trim();
            }
        }

        public SecureClient(int id, string name, string phone)
        {
            Id = id;
            _name = null;
            _phone = null;
            Name = name;
            Phone = phone;
        }
    }

    // HERENCIA, POLIMORFISMO, SOBRESCRITURA
    public abstract class Notification
    {
        public string To { get; set; }
        public string Message { get; set; }
        public Notification(string to, string message)
        {
            To = to; Message = message;
        }

        public abstract void Send(); // sobrescritura obligatoria
    }

    public class EmailNotification : Notification
    {
        public string Subject { get; set; }
        public EmailNotification(string to, string subject, string message) : base(to, message)
        {
            Subject = subject;
        }

        public override void Send()
        {
            // implementación simulada
            Console.WriteLine($"Enviando email a {To} - {Subject}: {Message}");
        }
    }

    public class SmsNotification : Notification
    {
        public SmsNotification(string to, string message) : base(to, message) { }
        public override void Send()
        {
            Console.WriteLine($"Enviando SMS a {To}: {Message}");
        }
    }

    // SOBRECARGA
    public static class TariffCalculatorEx
    {
        // sobrecarga 1: sólo distancia
        public static double Calculate(double distanceKm)
        {
            return Math.Round(1.2 * Math.Max(0, distanceKm), 2);
        }

        // sobrecarga 2: distancia + peso
        public static double Calculate(double distanceKm, double weightKg)
        {
            var baseFare = Calculate(distanceKm);
            if (weightKg > 10) baseFare += baseFare * 0.1; // recargo por peso
            return Math.Round(baseFare, 2);
        }

        // sobrecarga 3: distancia + tipo de servicio
        public static double Calculate(double distanceKm, ServiceType service)
        {
            var fare = Calculate(distanceKm);
            if (service == ServiceType.Prioritario) fare *= 1.1;
            if (service == ServiceType.Urgente) fare *= 1.2;
            return Math.Round(fare, 2);
        }
    }

    // RECURSIVIDAD (ejemplo simple)
    public static class RecursionExamples
    {
        // factorial recursivo (ejemplo didáctico)
        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("n negativo");
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }
    }

    // USO BASICO DE "PUNTEROS" con IntPtr/Marshal (evita unsafe)
    public static class MemoryHelper
    {
        public static IntPtr AllocateInt(int value)
        {
            var ptr = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(ptr, value);
            return ptr;
        }

        public static int ReadInt(IntPtr ptr)
        {
            return Marshal.ReadInt32(ptr);
        }

        public static void Free(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr);
        }
    }
}
