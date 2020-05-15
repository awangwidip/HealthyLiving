namespace HealthyLiving
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Nama { get; set; }

        public int Weight { get; set; }

        public double Height { get; set; }

        public int Usia { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
