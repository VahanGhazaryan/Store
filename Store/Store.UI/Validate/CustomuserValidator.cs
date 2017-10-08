using Microsoft.AspNet.Identity;
using Store.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Store.UI.Validate
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(UserManager<ApplicationUser> mgr)
            : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
            RequireUniqueEmail = false; 
        }
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            var errors = result.Errors.ToList();
            if (errors.Count() > 0)
            {
                for (int i = 0; i < errors.Count(); i++)
                {
                    if (errors[i].EndsWith("is already taken."))
                    {
                        errors[i] = "Email " + user.Email + " is already taken.";
                    }
                }
                result = new IdentityResult(errors);
            }
            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                errors.Add("Данный домен находится в спам-базе. Выберите другой почтовый сервис");
                result = new IdentityResult(errors);
            }
            if (user.UserName.Contains("admin"))
            {
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}