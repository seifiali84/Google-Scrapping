namespace Google_Scrapping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Confirm Button Click (Async)
        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            // Search for user input
            if (textBox1.Text != "")
            {
                List<string> q = await API.GetImage(textBox1.Text);
                foreach (var item in q)
                {
                    richTextBox1.Text += item + "\n";
                }
            }
            else
            {
                MessageBox.Show("Please Search Something!", "Please Search Something then click on Confirm Button!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            button3.Enabled = true;
        }
    }
}