namespace SharedTrip.Services
{
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUserRegister(RegisterUserFormModel model);
        
        ICollection<string> ValidateUserLogin(LoginUserFormModel model, string id);

        ICollection<string> ValidateTrip(CreateTripFormModel model);
    }
}