﻿using Suls.ViewModels.Problems;
using Suls.ViewModels.Users;
using System.Collections.Generic;

namespace Suls.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);
        ICollection<string> ValidateProblem(CreateProblemViewModel model);
    }
}
