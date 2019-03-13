using System;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.GenericData;

namespace WpfOrganization.ViewModel
{
    public class OrderOnCableTVViewModel
    {
        

        IOrderService _orderService;

        public OrderOnCableTVViewModel(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        void Index()
        {
            
        }
    }
}
