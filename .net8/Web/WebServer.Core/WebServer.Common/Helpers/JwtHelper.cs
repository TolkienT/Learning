using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Common.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetToken(string userName, string nickName)
        {
            string keyStr = AppSettingHelper.GetApp(new string[] { "Authorization", "Jwt", "Key" });
            int expiresTime = int.Parse(AppSettingHelper.GetApp(new string[] { "Authorization", "Jwt", "ExpiresTime" }));
            var now = DateTime.Now;
            DateTime expirationTime = now.AddSeconds(expiresTime);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr)); // 获取密钥
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //凭证 ，根据密钥生成

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.GivenName,nickName),
                new Claim(ClaimTypes.Expiration, expirationTime.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            /*
             * iss (issuer)：签发人
             * exp (expiration time)：过期时间
             * sub (subject)：主题
             * aud (audience)：受众
             * nbf (Not Before)：生效时间
             * iat (Issued At)：签发时间
             * jti (JWT ID)：编号
             */
            var jwt = new JwtSecurityToken(
                issuer: "test",
                audience: "test",
                claims: claims,
                notBefore: now,
                expires: expirationTime,
                signingCredentials: creds
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;

        }

        public static void GetUserInfo(string token)
        {
            string[] jwt = token.Split(' ');
            var tokenObj = new JwtSecurityToken(jwt[1]);
            var claimsIdentity = new ClaimsIdentity(tokenObj.Claims);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (claim is null || string.IsNullOrEmpty(claim.Value))
            {

            }
            else
            {
                string userName = claim.Value;
            }
        }


    }
}
