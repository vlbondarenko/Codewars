using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Users.Models;

namespace Users.Infrastructure
{
    public class CustomUserValidatorInh : UserValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            if (!user.Email.ToLower().EndsWith("@example.com"))
                errors.Add(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "only @example.com email addresses are allowed"
                });
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}

