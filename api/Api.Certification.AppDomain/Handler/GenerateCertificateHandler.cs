using Api.Certification.AppDomain.Commands.request;
using MediatR;
using Api.Certification.AppDomain.Interfaces;

namespace Api.Certification.AppDomain.Handler
{
    public class GenerateCertificateHandler(IGenerateCertificateService generateService) : IRequestHandler<GenerateCertificateRequest, GenerateCertificateResponse>
    {
        private readonly IGenerateCertificateService _generateService = generateService;

        public async Task<GenerateCertificateResponse> Handle(GenerateCertificateRequest request, CancellationToken cancellationToken)
        {
            var pdfBytes = await _generateService.GenerateCertificateAsync(request);

            var response = new GenerateCertificateResponse()
            {
                Certificate = pdfBytes
            };

            return response;
        }
    }
}
