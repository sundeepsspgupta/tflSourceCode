using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFL.Domain;

namespace TFL.Service.Interface
{
    public interface ITFLService
    {
        public Task<TFLResponse> InvokeTFLApi(string roadCode);
    }
}
