namespace Google_Scrapping
{
    public partial class Form1 : Form
    {
        int ImageIndex = 0;
        List<string> q;
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
                q = await API.GetImage(textBox1.Text);

                pictureBox1.ImageLocation = q[ImageIndex];
            }
            else
            {
                MessageBox.Show("Please Search Something!", "Please Search Something then click on Confirm Button!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            button3.Enabled = true;
        }
        // Next Image Button
        private void button2_Click(object sender, EventArgs e)
        {
            if(ImageIndex == 99)
            {
                ImageIndex = -1;
            }
            pictureBox1.ImageLocation = q[++ImageIndex];
        }
    }
}