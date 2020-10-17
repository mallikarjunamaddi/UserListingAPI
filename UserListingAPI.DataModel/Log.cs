using System;
using System.ComponentModel.DataAnnotations;

namespace UserListingAPI.DataModel
{
    public class Log
    {
        public long Id { get; set; }

        [StringLength(200)]
        public string MachineName { get; set; }
        
        [StringLength(5), Required]
        public string Level { get; set; }

        [StringLength(300)]
        public string Callsite { get; set; }

        [StringLength(500)]
        public string Type { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string InnerException { get; set; }

        [Required]
        public string AdditionalInfo { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }

    }
}
