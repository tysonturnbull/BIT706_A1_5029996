using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT706_A1_5029996
{
    public partial class Form1 : Form
    {

        List<Account> AllAcc = new List<Account>();
        Customer Customer = new Customer("Tyson", "Turnbull", 0202020202, "tysonturnbull@myop.ac.nz", "Feidling", false);
        List<String> EdTransactions = new List<string>();
        List<String> InvTransactions = new List<string>();
        List<String> OmniTransactions = new List<string>();

        Everyday edAcc = new Everyday(123.55);
        Investment invAcc = new Investment(5023.3, 0.04);
        Omni omniAcc = new Omni(3023.12, 0.05, -300);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEveryday_Click(object sender, EventArgs e)
        {
            //Adding an Everyday account object
            AllAcc.Add(edAcc);

            //View Account Info
            lblAccInfo.Text = edAcc.Info();

            //Clear ListBox
            listBox1.Items.Clear();
        }

        private void btnInterest_Click(object sender, EventArgs e)
        {
            //Adding an Investment account object   
            AllAcc.Add(invAcc);

            //View Account Info
            lblAccInfo.Text = invAcc.Info();

            //Clear ListBox
            listBox1.Items.Clear();
        }

        private void btnOmni_Click(object sender, EventArgs e)
        {
            
            AllAcc.Add(omniAcc);

            //View Account Info
            lblAccInfo.Text = omniAcc.Info();

            //Clear ListBox
            listBox1.Items.Clear();
        }
        
        public void DisplayHistory(List<string> Transactions)
        {
            listBox1.Items.Clear();
            foreach (string transaction in Transactions)
            {
                listBox1.Items.Add(transaction);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (lblAccInfo.Text.Contains("Everyday"))
            {
                EdTransactions.Add(edAcc.Deposit(40));
                DisplayHistory(EdTransactions);
            }
            else if (lblAccInfo.Text.Contains("Investment"))
            {
                
                InvTransactions.Add(invAcc.Deposit(50));
                DisplayHistory(InvTransactions);
            }
            else if (lblAccInfo.Text.Contains("Omni"))
            {
                OmniTransactions.Add(omniAcc.Deposit(80));
                DisplayHistory(OmniTransactions);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (lblAccInfo.Text.Contains("Everyday"))
            {
                EdTransactions.Add(edAcc.Withdrawal(40));
                DisplayHistory(EdTransactions);
            }
            else if (lblAccInfo.Text.Contains("Investment"))
            {

                InvTransactions.Add(invAcc.Withdrawal(50));
                DisplayHistory(InvTransactions);
            }
            else if (lblAccInfo.Text.Contains("Omni"))
            {
                OmniTransactions.Add(omniAcc.Withdrawal(80));
                DisplayHistory(OmniTransactions);
            }
        }

        private void btnAddInterest_Click(object sender, EventArgs e)
        {
            double interest = 5;
            if (lblAccInfo.Text.Contains("Omni"))
            {
                omniAcc.balance+= interest;
                OmniTransactions.Add("Interest Added:  $" + interest + ".  Balance:  $" + omniAcc.balance + ".");
                DisplayHistory(OmniTransactions);
            }
            else if (lblAccInfo.Text.Contains("Investment"))
            {
                invAcc.balance += interest;
                InvTransactions.Add("Interest Added:  $" + interest + ".  Balance:  $" + invAcc.balance + ".");
                DisplayHistory(InvTransactions);
            }
        }
    }
}
