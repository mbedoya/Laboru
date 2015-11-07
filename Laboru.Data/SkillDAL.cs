using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Laboru.Models;

namespace Laboru.Data
{
    public class SkillDAL
    {
        public static SkillDataModel MapItem(DataRow row)
        {
            SkillDataModel item = null;
            item = new SkillDataModel();

            if (row["ID"].GetType() != typeof(DBNull))
            {
                item.ID = Convert.ToInt32(row["ID"]);
            }
            if (row["Name"].GetType() != typeof(DBNull))
            {
                item.Name = Convert.ToString(row["Name"]);
            }

            return item;
        }

        public static List<SkillDataModel> GetAll()
        {
            List<SkillDataModel> items = new List<SkillDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetSkills", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                SkillDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
    }
}
