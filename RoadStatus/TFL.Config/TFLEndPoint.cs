namespace TFL.Config
{

    public class TFLEndPoint
    {
        public string PrimaryKey { get; set; }
        public string SecondaryKey {  get; set; }
        public string TFLBaseURL { get; set; }
        public string ApiEndPoint { get; set; }

        public string GetAipEndPointPath(string roadCode) 
        {
            return string.Format(ApiEndPoint, roadCode, PrimaryKey, SecondaryKey);
        }
    }
}
