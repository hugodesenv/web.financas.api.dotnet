using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api.aspnetcore.webfinancas.Application.UseCase.Account
{
    public interface IGenerateTokenUseCase
    {
        string Execute();
    }

    public class GenerateTokenUseCase : IGenerateTokenUseCase
    {
        public string Execute()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My_Random_k3y_here_by_hugoSouza.2025"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Hugo Souza",
                audience: "Audience HG",
                expires: DateTime.Now.AddDays(3),
                signingCredentials: creds
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
