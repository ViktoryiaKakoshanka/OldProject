using System.ComponentModel.DataAnnotations;

namespace WpfOrganization.BLL.DTO
{
    public enum OrderStatus
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Поручен")]
        Delegated,

        [Display(Name = "Выполнен")]
        Completed,

        [Display(Name = "Проверен")]
        Checked
    }
}
