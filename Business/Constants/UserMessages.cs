using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class UserMessages
    {
        public static string UserAdded { get; internal set; }
        public static string UsersListed { get; internal set; }
        public static User MessageNotListed { get; internal set; }
        public static string MessageListed { get; internal set; }
        public static string UserUpdated { get; internal set; }
    }
}
