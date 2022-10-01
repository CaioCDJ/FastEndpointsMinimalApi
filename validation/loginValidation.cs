using Api.Models;
using FastEndpoints;
using FluentValidation;

public class LoginValidation : Validator<LoginRequest>{

    public LoginValidation(){
        RuleFor(x=>x.email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x=>x.password).NotEmpty().NotNull().MinimumLength(5);
    }
}