// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using System.Text.Json;
// using System.Net.Http;
// using System.Net.Http.Headers;

// async Task GetData(HttpContext context)
// {

//     HttpClient client = new HttpClient();

//     var setup = await JsonSerializer.DeserializeAsync<ApiCaller.Setup>(context.Request.Body, serializerOptions);

//     client.BaseAddress = new Uri("https://www.myofficeguy.com/api/accounting/documents/create/");
//     client.DefaultRequestHeaders.Accept.Clear();
//     client.DefaultRequestHeaders.Accept.Add(
//         new MediaTypeWithQualityHeaderValue("application/json"));

//     ApiCaller.Credentials credentials = new ApiCaller.Credentials{
//         APIKey = "AWrQx04WMUEpc3VKmhOmHJ4p9Fy0npMTfem2SmqtvjekdKLQqk",
//         CompanyID = 112355
//     };

//     ApiCaller.Customer customer = new ApiCaller.Customer{
//         Name = setup.cname
//     };

//     ApiCaller.Details details = new ApiCaller.Details{
//         Customer = customer,
//         Type = 12
//     };

//     ApiCaller.GetQuota getQuota = new ApiCaller.GetQuota{
//         Credentials = credentials,
//         Details = details
//     };

//     HttpResponseMessage response = await client.PostAsJsonAsync("", getQuota);

//     await context.Response.WriteAsJsonAsync(new { 
//         message = response
//     });

// }