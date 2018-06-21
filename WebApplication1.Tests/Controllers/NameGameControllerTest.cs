using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Names.API;
using Names.API.Controllers;
using Names.API.Models;

namespace Names.API.Tests.Controllers
{
	[TestClass]
	public class NameGameControllerTest
	{

		[TestMethod]
		public void Get()
		{
			// Arrange
			NameGameController controller = new NameGameController();

			// Act
			DisplayPersons result = controller.Get().Result;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
