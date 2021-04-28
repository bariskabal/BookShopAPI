using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class CreditCardMessage
    {
        public static string CreditCardAdded { get; internal set; }
        public static string CreditCardDeleted { get; internal set; }
        public static string CreditCardListed { get; internal set; }
        public static string CreditCardUpdated { get; internal set; }
    }
}
