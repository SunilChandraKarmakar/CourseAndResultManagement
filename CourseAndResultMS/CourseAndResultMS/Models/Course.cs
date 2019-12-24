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
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseAssignToTeachers = new HashSet<CourseAssignToTeacher>();
            this.AllocateClassRooms = new HashSet<AllocateClassRoom>();
        }
    
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Cradit { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Semester Semester { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeachers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; }
    }
}
