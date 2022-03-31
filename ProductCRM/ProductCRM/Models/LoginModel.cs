﻿using System.ComponentModel.DataAnnotations;

namespace ProductCRM.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Не указан Email")]
    public string Login { get; set; }
         
    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}