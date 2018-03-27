namespace PayBuddy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApplicationObject
    {
        public int ApplicationObjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string ApplicationObjectName { get; set; }

        public int ApplicationObjectTypeId { get; set; }

        public virtual ApplicationObjectType ApplicationObjectType { get; set; }
    }
}
