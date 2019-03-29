using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models.Connection
{
    public class ConnectionModel
    {
        [Required]
        public string DataSource { get; set; }
        public string AttachDBFilename { get; set; }
        [Required]
        public string InitialCatalog { get; set; }
        [Required]
        public bool IntegratedSecurity { get; set; }
        public string User { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}