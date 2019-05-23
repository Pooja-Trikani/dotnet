using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.ParticipantDetails.Entities;
using Capgemini.ParticipantDetails.DataAccessLayer;
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
            if(participant.VoucherNumber.Equals(String.Empty)|| participant.ParticipantName.Equals(String.Empty) || participant.Technology.Equals(String.Empty) || participant.CertificationCode.Equals(String.Empty) || participant.CertificationName.Equals(String.Empty) || participant.CertificationDate.Equals(String.Empty))
            {
                validateParticipant = false;
                sb.Append(Environment.NewLine + "Fields Cannot be Empty.. ");
            }
            if (participant.VoucherNumber.Length>19)
            {
                validateParticipant = false;
                sb.Append(Environment.NewLine + "Voucher Number cannot be greater than 19 ");
            }
            if (!(Regex.IsMatch(participant.VoucherNumber.ToString(), "[A-Z]{3}-[0-9]{4}-[0-9]{4}-[0-9]{4}")))
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

        public static Participant SearchParticipantBL(string voucher)
        {
            Participant searchedParticipant = null;
            try
            {
                PartcipantDAL participantDAL = new PartcipantDAL();
                searchedParticipant = participantDAL.SearchParticipantDAL(voucher);
            }
            catch (ParticipantException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchedParticipant;
        }
    }
}
