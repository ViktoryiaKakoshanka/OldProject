using System.ComponentModel.DataAnnotations;

namespace WpfOrganization.BLL.DTO
{
    public enum OrderStatus : byte
    {
        Created = 1,
        Delegated = 2,
        Completed = 3,
        Checked = 4
    }
}