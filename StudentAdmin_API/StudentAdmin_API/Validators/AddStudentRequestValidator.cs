using FluentValidation;
using StudentAdmin_API.DomainModels;
using StudentAdmin_API.Repository;

namespace StudentAdmin_API.Validators
{
    public class AddStudentRequestValidator:AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator(IStudentRepository studentRepository) {
            RuleFor(x =>x.firstName).NotEmpty();
            RuleFor(x => x.lastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x =>x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.mobile).GreaterThan(99999).LessThan(1000000000);
            RuleFor(x => x.GenderId).Must(id =>
            {
                var gender = studentRepository.GetGendersAsync().Result.
                ToList().FirstOrDefault();
                if (gender != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Please select a valid gender");
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();

        }
    }
}
