Console.WriteLine("Welcome to API Consume Application");
Console.WriteLine();
Console.WriteLine(" ###  Please select a transaction  ### \n");
Console.WriteLine(" 1 - Get city list");
Console.WriteLine(" 2 - Add a new city");
Console.WriteLine(" 3 - Delete a city");
Console.WriteLine(" 4 - Update a city");
Console.WriteLine(" 5 - Get city by ID");
Console.WriteLine();

int choice;


Console.WriteLine("Please make your choice: ");
choice = Convert.ToInt32(Console.ReadLine());

if (choice == 1)
{
    Console.WriteLine("Transaction 1");
} 
else if (choice == 2)
{
    Console.WriteLine("Transaction 2");
}
else if (choice == 3)
{
    Console.WriteLine("Transaction 3");
}
else if (choice == 4)
{
    Console.WriteLine("Transaction 4");
}
else if (choice == 5)
{
    Console.WriteLine("Transaction 5");
}
else
{
    Console.WriteLine("Invalid choice. Please try again.");
}