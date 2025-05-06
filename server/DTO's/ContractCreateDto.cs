using System;

namespace HelloWorld.Models
{
    public class ContractCreateDto
    {
        public int FreelancerId { get; set; }
        public int ClientId { get; set; }
        public int JobId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ContractStatusId { get; set; }
    }
}
