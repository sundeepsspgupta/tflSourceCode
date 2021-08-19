using Microsoft.Extensions.Options;
using TFL.Config.Interface;

namespace TFL.Config
{
    public class ConfigDetails : ITFLEndPoint
    {
        private readonly IOptions<TFLEndPoint> _tflEndPoint;
        public ConfigDetails(IOptions<TFLEndPoint> tflEndPoint)
        {
            _tflEndPoint = tflEndPoint;
        }
        public TFLEndPoint TFLEndPoint => _tflEndPoint.Value;
    }
}
