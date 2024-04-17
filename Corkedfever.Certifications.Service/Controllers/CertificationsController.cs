using Corkedfever.Certifications.Data.Models;
using Corkedfever.Certifications.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Certifications.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificationsController : ControllerBase
    {

        private readonly ICertificationService _certificationService;

        public CertificationsController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }

        [HttpGet]
        public IActionResult GetCertifications()
        {
            try
            {
                return Ok(_certificationService.GetCertifications());

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCertificationById(int id)
        {
            try
            {
                return Ok(_certificationService.GetCertificationById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetCertificationByName(string name)
        {
            try
            {
                return Ok(_certificationService.GetCertificationByName(name));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("types/{id}/certifications")]
        public IActionResult GetCertificationsByType(int id)
        {
            try
            {
                return Ok(_certificationService.GetCertificationsByType(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetCertificationTypes()
        {
            try
            {
                return Ok(_certificationService.GetCertificationTypes());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("types/{id}")]
        public IActionResult GetCertificationType(int id)
        {
            try
            {
                return Ok(_certificationService.GetCertificationTypeById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(CertificationModel certification)
        {
            try
            {
                _certificationService.AddCertification(certification);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("types")]
        public IActionResult Post(CertificationTypesModel certificationType)
        {
            try
            {
                _certificationService.AddCertificationType(certificationType);
                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
