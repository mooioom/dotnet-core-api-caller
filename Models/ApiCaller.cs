using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiCaller{

    public class Methods{

        public static async Task GetData(HttpContext context)
        {

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();

            HttpClient client = new HttpClient();

            var setup = await JsonSerializer.DeserializeAsync<ApiCaller.Setup>(context.Request.Body, jsonOptions);

            client.BaseAddress = new Uri("https://www.someapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ApiCaller.Credentials credentials = new ApiCaller.Credentials{
                APIKey = "AWrQx04WMUEpc3VKmhOmHJ4p9Fy0npMTfem2SmqtvjekdKLQqk",
                CompanyID = 112355
            };

            ApiCaller.Customer customer = new ApiCaller.Customer{
                Name = setup.cname
            };

            ApiCaller.Details details = new ApiCaller.Details{
                Customer = customer,
                Type = 12
            };

            ApiCaller.GetQuota getQuota = new ApiCaller.GetQuota{
                Credentials = credentials,
                Details = details
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("", getQuota);

            await context.Response.WriteAsJsonAsync(new { 
                message = response
            });

        }

    }

    public class Setup
    {
        public string cname { get; set; }
        public string pname { get; set; }
        public int cost { get; set; }
    }

    public class Credentials{
        public int CompanyID { get; set; }
        public string APIKey { get; set; }
    }

    public class Customer{
        public string Name { get; set; }
    }
    
    public class Details{

        public Customer Customer { get; set; }
        public int Type {get; set; }

    }

    public class GetQuota{

        public Credentials Credentials { get; set; }
        public Details Details {get; set; }

    }

}