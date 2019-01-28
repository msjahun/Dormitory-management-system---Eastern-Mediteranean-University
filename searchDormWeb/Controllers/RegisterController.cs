using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Dau.Core.Domain.Users;
using Dau.Services.Email;
using Dau.Services.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers
{
    //[Authorize]
    public class RegisterController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMessageQueueService _messageQueueService;
        private readonly IEventService _eventService;

        public RegisterController(UserManager<User> userManager,
          IMessageQueueService messageQueueService,
            SignInManager<User> signInManager,
            IEventService eventService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _messageQueueService = messageQueueService;
            _eventService = eventService;
            
        }
        [Route("Register/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Register/")]
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = vm.Email, Email = vm.Email ,
                    FirstName =vm.Firstname, LastName= vm.LastName,
                    CreatedOnUtc =DateTime.Now,
                    StudentNumber =vm.studentNumber,
                Active=true, LastActivityDateUtc= DateTime.Now};
                var result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    string confirmationToken = userManager.
                    GenerateEmailConfirmationTokenAsync(user).Result;

                    string confirmationLink = Url.Action("ConfirmEmail",
                      "Login", new
                      {
                          userid = user.Id,
                          token = confirmationToken
                      },
                       protocol: HttpContext.Request.Scheme);

                    //send confirmation link to email  service
                    _eventService.Trigger_NewStudent_Notification_Event(user.Id,user.StudentNumber,user.FirstName,user.LastName,user.Email,user.ParmanentAddress);
                    _eventService.Trigger_Student_EmailValidationMessage_Event(user.Email, user.FirstName, user.LastName, confirmationLink );
                    _eventService.Trigger_Student_WelcomeMessage_Event(user.Email, user.FirstName, user.LastName);
                  //  _messageQueueService.QueueVerificationEmail(confirmationLink, user.FirstName  + " " + user.LastName, user.Email);
                   
                   // await signInManager.SignInAsync(user, false);
                    return RedirectToAction( "Success", "Register");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }
            return View(vm);
        }

    
    [HttpGet]
    public IActionResult Success()
    {
        return View(true);
    }
    }

}