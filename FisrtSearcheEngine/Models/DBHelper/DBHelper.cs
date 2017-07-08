using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DBHelper
{
    public bool CheckConnectionDb()
    {
        bool ret = false;

        X_DBASE x_dbase = Initial();
        x_dbase.sqlCommand.CommandText = sqlCommand.Select(sqlCommand.Apk_Activity.TABLE_NAME);

        try
        {
            x_dbase.sqlConnection.Open();
            ret = true;
        }
        catch (Exception ex)
        {
            ret = false;
        }

        x_dbase.sqlConnection.Close();
        x_dbase.sqlConnection.Dispose();
        return ret;
    }

    internal X_DBASE Initial()
    {
        X_DBASE x_dbase = new X_DBASE();
        SqlConnection sc = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        sc.ConnectionString = sqlCommand.StringConnection;
        cmd.Connection = sc;
        cmd.CommandType = CommandType.Text;
        x_dbase.sqlCommand = cmd;
        x_dbase.sqlConnection = sc;

        return x_dbase;
    }

    public String ExecuteThenClose(X_DBASE x_dbase)
    {
        String ack = "";
        if (x_dbase.sqlConnection.State != ConnectionState.Open)
        {
            x_dbase.sqlConnection.Open();
        }
        ack = Convert.ToString(x_dbase.sqlCommand.ExecuteScalar());
        x_dbase.sqlConnection.Close();
        x_dbase.sqlConnection.Dispose();
        return ack;
    }

    public String ExecuteWithoutClose(X_DBASE x_dbase)
    {
        if (x_dbase.sqlConnection.State != ConnectionState.Open)
        {
            x_dbase.sqlConnection.Open();
        }
        String ack = Convert.ToString(x_dbase.sqlCommand.ExecuteScalar());
        return ack;
    }

    public List<String> ExecuteSerialize(X_DBASE x_dbase, int index)
    {
        List<String> ret = new List<string>();
        if (x_dbase.sqlConnection.State != ConnectionState.Open)
        {
            x_dbase.sqlConnection.Open();
        }
        using (SqlDataReader reader = x_dbase.sqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                if (!Convert.IsDBNull(reader[index]))
                {
                    if (index != 0)
                    {
                        ret.Add((Convert.ToString(reader.GetString(index))));
                    }
                    else
                    {
                        ret.Add(Convert.ToString(reader.GetInt32(index)));
                    }
                }
            }
        }
        return ret;
    }

    public void Close(X_DBASE x_dbase)
    {
        x_dbase.sqlConnection.Close();
        x_dbase.sqlConnection.Dispose();
    }
}
