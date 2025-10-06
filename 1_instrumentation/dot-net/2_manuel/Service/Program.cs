// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0


using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var connectionString = System.Environment.GetEnvironmentVariable("DB_CONNECTION");
app.MapGet("/", Handler);
app.Run();

async Task<string> Handler(ILogger<Program> logger)
{
    await ExecuteSql("SELECT 1");

    var waitTime = Random.Shared.NextDouble(); // max 1 seconds
    await Task.Delay(TimeSpan.FromSeconds(waitTime));

    // .NET ILogger: create a log
    logger.LogInformation("Success! Today is: {Date:MMMM dd, yyyy}", DateTimeOffset.UtcNow);

    return "Hello there";
}

async Task ExecuteSql(string sql)
{
    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();
    using var command = new SqlCommand(sql, connection);
    using var reader = await command.ExecuteReaderAsync();
}
