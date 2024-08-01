using System.Text.Json;
   using System.Text.Json.Serialization;
   using System;
namespace APIS
{
   public class Api
   {
      public  async Task<argentApi> GetArgentoAsync()
      {
          var url= "https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
         try
         {
            HttpClient client= new HttpClient();
            HttpResponseMessage response= await client.GetAsync(url); 
            response.EnsureSuccessStatusCode();  
            string responseBody= await response.Content.ReadAsStringAsync();
            argentApi resp= JsonSerializer.Deserialize<argentApi>(responseBody); 
            return resp;
         }
         catch (HttpRequestException e) 
         {
            Console.WriteLine("problemas con acceso a la API");
            Console.WriteLine("mensaje: {0}", e.Message);
            return null;
         }
      }
   }
 
}