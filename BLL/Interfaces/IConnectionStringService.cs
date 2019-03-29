using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IConnectionStringService
    {
        string DataSource { get; set; }
        string InitialCatalog { get; set; }
        string AttachDBFilename { get; set; }
        bool IntegratedSecurity { get; set; }
        string User { get; set; }
        string Password { get; set; }
        int ConnectionTimeout { get; set; }
        string ConnectionString();
    }
}
