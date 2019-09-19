using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWingsAir.Models {
	[MetadataType( typeof( TipoavionMetaData ) )]
	public partial class TipoAvion {
	}
	public class TipoavionMetaData {

		public int IdTipoAvion { get; set; }

		[DisplayName( "Tipo de Avión" )]
		[Required( ErrorMessage = "El campo Nombre es requerido" )]
		[RegularExpression( @"^[\w]{6}\-[0-9]{3}$", ErrorMessage = "Por Ejemplo: BOEING-000" )]
		public string Nombre { get; set; }
	}
}