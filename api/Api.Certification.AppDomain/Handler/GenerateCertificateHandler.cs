using Api.Certification.AppDomain.Commands.request;
using MediatR;
using Api.Certification.AppDomain.Interfaces;
using Api.Certification.AppDomain.Model;
using Api.Certification.AppDomain.Utils;
using Api.Certification.AppDomain.Utils.AppSettings;

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

            var PdfFile = new PdfFileModel()
            {
                FileName = request.StudentModel.GeneratePdfFileName(),
                FilePath = TemplateConfig.FilePath
            };

            var student = generateService.SaveStudentAsync(request.StudentModel);
            var certificate = generateService.SaveCertificateAsync(PdfFile);

            await Task.WhenAll(student, certificate);
            return response;
        }
    }
}
