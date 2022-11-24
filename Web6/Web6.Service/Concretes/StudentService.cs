
using Web6.Data.Entities;
using Web6.Infra.DataAccess;
using Web6.Infra.Service;
using Web6.Service.Abstracts;

namespace Web.Service.Concretes
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IDataContext dbContext) : base(dbContext)
        {
        }
    }
}
