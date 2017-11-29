using System.ComponentModel.DataAnnotations;

namespace ContactList_MVC.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Contact's First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Contact's Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact's email is missing!")]
        [Display(Name = "Contact's Email")]
        [StringLength(70)]
        public string Email { get; set; }
    }
}
