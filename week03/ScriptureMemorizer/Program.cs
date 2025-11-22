class Program
{
    static void Main(string[] args)
    {
        // Create scripture
        Reference reference = new Reference("Matthew", 6, 9, 13);
        Scripture scripture = new Scripture(reference,
            "Our Father in heaven, hallowed be your name. Your kingdom come, your will be done, on earth as it is in heaven.");

        while (true)

        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
                break;

            scripture.HideRandomWords(3);
        }

        Console.WriteLine("Program ended. Great job memorizing!");
    }
}