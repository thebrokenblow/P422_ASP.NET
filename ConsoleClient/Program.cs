using ConsoleClient.Model;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

//var httpClient = new HttpClient();
//var responce = await httpClient.GetAsync("https://localhost:7273/Product");

//var options = new JsonSerializerOptions
//{
//    PropertyNameCaseInsensitive = true
//};
//List<Product> products = null; 
//if (responce.StatusCode == HttpStatusCode.OK)
//{
//    var json = await responce.Content.ReadAsStringAsync();
//    products = JsonSerializer.Deserialize<List<Product>>(json, options);
//}

//if (products != null)
//{
//    var firstProduct = products.First();
//    var responceDetailsProduct = await httpClient.GetAsync($"https://localhost:7273/Product/{firstProduct.Id}");
//    var json = await responceDetailsProduct.Content.ReadAsStringAsync();
//    var product = JsonSerializer.Deserialize<Product>(json, options);

//    var deleteResponce = await httpClient.DeleteAsync($"https://localhost:7273/Product/{firstProduct.Id}");


//    var responceAllProduct = await httpClient.GetAsync("https://localhost:7273/Product");
//    json = await responceAllProduct.Content.ReadAsStringAsync();
//    products = JsonSerializer.Deserialize<List<Product>>(json, options);
//}

//UPDATE

//var httpClient = new HttpClient();

//var product = new Product
//{
//    Id = Guid.NewGuid(),
//    Name = "Huawei",
//    Description = "Крутой Ноутбук",
//    Price = 150_000
//};

//var responce = await httpClient.PostAsJsonAsync("https://localhost:7273/Product", product);

//product.Price = 100_000;

//var responceUpdate = await httpClient.PutAsJsonAsync("https://localhost:7273/Product", product);

//Console.ReadLine();