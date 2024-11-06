using Api.Certification.AppDomain.Commands.request;
using Api.Certification.AppDomain.Model;

namespace Api.Certification.AppDomain.Interfaces
{
    public interface IGenerateCertificateService
    {
        Task<byte[]> GenerateCertificateAsync(GenerateCertificateRequest request);
        Task<StudentModel> TesteBanco();
    }
}
