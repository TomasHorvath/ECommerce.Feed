using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TomasHorvath.ECommerce.Feed.Domain.Zbozi
{
	/// <summary>
	/// Uvádějte s parametrem xmlns="http://www.zbozi.cz/ns/offer/1.0", který značí že jde o feed vytvořený podle aktuální specifikace.
	/// </summary>
	[XmlRoot("SHOP", Namespace = "http://www.zbozi.cz/ns/offer/1.0")]
	public class Shop
	{
		[XmlElement("SHOPITEM")]
		public List<ShopItem> ShoptItems { get; set; }
	}
}
