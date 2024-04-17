using Corkedfever.Certifications.Data;
using Corkedfever.Certifications.Data.Models;
namespace Corkedfever.Certifications.Business
{
    public interface ICertificationService
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
    public class CertificationService : ICertificationService
    {
        public readonly ICertificationRepository _certificationRepository;
        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }
        public void AddCertification(CertificationModel certification)
        {
            _certificationRepository.AddCertification(certification);
        }

        public void AddCertificationType(CertificationTypesModel certificationType)
        {
            _certificationRepository.AddCertificationType(certificationType);
        }

        public CertificationModel GetCertificationById(int id)
        {
            return _certificationRepository.GetCertificationById(id);
        }

        public CertificationModel GetCertificationByName(string name)
        {
            return _certificationRepository.GetCertificationByName(name);
        }

        public List<CertificationModel> GetCertifications()
        {
            return _certificationRepository.GetCertifications();
        }

        public CertificationTypesModel GetCertificationsByType(int id)
        {
            return _certificationRepository.GetCertificationsByType(id);
        }

        public CertificationTypesModel GetCertificationTypeById(int id)
        {
            return _certificationRepository.GetCertificationTypeById(id);
        }

        public List<CertificationTypesModel> GetCertificationTypes()
        {
            return _certificationRepository.GetCertificationTypes();
        }
    }
}
