using Corkedfever.Education.Data.Models;
using Corkedfever.Common.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
namespace Corkedfever.Education.Data
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
            using (var context = _context.CreateDbContext())
            {
                var newEducation = new Corkedfever.Common.Data.DBModels.Education
                { 
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    Major = education.Major,
                    Minor = education.Minor,
                    GraduationDate = education.GraduationDate
                };
                context.Education.Add(newEducation);
                context.SaveChanges();
            }   
        }

        public EducationModel GetEducationById(int id)
        {
            using (var context = _context.CreateDbContext())
            {
                var educationEntry = context.Education.FirstOrDefault(i => i.Id == id);
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
            using (var context = _context.CreateDbContext())
            {
                var educationEntry = context.Education.FirstOrDefault(i => i.SchoolName.ToLower() == name.ToLower());
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
            using (var context = _context.CreateDbContext())
            {
                var educationEntries = context.Education.ToList();
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
