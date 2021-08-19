using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL.Domain
{
    public class CommonConstant
    {
        public const string INVALID_RESPONSE_MESSAGE = "{0} is not a valid road";
        public const string MORE_THAN_ONE_RESULT = "There are more than one result for provided road code";
        public const string INVALID_RESPONSE = "Invalid response from Api";
        public const string VALID_RESPONSE_MESSAGE = "The status of the {0} is as follows #NEWLINE#" + 
                    "\tRoad DisplayName is {1} #NEWLINE#"  +
                    "\tRoad Status is {2} #NEWLINE#" +
                    "\tRoad Status Description is {3} #NEWLINE#";
    }
}
