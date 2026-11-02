using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ElevatorApp
{
    public class ElevatorLog
    {
        readonly string connStr;

        public ElevatorLog()
        {
            string folder = Path.Combine(Application.StartupPath, "Data");
            Directory.CreateDirectory(folder);
            connStr = "Data Source=" + Path.Combine(folder, "elevator.db") + ";Version=3;";

            using (var con = new SQLiteConnection(connStr))
            {
                con.Open();
                new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Log (Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Elevator TEXT, Floor INTEGER, Action TEXT, LoggedAt TEXT)", con).ExecuteNonQuery();
            }
        }

        public DataTable Load()
        {
            var table = new DataTable();
            using (var da = new SQLiteDataAdapter("SELECT * FROM Log ORDER BY Id DESC", connStr))
                da.Fill(table);
            return table;
        }

        public void Add(int floor, string action, string elevator)
        {
            using (var da = new SQLiteDataAdapter("SELECT * FROM Log WHERE 1=0", connStr))
            using (var builder = new SQLiteCommandBuilder(da))
            {
                var table = new DataTable();
                da.Fill(table);

                DataRow row = table.NewRow();
                row["Elevator"] = elevator;
                row["Floor"] = floor;
                row["Action"] = action;
                row["LoggedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                table.Rows.Add(row);

                da.Update(table);
            }
        }
    }
}