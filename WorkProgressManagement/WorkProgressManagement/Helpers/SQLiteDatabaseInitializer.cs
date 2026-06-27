using System;
using System.Data.SQLite;
using System.IO;

namespace WorkProgressManagement.Helpers
{
    internal class SQLiteDatabaseInitializer
    {
        private const string DatabaseFolder = "Database";
        private const string DatabaseFile = "Database\\work_progress.db";
        private const string SqlScript = "Database\\init.sql";

        public static void InitializeDatabase()
        {
            // Tạo thư mục Database nếu chưa có
            if (!Directory.Exists(DatabaseFolder))
            {
                Directory.CreateDirectory(DatabaseFolder);
            }

            // Nếu database đã tồn tại thì không tạo lại
            if (File.Exists(DatabaseFile))
            {
                return;
            }

            // Tạo file database
            SQLiteConnection.CreateFile(DatabaseFile);

            using (var connection = new SQLiteConnection($"Data Source={DatabaseFile};Version=3;"))
            {
                connection.Open();

                string sql = File.ReadAllText(SqlScript);

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}