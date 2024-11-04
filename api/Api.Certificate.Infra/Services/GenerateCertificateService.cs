using Api.Certification.AppDomain.Commands.request;
using Api.Certification.AppDomain.Interfaces;
using MediatR;

namespace Api.Certification.Infra.Services
{
    public class GenerateCertificateService : IGenerateCertificateService
    {
        public async Task<string> GenerateCertificateAsync(GenerateCertificateRequest request)
        {
            var template = await File.ReadAllTextAsync("caminho/para/o/template.html");

            var htmlContent = template
                .Replace("{{Nome}}", request.StudentModel.Name)
                .Replace("{{Curso}}", request.StudentModel.Course)
                .Replace("{{DataConclusao}}", request.StudentModel.ConclusionDate);

            var pdfBase64 = ConverterHtmlParaPdf(htmlContent);

            return pdfBase64;
        }
        private string ConverterHtmlParaPdf(string html)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var converter = new BasicConverter(new PdfTools());
                var doc = new HtmlToPdfDocument
                {
                    GlobalSettings = { ColorMode = ColorMode.Color, Orientation = Orientation.Portrait, PaperSize = PaperKind.A4 }
                };
                doc.ObjectSettings.Add(new ObjectSettings { HtmlContent = html });
                converter.Convert(doc);

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
