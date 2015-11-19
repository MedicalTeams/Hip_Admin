using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
