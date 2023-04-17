namespace StudentAdmin_API.DomainModels
{
    public class UpdateStudentRequest
    {
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string DateOfBirth { get; set; }
        public string email { get; set; }
        
        public long mobile { get; set; }
        public Guid GenderId { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}
