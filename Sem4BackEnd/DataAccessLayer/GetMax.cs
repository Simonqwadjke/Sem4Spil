﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class GetMax
    {
        public static int GetMaxID(string tableName)
        {
            int maxID = 0;
            string query = "SELECT MAX(" + tableName + "ID)  FROM " + tableName;
            if (tableName.Equals("User"))
            {
                query += "Data";
            }

            using (SqlCommand command = DBConnection.GetDbCommand(query))
            {
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        maxID = reader.GetInt32(0);
                    }
                }
            }

            return maxID;
        }
    }
}