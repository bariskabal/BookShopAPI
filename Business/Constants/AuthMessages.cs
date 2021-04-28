using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class AuthMessages
    {
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string PasswordError = "şifre hatalı";
        public static string SuccessfulLogin { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
        public static string CurrentPasswordIsWrong = "Current password is wrong";
        public static string PasswordUpdated = "Password updated";
    }
}
