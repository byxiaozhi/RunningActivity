using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningActivity.Models
{
    public class RunningRecord
    {
        [Key]
        public Guid Id { get; set; }

        public Member? Member { get; set; }

        public DateTime RecordDate { get; set; }

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }

        public double AverageSpeed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }
}
