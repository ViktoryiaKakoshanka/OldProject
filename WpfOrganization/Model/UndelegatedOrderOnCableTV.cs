using System;
using WpfOrganization.BLL.DTO;

namespace WpfOrganization.Model
{
    public class UndelegatedOrderOnCableTV
    {
        public bool IsCollectiveOrder { get; }
        public int NumberOfContract { get; }
        public string SubscriberSurname { get; }
        public string SubscriberName { get; }
        public string SubscriberPatronymic { get; }
        public string Problem { get; }
        public DateTime DateTimeOfOrderCtreation { get; }
        public DateTime EstimatedCompletionDate { get; }
        public string Remark { get; }
        public string PhoneNumber { get; }

        public UndelegatedOrderOnCableTV(OrderOnCableTVDTO orderOnCableTVDTO)
        {
            IsCollectiveOrder = orderOnCableTVDTO.IsCollectiveOrder;
            NumberOfContract = orderOnCableTVDTO.Subscriber.NumberOfContract;
            SubscriberSurname = orderOnCableTVDTO.Subscriber.Surname;
            SubscriberName = orderOnCableTVDTO.Subscriber.Name;
            SubscriberPatronymic = orderOnCableTVDTO.Subscriber.Patronymic;
            Problem = orderOnCableTVDTO.Problem.NameOfProblem ?? orderOnCableTVDTO.NonStandardProblem;
            DateTimeOfOrderCtreation = orderOnCableTVDTO.CreationDate;
            EstimatedCompletionDate = orderOnCableTVDTO.EstimatedCompletionDate;
            Remark = orderOnCableTVDTO.Remark;
            PhoneNumber = orderOnCableTVDTO.PhoneNumber;
        }
    }
}
