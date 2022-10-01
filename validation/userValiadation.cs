using Api.Models;
using FastEndpoints;
using FluentValidation;

public class UserValidation: Validator<UserRequest>{

    public UserValidation(){
        RuleFor(x=>x.name).NotEmpty();
        RuleFor(x=>x.password).NotEmpty().NotNull().MinimumLength(4);
        RuleFor(x=>x.email).NotEmpty().NotNull().EmailAddress();
    }

}