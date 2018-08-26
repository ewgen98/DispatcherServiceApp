using System;

namespace DispatcherServiceApp
{
    public class Document
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int? HomeNumber { get; set; }
        public int? Apartment { get; set; }
        public string DescriptionProblem { get; set; }
        public string Worker { get; set; }
        public string FirstDate { get; set; }
        public string LastDate { get; set; }
        public string DescriptionResult { get; set; }
        public decimal Money { get; set; }
    }
}
