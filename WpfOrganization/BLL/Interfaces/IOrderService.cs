using System.Collections.Generic;
using WpfOrganization.BLL.DTO;

namespace WpfOrganization.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderOnCableTVDTO orderDTO);

        MasterDTO GetMaster(int idMaster);
        IEnumerable<MasterDTO> GetMasters();

        CableTVProblemDTO GetCableTVProblem(int idProblem);
        IEnumerable<CableTVProblemDTO> GetCableTVProblems();

        void Dispose();
    }
}
