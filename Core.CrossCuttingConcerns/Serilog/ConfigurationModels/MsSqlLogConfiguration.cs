using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.ConfigurationModels;

public class MsSqlLogConfiguration
{
    public string ConnectionString { get; set; }
    public string TableName { get; set; }
    public bool AutoCreateSqlTable { get; set; }


    public MsSqlLogConfiguration()
    {
        ConnectionString = string.Empty;
        TableName = string.Empty;
    }
    public MsSqlLogConfiguration(string connectionString, string tableName, bool autoCreateSqlTable)
    {
        ConnectionString = connectionString;
        TableName = tableName;
        AutoCreateSqlTable = autoCreateSqlTable;
    }



}
