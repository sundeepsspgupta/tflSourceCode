using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TFL.Config.Interface;
using TFL.Domain;
using TFL.Service.Interface;

namespace TFL.Service
{
   
    public class TFLService:ITFLService
    {
        private readonly ITFLEndPoint _tFLEndPoint;
        public TFLService(ITFLEndPoint tFLEndPoint)
        {
            _tFLEndPoint = tFLEndPoint;
        }

        public async Task<TFLResponse> InvokeTFLApi(string roadCode)
        {
            TFLResponse tFLResponse = new TFLResponse();
           
            // Create HTTPClient object
            using var client = new HttpClient();

            // Set BaseURL of TFL Api that set on AppSetting.json 
            client.BaseAddress = new Uri(_tFLEndPoint.TFLEndPoint.TFLBaseURL);

            // Set request Header to make Api call 
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Invoke TFL Api. 
            HttpResponseMessage response = await client.GetAsync(_tFLEndPoint.TFLEndPoint.GetAipEndPointPath(roadCode));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<RoadCorridor> roadCorridor = JsonConvert.DeserializeObject<List<RoadCorridor>>(response.Content.ReadAsStringAsync().Result);
                if(roadCorridor.Count> 0)
                {
                    tFLResponse.ResponseMessage = string.Format(CommonConstant.VALID_RESPONSE_MESSAGE.Replace("#NEWLINE#", Environment.NewLine),
                        roadCode,
                        roadCorridor[0].displayName,
                        roadCorridor[0].statusseverity, roadCorridor[0].statusSeverityDescription);
                    tFLResponse.ResponseCode = 0;
                }
                else
                {
                    tFLResponse.ResponseMessage = CommonConstant.MORE_THAN_ONE_RESULT;
                    tFLResponse.ResponseCode = 1;
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                tFLResponse.ResponseMessage = string.Format(CommonConstant.INVALID_RESPONSE_MESSAGE,roadCode);
                tFLResponse.ResponseCode = 1;
            }
            else
            {
                tFLResponse.ResponseMessage = CommonConstant.INVALID_RESPONSE;
                tFLResponse.ResponseCode = 1;
            }
            return tFLResponse;
        }
    }
}
