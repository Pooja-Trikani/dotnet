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
using System.Windows.Shapes;
using Capgemini.ParticipantDetails.BusinessLayer;
using Capgemini.ParticipantDetails.Entities;
using Capgemini.ParticipantDetails.Exceptions;

namespace ParticipantApplicationWPF
{
    /// <summary>
    /// Interaction logic for ParticipantSearch.xaml
    /// </summary>
    public partial class ParticipantSearch : Window
    {
        public ParticipantSearch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Participant res = ParticipantBL.SearchParticipantBL(txtVoucherNumber.Text);
                if (res != null)
                {
                    lblResParticipantname.Content = res.ParticipantName;
                    lblResTechnology.Content = res.Technology;
                    lblCertificateCode.Content = res.CertificationCode;
                    lblCertificateName.Content = res.CertificationName;
                    lblCertificateDate.Content = res.CertificationDate;
                }
                else
                {
                    MessageBox.Show("Voucher Number " + txtVoucherNumber.Text + " Does not exist");
                }
            }
            catch (ParticipantException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
