namespace WebApplication1.Data.Entity
{
    public class MedicalCard
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? Workplace { get; set; }
        public string? Dolznost { get; set; }
        public string? Anamez { get; set; }
        public bool? isMan { get; set; }
    }
}
