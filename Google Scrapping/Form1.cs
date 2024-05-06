namespace Google_Scrapping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Confirm Button Click
        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            List<string> q = await API.GetImage("Dog");
            foreach (var item in q)
            {
                richTextBox1.Text += item + "\n";
            }
        }
    }
}