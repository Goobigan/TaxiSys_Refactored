using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiSys
{
    internal class Utility
    {
        public static ComboBox loadMakes(ComboBox cboMakes)
        {
            cboMakes.Items.Clear();
            DataSet ds = Driver.getMakes();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboMakes.Items.Add(ds.Tables[0].Rows[i][0]);
            }
            return cboMakes;

        }

        public static ComboBox loadModels(ComboBox cboModels, String make)
        {
            cboModels.Items.Clear();
            DataSet ds = Driver.getModels(make);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboModels.Items.Add(ds.Tables[0].Rows[i][0]);
            }
            return cboModels;

        }

        public static void formatDriversGrid(DataGridView dg)
        {
            dg.Columns["DriverID"].Width = 30;
            dg.Columns["DriverID"].DefaultCellStyle.Format = "000";
            dg.Columns["DriverID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["Forename"].Width = 70;
            dg.Columns["Forename"].DefaultCellStyle.Format = "000";
            dg.Columns["Forename"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns["Surname"].Width = 70;
            dg.Columns["Surname"].DefaultCellStyle.Format = "000";
            dg.Columns["Surname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public static void validateAccountTextboxes()
        {
            if (txtUsername.Text.Equals("") || txtPassword.Text.Equals("") || txtEmail.Text.Equals("") || txtPhone.Text.Equals(""))
            {
                MessageBox.Show("All textboxes must contain valid data", "Error!");
                return;
            }

            if (txtPhone.Text.Any(char.IsLetter) || txtPhone.Text.Any(char.IsSymbol))
            {
                functionErrorResponse(txtPhone,"Phone Number must only contain digits", "Error!");
            }

            if (txtPhone.Text.Length != 10)
            {
                functionErrorResponse(txtPhone,"Phone Number is not 10 digits long", "Error!");
            }
            
            //Checks that the password fits all necessary criteria       
            if (!(txtPassword.Text.Length >= 8 && txtPassword.Text.Any(char.IsLetter) && (txtPassword.Text.Any(char.IsSymbol) || txtPassword.Text.Any(char.IsPunctuation)) && txtPassword.Text.Any(char.IsDigit)))
            {
                functionErrorResponse(txtPassword,"Password must contain at least 8 characters, including at least one letter, one number and one symbol", "Error!");
            }

            if (!txtEmail.Text.EndsWith(".ie") && !txtEmail.Text.EndsWith(".com") && !txtEmail.Text.EndsWith(".net"))
            {
                functionErrorResponse(txtEmail,"Email address must end in .ie,.com or .net", "Error!");
            }

            //checks the number of @ symbols in the email address
            if (txtEmail.Text.Count(c => c == '@') != 1)
            {
                functionErrorResponse(txtEmail,"There must be 1 @ symbol in email address", "Error!");
            } 

            //checks whether an account already has this username
            Account account = new Account();
            if (account.CheckUniqueUsername(txtUsername.Text) > 0)
            {
                functionErrorResponse(txtUsername,"Username already taken", "Sorry!");
            }
        }

        public static void errorResponse(TextBox textBox, string errorMessage,string  errorHeading){
            MessageBox.Show(errorMessage, errorHeading);
            textBox.Focus();
            return ;
        }
    }
}
