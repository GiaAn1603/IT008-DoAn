using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class CafeTableBUS
    {
        private static CafeTableBUS instance;
        public static CafeTableBUS Instance => instance ?? (instance = new CafeTableBUS());
        private CafeTableBUS() { }

        public List<CafeTableDTO> GetAllTables()
        {
            return CafeTableDAO.Instance.GetListTable();
        }

        public bool AddTable(string name, string area)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            CafeTableDTO table = new CafeTableDTO
            {
                TableName = name,
                Area = area,
                Status = 0
            };
            return CafeTableDAO.Instance.InsertTable(table);
        }

        public bool EditTable(string id, string name, string area, int status)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            CafeTableDTO table = new CafeTableDTO
            {
                Id = id,
                TableName = name,
                Area = area,
                Status = status
            };
            return CafeTableDAO.Instance.UpdateTable(table);
        }

        public bool SwitchStatus(string id, int newStatus)
        {
            return CafeTableDAO.Instance.UpdateTableStatus(id, newStatus);
        }

        public bool RemoveTable(string id)
        {
            return CafeTableDAO.Instance.DeleteTable(id);
        }
    }
}
