using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TomasHorvath.ECommerce.Feed.Domain.Heureka
{
	[XmlRoot("DELIVERY")]
	public class Delivery
	{
		[XmlElement("DELIVERY_ID")]
		public string Id { get; set; }
		[XmlElement("DELIVERY_PRICE")]
		public decimal Price { get; set; }
		[XmlElement("DELIVERY_PRICE_COD")]
		public decimal PriceWithDelivery { get; set; }
	}
}
