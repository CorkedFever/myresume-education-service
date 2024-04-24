using Corkedfever.Educations.Data.Models;
using Corkedfever.Common.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Corkedfever.Common.Data.DBModels;
namespace Corkedfever.Educations.Data
{
    public interface IEducationRepository
    {
        void CreateEducation(EducationModel education);
        EducationModel GetEducationById(int id);
        EducationModel GetEducationByName(string name);
        List<EducationModel> GetEducations();
    }
    public class EducationRepository : IEducationRepository
    {
        public readonly IDbContextFactory<CorkedFeverDataContext> _context;
        public EducationRepository(IDbContextFactory<CorkedFeverDataContext> corkedFeverDataContext ) 
        {
            _context = corkedFeverDataContext;
        }
        public void CreateEducation(EducationModel education)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var something = dbContext.Email.FirstOrDefault();
                var something2 = dbContext.Skill.FirstOrDefault();
                var Something3 = dbContext.Education.FirstOrDefault();
                var newEducation = new Education
                { 
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    Major = education.Major,
                    Minor = education.Minor,
                    GraduationDate = education.GraduationDate,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                dbContext.Education.Add(newEducation);
                dbContext.SaveChanges();
            }   
        }

        public EducationModel GetEducationById(int id)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var educationEntry = dbContext.Education.FirstOrDefault(i => i.Id == id);
                if (educationEntry == null)
                {
                    return null;
                }
                return new EducationModel
                {
                    SchoolName = educationEntry.SchoolName,
                    Degree = educationEntry.Degree,
                    Major = educationEntry.Major,
                    Minor = educationEntry.Minor,
                    GraduationDate = educationEntry.GraduationDate
                };
            }
        }

        public EducationModel GetEducationByName(string name)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var educationEntry = dbContext.Education.FirstOrDefault(i => i.SchoolName.ToLower() == name.ToLower());
                if (educationEntry == null)
                {
                    return null;
                }
                return new EducationModel
                {
                    SchoolName = educationEntry.SchoolName,
                    Degree = educationEntry.Degree,
                    Major = educationEntry.Major,
                    Minor = educationEntry.Minor,
                    GraduationDate = educationEntry.GraduationDate
                };
            }
        }

        public List<EducationModel> GetEducations()
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var educationEntries = dbContext.Education.ToList();
                if (educationEntries == null)
                {
                    return null;
                }
                return educationEntries.Select(e => new EducationModel
                {
                    SchoolName = e.SchoolName,
                    Degree = e.Degree,
                    Major = e.Major,
                    Minor = e.Minor,
                    GraduationDate = e.GraduationDate
                }).ToList();
            }
        }
    }
}
