using CollegeAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CollegeAPI.helpers
{
    // Este helper nos ayuda a generar token cuando se inicie session de un usuario.
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid id)
        {
            // tenemos que penar si nuestrousuario va a tenr roles 
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MM ddd yyyy HH:mm:ss tt")),

            };

            if(userAccounts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            } else if (userAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;

        }
        
        public static IEnumerable<Claim> GetClaims (this UserTokens userAccoutn, out Guid Id)
        {
            Id = Guid.NewGuid(); // generamos nuevo id
            return GetClaims(userAccoutn, out Id); // retornamos en nuevo id generado.

        }

        public static UserTokens GeneateTokenKey (UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if ( model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                //obtain secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id;
                // Expira en un dia
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validacin del token
                userToken.Validity = expireTime.TimeOfDay; // esta es la valides

                // Generar el json web token
                var jwtToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime, // este el tiempo de espiracion que no puede estar aun moemnto concreto
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256)
                    );


                // 
                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;

                return userToken; // devolvemos el token

            } catch(Exception e)
            {
                throw new Exception("Error al generar el token the JWT" + e.Message);
            }
        }
    }
}
