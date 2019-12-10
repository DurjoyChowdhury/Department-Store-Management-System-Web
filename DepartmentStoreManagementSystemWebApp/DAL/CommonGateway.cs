using System.Data.SqlClient;
using System.Web.Configuration;

namespace HospitalManagementSystemWebApp.Getway
{
    public class CommonGateway
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["DepartmentStoreManagementSystem"].ConnectionString;
        public SqlConnection Connection { set; get; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public string Query { set; get; }

        public CommonGateway()
        {
            Connection=new SqlConnection(connectionstring);
        }
    }
}