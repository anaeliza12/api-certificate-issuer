using Api.Certification.AppDomain.Commands.request;

namespace Api.Certification.AppDomain.Interfaces
{
    public interface IGenerateCertificateService
    {
        Task<string> GenerateCertificateAsync(GenerateCertificateRequest request);
    }
}
