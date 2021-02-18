using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBRepository
{
    public class UserAccountRepository : IUserAccountInterface<UserModel>
    {
        public Task<string> AddUser(UserModel entity)
        {
            throw new System.NotImplementedException();
        }



        public Task<string> DeleteUser(UserModel entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserModel>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserModel> GetUserByName()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateUser(UserModel entity)
        {
            throw new System.NotImplementedException();
        }
    }

    //public class UserAccountRepository : IUserAccountInterface<UserModel>
    //{
    //    enum DB_ACtion { Select = 0, SelectID, Insert, Update, Delete, isRecFound }

    //    public IDbConnection Connection { get; set; }

    //    readonly private static AppConstants appConst = new AppConstants();
    //    readonly string Sp_Name = appConst.Usp_CRUD_tb_AssetMaster;

    //    public AssetsRepository()
    //    {
    //        Connection = new SqlConnection(appConst.connectionString);
    //    }

    //    public List<AssetMasterModel> GetAllTablesInfo()
    //    {
    //        var list = Connection.Query<AssetMasterModel>("Usp_InsertUpdateDelete_tb_GetAllTablesInfo", commandType: CommandType.StoredProcedure).ToList();
    //        return list;
    //    }

    //    public DataSet GetDataSet(SqlConnection connection)
    //    {
    //        var command = new SqlCommand("Usp_InsertUpdateDelete_tb_GetAllTablesInfo", connection)
    //        { CommandType = CommandType.StoredProcedure };

    //        var result = new DataSet();
    //        var dataAdapter = new SqlDataAdapter(command);
    //        dataAdapter.Fill(result);
    //        dataAdapter.Dispose();
    //        return result;
    //    }

    //    public List<AssetMasterModel> GetAll()
    //    {
    //        var list = Connection.Query<AssetMasterModel>(Sp_Name, commandType: CommandType.StoredProcedure).ToList();
    //        return list;
    //    }
    //    public AssetMasterModel GetById(int id)
    //    {
    //        var list = Connection.Query<AssetMasterModel>(Sp_Name, commandType: CommandType.StoredProcedure).FirstOrDefault(x => x.ID == id);
    //        return list;
    //    }

    //    public string CreateItem(AssetMasterModel entity)
    //    {
    //        try
    //        {
    //            if (Connection.State == ConnectionState.Closed) Connection = new SqlConnection(appConst.connectionString); Connection.Open();

    //            using (Connection)
    //            {
    //                var param = new DynamicParameters();
    //                param.Add("@Description", entity.Description);
    //                param.Add("@MainTypeID", entity.MainTypeID);
    //                param.Add("@SubTypeID", entity.SubTypeID);
    //                param.Add("@Weight", entity.Weight);
    //                param.Add("@Quantity", entity.Quantity);
    //                param.Add("@DonorName", entity.DonorName);
    //                param.Add("@DonationPlace", entity.DonationPlace);
    //                param.Add("@DonorContact", entity.DonorContact);
    //                param.Add("@DonorEmail", entity.DonorEmail);
    //                param.Add("@DonorAddress", entity.DonorAddress);
    //                param.Add("@DonorPAN", entity.DonorPAN);
    //                param.Add("@DonationObjective", entity.DonationObjective);
    //                param.Add("@Remarks", entity.Remarks);
    //                param.Add("@Photo1", entity.Photo1);
    //                param.Add("@Photo2", entity.Photo2);
    //                param.Add("@Photo3", entity.Photo3);
    //                param.Add("@TranDate", entity.TranDate);
    //                param.Add("@ApproxValue", entity.ApproxValue);
    //                param.Add("@FirstPlace", entity.FirstPlace);
    //                param.Add("@SecondPlace", entity.SecondPlace);
    //                param.Add("@DateOfReceipt", DateTime.Now);
    //                param.Add("@ReceiptNo", 0);
    //                param.Add("@CreatedBy", entity.CreatedBy);
    //                param.Add("@CreatedOn", entity.CreatedOn);
    //                param.Add("@ModifiedBy", entity.CreatedBy);
    //                param.Add("@ModifiedOn", entity.CreatedOn);

    //                param.Add("@Action", DB_ACtion.Insert);
    //                param.Add("@Msg_StorProc", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
    //                Connection.Execute(Sp_Name, param, commandType: CommandType.StoredProcedure);

    //                appConst.MsgFrom_StorProc = param.Get<string>("@Msg_StorProc");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            appConst.MsgFrom_StorProc = ex.Message;
    //            throw;
    //        }
    //        return appConst.MsgFrom_StorProc;
    //    }

    //    public string EditItem(AssetMasterModel entity)
    //    {
    //        try
    //        {
    //            if (Connection.State == ConnectionState.Closed) Connection = new SqlConnection(appConst.connectionString); Connection.Open();
    //            using (Connection)
    //            {
    //                var param = new DynamicParameters();

    //                param.Add("@ID", entity.ID);
    //                param.Add("@Description", entity.Description);
    //                param.Add("@MainTypeID", entity.MainTypeID);
    //                param.Add("@SubTypeID", entity.SubTypeID);
    //                param.Add("@Weight", entity.Weight);
    //                param.Add("@Quantity", entity.Quantity);
    //                param.Add("@DonorName", entity.DonorName);
    //                param.Add("@DonationPlace", entity.DonationPlace);
    //                param.Add("@DonorContact", entity.DonorContact);
    //                param.Add("@DonorEmail", entity.DonorEmail);
    //                param.Add("@DonorAddress", entity.DonorAddress);
    //                param.Add("@DonorPAN", entity.DonorPAN);
    //                param.Add("@DonationObjective", entity.DonationObjective);
    //                param.Add("@Remarks", entity.Remarks);
    //                param.Add("@Photo1", entity.Photo1);
    //                param.Add("@Photo2", entity.Photo2);
    //                param.Add("@Photo3", entity.Photo3);
    //                param.Add("@ApproxValue", entity.ApproxValue);
    //                param.Add("@FirstPlace", entity.FirstPlace);
    //                param.Add("@ModifiedBy", entity.ModifiedBy);
    //                param.Add("@ModifiedOn", entity.ModifiedOn);

    //                param.Add("@Action", DB_ACtion.Update);
    //                param.Add("@Msg_StorProc", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

    //                Connection.Execute(Sp_Name, param, commandType: CommandType.StoredProcedure);
    //                appConst.MsgFrom_StorProc = param.Get<string>("@Msg_StorProc");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            appConst.MsgFrom_StorProc = ex.Message;
    //        }
    //        return appConst.MsgFrom_StorProc;
    //    }

    //    public string DeleteItem(AssetMasterModel entity)
    //    {
    //        try
    //        {
    //            if (Connection.State == ConnectionState.Closed) Connection = new SqlConnection(appConst.connectionString); Connection.Open();
    //            using (Connection)
    //            {
    //                var param = new DynamicParameters();
    //                param.Add("@ID", entity.ID);
    //                param.Add("@ModifiedBy", entity.ModifiedBy);
    //                param.Add("@ModifiedOn", entity.ModifiedOn);

    //                param.Add("@Action", DB_ACtion.Delete);
    //                param.Add("@Msg_StorProc", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

    //                Connection.Execute(Sp_Name, param, commandType: CommandType.StoredProcedure);
    //                appConst.MsgFrom_StorProc = param.Get<string>("@Msg_StorProc");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            appConst.MsgFrom_StorProc = ex.Message;
    //        }
    //        return appConst.MsgFrom_StorProc;
    //    }

    //    public List<SelectListItem> PopulateDropDown(string sqlQuery, string NameFld, string IDFld)
    //    {
    //        List<SelectListItem> li = new List<SelectListItem>();

    //        return li;

    //    }
    //}
}
