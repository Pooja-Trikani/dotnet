using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.ParticipantDetails.Entities;
using Capgemini.ParticipantDetails.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Capgemini.ParticipantDetails.DataAccessLayer
{
    public class ParticipantDAL
    {
        ParticipantContext context = new ParticipantContext();
        public bool AddParticipantDAL(Participant participant)
        {
            bool participantAdded = false;
            try
            {
                context.Participants.Add(participant);

                int status = context.SaveChanges();

                if (status > 0)
                {
                    participantAdded = true;
                }
            }
            catch (Exception ex)
            {

                throw new ParticipantException(ex.Message);
            }
            return participantAdded;
        }

        public List<Participant> GetAllParticipantDAL()
        {
            List<Participant> employList = null;
            try
            {
                employList = context.Participants.ToList();
            }
            catch (Exception ex)
            {

                throw new ParticipantException(ex.Message);
            }
            return employList;
        }
    }
}
