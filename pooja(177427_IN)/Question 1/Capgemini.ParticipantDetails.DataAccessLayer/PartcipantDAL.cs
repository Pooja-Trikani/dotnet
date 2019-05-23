using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Capgemini.ParticipantDetails.Entities;
using Capgemini.ParticipantDetails.Exceptions;

namespace Capgemini.ParticipantDetails.DataAccessLayer
{
    public class PartcipantDAL
    {      
        public Participant SearchParticipantDAL(string voucher)
        {
            string strcon = "integrated security=true;initial catalog=sqlpractice; data source=DESKTOP-10SH1EN";
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmdSearch = new SqlCommand("prcParticipantSearch", conn);
            cmdSearch.CommandType = CommandType.StoredProcedure;
            cmdSearch.Parameters.AddWithValue("@VourcherNumber", voucher);
            SqlDataReader dr = cmdSearch.ExecuteReader();
            Participant participant = null;
            if (dr.Read())
            {
                participant = new Participant();
                participant.ParticipantName = dr["ParticipantName"].ToString();
                participant.Technology = dr["Technology"].ToString();
                participant.CertificationCode = dr["CertificationCode"].ToString();
                participant.CertificationName = dr["CertificaionName"].ToString();
                participant.CertificationDate = Convert.ToDateTime(dr["CertificationDate"]);

            }
            return participant;
        }
    }
}
