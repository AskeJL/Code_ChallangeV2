using WeatherDocument;

namespace WeatherDocuementUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var code1 = textBox1.Text.Trim().Split(',');

            try
            {
                await WeatherDocumentService.GenerateWeatherDocument(code1);

                MessageBox.Show("Weather document generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
