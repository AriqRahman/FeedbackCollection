using FeedbackCollectionAPI.DataManager.IRepository;
using FeedbackCollectionAPI.Models;
using FeedbackCollectionAPI.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackCollectionAPI.DataManager.RepositoryManager
{
    public class PostRepositoryManager : IPostRepository, IDisposable
    {

        private readonly Feedback_Collection_DBContext _context;
        private readonly string _connectionString;
        public PostRepositoryManager(Feedback_Collection_DBContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("FeedbackCollectionConnectionString");
        }

        public List<PostInfoVM> GetPostInformation()
        {

            List<PostInfoVM> objectList = new List<PostInfoVM>();
            try
            {

                DataTable dt = new DataTable();
                

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SPGetPostInformation", connection);
                    command.Parameters.Clear();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader;
                        reader = command.ExecuteReader();
                        dt.Load(reader);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        objectList.Add(new PostInfoVM()
                        {
                            PostId = Convert.ToInt32(dr["PostId"]),
                            PostName = dr["PostName"].ToString(),
                            PostComments = dr["PostComments"].ToString(),
                            UserName = dr["UserName"].ToString(),
                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            LikeCount = dr["LikeCount"].ToString(),
                            DislikeCount = dr["DislikeCount"].ToString()

                        });
                    }
                }


                return objectList;

            }
            catch (Exception ex)
            {
                return objectList;
            }



        }






        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PostRepositoryManager()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion






    }
}
