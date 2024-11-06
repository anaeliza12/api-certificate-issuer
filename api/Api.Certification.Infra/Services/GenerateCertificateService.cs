using Api.Certification.AppDomain.Commands.request;
using Api.Certification.AppDomain.Interfaces;
using Api.Certification.AppDomain.Model;
using Api.Certification.AppDomain.Utils.AppSettings;
using Api.Certification.Infra.ApiSettings.Repositories.Context;
using SelectPdf;

namespace Api.Certification.Infra.Services
{
    public class GenerateCertificateService : IGenerateCertificateService
    {
        private readonly MySQLContext _Dbcontext;
        public GenerateCertificateService(MySQLContext Dbcontext)
        {
            _Dbcontext = Dbcontext;
        }

        public async Task<byte[]> GenerateCertificateAsync(GenerateCertificateRequest request)
        {
            var template = await File.ReadAllTextAsync(TemplateConfig.TemplatePath);

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

        public async Task<PdfFileModel> SaveCertificateAsync(PdfFileModel PdfFile)
        {
            var pdfSaved = _Dbcontext.PdfFile.Add(PdfFile);
            var rowsAffected = await _Dbcontext.SaveChangesAsync();

            if (rowsAffected < 1)
            {
                throw new Exception("It was not possible to save: " + PdfFile.FileName + " in database");
            }

            return pdfSaved.Entity;
        }
        public async Task<StudentModel> SaveStudentAsync(StudentModel student)
        {
            var studentSaved =  _Dbcontext.Student.Add(student);
            var rowsAffected = await _Dbcontext.SaveChangesAsync();

            if(rowsAffected < 1)
            {
                throw new Exception("It was not possible to save: " + student.Name + " in database");
            }

            return studentSaved.Entity;
        }
        private byte[] GeneratePdf(string htmlContent)
        {
            string htmlEnginePath = TemplateConfig.SelectHtmlPath;

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
