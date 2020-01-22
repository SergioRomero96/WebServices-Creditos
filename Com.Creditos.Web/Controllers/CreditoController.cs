using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Com.Creditos.Web.Models;
using System.IO;
using System.Text;

namespace Com.Creditos.Web.Controllers
{
    public class CreditoController : Controller
    {
        // GET: Credito
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51205/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync("CreditoService.svc/rest/GetCreditos");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStreamAsync().Result;

                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<CreditoViewModel>));

                    List<CreditoViewModel> response = obj.ReadObject(result) as List<CreditoViewModel>;

                    return View(response);
                }
            }
                return View();
        }

        // GET: Credito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Credito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Credito/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreditoViewModel credito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51205/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(CreditoViewModel));
                MemoryStream memoryStream = new MemoryStream();

                obj.WriteObject(memoryStream, credito);
                string data = Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);

                HttpResponseMessage responseMessage = await client.PostAsync("CreditoService.svc/rest/NewCredito",
                    new StringContent(data, Encoding.UTF8, "application/json"));

                if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
        }

        // GET: Credito/Edit/5
        public async Task<ActionResult> Edit(int idCredito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51205/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync("CreditoService.svc/rest/GetCredito/" + idCredito);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(CreditoViewModel));
                    CreditoViewModel response = obj.ReadObject(result) as CreditoViewModel;

                    return View(response);
                }
                return View();
            }
        }

        // POST: Credito/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CreditoViewModel credito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51205/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(CreditoViewModel));
                MemoryStream memoryStream = new MemoryStream();

                obj.WriteObject(memoryStream, credito);
                string data = Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);

                HttpResponseMessage responseMessage = await client.PutAsync("CreditoService.svc/rest/UpdateCredito",
                    new StringContent(data, Encoding.UTF8, "application/json"));

                if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
        }

        // GET: Credito/Delete/5
        public async Task<ActionResult> Delete(int idCredito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51205/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync("CreditoService.svc/rest/GetCredito/" + idCredito);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(CreditoViewModel));
                    CreditoViewModel response = obj.ReadObject(result) as CreditoViewModel;

                    return View(response);
                }
                return View();
            }
        }

        // POST: Credito/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(CreditoViewModel credito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51205/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.DeleteAsync("CreditoService.svc/rest/DeleteCredito/" + credito.IdCredito);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }
}
