using DawaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace DawaWebApp.Controllers
{
    public class EstateController : ApiController
    {
        // GET: api/Estate
        public async Task <Estate> Get()
        {

            HttpClient httpClient = new HttpClient();
            
            // connecting to the Rest Api
            string response = await httpClient.GetStringAsync("https://dawa.aws.dk/adresser?vejnavn=Anemonevej&husnr=28&struktur=mini");

            // converting from json to c# object liste.
            List<Estate> estateListe = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Estate>>(response);

            // Sorting to find the specific estate from the list with the "3500 zipcode"    
            Estate es = estateListe.Find(e => e.postnr == "3500"); 

            return es;
        }

    }
}
