using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.Logger;

public class MsSqlLogger:LoggerServiceBase
{
    private readonly IConfiguration _configuration;


    public MsSqlLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        MsSqlLogConfiguration logConfiguration =
            configuration.GetSection("SeriLogConfigurations:MsSqlLogConfiguration").Get<MsSqlLogConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        MSSqlServerSinkOptions sinkOptions = new()
        {
            TableName = logConfiguration.TableName,
            AutoCreateSqlDatabase = logConfiguration.AutoCreateSqlTable,
        };

        ColumnOptions columnOptions = new();


        global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(logConfiguration.ConnectionString,sinkOptions,columnOptions:columnOptions).CreateLogger();

        Logger = seriLogConfig;

    }

//    https://github.com/serilog-mssql/serilog-sinks-mssqlserver
    
//        CREATE TABLE[Logs] (

//   [Id] int IDENTITY(1,1) NOT NULL,
//   [Message] nvarchar(max) NULL,
//   [MessageTemplate] nvarchar(max) NULL,
//   [Level] nvarchar(128) NULL,
//   [TimeStamp] datetime NOT NULL,
//   [Exception] nvarchar(max) NULL,
//   [Properties] nvarchar(max) NULL

//   CONSTRAINT[PK_Logs] PRIMARY KEY CLUSTERED([Id] ASC)
//);


}
