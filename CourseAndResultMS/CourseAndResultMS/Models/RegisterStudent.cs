//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class RegisterStudent
    {
        public int RegisterStudentId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string Address { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
