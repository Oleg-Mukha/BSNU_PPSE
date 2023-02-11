internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n\t\t\t- Menu -");
            Console.WriteLine("/text - choose amount of words from text file 'Lorem Ipsum'");
            Console.WriteLine("/math - choose basic math operation");
            Console.WriteLine("/exit - stop program");
            Console.Write("Select menu item: ");

            var choice = Convert.ToString(Console.ReadLine()); // Variable defines item from menu list
            switch (choice)
            {
                case "/text":
                    OutputAmountOfWords();
                    break;
                case "/math":
                    MathOperations();
                    break;
                case "/exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Oops.. Error! Unknown command, try again.");
                    break;
            }
        }
    }

    // Method outputs certain amount of words from text file "Lorem ipsum"
    private static void OutputAmountOfWords()
    {
        Console.Write("\nHow many words should be output?: ");
        var wordCount = Convert.ToInt32(Console.ReadLine());

        var pathFile = @"C:\Users\Admin\RiderProjects\Lab1\Lab1\text.txt";
        var text = File.ReadAllText(pathFile);

        var outputString = text.Split(' ');
        for (var i = 0; i < wordCount; i++) Console.Write(outputString[i] + " ");
        Console.WriteLine(" ");
    }

    // Method provides 4 basic mathematical operations - addition, subtraction, multiplication and division.
    private static void MathOperations()
    {
        Console.WriteLine("\n/add - addition");
        Console.WriteLine("/sub - subtraction");
        Console.WriteLine("/mult - multiplication");
        Console.WriteLine("/div - division");
        Console.Write("Select math operation: ");
        var operation = Convert.ToString(Console.ReadLine());

        Console.Write("Number #1: ");
        var firstNumber = Convert.ToDouble(Console.ReadLine());

        Console.Write("Number #2: ");
        var secondNumber = Convert.ToDouble(Console.ReadLine());

        double operationResult = 0;
        switch (operation)
        {
            case "/add":
                operationResult = firstNumber + secondNumber;
                Console.WriteLine($"{firstNumber} + {secondNumber} = {operationResult}");
                break;
            case "/sub":
                operationResult = firstNumber - secondNumber;
                Console.WriteLine($"{firstNumber} - {secondNumber} = {operationResult}");
                break;
            case "/mult":
                operationResult = firstNumber * secondNumber;
                Console.WriteLine($"{firstNumber} * {secondNumber} = {operationResult}");
                break;
            case "/div":
                Console.WriteLine($"{firstNumber} / {secondNumber} = {operationResult}");
                break;
            default:
                Console.WriteLine("Oops.. Unknown math operation. Try '/add', '/sub', '/mult', '/div'.");
                break;
        }
    }
}