using Laboru.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Laboru.Data
{
    public class PostDAL : BasePostDAL
    {
        public static List<PostDataModel> GetPostForExpert(int id)
        {
            List<PostDataModel> items = new List<PostDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetPostForExpert", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                PostDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
    }
}