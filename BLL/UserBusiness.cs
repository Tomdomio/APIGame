﻿using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public partial class UserBusiness : IUserBusiness
    {
        private IUserRepository _res;
        private string Secret;

        public List<UserModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm viết ở đây
        }
        public UserBusiness(IUserRepository res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = res;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public UserModel Authenticate(string username, string password)
        {
            var user = _res.GetUser(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.hoten.ToString()),
                    new Claim(ClaimTypes.Role, user.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;

        }

        public UserModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool CreateUser(UserModel model)
        {
            return _res.CreateUser(model);
        }
        public bool Update(UserModel model)
        {
            return _res.Update(model);
        }
        public bool UpdateMoney(UserModel model)
        {
            return _res.UpdateMoney(model);
        }
        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten, taikhoan);
        }
    }

}

