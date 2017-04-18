using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TomasHorvath.ECommerce.Feed.WebAPI.Controllers
{
	public class FeedController : ApiController
	{

		public Domain.Heureka.Shop GetHeurekaFeed()
		{

			var polozka = new Domain.Heureka.ShopItem();
			polozka.Id = "AB123";

			return new Domain.Heureka.Shop()
			{
				ShoptItems = new List<Domain.Heureka.ShopItem>()
						{
							new Domain.Heureka.ShopItem()
							{
								Id =  "AB123",
								Url = "http://obchod.cz/mobily/nokia-5800-xpressmusic",
								ImageUrl = "http://obchod.cz/mobily/nokia-5800-xpressmusic/obrazek.jpg",
								ImageUrlAlternative = new List<string>()
								{
									"http://obchod.cz/mobily/nokia-5800-xpressmusic/obrazek2.jpg","http://obchod.cz/mobily/nokia-5800-xpressmusic/obrazek2.jpg"
								},
								VideoUrl = "http://www.youtube.com/watch?v=KjR759oWF7w",
								PriceWithVAT = "6000",
								HeurekaCPC = "5,1",
								CategoryText = "Elektronika | Mobilní telefony",
								EAN = "6417182041488",
								ProductNo = "RM-559394",
								ParameterList = new List<Domain.Heureka.Param>()
								{
									new Domain.Heureka.Param() { Name = "Barva" , Value = "Černá"}
								},
								 DeliveryDate = "2",
								 Deliveries = new List<Domain.Heureka.Delivery>()
								 {
									 new Domain.Heureka.Delivery() { Id="CESKA_POSTA" ,Price = 120 , PriceWithDelivery = 120}
								 },
								 ItemGroup = "EF789",
								 Accessory = "CD456",
								 Gift = "Pouzdro zdarma"

							}
							.SetProductName("Nokia 5800 XpressMusic")
							.SetProduct("Nokia 5800 XpressMusic")
							.SetDescription("Klasický s plným dotykovým uživatelským rozhraním")
							.SetManufacturer("NOKIA")

						}
			};
		}


	}
}
