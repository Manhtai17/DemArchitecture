using System;
using System.Collections.Generic;
using System.Text;

namespace DemoArchitecture.Entity.Entities
{
	public class BaseEntity
	{
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
