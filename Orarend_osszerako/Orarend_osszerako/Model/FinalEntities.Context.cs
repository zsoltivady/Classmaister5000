﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Orarend_osszerako.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Classmaister5000Entities : DbContext
    {
        public Classmaister5000Entities()
            : base("name=Classmaister5000Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Timetable> Timetables { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}