using Api.Certification.AppDomain.Commands.request;
using MediatR;
using Api.Certification.AppDomain.Interfaces;

namespace Api.Certification.AppDomain.Handler
{
    public class GenerateCertificateHandler : IRequestHandler<GenerateCertificateRequest, GenerateCertificateResponse>
    {

        private readonly IGenerateCertificate _generateService;

        public GenerateCertificateHandler(IGenerateCertificate generateService)
        {
            _generateService = generateService;
        }

        public async Task<GenerateCertificateResponse> Handle(GenerateCertificateRequest request, CancellationToken cancellationToken)
        {
            var response = new GenerateCertificateResponse();

            response = await _generateService.GenerateCertificateAsync();
            throw new NotImplementedException();
        }
    }
}
