namespace SB.TechnicalChallenge.Application;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SB.TechnicalChallenge.Infrastructure;

public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public SignInCommandHandler(
    IConfiguration configuration
    )
    {
        //_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityToken:Key"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokeOptions = new JwtSecurityToken(
            issuer: _configuration["JwtSecurityToken:Issuer"],
            audience: _configuration["JwtSecurityToken:Audience"],
            claims: new List<Claim>
            {
                    new Claim("rol", "Administrador"),
                    new Claim("name", "Angel Hinostroza"),
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signinCredentials);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);


        return tokenString;
    }
}
