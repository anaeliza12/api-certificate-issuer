using Api.Certification.AppDomain.Model;
using MediatR;

namespace Api.Certification.AppDomain.Handler.request
{
    public class GenerateCertificateRequest : IRequest<GenerateCertificateResponse>
    {
        public StudentModel StudentModel { get; set; }     
    }
}
