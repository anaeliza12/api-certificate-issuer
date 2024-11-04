using Api.Certification.AppDomain.Commands.request;

namespace Api.Certification.AppDomain.Interfaces
{
    public interface IGenerateCertificate
    {
        Task<string> GenerateCertificateAsync(GenerateCertificateRequest request);
    }
}
