using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd
{
    public class UserDetails
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public bool isAddUser { get; set; }
        public string emails { get; set; }
        public string emailsA { get; set; }
        public string emailsM { get; set; }
        public int emailMicroID { get; set; }
        public string GPhoto { get; set; }

        public void CheckID(string username, string password)
        {
            Username = "";
            UserID = 0;
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand login = new SqlCommand();
                login.Connection = myConn;
                myConn.Open();

                login.Parameters.AddWithValue("@username", username);
                login.Parameters.AddWithValue("@password", password);

                login.CommandText = ("[spLogin]");
                login.CommandType = System.Data.CommandType.StoredProcedure;

                var result = login.ExecuteScalar();

                if (result != null)
                {
                    UserID = Convert.ToInt32(result);
                    Username = username;
                }
                myConn.Close();
            }
        }

        public void EmailChanges(int UserID)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                //gmail
                SqlCommand returnEmail = new SqlCommand();
                returnEmail.Connection = myConn;
                myConn.Open();

                returnEmail.Parameters.AddWithValue("@UserID", UserID);

                returnEmail.CommandText = ("[spEmailReturn]");
                returnEmail.CommandType = System.Data.CommandType.StoredProcedure;

                var email = returnEmail.ExecuteScalar();

                if (email != null)
                {
                    emails = Convert.ToString(email);
                }

                //apple
                SqlCommand returnApple = new SqlCommand();
                returnApple.Connection = myConn;

                returnApple.Parameters.AddWithValue("@UserID", UserID);

                returnApple.CommandText = ("[spEmailApple]");
                returnApple.CommandType = System.Data.CommandType.StoredProcedure;

                var emailApple = returnApple.ExecuteScalar();

                if (emailApple != null)
                {
                    emailsA = Convert.ToString(emailApple);
                }

                //microsoft
                SqlCommand returnMicro = new SqlCommand();
                returnMicro.Connection = myConn;

                returnMicro.Parameters.AddWithValue("@UserID", UserID);

                returnMicro.CommandText = ("[spEmailMicro]");
                returnMicro.CommandType = System.Data.CommandType.StoredProcedure;

                var emailMicro = returnMicro.ExecuteScalar();

                if (emailMicro != null)
                {
                    emailsM = Convert.ToString(emailMicro);
                }

                myConn.Close();
            }
        }

        public void PhotoChanges(int UserID)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                //gmail
                SqlCommand returnEmail = new SqlCommand();
                returnEmail.Connection = myConn;
                myConn.Open();

                returnEmail.Parameters.AddWithValue("@UserID", UserID);

                returnEmail.CommandText = ("[spPhotoAccountReturn]");
                returnEmail.CommandType = System.Data.CommandType.StoredProcedure;

                var email = returnEmail.ExecuteScalar();

                if (email != null)
                {
                    GPhoto = Convert.ToString(email);
                }
            }
        }
    }
}