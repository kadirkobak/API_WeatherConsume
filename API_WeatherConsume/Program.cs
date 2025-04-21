using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

Console.WriteLine("Welcome to API Consume Application");
Console.WriteLine();
Console.WriteLine(" ###  Please select a transaction  ### \n");
Console.WriteLine(" 1 - Get city list");
Console.WriteLine(" 2 - Get city name and weather list");
Console.WriteLine(" 3 - Add a new city");
Console.WriteLine(" 4 - Delete a city");
Console.WriteLine(" 5 - Update a city");
Console.WriteLine(" 6 - Get city by ID");
Console.WriteLine();

string choice;


Console.WriteLine("Please make your choice: ");
choice = Console.ReadLine();

if (choice == "1")
{
    string url = "https://localhost:7222/api/Weathers";

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);

        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            Console.WriteLine($"City Name: {cityName}");
        }
    }

}
else if (choice == "2")
{
    string url = "https://localhost:7222/api/Weathers";

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);

        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            string cityTemp = item["temp"].ToString();
            Console.WriteLine($"City Name: {cityName} ----- City Temp: {cityTemp}");
            
           
        }
    }
}
else if (choice == "3")
{
    Console.WriteLine("Transaction 3.");
}
else if (choice == "4")
{
    Console.WriteLine("Transaction 4");
}
else if (choice == "5")
{
    Console.WriteLine("Transaction 5");
}
else if (choice == "6")
{
    Console.WriteLine("Transaction 6");
}
else
{
    Console.WriteLine("Invalid choice. Please try again.");
}

Console.Read();