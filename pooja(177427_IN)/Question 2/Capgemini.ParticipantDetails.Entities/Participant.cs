using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capgemini.ParticipantDetails.Entities
{
    public class Participant
    {
        [Key]
        public string VoucherNumber { get; set; }
        public string ParticipantName { get; set; }
        public string Technology { get; set; }
        public string CertificationCode { get; set; }
        public string CertificationName { get; set; }
        public DateTime CertificationDate { get; set; }

        public Participant()
        {
            VoucherNumber = string.Empty;
            ParticipantName = string.Empty;
            Technology = string.Empty;
            CertificationCode = string.Empty;
            CertificationName = string.Empty;
            CertificationDate = DateTime.Now;
        }
    }
}
