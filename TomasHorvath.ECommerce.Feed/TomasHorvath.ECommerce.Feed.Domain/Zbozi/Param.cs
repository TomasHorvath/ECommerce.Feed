using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TomasHorvath.ECommerce.Feed.Domain.Zbozi
{
	[XmlRoot("PARAM")]
	public class Param
	{
		[XmlElement("PARAM_NAME")]
		public string Name { get; set; }
		[XmlElement("VAL")]
		public string Value { get; set; }
		[XmlElement("UNIT")]
		public string Unit { get; set; }
	}
}
