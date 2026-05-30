using EmployeeManagementSystem.Enums;
namespace EmployeeManagementSystem.Core
{

    public class PaginatedRequestDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public string Search { get; set; } = string.Empty;
        public SortDirection SortDirection { get; set; } = SortDirection.DESC;
        public int SortColumn { get; set; } = 0;

    }
}
