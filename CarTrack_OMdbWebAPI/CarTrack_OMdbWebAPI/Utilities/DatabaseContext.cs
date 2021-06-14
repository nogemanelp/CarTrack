using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  CarTrack_OMdbWebAPI.Model;

namespace CarTrack_OMdbWebAPI.Utilities
{
    public class DatabaseContext
    {
        public List<Item> GetAllCachedItems()
        {
            List<Item> items = new List<Item>();
            DynamicParameters dataParams = new DynamicParameters();
            items = DapperContext.ReturnList<Item>("sp_GetAllCachedItems", null).ToList();
            return items;
        }

        public Item GetItemById(int id)
        {
            Item item = new Item();
            DynamicParameters dataParams = new DynamicParameters();
            dataParams.Add("@Id", id);
            item = DBContext.ExecuteReturnScalar<Item>("sp_GetItemById", dataParams);
            return item;
        }

        public Item GetItemByTitle(string title)
        {
            Item item = new Item();
            DynamicParameters dataParams = new DynamicParameters();
            dataParams.Add("@Title", title);
            item = DBContext.ExecuteReturnScalar<Item>("sp_GetItemByTitle", dataParams);
            return item;
        }

        public Item GetItemByTitleAndYear(string title,int year)
        {
            Item item = new Item();
            DynamicParameters dataParams = new DynamicParameters();
            dataParams.Add("@Title", title);
            dataParams.Add("@Year", year);
            item = DBContext.ExecuteReturnScalar<Item>("sp_GetItemByTitle", dataParams);
            return item;
        }

        public void AddCachedItem(Item item)
        {
            DynamicParameters dataParams = new DynamicParameters();

            dataParams.Add("@Id", id);
            dataParams.Add("@Title", title);
            dataParams.Add("@Year", year);

            DBContext.ExecuteWithoutReturn("sp_AddCachedItem", dataParams);

        }

        public void UpdateCachedItemByID(Item item)
        {
            DynamicParameters dataParams = new DynamicParameters();

            dataParams.Add("@Id", id);
            dataParams.Add("@Title", title);
            dataParams.Add("@Year", year);

            DBContext.ExecuteWithoutReturn("sp_UpdateCachedItemByID", dataParams);

        }

        public void RemoveCachedItemByID(int id)
        {
            DynamicParameters dataParams = new DynamicParameters();

            dataParams.Add("@Id", id);
            dataParams.Add("@Title", title);
            dataParams.Add("@Year", year);

            DBContext.ExecuteWithoutReturn("sp_RemoveCachedItemByID", dataParams);

        }
    }
}
