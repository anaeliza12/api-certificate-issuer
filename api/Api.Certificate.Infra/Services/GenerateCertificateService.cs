using Api.Certification.AppDomain.Commands.request;
using Api.Certification.AppDomain.Interfaces;
using Api.Certification.Infra.ApiSettings.AppSettings;
using SelectPdf;

namespace Api.Certification.Infra.Services
{
    public class GenerateCertificateService(TemplateConfig templateConfig) : IGenerateCertificateService
    {
        private readonly TemplateConfig _templateConfig = templateConfig;

        public async Task<byte[]> GenerateCertificateAsync(GenerateCertificateRequest request)
        {
            var template = await File.ReadAllTextAsync(_templateConfig.TemplatePath);

            var htmlContent = template
                .Replace("[[nome]]", request.StudentModel.Name)
                .Replace("[[curso]]", request.StudentModel.Course)
                .Replace("[[nacionalidade]]", request.StudentModel.Nationality)
                .Replace("[[estado]]", request.StudentModel.State)
                .Replace("[[data_nascimento]]", request.StudentModel.BirthDate)
                .Replace("[[documento]]", request.StudentModel.RG)
                .Replace("[[data_conclusao]]", request.StudentModel.ConclusionDate)
                .Replace("[[carga_horaria]]", request.StudentModel.WorkLoad)
                .Replace("[[data_emissao]]", request.StudentModel.IssueDate)
                .Replace("[[nome_assinatura]]", request.StudentModel.Sign)
                .Replace("[[cargo]]", request.StudentModel.Role);

            var pdfBytes = GeneratePdf(htmlContent);
            return pdfBytes;
        }
        private byte[] GeneratePdf(string htmlContent)
        {
            string htmlEnginePath = _templateConfig.SelectHtmlPath;

            GlobalProperties.HtmlEngineFullPath = htmlEnginePath;

            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;

            PdfDocument doc = converter.ConvertHtmlString(htmlContent);

            byte[] pdfFile = doc.Save();
            doc.Close();

            return pdfFile;
        }
    }
}
