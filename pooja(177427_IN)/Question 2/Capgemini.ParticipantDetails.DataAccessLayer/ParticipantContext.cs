using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Capgemini.ParticipantDetails.Entities;

namespace Capgemini.ParticipantDetails.DataAccessLayer
{
    class ParticipantContext:DbContext
    {
        public ParticipantContext() : base("MyContextDB") { }
        public DbSet<Participant> Participants { get; set; }
    }
}
