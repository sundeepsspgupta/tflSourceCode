using System;

namespace TFL.Domain
{
    /// <summary>
    /// This class used to contains Api resonse in form of Deserialize. 
    /// </summary>
    public class RoadCorridor
    {
        public string Id { get; set; }
        public string displayName { get; set; }
        public string group { get; set; }
        public string statusseverity { get; set; }
        public string statusSeverityDescription { get; set; }
        public string bounds { get; set; }
        public string envelope { get; set; }
        public DateTime statusAggregationStartDate { get; set; }
        public DateTime statusAggregationEndDate { get; set; }
        public string url { get; set; }
    }
}
