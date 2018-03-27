namespace PayBuddy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public byte[] Password { get; set; }

        public long Contact { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Address { get; set; }

        public int RoleId { get; set; }

        public int? GenderId { get; set; }

        public int Salt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Role Role { get; set; }
    }
}
