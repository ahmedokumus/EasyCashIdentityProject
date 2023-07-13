using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace PresentationLayer.Controllers;

public class RegisterController : Controller
{
	private readonly UserManager<AppUser> _userManager;
	public RegisterController(UserManager<AppUser> userManager)
	{
		_userManager = userManager;
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
	{
		if (ModelState.IsValid)
        {
            Random random = new Random();
            string code = random.Next(100000, 1000000).ToString();
            AppUser appUser = new AppUser()
            {
                CustomerName = appUserRegisterDto.Name,
                CustomerSurname = appUserRegisterDto.Surname,
                UserName = appUserRegisterDto.Username,
				Email = appUserRegisterDto.Email,
				CustomerDistrict = "test",
				CustomerCity = "test",
				CustomerImageUrl = "test",
				ConfirmCode = code
			};
			var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
			if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "ahmed.aho666@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

				mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Kayıt işlemini gerçekleştirmek için onay kodunuz: {code}";
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Easy Cash Onay Kodu";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("ahmed.aho666@gmail.com", "nzewhsqmumjravvx");
                client.Send(mimeMessage);
				client.Disconnect(true);

                TempData["Mail"] = appUserRegisterDto.Email;

				return RedirectToAction("Index", "ConfirmMail");
			}
			else
			{
				foreach (var identityError in result.Errors)
				{
					ModelState.AddModelError("", identityError.Description);
				}
			}
		}

		return View();
	}
}