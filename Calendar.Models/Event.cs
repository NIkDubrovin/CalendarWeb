
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "Date")]
        public DateTime? Date { get; set; }

        [Required]
        [Range(0, 0xFFFFFF, ErrorMessage = "Color is not valid.")]
        public uint Color { get; set; }
    }
}
