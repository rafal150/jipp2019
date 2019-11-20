/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Labs.Databases
{
    public class SQLModel: DbContext
    {
        public SQLModel(): base("name=SQLModel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<SQLValues> Values { get; set; }


    }
}
*/