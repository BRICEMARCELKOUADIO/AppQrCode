using System;
using System.Collections.Generic;
using System.Text;

namespace AppQrCode.Models
{
    public class PreserveAttribute : System.Attribute
    {
        public bool AllMembers;
        public bool Conditional;
    }
}
