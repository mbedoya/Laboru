
using Laboru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Laboru.Data
{
    public class BaseExpertDAL
    {
		public static ExpertDataModel MapItem(DataRow row)
		{
			ExpertDataModel item = null;
			item = new ExpertDataModel();

			if (row["ID"].GetType() != typeof(DBNull))
			{
				item.ID = Convert.ToInt32(row["ID"]);
			}
			if (row["Name"].GetType() != typeof(DBNull))
			{
				item.Name = Convert.ToString(row["Name"]);
			}
			if (row["LastName"].GetType() != typeof(DBNull))
			{
				item.LastName = Convert.ToString(row["LastName"]);
			}
			if (row["Mobile"].GetType() != typeof(DBNull))
			{
				item.Mobile = Convert.ToString(row["Mobile"]);
			}
			if (row["Bio"].GetType() != typeof(DBNull))
			{
				item.Bio = Convert.ToString(row["Bio"]);
			}
			
			return item;
		}

		public static List<ExpertDataModel> GetAll()
        {
            List<ExpertDataModel> items = new List<ExpertDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetAllExpert", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ExpertDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

		
		public static List<ExpertDataModel> Filter(ExpertDataModel model)
        {
            List<ExpertDataModel> items = new List<ExpertDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            string FilterSelect = "" +
                " SELECT  ID,  Name,  LastName,  Mobile,  Bio  " +
                " FROM expert " +
                " WHERE Mobile LIKE '%" + model.Mobile.Replace("'","").Replace("-","") + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(FilterSelect, connection);
            adapter.SelectCommand.CommandType = CommandType.Text;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ExpertDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

		
        public static ExpertDataModel Get(int id)
        {
            ExpertDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetExpertByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);			

            if (results.Rows.Count > 0)
            {
                DataRow row = results.Rows[0];
                item = MapItem(row);
            }

            return item;
        }

		public static ExpertDataModel GetByName(string name)
        {
            ExpertDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetExpertByName", connection);
            MySqlParameter paramID = new MySqlParameter("pName", name);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);			

            if (results.Rows.Count > 0)
            {
                DataRow row = results.Rows[0];
                item = MapItem(row);
            }

            return item;
        }

        public static void Update(ExpertDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateExpert", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramLastName = new MySqlParameter("pLastName", item.LastName);
            paramLastName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramLastName);
					MySqlParameter paramMobile = new MySqlParameter("pMobile", item.Mobile);
            paramMobile.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMobile);
					MySqlParameter paramBio = new MySqlParameter("pBio", item.Bio);
            paramBio.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBio);
		
            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static int Create(ExpertDataModel item)
        {
           MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateExpert", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramLastName = new MySqlParameter("pLastName", item.LastName);
            paramLastName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramLastName);
					MySqlParameter paramMobile = new MySqlParameter("pMobile", item.Mobile);
            paramMobile.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMobile);
					MySqlParameter paramBio = new MySqlParameter("pBio", item.Bio);
            paramBio.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBio);
		
            DataTable results = new DataTable();
            adapter.Fill(results);

			if(results.Rows.Count > 0)
			{
				return Convert.ToInt32(results.Rows[0]["ID"]);
			}else{
				throw new Exception("Error creating Expert");
			}
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteExpert", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
