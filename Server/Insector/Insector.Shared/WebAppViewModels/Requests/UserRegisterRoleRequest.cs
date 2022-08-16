﻿using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public class UserRegisterRoleRequest : BaseRequestModel
    {
        [Required]
        public int Id { get; set; }
    }
}