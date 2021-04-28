using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class AddressMessage
    {
        public static string AddressAdded { get; internal set; }
        public static string AddressDeleted { get; internal set; }
        public static string AddressListed { get; internal set; }
        public static string AddressUpdated { get; internal set; }
    }
}
