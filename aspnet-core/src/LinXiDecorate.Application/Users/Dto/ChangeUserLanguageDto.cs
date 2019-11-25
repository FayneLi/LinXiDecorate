using System.ComponentModel.DataAnnotations;

namespace LinXiDecorate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}