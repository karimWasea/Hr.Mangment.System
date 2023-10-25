// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

using DataAcess.layes;

using HR.Utailites;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

using SystemEnums;

namespace Hr.Mangment.System.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Applicaionuser> _signInManager;
        private readonly UserManager<Applicaionuser> _userManager;
        private readonly IUserStore<Applicaionuser> _userStore;
        private readonly IUserEmailStore<Applicaionuser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDBcontext _ApplicationDBcontext;
        private readonly Imgoperation _imgoperation;

        public RegisterModel(
            UserManager<Applicaionuser> userManager,
            IUserStore<Applicaionuser> userStore,
            SignInManager<Applicaionuser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ApplicationDBcontext ApplicationDBcontext, Imgoperation imgoperation)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _ApplicationDBcontext = ApplicationDBcontext;
            _imgoperation = imgoperation;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            [Display(Name = "Profile Image")]
            public string? ImgUrl { get; set; } = string.Empty;

            [Display(Name = "Profile Image")]
            [DataType(DataType.Upload)]
            public IFormFile Impath { get; set; }

            [Display(Name = "Contract URL")]
            [DataType(DataType.Upload)]
            public IFormFile ContrutruelPath { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Birth Date")]
            public DateTime? BirthDate { get; set; }

            [Display(Name = "Address")]
            public string? Adress { get; set; } = string.Empty;

            [Display(Name = "Salary")]
            [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid salary.")]
            public double? Salary { get; set; }

            [Display(Name = "Phone Number")]
            [Phone(ErrorMessage = "Please enter a valid phone number.")]
            public string pHoneNumber { get; set; }

            [Required]
            [Display(Name = "Username")]
            public string USERname { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Display(Name = "Is Deleted")]
            public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

            [Display(Name = "Department")]
            public int? DepartmentId { get; set; }

            [Display(Name = "Bonus")]
            [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid bonus.")]
            public double? Bouns { get; set; }

            [Display(Name = "Job Title")]
            public string? JobTitle { get; set; }

            [Display(Name = "Contract URL")]
            public string? ContructUrl { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Hiring Date")]
            public DateTime? HirangDate { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            // Fetch department options and store them in ViewData
            var departmentOptions = _ApplicationDBcontext.Departments
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.DepartmentName })
                .ToList();

            ViewData["DepartmentOptions"] = departmentOptions;
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.Adress = Input.Adress;
                user.Email = Input.Email;
                user.HirangDate = Input.HirangDate;
                user.BirthDate = Input.BirthDate;
                user.PhoneNumber = Input.pHoneNumber;
                user.Salary = Input.Salary;
                user.DepartmentId = Input.DepartmentId;
                user.Gender = Input.Gender;
                user.ContructUrl = _imgoperation. SaveImage(Input.ContrutruelPath);
                user.ImgUrl = _imgoperation.SaveImage(Input.Impath);

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    

                            await _userManager.AddToRoleAsync(user, SystemRols.SuperAdmin);
                    await _userManager.GetUserIdAsync(user);

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private Applicaionuser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Applicaionuser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Applicaionuser)}'. " +
                    $"Ensure that '{nameof(Applicaionuser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Applicaionuser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Applicaionuser>)_userStore;
        }
    }
}
