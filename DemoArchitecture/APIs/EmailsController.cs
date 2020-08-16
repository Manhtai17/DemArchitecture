using Confluent.Kafka;
using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.Common.Kafka;
using DemoArchitecture.Controllers;
using DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DemoArchitecture.APIs
{
	public class EmailsController : BaseController<Email>
	{
		private readonly ProducerConfig _producerConfig;
		public EmailsController(IBaseBL<Email> emp, ProducerConfig producerConfig) : base(emp)
		{
			_producerConfig = producerConfig;
		}





		[HttpPost]
		[Route("send")]

		public async Task<IActionResult> SendMail([FromBody]Email email)
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
				using (var producer = new ProducerWrapper<Null,string>(_producerConfig,email.Topic))
				{
					 await producer.SendMessage(email.ToString());
				}
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
