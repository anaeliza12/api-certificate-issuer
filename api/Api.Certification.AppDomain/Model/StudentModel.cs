using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Certification.AppDomain.Model
{
    public class StudentModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        public string BithDate { get; set; }
        public string RG { get; set; }
        public string ConclusionDate { get; set; }
        public string IssueDate { get; set; }
        public string Course { get; set; }
        public string WorkLoad { get; set; }
        public string Sign { get; set; }
        public string Role { get; set; }

        public StudentModel(long id, string name, string nationality, string state,
            string bithDate, string rG, string conclusionDate, string issueDate, string course, string workLoad, string sign, string role)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
            State = state;
            BithDate = bithDate;
            RG = rG;
            ConclusionDate = conclusionDate;
            IssueDate = issueDate;
            Course = course;
            WorkLoad = workLoad;
            Sign = sign;
            Role = role;
        }

    }
}
