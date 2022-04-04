using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Practical.BAL
{
    public class Helper
    {
       public NpgsqlConnection conn = new NpgsqlConnection(@"Server=localhost;User Id=postgres;Database=Arjun;port=5432;Password=123");
    }
}