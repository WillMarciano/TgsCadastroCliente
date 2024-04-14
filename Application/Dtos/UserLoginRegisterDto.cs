﻿using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UserLoginRegisterDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
            ErrorMessage = "A senha deve ter no minimo 6 caracteres, 1 letra maiuscula, 1 letra minuscula, 1 numero e 1 caracter especial")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
        public required string ConfirmPassword { get; set; }
    }
}