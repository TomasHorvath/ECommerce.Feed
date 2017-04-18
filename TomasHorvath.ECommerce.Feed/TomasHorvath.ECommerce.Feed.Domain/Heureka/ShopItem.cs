using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TomasHorvath.ECommerce.Feed.Domain.Heureka
{
	/// <summary>
	/// Element obsahuje informace o konkrétním produktu, v souboru je obsažen tolikrát, kolik máte variant produktů.
	/// </summary>
	public class ShopItem
	{
		#region private props for CDATA attributes 

		[XmlIgnore]
		private string _productName { get; set; }
		[XmlIgnore]
		private string _product { get; set; }
		[XmlIgnore]
		private string _description { get; set; }
		[XmlIgnore]
		private string _manufacturer { get; set; }

		#endregion

		#region Fluent API setting 

		public ShopItem SetProductName(string productName)
		{
			this._productName = productName;
			return this;
		}

		public ShopItem SetProduct(string product)
		{
			this._product = product;
			return this;
		}

		public ShopItem SetDescription(string description)
		{
			this._description = description;
			return this;
		}

		public ShopItem SetManufacturer(string manufacturer)
		{
			this._manufacturer = manufacturer;
			return this;
		}
		#endregion

		/// <summary>
		/// Unikátní označení produktu v rámci e-shopu. Musí zůstat unikátní navždy, díky čemuž budeme schopni jednoznačně identifikovat produkt pro službu Ověřeno zákazníky či Dostupnostní XML soubor, i když se změní URL.
		/// Kombinace maximálně 36 znaků [0-9a-zA-Z_\-] tedy čísel nula až devět, malých a velkých písmen bez diakritiky, podtržítka a pomlčky.
		/// Tag se dosud pro párování položek nevyužívá.
		///	Uvádění tohoto tagu je zároveň nezbytné pro fungování modelu Heureka Košíku.
		/// </summary>
		[XmlElement("ITEM_ID")]
		public string Id { get; set; }

		/// <summary>
		/// Přesný název produktu. Nesmí obsahovat žádné jiné informace, jako např. dárek, pouzdro či nabíječka zdarma, atd. 
		/// Hodnota musí být obsažena také v tagu PRODUCT, jinak nebude brána v potaz.
		/// Pokud názvy produktů nebudou obsahovat produktové číslo, hrozí, že nedokážeme produkty správně identifikovat a tudíž spárovat.
		/// Maximální délka názvu produktu je 255 znaků.
		/// </summary>
		[XmlElement("PRODUCTNAME")]
		public System.Xml.XmlCDataSection ProductName
		{
			get
			{
				return new System.Xml.XmlDocument().CreateCDataSection(_productName);
			}
			set
			{
				_productName = value.Value;
			}
		}

		/// <summary>
		/// Obsahuje PRODUCTNAME + informaci navíc. Tento název bude zobrazen v porovnání cen. Např. „Whirlpool WBA 43983 NFC IX – 5 let rozšířená záruka“. 
		/// Maximální délka názvu produktu je 255 znaků pro zobrazení ve fulltextovém vyhledávání.
		/// Na detailu produktu v katalogu Heureky se zobrazuje pouze 200 znaků.
		/// </summary>
		[XmlElement("PRODUCT")]
		public System.Xml.XmlCDataSection Product
		{
			get
			{
				return new System.Xml.XmlDocument().CreateCDataSection(_product);
			}
			set
			{
				_product = value.Value;
			}
		}

		/// <summary>
		/// Popis produktu, snažte se uvádět co nejrelevantnější popis, ve fulltextovém vyhledávání se bere v potaz. 
		/// Měl by obsahovat popis a specifikaci výrobku bez reklamy na dopravu zdarma, akce a daný obchod. 
		/// Není povolena nadměrná interpunkce. Počet znaků v tagu DESCRIPTION není omezen, avšak ve fulltextu zobrazujeme pouze 200 znaků.
		/// </summary>
		[XmlElement("DESCRIPTION")]
		public System.Xml.XmlCDataSection Description
		{
			get
			{
				return new System.Xml.XmlDocument().CreateCDataSection(_description);
			}
			set
			{
				_description = value.Value;
			}
		}

		/// <summary>
		/// Odkaz na stránku s nabídkou daného výrobku v obchodě. Na této stránce musí být uvedena cena produktu a možnost vložit do košíku. Adresa musí být unikátní v rámci celého feedu.
		/// </summary>
		[XmlElement("URL")]
		public string Url { get; set; }

		/// <summary>
		/// Adresa obrázku nesmí obsahovat mezery či diakritiku. Maximální délka URL adresy obrázku je 255 znaků.
		/// Pokud máte pro více produktů jeden obrázek, použijte vždy jednu a tu samou adresu (adresa nemusí být jedinečná v rámci feedu).
		/// Dále by obrázek neměl mít průhledné pozadí. Při změně obrázku na stránkách obchodu je třeba změnit též url adresu obrázku v XML souboru. 
		/// Minimální potřebná velikost obrázku je 20x50 nebo 50x20 pixelů, avšak aby byl obrázek kvalitní, je třeba, 
		/// aby měl alespoň 30 000 pixelů (cca 175x175 pixelů). Maximální velikost obrázků je rozlišení 4096 x 4096 pixelů a datově max. 2000 KB (2MB)
		/// </summary>
		[XmlElement("IMGURL")]
		public string ImageUrl { get; set; }

		/// <summary>
		/// Odkaz na další obrázek výrobku, například pohled z jiného úhlu, přehled celého balení, apod. Lze uvést vícekrát.
		/// </summary>
		[XmlElement("IMGURL_ALTERNATIVE")]
		public List<string> ImageUrlAlternative { get; set; }

		/// <summary>
		/// Odkaz na videorecenzi produktu. Lze uvádět pouze odkazy na videa umístěná na serveru www.youtube.com.
		/// </summary>
		[XmlElement("VIDEO_URL")]
		public string VideoUrl { get; set; }

		/// <summary>
		/// Koncová cena produktu s DPH, v ceně musí být uvedeny autorské a recyklační poplatky.
		/// Nepoužívejte jako oddělovač tisíců/miliónů tečku ('.'), ta je použita k oddělování desetinných míst. 
		/// Cenu uvádějte maximálně na 2 desetinná místa.
		/// </summary>
		[XmlElement("PRICE_VAT")]
		public string PriceWithVAT { get; set; }

		/// <summary>
		/// Tagem nastavujete maximální cenu, kterou jste ochotni za proklik nabídnout. Desetinná místa oddělujte desetinnou čárkou.
		/// Maximální cena za klik je 100 Kč.
		/// Pokud nechcete bidovat, ponechte tag prázný nebo jej vůbec neuvádějte. Nepište prosím číslo 0.
		/// </summary>
		[XmlElement("HEUREKA_CPC")]
		public string HeurekaCPC { get; set; }

		/// <summary>
		/// Obsahuje název výrobce produktu, využívá se pro zařazení pod filtrovací parametr, nikoli pro párování položek.
		/// Výrobce tedy musí být obsažen taktéž i v tagu PRODUCTNAME. Pokud je produkt prodáván pod jinou značkou,
		/// která se neshoduje s výrobcem a uživatelé podle ní produkt vyhledávají – udejte značku.Např.u pracího prášku Palmex je výrobcem Henkel. 
		/// Do tagu Manufacturer uveďte Palmex.
		/// </summary>
		[XmlElement("MANUFACTURER")]
		public System.Xml.XmlCDataSection Manufacturer
		{
			get
			{
				return new System.Xml.XmlDocument().CreateCDataSection(_manufacturer);
			}
			set
			{
				_manufacturer = value.Value;
			}
		}

		/// <summary>
		/// Zařazení produktu do kategorie, uvádějte vždy celou cestu k produktu, 
		/// tak jak to máte na vašem eshopu (stačí nám tedy vaše kategorie) pokud jasně určují druh produktu. 
		/// Případně využijte náš strom aktivních kategorií http://www.heureka.cz/direct/xml-export/shops/heureka-sekce.xml
		/// </summary>
		[XmlElement("CATEGORYTEXT")]
		public string CategoryText { get; set; }

		[XmlElement("PARAM")]
		public List<Param> ParameterList { get; set; }

		[XmlElement("DELIVERY")]
		public List<Delivery> Deliveries { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[XmlElement("EAN")]
		public string EAN { get; set; }
		[XmlElement("PRODUCTNO")]
		public string ProductNo { get; set; }
		[XmlElement("DELIVERY_DATE")]
		public string DeliveryDate { get; set; }
		[XmlElement("ITEMGROUP_ID")]
		public string ItemGroup { get; set; }
		[XmlElement("ACCESSORY")]
		public string Accessory { get; set; }
		[XmlElement("GIFT")]
		public string Gift { get; set; }
	}
}
