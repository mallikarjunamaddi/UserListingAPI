using Microsoft.EntityFrameworkCore.Migrations;

namespace UserListingAPI.DataModel.Migrations
{
    public partial class AddedInsertLogProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[Insert_Log] (
                           @machineName nvarchar(200),
                           @level varchar(5),
                           @callsite nvarchar(300),
                           @type nvarchar(500),
                           @message nvarchar(max),
                           @stackTrace nvarchar(max),
                           @innerException nvarchar(max),
                           @additionalInfo nvarchar(max)
                        ) AS
                        BEGIN
                          INSERT INTO [dbo].[Log] (
                            [MachineName],
                            [Level],
	                        [Callsite],
	                        [Type],
                            [Message],
                            [StackTrace],
                            [InnerException],
	                        [AdditionalInfo],
                            [LogDateTime]
                          ) VALUES (
                            @machineName,
                            @level,
                            @callsite,
                            @type,
	                        @message,
                            @stackTrace,
                            @innerException,
                            @additionalInfo,
	                        SYSUTCDATETIME()
                          );
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
