using System.Threading.Tasks;
using Corkedfever.Educations.Data;
using Corkedfever.Educations.Data.Models;
namespace Corkedfever.Educations.Business
{
    public interface IEducationService
    {
        void CreateEducation(EducationModel education);
        EducationModel GetEducationById(int id);
        EducationModel GetEducationByName(string name);
        List<EducationModel> GetEducations();
    }
    public class EducationService : IEducationService
    {
        public readonly IEducationRepository _educationRepository;
        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }
        public void CreateEducation(EducationModel education)
        {
            _educationRepository.CreateEducation(education);
        }

        public EducationModel GetEducationById(int id)
        {
            return _educationRepository.GetEducationById(id);
        }

        public EducationModel GetEducationByName(string name)
        {
            return _educationRepository.GetEducationByName(name);
        }

        public List<EducationModel> GetEducations()
        {
            return _educationRepository.GetEducations();
        }
    }
}
