using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NameGameUI.Models;
using Newtonsoft.Json;

namespace NameGameUI.Controllers
{
	public class HomeController : Controller
	{
		string url = "api/NameGame";
		string baseurl = "http://localhost:64612/";

		public ActionResult Index()
		{
			HttpClient apiClient = new HttpClient();
			apiClient.BaseAddress = new Uri(baseurl);
			apiClient.DefaultRequestHeaders.Clear();
			//Define request data format  
			apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			Colleagues images = new Colleagues();
			try
			{
				Task <HttpResponseMessage> responseMessage = apiClient.GetAsync(url);
				if (responseMessage.Result.IsSuccessStatusCode)
				{
					List<Colleague> colleagueImages = new List<Colleague>();
					var responseData = responseMessage.Result.Content;
					using (var reader = new StreamReader(responseData.ReadAsStreamAsync().Result))
					{
						using (var jtr = new JsonTextReader(reader))
						{
							dynamic colleagues = new JsonSerializer().Deserialize(jtr);
							ViewBag.nameSought = colleagues.nameToID;
							images.nameToId = colleagues.nameToId;
							images.slugToId = colleagues.slugToId;
							
							//convert dynamic object instance to a strongly typed instance.
							colleagueImages = colleagues.displayPersons.ToObject<List<Colleague>>();
							images.colleagues = colleagueImages;
						}
					}
					images.slugToId = images.colleagues.Single(s => s.Name == images.nameToId).slug;

					return View(images);
				}
				return View("Error");
			}
			catch (Exception ex)
			{
				// log exception 
				return View("Error");
			}
		}

		[HttpPost]
		public ActionResult Compare(string selectedName, string soughtName)
		{
			_Evaluation evaluation = new _Evaluation();
			evaluation.result = soughtName == selectedName ? "Correct!" : "Sorry, Please try again";
			return PartialView("_Evaluation", evaluation);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Peter Carlson's Name Game for WillowTree.";

			return View(); ;
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}