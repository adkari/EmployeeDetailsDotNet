﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeDbEntities : DbContext
    {
        public EmployeeDbEntities()
            : base("name=EmployeeDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SW_TBL_EMPLOYEE> SW_TBL_EMPLOYEE { get; set; }
    
        public virtual ObjectResult<crudEmp_Result> crudEmp(Nullable<int> empId, string empName, Nullable<double> salary, string option)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(int));
    
            var empNameParameter = empName != null ?
                new ObjectParameter("EmpName", empName) :
                new ObjectParameter("EmpName", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(double));
    
            var optionParameter = option != null ?
                new ObjectParameter("Option", option) :
                new ObjectParameter("Option", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<crudEmp_Result>("crudEmp", empIdParameter, empNameParameter, salaryParameter, optionParameter);
        }
    
        public virtual int insertInto(string empName, Nullable<double> salary)
        {
            var empNameParameter = empName != null ?
                new ObjectParameter("EmpName", empName) :
                new ObjectParameter("EmpName", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertInto", empNameParameter, salaryParameter);
        }
    
        public virtual ObjectResult<selectTbl_Result> selectTbl()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectTbl_Result>("selectTbl");
        }
    
        public virtual int updateTbl(Nullable<int> empId, string empName, Nullable<double> salary)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(int));
    
            var empNameParameter = empName != null ?
                new ObjectParameter("EmpName", empName) :
                new ObjectParameter("EmpName", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateTbl", empIdParameter, empNameParameter, salaryParameter);
        }
    }
}
