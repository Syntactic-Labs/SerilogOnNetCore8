using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Data;

namespace SerilogOnNetCore8.Configurations;

public static class SerilogConfigurations
{
	public static void AddAndConfigureSerilog(this IHostBuilder host)
	{
		host.UseSerilog((hostingContext, loggerConfiguration) =>
		{
			var columnConfig = ConfigureColumns();
			var sinkConfig = ConfigureSinks();
			loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
			.Enrich.WithMachineName()
			.Enrich.WithClientIp()
			.WriteTo.MSSqlServer
			(
				connectionString: hostingContext.Configuration.GetConnectionString("SeriLogConn"),
				sinkOptions: sinkConfig,
				columnOptions: columnConfig
			);
		});
	}
	private static ColumnOptions ConfigureColumns()
	{
		ColumnOptions colOptions = new()
		{
			AdditionalColumns =
			[
				new SqlColumn(columnName: "ActionName", dataType: SqlDbType.NVarChar, dataLength: 128),
				new SqlColumn(columnName:"MachineName", dataType: SqlDbType.NVarChar, dataLength: 128),
				new SqlColumn(columnName: "ClientIp", dataType: SqlDbType.NVarChar, dataLength: 45)
			],
			TimeStamp = { DataType = SqlDbType.DateTime2 },
			Level = { DataLength = 24 },
		};
		colOptions.Store.Remove(StandardColumn.MessageTemplate);
		colOptions.Store.Remove(StandardColumn.Properties);

		return colOptions;
	}
	private static MSSqlServerSinkOptions ConfigureSinks() =>
		new()
		{
			TableName = "ApiLogs",
			AutoCreateSqlTable = true
		};
}