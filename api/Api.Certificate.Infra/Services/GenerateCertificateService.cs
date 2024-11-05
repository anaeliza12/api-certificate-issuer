using Api.Certification.AppDomain.Commands.request;
using Api.Certification.AppDomain.Interfaces;
using Api.Certification.Infra.ApiSettings.AppSettings;
using SelectPdf;
using System.Net.Http;

namespace Api.Certification.Infra.Services
{
    public class GenerateCertificateService(TemplateConfig templateConfig, HttpClient httpClient) : IGenerateCertificateService
    {

        private readonly TemplateConfig _templateConfig = templateConfig;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<byte[]> GenerateCertificateAsync(GenerateCertificateRequest request)
        {
            var template = await File.ReadAllTextAsync(_templateConfig.TemplatePath);

            var htmlContent = template
                .Replace("[[nome]]", request.StudentModel.Name)
                .Replace("[[curso]]", request.StudentModel.Course)
                .Replace("[[nacionalidade]]", request.StudentModel.Nationality);

            var pdfBytes = GeneratePdf(htmlContent);
            return pdfBytes;
        }
        private byte[] GeneratePdf(string htmlContent)
        {
            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;

            PdfDocument doc = converter.ConvertHtmlString(htmlContent);

            byte[] pdfFile = doc.Save();
            doc.Close();

            return pdfFile;
        }
    }
}
