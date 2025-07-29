using Microsoft.EntityFrameworkCore;

namespace EFCore.DBContext
{
    public static class StoredProcedureInitializer
    {
        public static async Task EnsureStoredProceduresCreatedAsync(AppDbContext context)
        {
            const string createProcIfNotExists = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetTodoItems')
            BEGIN
                EXEC('CREATE PROCEDURE sp_GetTodoItems AS BEGIN SELECT * FROM dbo.TodoItems END')
            END";

            await context.Database.ExecuteSqlRawAsync(createProcIfNotExists);
        }
    }
}
