//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCAPP_TRAVELUPTASK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLSTUDENT
    {
        [Required]
        [DisplayName("ID")]
        public int STUD_ID { get; set; }

        [Required]
        [DisplayName("Student No.")]
        public string STUD_NO { get; set; }

        [Required]
        [DisplayName("Student Name")]
        public string STUD_NAME { get; set; }

        [DisplayName("Date Of Birth")]
        public Nullable<System.DateTime> STUD_DOB { get; set; }

        [DisplayName("Mobile No.")]
        public Nullable<int> STUD_MOB { get; set; }

        [DisplayName("City")]
        public string STUD_CITY { get; set; }

        [DisplayName("Country")]
        public string STUD_COUNTRY { get; set; }
    }
}