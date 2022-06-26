using System.ComponentModel.DataAnnotations;

namespace LiveLife.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}