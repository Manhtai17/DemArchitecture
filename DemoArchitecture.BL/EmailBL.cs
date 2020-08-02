using DemoArchitecture.DL.Repository;
using DemoArchitecture.Entity.Entities;

namespace DemoArchitecture.BL
{
	public class EmailBL : BaseBL<Email>
	{
		public EmailBL(IRepository<Email> repository) : base(repository)
		{

		}
		

	}
}
