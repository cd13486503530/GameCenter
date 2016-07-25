using AutoMapper;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using NeedIndex.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class AdminUserService
    {
        public static DtoAdminUser GetUserAndPassWord()
        {
            using (var db = new PortalContext())
            {
                var info = db.AdminUsers.FirstOrDefault();
                return Mapper.Map<DtoAdminUser>(info);
            }
        }
        public static AdminUser GetAdminUser(DtoAdminUser dAdminUser)
        {
            var passWord = dAdminUser.PassWord.MD5Encrypt();
            using (var db = new PortalContext())
            {
                var info = db.AdminUsers.FirstOrDefault(a => a.UserName == dAdminUser.UserName && a.Password == passWord);
                return Mapper.Map<AdminUser>(info);
            }
        }
        public static bool AdminLogin(DtoAdminUser dAdminUser, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(dAdminUser.UserName))
            {
                msg = "用户名不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(dAdminUser.PassWord))
            {
                msg = "密码不能为空";
                return false;
            }
            var info = GetAdminUser(dAdminUser);
            if (info == null)
            {
                msg = "用户名或密码错误";
                return false;
            }
            return true;
        }

        public static bool UpdatePassWord(DtoAdminUser dAdminUser, out string msg)
        {
            msg = string.Empty;
            var info = GetAdminUser(dAdminUser);
            if (info == null)
            {
                msg = "输入的原始密码不正确";
                return false;
            }
            if (string.IsNullOrEmpty(dAdminUser.NewPassWord))
            {
                msg = "新密码不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(dAdminUser.ConfirmPassword))
            {
                msg = "确认密码不能为空";
                return false;
            }
            if (dAdminUser.NewPassWord != dAdminUser.ConfirmPassword)
            {
                msg = "新密码和确认密码不相等,请重新输入";
                return false;
            }

            using (var db = new PortalContext())
            {
                try
                {
                    var admin = Mapper.Map<AdminUser>(dAdminUser);
                    admin.Password = dAdminUser.NewPassWord.MD5Encrypt();
                    db.Set<AdminUser>().Attach(admin);
                    db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch(DbEntityValidationException e)
                {
                    msg = e.ToString();
                    return false;
                } 
            } 
        }
    }
}
