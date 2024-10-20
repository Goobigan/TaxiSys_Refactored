using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiSys
{
    public partial class frmAccountsUpdate : Form
    {
        Account theAccount=new Account();
        public frmAccountsUpdate()
        {
            InitializeComponent();
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            frmHomepage frmHomepage = new frmHomepage();
            frmHomepage.Show();
        }



        private void accountUpdateBtn_Click(object sender, EventArgs e)
        {

            Utility.validateAccountTextboxes();
            
            Account updatedAccount = new Account(theAccount.getAccountID(), txtUsername.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text, 'A');
            updatedAccount.updateAccount();
            MessageBox.Show("Account Successfully Updated", "Success!");
            
            this.Close();
            frmHomepage frmHomepage = new frmHomepage();
            frmHomepage.Show();
        }


    

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            int count = account.CheckUniqueUsername(txtUsernameSearch.Text);

            if (txtPasswordSearch.Text == "" || txtUsernameSearch.Text == "")
            {
                MessageBox.Show("No text entered!", "Error");
                return;
            }

            if (count !=1)
            {
                MessageBox.Show("Username not found.", "Sorry!");
                txtUsernameSearch.Focus();
                return;
            }
            if (account.CheckStatus(txtUsernameSearch.Text) != "A")
            {
                MessageBox.Show("Username not found.", "Sorry!");
                txtUsernameSearch.Focus();
                return;
            }

            if (txtPasswordSearch.Text != account.ReturnPassword(txtUsernameSearch.Text))
            {
                MessageBox.Show("Username and password do not match.", "Sorry!");
                txtPasswordSearch.Focus();
                return;
            }

            theAccount.GetAccount(txtUsernameSearch.Text);

            txtID.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPasswordSearch.Text = "";
            txtUsernameSearch.Text = "";

            txtID.Text = Convert.ToString(theAccount.getAccountID());
            txtUsername.Text = theAccount.getUsername();
            txtPassword.Text = theAccount.getPassword();
            txtEmail.Text = theAccount.getEmailAddress();
            txtPhone.Text = theAccount.getPhoneNumber();

            accountDetailsGroupBox.Visible = true;

        }
    }
}
