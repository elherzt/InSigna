using InSigna.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using InSigna.Enums;

namespace InSigna.JWTSevrice
{
    public interface IJWTGenerator
    {
        InSignaResponse GenerateToken(BasicSessionModel model);
    }

    public class JWTGenerator : IJWTGenerator
    {
        private readonly JWTSettings _jwtconfig;

        public JWTGenerator(IOptions<JWTSettings> jwtConfig)
        {
            _jwtconfig = jwtConfig.Value ?? throw new ArgumentNullException(nameof(jwtConfig));
        }

        public InSignaResponse GenerateToken(BasicSessionModel model)
        {
            InSignaResponse response = new InSignaResponse(TypeOfResponse.OK, "Token was created successfully");
            try {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtconfig.SecretKey);
                var now = DateTime.UtcNow;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, model.Name),
                    new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
                    new Claim(ClaimTypes.Role, model.Role),
                    new Claim("Provider", model.Provider)
                    }),
                    NotBefore = now,
                    Expires = DateTime.UtcNow.AddMinutes(_jwtconfig.ExpirationMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _jwtconfig.Issuer,
                    Audience = _jwtconfig.Audience
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Data =  tokenHandler.WriteToken(token);
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
