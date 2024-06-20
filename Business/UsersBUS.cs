using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using DataAccessLayer;

namespace Business
{
    public class UsersBUS
    {
        private string secret;
        UsersDAL usersDAL = new UsersDAL();


        public int GetTotalUser()
        {
            return usersDAL.GetTotalUser();
        }
        public UsersModel getById(int id)
        {
            return usersDAL.getById(id);
        }

        public List<UsersModel> getList(int? pageIndex,int? pageSize,int role_id,out int total)
        {
            return usersDAL.getList(pageIndex, pageSize,role_id,out total);
        }

        public List<UsersModel> searchUser(int? pageIndex, int? pageSize, string value, out int total)
        {
            return usersDAL.searchUser(pageIndex, pageSize, value, out total);
        }

        public List<UsersModel> searchCustomer(int? pageIndex, int? pageSize, string value, out int total)
        {
            return usersDAL.searchCustomer(pageIndex, pageSize, value, out total);
        }

        public int Create(UsersModel model)
        {
            return usersDAL.Create(model);
        }
        public int Update(UsersModel model)
        {
            return usersDAL.Update(model);
        }
        public int Delete(int id)
        {
            return usersDAL.Delete(id);
        }

        public UsersModel Login(string uName, string PassWord)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            IConfigurationSection configuration1 = configuration.GetSection("AppSettings").GetSection("Secret");
            secret = configuration1.Value;
            // secret = configuration1.Value;
            UsersModel acc = usersDAL.Login(uName, PassWord);
            if (acc == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, acc.role_id.ToString()),
                    new Claim(ClaimTypes.Name, acc.us_name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            acc.token = tokenHandler.WriteToken(token);
            return acc;
        }
    }
}
