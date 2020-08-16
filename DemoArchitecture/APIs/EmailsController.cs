using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.Controllers;
using DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoArchitecture.APIs
{
	public class EmailsController : BaseController<Email>
	{
		public EmailsController(IBaseBL<Email> emp) : base(emp)
		{

		}





		[HttpPost]
		[Route("send")]

		public IActionResult SendMail([FromBody]Email email)
		{
			try
			{
				email.EmailId = Guid.NewGuid().ToString();
				if (email.Recipients == null)
				{
					return BadRequest();
				}

				if (!ValidateEmail(email.Recipients))
				{
					return BadRequest();
				}

				//foreach (var mail in email.Recipients)
				//{
				//	if (!ValidateEmail(mail))
				//	{
				//		return BadRequest();
				//	}
				//}


				return Ok(email);
			}
			catch (Exception ex)
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
			}
			catch (Exception ex)
			{
				return false;
			}

		}
	}
}
