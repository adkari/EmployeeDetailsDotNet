using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeService.Controllers
{
    public class NewApiController : ApiController
    {
        EmployeeDbEntities db = new EmployeeDbEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Action()
        {
            var obj = db.crudEmp(0, "", 0, "Get").ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.SW_TBL_EMPLOYEE.Where(model => model.EmpId == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(SW_TBL_EMPLOYEE e)
        {
            SqlParameter param1 = new SqlParameter("@EmpName", e.EmpName);
            SqlParameter param2 = new SqlParameter("@Salary", e.Salary);
            db.Database.ExecuteSqlCommand("crudEmp 0,@EmpName,@Salary,'Insert'",param1,param2);
            return Ok();

        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(SW_TBL_EMPLOYEE e)
        {
            SqlParameter param1 = new SqlParameter("@EmpName", e.EmpName);
            SqlParameter param2 = new SqlParameter("@Salary", e.Salary);
            SqlParameter param3 = new SqlParameter("@EmpId", e.EmpId);
            db.Database.ExecuteSqlCommand("crudEmp @EmpId,@EmpName,@Salary,'Update'",param3, param1, param2);
            return Ok();
        }
    }
}
