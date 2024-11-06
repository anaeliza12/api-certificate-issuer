using Api.Certification.AppDomain.Commands.request;
using Api.Certification.AppDomain.Model;

namespace Api.Certification.AppDomain.Interfaces
{
    public interface IGenerateCertificateService
    {
        Task<byte[]> GenerateCertificateAsync(GenerateCertificateRequest request);
        Task<PdfFileModel> SaveCertificateAsync(PdfFileModel PdfFile);
        Task<StudentModel> SaveStudentAsync(StudentModel student);
        //Task<StudentModel> FindCertificateAsync(StudentModel student);
    }
}
