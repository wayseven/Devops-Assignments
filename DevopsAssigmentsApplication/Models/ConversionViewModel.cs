using System;

namespace DevopsAssigmentsApplication.Models
{
    public class ConversionViewModel
    {
        public Guid Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public bool Success { get; set; }
        public string CreatedAt { get; set; }
    }
}
