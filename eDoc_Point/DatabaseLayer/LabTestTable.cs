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

    public partial class LabTestTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LabTestTable()
        {
            this.LabAppointTables = new HashSet<LabAppointTable>();
            this.LabTestDetailsTables = new HashSet<LabTestDetailsTable>();
        }
    
        public int LabTestID { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public int LabID { get; set; }
        [Required(ErrorMessage = "*Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Required!")]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabAppointTable> LabAppointTables { get; set; }
        public virtual LabTable LabTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabTestDetailsTable> LabTestDetailsTables { get; set; }
    }
}
