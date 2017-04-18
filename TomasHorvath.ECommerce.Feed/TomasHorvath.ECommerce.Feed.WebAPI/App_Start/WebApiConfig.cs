using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TomasHorvath.ECommerce.Feed.WebAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.XmlFormatter.UseXmlSerializer = true;
			config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
			config.Formatters.Clear();
			config.Formatters.Add(new CustomNamespaceXmlFormatter { UseXmlSerializer = true });

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
