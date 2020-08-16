using DemoArchitecture.DL.Database;
using DemoArchitecture.Entity.Entities;

namespace DemoArchitecture.DL.Repository
{
	public class EmailRepsitory : BaseRepository<Email>
	{
		public EmailRepsitory(IDbContext<Email> dbContext) : base(dbContext)
		{
		}
	}
}
