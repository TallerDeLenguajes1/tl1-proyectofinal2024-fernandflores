// See https://aka.ms/new-console-template for more information
using System.Text.Json;


var player= await GetCurrencyRateAsync();
static async Task<argentApi> GetCurrencyRateAsync()
{
 var url= "https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
 try
 {
    HttpClient client= new HttpClient();
    HttpResponseMessage response= await client.GetAsync(url); 
    response.EnsureSuccessStatusCode();  
    string responseBody= await response.Content.ReadAsStringAsync();
    argentApi argentina= JsonSerializer.Deserialize<argentApi>(responseBody); 
    return argentina;
 }
 catch (HttpRequestException e) 
 {
    Console.WriteLine("problemas con acceso a la API");
    Console.WriteLine("mensaje: {0}", e.Message);
    return null;
 }
}

/*
foreach( var item in player.Provincias)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Nombre);
    Console.WriteLine(item.stats.Armadura);
    item.stats.Armadura+=40;
    Console.WriteLine(item.stats.Armadura);
}
Console.WriteLine(player.Total);
foreach (var item2 in  player.Provincias)
{
    Console.WriteLine(item2.Nombre+" "+item2.stats.Armadura);
}*/
player.incializarJuego();
foreach (var item in player.Provincias)
{
    Console.WriteLine($"nombre: {item.Nombre}");
    Console.WriteLine("transporte publico: "+item.stats.TransportePublico);
    Console.WriteLine($"inteligencia: {item.stats.Inteligencia}");
    Console.WriteLine($"fuerzaas armadas: {item.stats.FuerzasArmada}");
    Console.WriteLine($"calidad de vida: {item.stats.CalidadDeVida}");
    Console.WriteLine($"sistema de salud: {item.stats.SistemaDeSalud}");
    Console.WriteLine($"poblacion: {item.stats.Poblacion}");
    Console.WriteLine("-----------....--------.....------");
}
