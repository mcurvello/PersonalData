using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalData.Model.Base
{
	public class BaseEntity
	{
		[Column("id")]
		public long Id { get; set; }
	}
}
