using System.Collections.Generic;
using System.Xml.Serialization;

namespace TomasHorvath.ECommerce.Feed.Domain.Zbozi
{
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

		#region GET/SET Methods 
		
		public void SetProductName(string productName)
		{
			this._productName = productName;
		}

		public void SetProduct(string product)
		{
			this._product = product;
		}

		public void SetDescription(string description)
		{
			this._description = description;
		}

		public void SetManufacturer(string mafucturer)
		{
			this._manufacturer = mafucturer;
		}

		#endregion

		#region Mandatory ATTRIBUTES 

		/// <summary>
		///povinné, doporučená délka 70 znaků
		///Obecné pojmenování výrobku z pohledu spotřebitele bez rozšiřujících údajů eshopu.Musí obsahovat všechny potřebné údaje tak, aby byla nabídka pomocí názvu odlišitelná od ostatních nabídek v XML feedu, a řídí se jednotnou šablonou rozlišenou pro různé kategorie produktů(vizte Pravidla pojmenování nabídek). Základní šablona platná pro většinu kategorií je
		///Výrobce(Produktová řada) Produktové označení Varianta
		///Do názvu uveďte skutečného výrobce dílu, nikoli značku, se kterou jsou vaše produkty kompatibilní.Informace o kompatibilitě s určitými značkami můžete uvést do atributu ‘popis’ [description].
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
		/// povinné (doporučená délka 250-1000 znaků)
		///	Textový popis jednotlivé nabídky ve formátu čistého textu s odřádkováním odstavců.Musí obsahovat výhradně informace o výrobku v českém jazyce.Začátek popisu by měl v několika větách obsahovat hlavní výhody daného produktu.Popis nesmí obsahovat:
		/// reklamní texty a slogany týkající se internetového obchodu
		/// nadměrně se opakující klíčová slova nebo fráze (dvakrát či vícekrát za sebou)
		/// V popisku není žádoucí opakovat název výrobce, modelové označení výrobku.Nevkládejte zde také informace týkající se dárků a dodání, pro ně je určena značka EXTRA_MESSAGE.Není povolena nadměrná interpunkce, použití emotikonů nebo ukončení věty třemi tečkami.Za tečkami a čárkami musí být mezery, jak je běžné v českých textech.
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
		///	povinné
		///URL adresa, která odkazuje na stránku nabídky v eshopu.
		///URL nesmí obsahovat znaky české diakritiky, mezery a jiné nestandardní znaky.
		/// </summary>
		[XmlElement("URL")]
		public string Url { get; set; }

		/// <summary>
		/// povinné (celé číslo nebo datum ve formátu RRRR-MM-DD)
		///Doba vyřízení objednávky – musí být uváděna jako doba od přijetí objednávky do expedice zboží.Číselná hodnota je systémem automaticky převáděna na textové vyjádření.
		///U předobjednávek a připravovaných produktů uvádějte datum uvedení na trh ve formátu RRRR-MM-DD.
		/// https://napoveda.seznam.cz/cz/zbozi/specifikace-xml-pro-obchody/specifikace-xml-feedu/
		/// </summary>
		[XmlElement("DELIVERY_DATE")]
		public string DeliveryDate { get; set; }

		/// <summary>
		/// povinné; číselná hodnota, max. dvě desetinná místa
		/// Konečná cena v Kč včetně DPH a poplatků.Při uvedení více desetinných míst budou přebytečná desetinná místa odříznuta.
		/// Pro oddělení řádu korun a haléřů je možné použít desetinnou čárku i tečku.
		/// </summary>
		[XmlElement("PRICE_VAT")]
		public string PriceWithVAT { get; set; }


		#endregion

		#region Recommended ATTIRIBUTES

		/// <summary>
		/// Samostatné nabídky budeme moci zařadit do výpisu příslušné kategorie pouze v případě, u nichž je uveden CATEGORYTEXT, který bude odpovídat názvu kategorií z našeho číselníku.
		/// Strojově čitelný strom kategorií Zboží.cz je průběžně aktualizovaný na adrese https://www.zbozi.cz/static/categories.json či ke stažení ve formátu pro MS Excel https://www.zbozi.cz/static/categories.csv. Do feedu je potřeba uvádět kompletní cestu kategorie ze stromu kategorií Zboží.cz. Jako oddělovač slouží svislá čára | (tzv. pipe)
		/// </summary>
		[XmlElement("CATEGORYTEXT")]
		public string CategoryText { get; set; }

