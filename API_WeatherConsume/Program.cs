﻿using Newtonsoft.Json;
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
    Console.WriteLine("New Data");
    Console.WriteLine();
    string cityName, country, detail;
    decimal temp;

    Console.Write("City Name: ");
    cityName = Console.ReadLine();

    Console.Write("Country: ");
    country = Console.ReadLine();

    Console.Write("Detail: ");
    detail = Console.ReadLine();

    Console.Write("Temp: ");
    temp = decimal.Parse(Console.ReadLine());



    string url = "https://localhost:7222/api/Weathers";

    var newWeatherCity = new
    {
        CityName = cityName,
        Country = country,
        Detail = detail,
        Temp = temp
    };


    using (HttpClient client = new HttpClient())
    {
        try
        {
            string json = JsonConvert.SerializeObject(newWeatherCity);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("New city added successfully.");
        }
        catch (HttpRequestException httpRequestException)
        {

            Console.WriteLine($"HTTP error: {httpRequestException.Message}");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }


}
else if (choice == "4")
{
    string url = "https://localhost:7222/api/Weathers?id=";

    Console.Write("Enter the id value you want to delete: ");
    int id = int.Parse(Console.ReadLine());

    using (HttpClient client = new HttpClient())
    {
        try
        {
            HttpResponseMessage response = await client.DeleteAsync(url + id);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("City deleted successfully.");
        }
        catch (HttpRequestException httpRequestException)
        {
            Console.WriteLine($"HTTP error: {httpRequestException.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }



}
else if (choice == "5")
{
    Console.WriteLine("Update Data");
    Console.WriteLine();
    string cityName, country, detail;
    decimal temp;
    int cityId;

    Console.Write("City Name: ");
    cityName = Console.ReadLine();

    Console.Write("Country: ");
    country = Console.ReadLine();

    Console.Write("Detail: ");
    detail = Console.ReadLine();
    Console.Write("Temp: ");
    temp = decimal.Parse(Console.ReadLine());

    Console.Write("Id: ");
    cityId = int.Parse(Console.ReadLine());
    
    string url = "https://localhost:7222/api/Weathers";

    var newWeatherCity = new
    {
        CityId = cityId,
        CityName = cityName,
        Country = country,
        Detail = detail,
        Temp = temp
        
    };

    using (HttpClient client = new HttpClient())
    {
        try
        {
            string json = JsonConvert.SerializeObject(newWeatherCity);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("City updated successfully.");
        }
        catch (HttpRequestException httpRequestException)
        {
            Console.WriteLine($"HTTP error: {httpRequestException.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

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