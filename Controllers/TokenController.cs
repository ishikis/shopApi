using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace shopApi.Controllers
{

    class tokenClass
    {
        public bool success { get; set; }
        public string token { get; set; }
    }

    [Route("api/[controller]")]
    [AllowAnonymous()]
    public class TokenController : ControllerBase
    {

        public IActionResult Get([FromBody]UserInfo user)
        {
            Console.WriteLine("User name:{0}", user.username);
            Console.WriteLine("Password:{0}", user.password);
            if (IsValidUserAndPassword(user.username, user.password))
            {
                string token = GenerateToken(user.username);

                return new ObjectResult(new tokenClass() { success = true, token = token });
            }
            return Unauthorized();//new ObjectResult(new tokenClass() { success = false, token = "" });

        }

        private string GenerateToken(string userName)
        {
            var someClaims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                new Claim(JwtRegisteredClaimNames.Email,"kuthaygumus@silverlab.com"),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu_benim_muhtesem_uzunluktaki_muhtesem_saklanmis_guvelik_keyim"));
            var token = new JwtSecurityToken(
                issuer: "kuthay-gumus.silverlab.com",
                audience: "kuthaygumus.silverlab.com",
                claims: someClaims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValidUserAndPassword(string userName, string password)
        {
            if (userName == "admin" && password == "admin")
                return true;
            else
                return false;
        }
    }

    public class UserInfo
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}