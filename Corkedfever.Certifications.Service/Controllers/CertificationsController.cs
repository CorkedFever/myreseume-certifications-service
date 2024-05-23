using Corkedfever.Certifications.Data.Models;
using Corkedfever.Certifications.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Certifications.Service.Controllers
{
    [Route("certifications")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {

        private readonly ICertificationService _certificationService;

        public CertificationsController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }

        [HttpGet("getAllCertifications")]
        [ProducesResponseType(typeof(List<CertificationModel>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpGet("GetCertification/{id}")]
        [ProducesResponseType(typeof(CertificationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpGet("getCertificationbyName/{name}")]
        [ProducesResponseType(typeof(CertificationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpGet("getCertificationByType/{id}")]
        [ProducesResponseType(typeof(CertificationTypesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpGet("GetAllCertificationTypes")]
        [ProducesResponseType(typeof(List<CertificationTypesModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpGet("GetCertificationType/{id}")]
        [ProducesResponseType(typeof(CertificationTypesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPost("CreateCertification")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateCertification(CertificationModel certification)
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

        [HttpPost("CreateCertificationTypes")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateCertificationType(CertificationTypesModel certificationType)
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
