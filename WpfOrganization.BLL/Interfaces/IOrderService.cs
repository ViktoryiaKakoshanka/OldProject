using System;
using System.Collections.Generic;
using WpfOrganization.BLL.DTO;

namespace WpfOrganization.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderOnCableTVDTO orderDTO);
        void DelegateToMaster(MasterDTO masterDTO);

        void Controlate();
        void Controlate(DateTime dateControlated);

        void Complete();
        void Complete(DateTime dateCompleted);

        IEnumerable<OrderOnCableTVDTO> GetUndelegatedOrdersOnCableTV();

        void Dispose();
    }
}
