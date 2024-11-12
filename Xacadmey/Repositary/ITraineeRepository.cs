using System.Collections.Generic;
using Xacadmey.Models;

namespace Xacadmey.Repositary
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAll();
        Trainee GetById(int id);
        void Insert(Trainee t);
        void Update(Trainee t);
        void Delete(int id);
    }
}

