﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDDemo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FishEntities : DbContext
    {
        public FishEntities()
            : base("name=FishEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LogSession> LogSessions { get; set; }
        public virtual DbSet<mstEmployee> mstEmployees { get; set; }
        public virtual DbSet<mstItem> mstItems { get; set; }
        public virtual DbSet<mstUser> mstUsers { get; set; }
    
        public virtual ObjectResult<Usp_Find_MstEmployee_Result> Usp_Find_MstEmployee(string employee_name)
        {
            var employee_nameParameter = employee_name != null ?
                new ObjectParameter("employee_name", employee_name) :
                new ObjectParameter("employee_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Find_MstEmployee_Result>("Usp_Find_MstEmployee", employee_nameParameter);
        }
    }
}
