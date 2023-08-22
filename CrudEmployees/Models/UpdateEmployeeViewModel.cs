namespace CrudEmployees.Models
{
    public class UpdateEmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
