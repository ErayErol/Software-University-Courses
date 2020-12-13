namespace Google
{
    public class Company
    {
        private string companyName;
        private string department;
        private string salary;

        public Company()
        {

        }
        public Company(string companyName, string department, string salary)
        {
            this.companyName = companyName;
            this.department = department;
            this.salary = salary;
        }

        public override string ToString()
        {
            if (companyName == null)
            {
                return "";
            }
            return "\r\n" + CompanyName + " " + Department + $" {double.Parse(Salary):f2}";
        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string Department { get => department; set => department = value; }
        public string Salary { get => salary; set => salary = value; }
    }
}