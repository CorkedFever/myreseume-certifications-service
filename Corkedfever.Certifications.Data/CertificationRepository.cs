using Corkedfever.Certifications.Data.Models;
using Corkedfever.Common.Data;
using Corkedfever.Common.Data.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkedfever.Certifications.Data
{
    public interface ICertificationRepository
    {
        void AddCertification(CertificationModel certification);
        void AddCertificationType(CertificationTypesModel certificationType);
        CertificationModel GetCertificationById(int id);
        CertificationModel GetCertificationByName(string name);
        List<CertificationModel> GetCertifications();
        CertificationTypesModel GetCertificationsByType(int id);
        CertificationTypesModel GetCertificationTypeById(int id);
        List<CertificationTypesModel> GetCertificationTypes();
    }
    public class CertificationRepository : ICertificationRepository
    {
        private readonly IDbContextFactory<CorkedFeverDataContext> _context;
        public CertificationRepository(IDbContextFactory<CorkedFeverDataContext> _corkedfeverDataContext) 
        { 
            _context = _corkedfeverDataContext;
        }
        public void AddCertification(CertificationModel certification)
        {
            using (var context = _context.CreateDbContext())
            {
                var getCertificationType = context.CertificationType.FirstOrDefault(x => x.CertificationTypeName == certification.CertificationType.CertificationTypeName);
                
                if(getCertificationType == null)
                {
                    return;
                }

                var newCertification = new Certification
                {
                    CertificationName = certification.CertificationName,
                    CertificationDescription = certification.CertificationDescription,
                    CertificationType = getCertificationType
                };
                context.Certification.Add(newCertification);
                context.SaveChanges();
            }
        }

        public void AddCertificationType(CertificationTypesModel certificationType)
        {
            using (var context = _context.CreateDbContext())
            {
                var newCertificationType = new CertificationType
                {
                    
                    CertificationTypeName = certificationType.CertificationTypeName,
                    CertificationTypeDescription = certificationType.CertificationTypeDescription,
                };
                context.CertificationType.Add(newCertificationType);
                context.SaveChanges();
            }
        }

        public CertificationModel GetCertificationById(int id)
        {
            using (var context = _context.CreateDbContext())
            {
                var certification = context.Certification.Include(x => x.CertificationType).FirstOrDefault(x => x.Id == id);
                if(certification == null)
                {
                    return null;
                }
                return new CertificationModel
                {
                    CertificationName = certification.CertificationName,
                    CertificationDescription = certification.CertificationDescription,
                    CertificationType = new CertificationTypesModel
                    {
                        CertificationTypeName = certification.CertificationType.CertificationTypeName,
                        CertificationTypeDescription = certification.CertificationType.CertificationTypeDescription
                    }
                };
            }
        }

        public CertificationModel GetCertificationByName(string name)
        {
            using (var context = _context.CreateDbContext())
            {
                var certification = context.Certification.Include(x => x.CertificationType).FirstOrDefault(x => x.CertificationName == name);
                if(certification == null)
                {
                    return null;
                }
                return new CertificationModel
                {
                    CertificationName = certification.CertificationName,
                    CertificationDescription = certification.CertificationDescription,
                    CertificationType = new CertificationTypesModel
                    {
                        CertificationTypeName = certification.CertificationType.CertificationTypeName,
                        CertificationTypeDescription = certification.CertificationType.CertificationTypeDescription
                    }
                };
            }
        }

        public List<CertificationModel> GetCertifications()
        {
            using (var context = _context.CreateDbContext())
            {
                var certifications = context.Certification.Include(x => x.CertificationType).ToList();
                if(certifications == null)
                {
                    return null;
                }
                return certifications.Select(x => new CertificationModel
                {
                    CertificationName = x.CertificationName,
                    CertificationDescription = x.CertificationDescription,
                    CertificationType = new CertificationTypesModel
                    {
                        CertificationTypeName = x.CertificationType.CertificationTypeName,
                        CertificationTypeDescription = x.CertificationType.CertificationTypeDescription
                    }
                }).ToList();
            }
        }

        public CertificationTypesModel GetCertificationsByType(int id)
        {
            using (var context = _context.CreateDbContext())
            {
                var certificationType = context.CertificationType.FirstOrDefault(x => x.Id == id);
                if(certificationType == null)
                {
                    return null;
                }
                return new CertificationTypesModel
                {
                    CertificationTypeName = certificationType.CertificationTypeName,
                    CertificationTypeDescription = certificationType.CertificationTypeDescription
                };
            }
        }

        public CertificationTypesModel GetCertificationTypeById(int id)
        {
            using (var context = _context.CreateDbContext())
            {
                var certificationType = context.CertificationType.FirstOrDefault(x => x.Id == id);
                if(certificationType == null)
                {
                    return null;
                }
                return new CertificationTypesModel
                {
                    CertificationTypeName = certificationType.CertificationTypeName,
                    CertificationTypeDescription = certificationType.CertificationTypeDescription
                };
            }

        }

        public List<CertificationTypesModel> GetCertificationTypes()
        {
            using (var context = _context.CreateDbContext())
            {
                var certificationTypes = context.CertificationType.ToList();
                if(certificationTypes == null)
                {
                    return null;
                }
                return certificationTypes.Select(x => new CertificationTypesModel
                {
                    CertificationTypeName = x.CertificationTypeName,
                    CertificationTypeDescription = x.CertificationTypeDescription
                }).ToList();
            }
        }
    }
}
