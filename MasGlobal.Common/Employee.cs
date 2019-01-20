namespace MasGlobal.Common
{
    public enum ContractType
    {
        HourlySalaryEmployee,
        MonthlySalaryEmployee
    }

    public class HourlyPaidEmployee : Employee
    {
        public override void CalculateSalary()
        {
            this.ContractType = ContractType.HourlySalaryEmployee;
            this.ContractTypeName = "Hourly";
            this.YearlySalary = 120 * this.HourlySalary * 12;
        }
    }

    public class MonthlyPaidEmployee : Employee
    {
        public override void CalculateSalary()
        {
            this.ContractType = ContractType.MonthlySalaryEmployee;
            this.ContractTypeName = "Montly";
            this.YearlySalary = this.MonthlySalary * 12;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public ContractType ContractType { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
        public double YearlySalary { get; set; }

        public virtual void CalculateSalary()
        {
        }
    }

    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
    }
}
