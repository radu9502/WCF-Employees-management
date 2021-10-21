using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesService
{
    [ServiceContract]
    public interface IManageEmployees
    {
        [OperationContract]
        void Add(Employee emp);

        [OperationContract]
        void Edit(Employee emp);

        [OperationContract]
        string Read(Employee emp);

        [OperationContract]
        void Delete(Employee emp);

        [OperationContract]
        void Update(Employee emp);
      


    }
}
