
using Api.Certification.AppDomain.Commands.request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Certification.Controller
{
    [ApiController]
    [Route("api/[controller]")]


    public class CertificateController: ControllerBase
    {
        public readonly IMediator _mediator;

        public CertificateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("v1/generate")]
        public async Task<IActionResult> GenerateCertificate([FromBody] GenerateCertificateRequest request)
        {
            return Ok("oi");
        }
    }
}
