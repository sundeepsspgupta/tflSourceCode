using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL.Domain
{
    /// <summary>
    ///  This class used to print formatted message on console with return response code.
    /// </summary>
    public class TFLResponse
    {
        public string ResponseMessage { get; set; }
        public int ResponseCode { get; set; }
    }
}
