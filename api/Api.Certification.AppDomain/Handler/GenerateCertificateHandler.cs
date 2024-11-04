using Api.Certification.AppDomain.Commands.request;
using MediatR;
using Api.Certification.AppDomain.Interfaces;

namespace Api.Certification.AppDomain.Handler
{
    public class GenerateCertificateHandler : IRequestHandler<GenerateCertificateRequest, GenerateCertificateResponse>
    {

        private readonly IGenerateCertificateService _generateService;

        public GenerateCertificateHandler(IGenerateCertificateService generateService)
        {
            _generateService = generateService;
        }

        public async Task<GenerateCertificateResponse> Handle(GenerateCertificateRequest request, CancellationToken cancellationToken)
        {

            var response = await _generateService.GenerateCertificateAsync(request);
            throw new NotImplementedException();
        }
    }
}
