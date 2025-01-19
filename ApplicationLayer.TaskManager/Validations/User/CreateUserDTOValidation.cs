using ApplicationLayer.TaskManager.DTOs.UserDTOs;

using FluentValidation;


namespace ApplicationLayer.TaskManager.Validations.User
{
    public class CreateUserDTOValidation : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidation()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("The field UserName cannot be empty")
                .MaximumLength(200).WithMessage("The maximum size is 200 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The field Email cannot be empty")
                .EmailAddress().WithMessage("The Email is not valid");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("The field Password is required")
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]).{8,}$").WithMessage("The password must be : min 8 characters, 1 special character, 1 upper character");
        }
    }
}
