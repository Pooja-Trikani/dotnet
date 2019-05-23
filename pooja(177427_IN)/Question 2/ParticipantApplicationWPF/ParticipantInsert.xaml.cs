using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capgemini.ParticipantDetails.BusinessLayer;
using Capgemini.ParticipantDetails.Entities;
using Capgemini.ParticipantDetails.Exceptions;

namespace ParticipantApplicationWPF
{
    /// <summary>
    /// Interaction logic for ParticipantInsert.xaml
    /// </summary>
    public partial class ParticipantInsert : Window
    {
        public ParticipantInsert()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Participant newParticipant = new Participant();
                newParticipant.VoucherNumber = txtVoucherNumber.Text;
                newParticipant.ParticipantName = txtParticipantName.Text;
                newParticipant.Technology = txtTechnology.Text;
                newParticipant.CertificationCode = txtCertificationCode.Text;
                newParticipant.CertificationName = txtCertificationName.Text;
                newParticipant.CertificationDate = Convert.ToDateTime(txtCertificationDate.Text);
                bool participantAdded = ParticipantBL.AddParticipantBL(newParticipant);
                if (participantAdded)
                {
                    MessageBox.Show("Participant Record Added...");
                }
                else
                {
                    MessageBox.Show("Participant Record Not Added...");
                }
            }
            catch (ParticipantException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
