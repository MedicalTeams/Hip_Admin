using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;

namespace HealthInformationProgram.Data.Repositories
{
    public class BaseRepository
    {
        internal string connString = string.Empty;

        public BaseRepository()
        {
            var config = new Configuration();
            connString = config.GetConnection();
        
        }

        public static void IdentityInsertOn<T>(ClinicDataContext ctx, T entity)
        {
            var name = entity.GetType().Name;
            var insertStatement = string.Format(@"SET IDENTITY_INSERT [dbo].[{0}] ON", name);
            ctx.Database.ExecuteSqlCommand(insertStatement);
        }
    }
}
