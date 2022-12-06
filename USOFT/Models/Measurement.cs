using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USOFT.Models
{
    public class Measurement
    {
        public string MeasurementCode { get; set; }
        public string MeasurementName { get; set; }
        public bool IsActive { get; set; }
        public DateTime created_date { get; set; }
        public string created_by { get; set; }
        public DateTime update_date { get; set; }
        public string update_by { get; set; }
    }
}