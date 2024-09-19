using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningActivity.Models
{
    public class Member
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public byte[]? Avatar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }
}
