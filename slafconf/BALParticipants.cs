using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace slafconf
{
    public class BALParticipants
    {
        public int insertParticipantData2(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int insertCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                insertCount = oDALParticipants.insertParticipantData2(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return insertCount;
        }
        public int insertParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int insertCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                insertCount = oDALParticipants.insertParticipantData(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return insertCount;
        }

        public int insertmeet(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int insertCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                insertCount = oDALParticipants.insertmeet(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return insertCount;
        }
        public int updateParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updateParticipantData(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        
               public int updateonline(string cid,  DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updateonline(cid, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        

                    public int updatechnlData(string cid, string sts, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updatechnlData(cid, sts, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        public int updatecloseData(string cid, string sts, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updatecloseData(cid, sts, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }

        public int insertauth(string cid,string aid ,DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.insertauth(cid,aid, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        public int deleteParticipantData(string cid, string sts, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.deleteParticipantData(cid,sts, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }

        
            public int updatepass(string cid, string sts, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updatepass(cid, sts, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        public int updatejoin(string cid, string sts, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updatejoin(cid, sts, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        public DataTable selectParticipantDataByCardID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectParticipantDataByCardID(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectAllParticipantData(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectAllParticipantData(oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataTable selectimg(string id,DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectimg(id,oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataTable selectver(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectver(oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectmeet(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectmeet(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataTable selectcurusers(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectcurusers(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectAllusers(string id,DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectAllusers(id,oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable searchParticipantData(string tst, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.searchParticipantData(tst,oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataSet SelectUserDetails(string username, string password,DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.SelectUserDetails(username,password,oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        
              public DataSet selectadmincount(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectadmincount(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataSet selectadmin(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectadmin(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectmeeeting(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectmeeeting(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        
               public DataSet selectactvcnt(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectactvcnt(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        
                 public DataSet selectactvemt(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectactvemt(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataSet selectactveconf(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectactveconf(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

        public DataSet selectjoin(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectjoin(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataSet selectcall(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectcall(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataSet selectwait(string id, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataSet oDataTable = new DataSet();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectwait(id, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
    }
}
