using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Certification.AppDomain.Handler.request
{
    public class GenerateCertificateRequest : IRequest<GenerateCertificateResponse>
    {
        public AlunoModel AlunoModel { get; set; }
    }
}
