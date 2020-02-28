﻿using System.ComponentModel.DataAnnotations;

namespace ComputerBuilder.BL.Model.Authorization
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
