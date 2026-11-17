using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1;

var http = new HttpClient();
var responce = await http.GetAsync("https://localhost:7040/WeatherForecast");

string json = await responce.Content.ReadAsStringAsync();
var result = JsonSerializer.Deserialize<List<WeatherForecast>>(json);

Console.ReadLine();