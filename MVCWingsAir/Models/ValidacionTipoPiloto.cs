using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWingsAir.Models {
	[MetadataType( typeof( TipoPilotoMetaData ) )]
	public partial class TipoPiloto {
	}
	public partial class TipoPilotoMetaData {

		public int IdTipoPiloto { get; set; }

		[DisplayName( "Tipo de Piloto" )]
		[Required( ErrorMessage = "El tipo de Piloto es necesario" )]
		[RegularExpression( @"^[A-Z]{2}\-[0-9]{4}$", ErrorMessage = "El tipo de piloto debe de llevar el formato ej: PA-0000" )]
		public string Tipo { get; set; }
	}
}