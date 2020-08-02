using DemoArchitecture.DL.Database;
using DemoArchitecture.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoArchitecture.DL.Repository
{
	public class EmailRepsitory : BaseRepository<Email>
	{
		public EmailRepsitory(IDbContext<Email> dbContext) : base(dbContext)
		{
		}
	}
}
