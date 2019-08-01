﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Users.Models;

namespace Users.Infrastructure
{
    public class CustomPasswordValidatorInh : PasswordValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
                errors.Add(new IdentityError
                {
                    Code = "passwordContainUserName",
                    Description = "Password cannot contain username"
                });

            if (password.Contains("12345"))
                errors.Add(new IdentityError
                {
                    Code = "passwordContainSequence",
                    Description = "Password cannot contain numeric sequence"
                });

            return errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}

