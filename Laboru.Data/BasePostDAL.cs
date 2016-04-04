
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
    public class BasePostDAL
    {
        public static PostDataModel MapItem(DataRow row)
        {
            PostDataModel item = null;
            item = new PostDataModel();

            if (row["ID"].GetType() != typeof(DBNull))
            {
                item.ID = Convert.ToInt32(row["ID"]);
            }
            if (row["Title"].GetType() != typeof(DBNull))
            {
                item.Title = Convert.ToString(row["Title"]);
            }
            if (row["Description"].GetType() != typeof(DBNull))
            {
                item.Description = Convert.ToString(row["Description"]);
            }
            if (row["SkillPageID"].GetType() != typeof(DBNull))
            {
                item.SkillPageID = Convert.ToInt32(row["SkillPageID"]);
            }
            if (row["FromExpertID"].GetType() != typeof(DBNull))
            {
                item.FromExpertID = Convert.ToInt32(row["FromExpertID"]);
            }
            if (row["DateCreated"].GetType() != typeof(DBNull))
            {
                item.DateCreated = Convert.ToDateTime(row["DateCreated"]);
            }

            return item;
        }

        public static List<PostDataModel> GetAll()
        {
            List<PostDataModel> items = new List<PostDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetAllPost", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                PostDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }


        public static List<PostDataModel> Filter(PostDataModel model)
        {
            List<PostDataModel> items = new List<PostDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            string FilterSelect = "" +
                " SELECT  ID,  Title,  Description,  SkillPageID,  FromExpertID,  DateCreated  " +
                " FROM post " +
                " WHERE ID LIKE '%" + model.ID.ToString() + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(FilterSelect, connection);
            adapter.SelectCommand.CommandType = CommandType.Text;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                PostDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

        public static List<PostDataModel> GetPostByPage(int id)
        {
            List<PostDataModel> items = new List<PostDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetPostByPage", connection);
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
        public static List<PostDataModel> GetPostByExpert(int id)
        {
            List<PostDataModel> items = new List<PostDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetPostByExpert", connection);
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

        public static PostDataModel Get(int id)
        {
            PostDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetPostByID", connection);
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

        public static PostDataModel GetByName(string name)
        {
            PostDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetPostByName", connection);
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

        public static void Update(PostDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdatePost", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramTitle = new MySqlParameter("pTitle", item.Title);
            paramTitle.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramTitle);
            MySqlParameter paramDescription = new MySqlParameter("pDescription", item.Description);
            paramDescription.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDescription);
            MySqlParameter paramSkillPageID = new MySqlParameter("pSkillPageID", item.SkillPageID);
            paramSkillPageID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramSkillPageID);
            MySqlParameter paramFromExpertID = new MySqlParameter("pFromExpertID", item.FromExpertID);
            paramFromExpertID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramFromExpertID);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", item.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static int Create(PostDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreatePost", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramTitle = new MySqlParameter("pTitle", item.Title);
            paramTitle.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramTitle);
            MySqlParameter paramDescription = new MySqlParameter("pDescription", item.Description);
            paramDescription.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDescription);
            MySqlParameter paramSkillPageID = new MySqlParameter("pSkillPageID", item.SkillPageID);
            paramSkillPageID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramSkillPageID);
            MySqlParameter paramFromExpertID = new MySqlParameter("pFromExpertID", item.FromExpertID);
            paramFromExpertID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramFromExpertID);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", item.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);

            DataTable results = new DataTable();
            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                return Convert.ToInt32(results.Rows[0]["ID"]);
            }
            else
            {
                throw new Exception("Error creating Post");
            }
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeletePost", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
