namespace HealthyLiving
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserDataModel : DbContext
    {
        public UserDataModel()
            : base("name=UserDataModel")
        {
        }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
