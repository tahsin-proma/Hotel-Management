//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DoctorTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorTable()
        {
            this.DoctorAppointTables = new HashSet<DoctorAppointTable>();
            this.DoctorTimeSlotTables = new HashSet<DoctorTimeSlotTable>();
        }
    
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "*Required!")]
       [DataType(DataType.Currency)]
        public double Fees { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string Splztion { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string ClinicAddress { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage = "*Required!")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "*Required!")]
       [DataType(DataType.PhoneNumber)]
        public string ClinicPhoneNo { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public Nullable<int> PerDayMaxAppitmnt { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public int AccountTypeID { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string AccountNo { get; set; }
        [Required(ErrorMessage = "*Required!")]

       // [NotMapped]
     //   public HttpPostedFileBase Logofile { get; set; }



        public virtual AccountTypeTable AccountTypeTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorAppointTable> DoctorAppointTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorTimeSlotTable> DoctorTimeSlotTables { get; set; }
    }
}