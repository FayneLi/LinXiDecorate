using Abp.Application.Services.Dto;

namespace LinXiDecorate.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

