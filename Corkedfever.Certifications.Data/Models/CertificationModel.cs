using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corkedfever.Certifications.Data.Models;

namespace Corkedfever.Certifications.Data.Models
{
    public class CertificationModel
    {
        public string CertificationName { get; set; }
        public string CertificationDescription { get; set; }
        public CertificationTypesModel CertificationType { get; set; }

    }
}
