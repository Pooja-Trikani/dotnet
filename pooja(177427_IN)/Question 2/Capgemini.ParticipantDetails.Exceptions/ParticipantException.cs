using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.ParticipantDetails.Exceptions
{
    public class ParticipantException:ApplicationException
    {
        public ParticipantException() : base()
        {
        }
        public ParticipantException(string message) : base(message)
        {

        }
        public ParticipantException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
