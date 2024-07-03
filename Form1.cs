using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BankManagementSystem
{
    public partial class MainForm : Form
    {
        private Dictionary<int, Account> accounts = new Dictionary<int, Account>();
        private int nextAccountNumber = 1000;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (!string.IsNullOrEmpty(name))
            {
                int accountNumber = nextAccountNumber++;
                Account account = new Account(accountNumber, name);
                accounts[accountNumber] = account;
                listAccounts.Items.Add($"Account {accountNumber}: {name}");
                MessageBox.Show($"Account created successfully. Your account number is {accountNumber}.");
            }
            else
            {
                MessageBox.Show("Please enter a name.");
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAccountNumber.Text, out int accountNumber) && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                if (accounts.ContainsKey(accountNumber))
                {
                    accounts[accountNumber].Deposit(amount);
                    MessageBox.Show("Amount deposited successfully.");
                }
                else
                {
                    MessageBox.Show("Account not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid account number and amount.");
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAccountNumber.Text, out int accountNumber) && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                if (accounts.ContainsKey(accountNumber))
                {
                    if (accounts[accountNumber].Withdraw(amount))
                    {
                        MessageBox.Show("Amount withdrawn successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance.");
                    }
                }
                else
                {
                    MessageBox.Show("Account not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid account number and amount.");
            }
        }

        private void btnCheckBalance_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAccountNumber.Text, out int accountNumber))
            {
                if (accounts.ContainsKey(accountNumber))
                {
                    MessageBox.Show($"The balance for account {accountNumber} is {accounts[accountNumber].Balance:C}.");
                }
                else
                {
                    MessageBox.Show("Account not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid account number.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
