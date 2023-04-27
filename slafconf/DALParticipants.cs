﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace slafconf
{
    public class DALParticipants
    {
        public int insertParticipantData2(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            try
            {
                sqlQuery = " INSERT INTO [tblParticipants] " +
                " ( " +
              
              
               
               
                "  Surname," +

                "  password," +
                "  ParticipantImage," +
                "  Status," +
                "  CardID)" +
                " VALUES " +
                " ( " +
              
                "  @Surname," +

                "  @password," +
                "  @ParticipantImage," +
                "  @Status," +
                "  @CardID) ";

                oSqlCommand = new SqlCommand();
             
                oSqlCommand.Parameters.AddWithValue("@Surname", oCMNParticipants.Surname);
             
                oSqlCommand.Parameters.AddWithValue("@password", oCMNParticipants.Initials);
                oSqlCommand.Parameters.AddWithValue("@ParticipantImage", oCMNParticipants.participantImage);
                oSqlCommand.Parameters.AddWithValue("@Status", 1);
                oSqlCommand.Parameters.AddWithValue("@CardID", oCMNParticipants.RegistrationNo);

                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                return oSqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insertParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            try
            {
                sqlQuery = " INSERT INTO [conflist] " +
                " ( " +
                "  callerid," +
                "  channel," +
                "  url," +
                 "  isadmin," +
                  "  createddate," +
                "  status) output INSERTED.cid" +
                " VALUES " +
                " ( " +
                "  @callerid," +
                "  @channel," +
                "  @url," +
                "  @isadmin," +
                 "  GETDATE()," + 
                "  @status) ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@callerid", oCMNParticipants.Surname);
                oSqlCommand.Parameters.AddWithValue("@channel", oCMNParticipants.RegistrationNo);
                oSqlCommand.Parameters.AddWithValue("@url", oCMNParticipants.RankID);
                oSqlCommand.Parameters.AddWithValue("@isadmin", oCMNParticipants.Status);
                oSqlCommand.Parameters.AddWithValue("@status", oCMNParticipants.Initials);
              

                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                int modified = Convert.ToInt32( oSqlCommand.ExecuteScalar());
                return modified;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertmeet(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            try
            {
                sqlQuery = " insert into  [vidconf].[dbo].[meet]  ([mdate],[uid],[isadmin],[mdesc]) " +
                " VALUES " +
                " ( " +
                "  @callerid," +
                "  @channel," +
                "  @isadmin," +
                "  @url)";
                

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@callerid", oCMNParticipants.RegistrationNo);
                oSqlCommand.Parameters.AddWithValue("@channel", oCMNParticipants.RankID);
                oSqlCommand.Parameters.AddWithValue("@url", oCMNParticipants.Initials);
                oSqlCommand.Parameters.AddWithValue("@isadmin", oCMNParticipants.Surname);


                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                int modified = Convert.ToInt32(oSqlCommand.ExecuteScalar());
                return modified;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectUserDetails(string username, string password, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT  CardID  " +
                           " FROM  tblParticipants WITH (NOLOCK) WHERE CardID=@CardID1 AND password=@CardID2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@CardID1", username);
                oSqlCommand.Parameters.AddWithValue("@CardID2", password);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            int updateCount;
            string sqlQuery;
            SqlCommand oSqlCommand;
            try
            {
                sqlQuery = " UPDATE [tblParticipants] SET" +
                "  RegistrationNo=@RegistrationNo," +
                "  RankID=@RankID," +
                "  Initials=@Initials," +
                "  FullName=@FullName," +
                "  Surname=@Surname," +
                "  OtherNames=@OtherNames," +
                "  CountryID=@CountryID," +
                "  ParticipantImage=@ParticipantImage, " +
                "  CardID=@CardID, " +
                "  WHERE SysID=@SysID";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID", oCMNParticipants.SysID);
                oSqlCommand.Parameters.AddWithValue("@RegistrationNo", oCMNParticipants.RegistrationNo);
                oSqlCommand.Parameters.AddWithValue("@RankID", oCMNParticipants.RankID);
                oSqlCommand.Parameters.AddWithValue("@Initials", oCMNParticipants.Initials);
                oSqlCommand.Parameters.AddWithValue("@Surname", oCMNParticipants.Surname);
                oSqlCommand.Parameters.AddWithValue("@OtherNames", oCMNParticipants.OtherNames);
                oSqlCommand.Parameters.AddWithValue("@CountryID", oCMNParticipants.CountryID);
                oSqlCommand.Parameters.AddWithValue("@ParticipantImage", oCMNParticipants.ParticipantImage);
                oSqlCommand.Parameters.AddWithValue("@CardID", oCMNParticipants.CardID);

                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deleteParticipantData(string clid, string sts, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [conflist] SET" +
                "  status=@SysID1" +
                "  WHERE callerid=@SysID2 and (status=1 or status=5)";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", sts);
                oSqlCommand.Parameters.AddWithValue("@SysID2", clid);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatepass(string un, string txt, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [tblParticipants] SET" +
                "  password=@SysID1" +
                "  WHERE CardID=@SysID2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", txt);
                oSqlCommand.Parameters.AddWithValue("@SysID2", un);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatejoin(string clid, string sts, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [conflist] SET" +
                "  status=@SysID1" +
                "  WHERE callerid=@SysID2 and status=5";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", sts);
                oSqlCommand.Parameters.AddWithValue("@SysID2", clid);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateonline(string clid,  DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [tblParticipants] SET" +
                "  Initials=@SysID1" +
                "  WHERE CardID=@SysID2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
                oSqlCommand.Parameters.AddWithValue("@SysID2", clid);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public int insertauth(string clid,string aid, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " INSERT INTO [auth] (uname,authid,status)" +
                "  values(@SysID2,@SysID1,1)";
               

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", aid);
                oSqlCommand.Parameters.AddWithValue("@SysID2", clid);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatechnlData(string clid, string sts, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [conflist] SET" +
                "  channel=@SysID1 ,isadmin='0'    " +
                "  WHERE callerid=@SysID2 and status=2";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", sts);
                oSqlCommand.Parameters.AddWithValue("@SysID2", clid);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updatecloseData(string clid, string sts, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [conflist] SET" +
                "  status=@SysID1" +
                "  WHERE callerid=@SysID2 and status=2";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID1", sts);
                oSqlCommand.Parameters.AddWithValue("@SysID2", clid);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectParticipantDataByCardID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT P.RegistrationNo, P.CardID ,R.ShortName, P.Initials, P.Surname, C.CountryName, P.ParticipantImage " +
                           " FROM tblCountry C  INNER JOIN tblParticipants P  ON C.CountryID = P.CountryID INNER JOIN tblRanks R  ON P.RankID = R.RankID  WHERE CardID=@CardID AND Status=1 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@CardID", oCMNParticipants.CardID);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectmeet(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT * FROM [vidconf].[dbo].[meet] where [uid]='"+id+ "' and Convert(date,mdate)=Convert(date,GETDATE()) order by [mdate] desc";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectcurusers(string id,DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT b.Surname,a.callerid,a.channel "+
 " FROM[dbo].[conflist] as a  left outer join[dbo].[tblParticipants] as b  on a.callerid = b.CardID  where  a.channel = '" + id + "'  and a.status = 2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
               public DataTable selectimg(string id,DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT SeatRowNo FROM [dbo].[tblParticipants]  where CardID='" + id+"' ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectver(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT vname FROM [dbo].[version]  ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectAllusers(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT * FROM [dbo].[conflist] WITH (NOLOCK) where callerid='" + id+ "' and status =2 ";
                          
                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectAllParticipantData(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT  P.CardID , P.Surname,  P.ParticipantImage,P.Initials" +
                           "  FROM [dbo].tblParticipants  P   WHERE p.Status=1 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable searchParticipantData(string tst,DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT  P.CardID , P.Surname,  P.ParticipantImage,P.Initials" +
                           "   FROM [dbo].tblParticipants  P    WHERE p.Status=1 and P.Surname like '%" + tst+ "%'  ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
             public DataSet selectjoin(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status] " +
       " FROM [dbo].[conflist]  WITH (NOLOCK) where channel ='" + id + "' and status=5 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectcall(string id,DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status] "+
       " FROM [dbo].[conflist]  WITH (NOLOCK) where callerid ='" + id+ "' and status=1 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable selectmeeeting(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT [cid],[callerid],[channel],[url],[status],[isadmin] FROM [dbo].[conflist] where [isadmin]=1 and [status]=2 and channel='"+id+"'";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectactveconf(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status] " +
       " FROM [dbo].[conflist]  WITH (NOLOCK) where callerid ='" + id + "' and status=2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet selectactvemt(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT *  FROM [vidconf].[dbo].[meet] WHERE GETDATE() >= [mdate] and [uid]='" + id + "' and convert(date,[mdate])=convert(date,GETDATE()) order by [mdate] desc ";


                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet selectactvcnt(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status] " +
       " FROM [dbo].[conflist]  WITH (NOLOCK) where channel ='" + id + "' and status=2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectadmin(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status] " +
       " FROM [dbo].[conflist]  WITH (NOLOCK) where callerid ='" + id + "' and status=2 and isadmin=1 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet selectadmincount(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status]  "+
     "  FROM[dbo].[conflist]  WITH(NOLOCK) where[channel] in (select[channel] FROM[dbo].[conflist] where callerid = '"+id+"' and status = 2 "+

     "  and isadmin = 1 )and status = 2 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet selectwait(string id, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataSet oDataTable = new DataSet();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT  [cid] ,[callerid],[channel],[url],[status] " +
       " FROM [dbo].[conflist] WITH (NOLOCK) where cid ='" + id + "' and (status!=1 and status!=5) ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
