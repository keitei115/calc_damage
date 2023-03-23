namespace testApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label.Visible = false;
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            //inputX‚ÆinputY‚Ìtextbox‚©‚ç”’l‚ğó‚¯æ‚èA‚»‚Ì‡Œv‚ğlabel‚É”½‰f‚³‚¹‚é
            int inputXval, inputYval;
            if (!int.TryParse(inputX.Text, out inputXval) || !int.TryParse(inputY.Text, out inputYval))
            {
                MessageBox.Show("Invalid input. Please enter only integers.");
                return;
            }
            int inputVal = inputXval + inputYval;
            String labelText = inputVal.ToString();
            label.Visible = true;
            label.Text = labelText;
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void inputX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') {
                return;
            }

            if (e.KeyChar < '0' || e.KeyChar > '9') {
                e.Handled = true;
            }
        }
    }
}