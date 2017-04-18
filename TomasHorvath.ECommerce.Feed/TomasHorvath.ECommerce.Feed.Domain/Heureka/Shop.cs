using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TomasHorvath.ECommerce.Feed.Domain.Heureka
{
	/// <summary>
	/// Kořenový element, v souboru je obsažen pouze jednou.
	/// </summary>
	[XmlRoot("SHOP", Namespace = "")]
	public class Shop
	{
		[XmlElement("SHOPITEM")]
		public List<ShopItem> ShoptItems { get; set; }
	}
}
