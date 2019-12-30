﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseAndResultMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CourseAndResultManagementEntities : DbContext
    {
        public CourseAndResultManagementEntities()
            : base("name=CourseAndResultManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<CourseAssignToTeacher> CourseAssignToTeachers { get; set; }
        public virtual DbSet<CourseInformation> CourseInformations { get; set; }
        public virtual DbSet<RegisterStudent> RegisterStudents { get; set; }
        public virtual DbSet<AllocateClassRoom> AllocateClassRooms { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Week> Weeks { get; set; }
        public virtual DbSet<EnrollCourse> EnrollCourses { get; set; }
        public virtual DbSet<ClassSchidule> ClassSchidules { get; set; }
    }
}
