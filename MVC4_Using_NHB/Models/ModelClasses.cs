using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace MVC4_Using_NHB.Models
{
    public class EmployeeInfo
    {
        int _EmpNo;

        public virtual int EmpNo
        {
            get { return _EmpNo; }
            set { _EmpNo = value; }
        }
        string _EmpName;

        public virtual string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }
        int _Salary;

        public virtual int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
        string _DeptName;

        public virtual string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }
        string _Designation;

        public virtual string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

    }

    /// <summary>
    /// class to perform the CRUD operations
    /// </summary>
    public class EmployeeInfoDAL
    {
        //Define the session factory, this is per database 
        ISessionFactory sessionFactory;

        /// <summary>
        /// Method to create session and manage entities
        /// </summary>
        /// <returns></returns>
        ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                var cgf = new Configuration();
                var data = cgf.Configure(HttpContext.Current.Server.MapPath(@"Models\NHibernate\Configuration\hibernate.cfg.xml"));
                cgf.AddDirectory(new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(@"Models\NHibernate\Mappings")));
                sessionFactory = data.BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }

        public IList<EmployeeInfo> GetEmployees()
        {
            IList<EmployeeInfo> Employees;
            using (ISession session = OpenSession())
            {
                //NHibernate query
                IQuery query = session.CreateQuery("from EmployeeInfo");
                Employees = query.List<EmployeeInfo>();
            }
            return Employees;
        }

        public EmployeeInfo GetEmployeeById(int Id)
        {
            EmployeeInfo Emp = new EmployeeInfo();
            using (ISession session = OpenSession())
            {
                Emp = session.Get<EmployeeInfo>(Id);
            }
            return Emp;
        }

        public int CreateEmployee(EmployeeInfo Emp)
        {
            int EmpNo = 0;

            using (ISession session = OpenSession())
            {
                //Perform transaction
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(Emp);
                    tran.Commit();
                }
            }

            return EmpNo;
        }


        public void UpdateEmployee(EmployeeInfo Emp)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(Emp);
                    tran.Commit();
                }
            }
        }

        public void DeleteEmployee(EmployeeInfo Emp)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(Emp);
                    tran.Commit();
                }
            }
        }
    }
}