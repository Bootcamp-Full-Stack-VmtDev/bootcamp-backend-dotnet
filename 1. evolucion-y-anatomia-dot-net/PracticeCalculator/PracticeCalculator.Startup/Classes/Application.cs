using PracticeCalculator.Startup.Interfaces;
using PracticeCalculator.Startup.Models;

namespace PracticeCalculator.Startup.Classes
{
    public class Application : ICalculator
    {
        private Operation sum = new Operation { Name = "Suma", Symbol = "+" };
        private Operation subtract = new Operation { Name = "Resta", Symbol = "-" };
        private Operation multiply = new Operation { Name = "Multiplicación", Symbol = "*" };
        private Operation divide = new Operation { Name = "División", Symbol = "/" };

        public void ShowMenu()
        {
            Console.WriteLine("---------- Calculadora de dos números ----------");
            Console.WriteLine($"1. {sum.Name} ({sum.Symbol})");
            Console.WriteLine($"2. {subtract.Name} ({subtract.Symbol})");
            Console.WriteLine($"3. {multiply.Name} ({multiply.Symbol})");
            Console.WriteLine($"4. {divide.Name} ({divide.Symbol})");
            Console.WriteLine("0. Salir");
            Console.WriteLine("------------------------------------------------\n");
        }

        public double GetNumber(string value)
        {
            while (true)
            {
                Console.Write(value);
                string? input = Console.ReadLine();
                try
                {
                    if (input is null) throw new ArgumentNullException();
                    return Convert.ToDouble(input);
                }
                catch
                {
                    Console.WriteLine("Número inválido, intente de nuevo.");
                }
            }
        }

        public void Start()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Seleccione una operación: ");
                string? option = Console.ReadLine();

                if (option == "0")
                {
                    Console.WriteLine("Gracias por usar la calculadora básica...");
                    break;
                }

                double a = GetNumber("\nIngrese el primer número: ");
                double b = GetNumber("Ingrese el segundo número: ");
                double result;

                try
                {
                    switch (option)
                    {
                        case "1":
                            result = a + b;
                            Console.WriteLine($"Resultado: {a} + {b} = {result}");
                            break;
                        case "2":
                            result = a - b;
                            Console.WriteLine($"Resultado: {a} - {b} = {result}");
                            break;
                        case "3":
                            result = a * b;
                            Console.WriteLine($"Resultado: {a} * {b} = {result}");
                            break;
                        case "4":
                            if (b == 0) throw new DivideByZeroException("No se puede dividir entre cero.");
                            result = a / b;
                            Console.WriteLine($"Resultado: {a} / {b} = {result}");
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
