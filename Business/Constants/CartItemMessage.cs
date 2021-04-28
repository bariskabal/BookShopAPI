using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class CartItemMessage
    {
        public static string CartItemUpdated { get; internal set; }
        public static string CartItemAdded { get; internal set; }
        public static string CartItemDeleted { get; internal set; }
        public static string CartItemsListed { get; internal set; }
    }
}
