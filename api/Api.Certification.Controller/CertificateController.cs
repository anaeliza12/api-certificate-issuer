﻿using Api.Certification.AppDomain.Commands.request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Certification.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController(IMediator mediator) : ControllerBase
    {
        public readonly IMediator _mediator = mediator;

        [HttpPost("v1/generate")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        public async Task<IActionResult> GenerateCertificate(GenerateCertificateRequest request)
        {
            var response = await _mediator.Send(request);

            return File(response.Certificate, "application/pdf", "certificado.pdf");
        }

    }
}
