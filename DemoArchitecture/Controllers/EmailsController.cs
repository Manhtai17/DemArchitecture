using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.DL.Database;
using DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DemoArchitecture.Controllers
{
	public class EmailsController : BaseController<Email>
	{
		public EmailsController(IBaseBL<Email> emp ) : base(emp)
		{

		}

		[HttpPost]
		[Route("send")]

		public IActionResult  SendMail([FromBody]Email email)
		{
			try
			{
				email.EmailId = Guid.NewGuid().ToString();
				foreach(var mail in email.Recipients)
				{
					if (!ValidateEmail(mail))
					{
						return BadRequest();
					}
				}
				
				return Ok(email);
			}
			catch(Exception ex)
			{
				return BadRequest(ex);
			}
		}

		public bool ValidateEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}catch(Exception ex)
			{
				return false;
			}
			
		}
	}
}
