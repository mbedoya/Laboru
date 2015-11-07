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
    public class ExpertDAL : BaseExpertDAL
    {
        public static ExpertDataModel GetByMobile(string mobile)
        {
            ExpertDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetExpertByMobile", connection);
            MySqlParameter paramID = new MySqlParameter("pMobile", mobile);
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

        public static List<ExpertSearchResultDataModel> GetBySkillAndExpert(int skillID, int fromExpertID)
        {
            List<ExpertSearchResultDataModel> items = new List<ExpertSearchResultDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetExpertsBySkill", connection);

            MySqlParameter paramID = new MySqlParameter("pSkillID", skillID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            MySqlParameter paramExpert = new MySqlParameter("pFromExpertID", fromExpertID);
            paramExpert.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramExpert);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                foreach (DataRow row in results.Rows)
                {
                    ExpertSearchResultDataModel item = null;
                    item = new ExpertSearchResultDataModel();

                    if (row["ID"].GetType() != typeof(DBNull))
                    {
                        item.ID = Convert.ToInt32(row["ID"]);
                    }
                    if (row["Name"].GetType() != typeof(DBNull))
                    {
                        item.Name = Convert.ToString(row["Name"]);
                    }
                    if (row["Recommendations"].GetType() != typeof(DBNull))
                    {
                        item.Recommendations = Convert.ToInt32(row["Recommendations"]);
                    }
                    if (row["FriendsRecommendations"].GetType() != typeof(DBNull))
                    {
                        item.FriendsRecommendations = Convert.ToInt32(row["FriendsRecommendations"]);
                    }

                    items.Add(item);
                    
                }
                
            }

            return items;
        }

        public static void AddContact(int fromExpertID, int expertID)
        {
            List<ExpertSearchResultDataModel> items = new List<ExpertSearchResultDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("AddContact", connection);

            MySqlParameter paramID = new MySqlParameter("pFromExpertID", fromExpertID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            MySqlParameter paramExpert = new MySqlParameter("pExpertID", expertID);
            paramExpert.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramExpert);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);
            
        }

        public static void DeleteContacts(int fromExpertID)
        {
            List<ExpertSearchResultDataModel> items = new List<ExpertSearchResultDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("DeleteExpertContacts", connection);

            MySqlParameter paramID = new MySqlParameter("pExpertID", fromExpertID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

        }
    }
}