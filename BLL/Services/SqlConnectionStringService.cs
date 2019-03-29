using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SqlConnectionStringService: IConnectionStringService
    {
        SqlConnectionStringBuilder builder;
        public SqlConnectionStringService()
        {
            builder = new SqlConnectionStringBuilder();
        }
        public string DataSource
        {
            get => builder.DataSource;
            set => builder.DataSource = value;
        }
        public string InitialCatalog
        {
            get => builder.InitialCatalog;
            set => builder.InitialCatalog = value;
        }
        public string AttachDBFilename
        {
            get => builder.AttachDBFilename;
            set => builder.AttachDBFilename = value;
        }
        public bool IntegratedSecurity
        {
            get => builder.IntegratedSecurity;
            set => builder.IntegratedSecurity = value;
        }
        public string User
        {
            get => builder.UserID;
            set => builder.UserID = value;
        }
        public string Password
        {
            get => builder.Password;
            set => builder.Password = value;
        }
        public int ConnectionTimeout
        {
            get => builder.ConnectTimeout;
            set
            {
                if (value > 0)
                    builder.ConnectTimeout = value;
            }
        }

        public string ConnectionString()
        {
            return builder.ConnectionString;
        }
    }
}
