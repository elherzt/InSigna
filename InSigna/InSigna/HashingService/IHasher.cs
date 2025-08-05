using InSigna.Common;
using InSigna.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSigna.HashingService
{
    public interface IHasher
    {
        InSignaResponse HashPassword(string password);
        InSignaResponse VerifyPassword(string hashedPassword, string providedPassword);
    }

    public class PasswordHasherService : IHasher
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<object>();
        }

        public InSignaResponse HashPassword(string password)
        {
            InSignaResponse response = new InSignaResponse(TypeOfResponse.OK, "Password hashed successfully");
            try { 
                if (string.IsNullOrEmpty(password))
                {
                    response.TypeOfResponse = TypeOfResponse.FailedResponse;
                    response.Message = "Password cannot be null or empty.";
                    return response;
                }

                // Validate password strength
                InSignaResponse strengthResponse = ValidateStrength(password);
                if (strengthResponse.TypeOfResponse != TypeOfResponse.OK)
                {
                    return strengthResponse;
                }


                var hashedPassword = _passwordHasher.HashPassword(null, password);
                response.Data = hashedPassword;

            }
            catch (Exception ex)
            {
                response.TypeOfResponse = TypeOfResponse.Exception;
                response.Message = ex.Message;
            }
            return response;
        }

        private InSignaResponse ValidateStrength(string password)
        {
            InSignaResponse response = new InSignaResponse(TypeOfResponse.OK, "Password meets strength requirements");
            // Example criteria: at least 8 characters, at least one uppercase letter, one lowercase letter, implement your own criteria here

            try
            {
                if (password.Length < 8 ||
                   !password.Any(char.IsUpper) ||
                   !password.Any(char.IsLower)
                )
                {
                    response.TypeOfResponse = TypeOfResponse.FailedResponse;
                    response.Message = "Password must be at least 8 characters long and include uppercase and lowercase.";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.TypeOfResponse = TypeOfResponse.Exception;
                response.Message = ex.Message;
                return response;
            }

           

            return response;
        }

        public InSignaResponse VerifyPassword(string hashedPassword, string providedPassword)
        {
            //verify the password
            InSignaResponse response = new InSignaResponse(TypeOfResponse.OK, "Passwords match");
            try
            {
                var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);

                if (result == PasswordVerificationResult.Success)
                {
                    response.TypeOfResponse = TypeOfResponse.OK;
                    response.Message = "Passwords match";
                }
                else 
                {
                    response.TypeOfResponse = TypeOfResponse.FailedResponse;
                    response.Message = "Passwords doesn't match";
                }
            }
            catch (Exception ex)
            {
                response.TypeOfResponse = TypeOfResponse.Exception;
                response.Message = ex.Message;
            }
            
            return response;

        }
    }
}