		[XmlElement("PRODUCT")]

		/// <summary>
		/// výrazně doporučujeme uvádět
		/// Unikátní identifikátor(alfanumerické znaky) nabídky v rámci eshopu, typicky např.ID položky ve skladovém systému, je povolena jakákoli kombinace znaků[0 - 9, a - z, A - Z, _, -] tedy čísel nula až devět, malých a velkých písmen bez diakritiky, a také podtržítka a pomlčky.Díky této značce budete schopni vždy jednoznačně identifikovat nabídku a sledovat její historii a výkon v rámci služby Zboží.cz, i když se změní její URL či název.Proto je klíčové, aby zůstala stejná a v případě např.změny eshopového řešení
		/// </summary>
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

		[XmlElement("ITEM_ID")]
		public string Id { get; set; }


		[XmlElement("PARAM")]
		public List<Param> ParameterList { get; set; }


		[XmlElement("IMGURL")]
		public string ImageUrl { get; set; }

		/// <summary>
		/// nepovinné, doporučujeme uvádět
		///Mezinárodní číslo obchodní položky ve formátu EAN-8, UPC-12, EAN-13 a ITF-14. Akceptováno je osmi-, dvanácti-, třinácti-, nebo čtrnáctimístné číslo bez mezer.
		///Nástroj pro výpočet kontrolní číslice ve výše zmíněných typech kódů najdete na http://www.gs1cz.org/nastroje-a-pomucky/vypocet-kontrolni-cislice/.
		/// </summary>
		[XmlElement("EAN")]
		public string Ean { get; set; }

		/// <summary>
		/// nepovinné, doporučujeme uvádět
		/// Mezinárodní standardní číslo knihy ve formátu ISBN-10 nebo ISBN-13. 
		/// Akceptováno je desetimístné nebo třináctimístné číslo, buď bez mezer, nebo může být jako oddělovač skupin použita mezera či pomlčka,
		/// oddělovače však nesmějí být kombinovány.
		/// </summary>
		[XmlElement("ISBN")]
		public string ISBN { get; set; }

		/// <summary>
		/// nepovinné, doporučujeme uvádět
		/// Označení produktu uváděné výrobcem(Manufacturer Part Number, MPN). 
		/// Tímto označením výrobce jedinečným způsobem identifikuje produkt.Akceptována je libovolná kombinace čísel a písmen.
		/// </summary>
		[XmlElement("PRODUCTNO")]
		public string ProductNO { get; set; }

		[XmlElement("ITEMGROUP_ID")]
		public string ItemGroupId { get; set; }

		/// <summary>
		/// <EROTIC>1</EROTIC>
		/// </summary>
		[XmlElement("EROTIC")]
		public string Erotic { get; set; }


		/// <summary>
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


		#endregion

		#region Optional ATTRIBUTES 

		/// <summary>
		/// značka produktu
		/// </summary>
		public string BRAND { get; set; }

		/// <summary>
		/// fyzický stav nabídky
		/// </summary>
		public string ITEM_TYPE { get; set; }
		/// <summary>
		/// – doplňkové informace o nabídce
		/// </summary>
		public string EXTRA_MESSAGE { get; set; }
		/// <summary>
		///  – výdejní místo pro okamžitý odběr
		/// </summary>
		public string SHOP_DEPOTS { get; set; }
		/// <summary>
		///  – zobrazování nabídky na Zboží.cz
		/// </summary>
		public string VISIBILITY { get; set; }
		public string CUSTOM_LABEL_0 { get; set; }
		public string CUSTOM_LABEL_1 { get; set; }
		public string CUSTOM_LABEL_2 { get; set; }
		public string CUSTOM_LABEL_3 { get; set; }
		/// <summary>
		///  – maximální cena za proklik v detailu produktu
		/// </summary>
		public string MAX_CPC { get; set; }
		/// <summary>
		///  – maximální cena za proklik v nabídkách
		/// </summary>
		public string MAX_CPC_SEARCH { get; set; }
		/// <summary>
		///  – produktová řada
		/// </summary>
		public string PRODUCT_LINE { get; set; }
		/// <summary>
		/// – doporučená koncová prodejní cena
		/// </summary>
		public string LIST_PRICE { get; set; }

		/// <summary>
		/// – datum oficiálního zahájení prodeje v ČR
		/// </summary>
		public string RELEASE_DATE { get; set; } 
		#endregion
	}
}