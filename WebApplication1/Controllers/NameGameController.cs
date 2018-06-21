using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Runtime.Caching;
using Names.API.Models;

namespace Names.API.Controllers
{
	public class NameGameController : ApiController
	{
		private ObjectCache _cache = MemoryCache.Default;

		// GET api/People
		public async Task<DisplayPersons> Get()
		{
			DisplayPersons dps = new DisplayPersons();
			try
			{
				List<Person> persons = _cache.Get("persons") as List<Person>;
				if (persons is null)
				{
					persons = new List<Person>();

					HttpClient client = new HttpClient();
					//string path = @"https://www.willowtreeapps.com/api/v1.0/profiles";  //TBD move value to config file 
					string path = ConfigurationManager.AppSettings["WillowTreeAPI"];

					HttpResponseMessage response = await client.GetAsync(path);
					if (response.IsSuccessStatusCode)
					{
						persons = await response.Content.ReadAsAsync<List<Person>>();
					}

					_cache.Add("persons", persons, DateTime.Now.AddMinutes(10));
				}

				if (persons.Count > 0)
				{
					List<DisplayPerson> displayPersons = new List<DisplayPerson>();
					int numberToGet = int.Parse(ConfigurationManager.AppSettings["imagesToShow"]);
					int enough = persons.Count < numberToGet ? persons.Count : numberToGet; 
					//int enough = persons.Count < 6 ? persons.Count : 6; //TBD make the 6 a value in config file

					List<int> indices = new List<int>();
					string findName = string.Empty;

					while (indices.Count < enough)
					{
						Random rnd = new Random();
						int index = rnd.Next(1, persons.Count);
						if (!indices.Contains(index))
						{
							indices.Add(index);
							Person selectedPerson = persons.ToArray()[index];
							DisplayPerson displayPerson = new DisplayPerson();
							displayPerson.id = selectedPerson.id;
							displayPerson.jobTitle = selectedPerson.jobTitle;
							displayPerson.Name = selectedPerson.firstName + ' ' + selectedPerson.lastName;
							displayPerson.slug = selectedPerson.slug;
							displayPerson.url = selectedPerson.headshot.url;
							displayPerson.alt = selectedPerson.headshot.alt;
							displayPerson.height = selectedPerson.headshot.height;
							displayPerson.width = selectedPerson.headshot.width;
							displayPersons.Add(displayPerson);
							//here's a mundane way to "randomly pick" one of the six persons being returned as the one to identify.
							if (findName.GetHashCode() > displayPerson.Name.GetHashCode())
							{
								findName = displayPerson.Name;
							}
							dps.displayPersons.Add(displayPerson);
						}
					}
					dps.nameToId = findName;
				}
				return dps;
			}
			catch (Exception ex)
			{
				//log exception
				return dps;
			}
		}

		//[HttpPost]
		//public string Compare(string nameSought, string nameSelected)
		//{
		//	string result = "Sorry, please try again.";
		//	if (nameSought == nameSelected)
		//	{
		//		result = "Correct!";
		//	}
		//	return result;
		//}
	}
}