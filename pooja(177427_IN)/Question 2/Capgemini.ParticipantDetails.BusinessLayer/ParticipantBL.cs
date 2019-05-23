using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.ParticipantDetails.DataAccessLayer;
using Capgemini.ParticipantDetails.Entities;
using Capgemini.ParticipantDetails.Exceptions;
using System.Text.RegularExpressions;

namespace Capgemini.ParticipantDetails.BusinessLayer
{
    public class ParticipantBL
    {
        private static bool Validate(Participant participant)
        {
            StringBuilder sb = new StringBuilder();
            bool validateParticipant = true;
            if (participant.VoucherNumber.Length==0 || participant.ParticipantName.Length==0 || participant.Technology.Length==0 || participant.CertificationCode.Length==0 || participant.CertificationName.Length==0)
            {
                validateParticipant = false;
                sb.Append(Environment.NewLine + "Fields Cannot be Empty.. ");
            }
            if (participant.VoucherNumber.Length > 19)
            {
                validateParticipant = false;
                sb.Append(Environment.NewLine + "Voucher Number cannot be greater than 19 ");
            }
            if (!(Regex.IsMatch(participant.VoucherNumber.ToString(), "[A-Z]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}")))
            {
                validateParticipant = false;
                sb.Append(Environment.NewLine + "Voucher Number not valid ");
            }
            if (validateParticipant == false)
            {
                throw new ParticipantException(sb.ToString());
            }
            return validateParticipant;
        }
        public static bool AddParticipantBL(Participant participant)
        {
            bool participantAdded = false;
            try
            {
                if (Validate(participant))
                {
                    ParticipantDAL participantDAL = new ParticipantDAL();
                    participantAdded = participantDAL.AddParticipantDAL(participant);
                }
            }
            catch (ParticipantException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return participantAdded;
        }
        public static List<Participant> GetAllParticipantBL()
        {
            List<Participant> participantList = null;
            ParticipantDAL employDAL = new ParticipantDAL();
            participantList = employDAL.GetAllParticipantDAL();
            return participantList;
        }
    }
}
