using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Resume
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Bio { get; set; }
        public required string Description { get; set; }
        public required string ProgressWork { get; set; }
    }
}
