using System;

namespace DevopsAssigmentsApplication.Models
{
    public class ConversionModel
    {
        public Guid Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public bool Success { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
