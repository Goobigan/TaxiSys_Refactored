using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiSys
{
    public partial class frmAccountsOpen : Form
    {
        public frmAccountsOpen()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            frmHomepage frmHomepage = new frmHomepage();
            frmHomepage.Show();
        }

        private void accountCreateBtn_Click(object sender, EventArgs e)
        {
            
            Utility.validateAccountTextboxes();

            int accountID = Account.getNextAccountId();
            Account anAccount = new Account(accountID,txtUsername.Text,txtPassword.Text,txtEmail.Text,txtPhone.Text,'A');
            anAccount.addAccount();
            MessageBox.Show("Account Successfully Created", "Success!");

            this.Close();
            frmHomepage frmHomepage = new frmHomepage();
            frmHomepage.Show(); 
        }

    }
}
