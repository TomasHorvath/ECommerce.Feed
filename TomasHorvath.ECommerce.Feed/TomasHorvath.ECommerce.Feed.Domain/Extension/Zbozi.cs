using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.ECommerce.Feed.Domain.Zbozi;

namespace TomasHorvath.ECommerce.Feed.Domain.Extension
{

	/// <summary>
	/// Fluent API
	/// </summary>
	public static class Zbozi
	{
		public static Domain.Zbozi.ShopItem ProductName(this Domain.Zbozi.ShopItem item, string productName)
		{
			item.SetProductName(productName);
			return item;
		}

		public static Domain.Zbozi.ShopItem Product(this Domain.Zbozi.ShopItem item, string product)
		{
			item.SetProduct(product);
			return item;
		}

		public static Domain.Zbozi.ShopItem Description(this Domain.Zbozi.ShopItem item, string description)
		{
			item.SetDescription(description);
			return item;
		}

		public static Domain.Zbozi.ShopItem Manufacturer(this Domain.Zbozi.ShopItem item, string manufacturer)
		{
			item.SetManufacturer(manufacturer);
			return item;
		}

		public static Domain.Zbozi.ShopItem Url(this Domain.Zbozi.ShopItem item, string url)
		{
			item.Url = url;
			return item;
		}
		
		public static Domain.Zbozi.ShopItem DeliveryDate(this Domain.Zbozi.ShopItem item, string deliveryDate)
		{
			item.DeliveryDate = deliveryDate;
			return item;
		}

		public static Domain.Zbozi.ShopItem PriceWithVat(this Domain.Zbozi.ShopItem item, string priceWithVat)
		{
			item.PriceWithVAT = priceWithVat;
			return item;
		}


		public static Domain.Zbozi.ShopItem CategoryText(this Domain.Zbozi.ShopItem item, string categoryText)
		{
			item.CategoryText = categoryText;
			return item;
		}

		public static Domain.Zbozi.ShopItem ItemId(this Domain.Zbozi.ShopItem item, string ItemId)
		{
			item.Id  = ItemId;
			return item;
		}
	}
}
