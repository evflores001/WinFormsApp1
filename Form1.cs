namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnFindFile_Click(object sender, EventArgs e)
        {
            // Clears the contents of the list box
            listBox1.Items.Clear();
            // Assign string 'searchTerm' to the value of the textBox input field
            string searchTerm = textBox1.Text;

            // Display error message if user does not enter anything to search
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a file name to search.");
                return;
            }

            // Wrapping this in a try-catch block because we could get errors when accessing folders which we don't have access to
            try
            {
                var files = await Task.Run(() => FindFiles(searchTerm));
                if (files.Count == 0)
                {
                    MessageBox.Show("No files found.");
                }
                else
                {
                    foreach (var file in files)
                    {
                        listBox1.Items.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw;
            }
        }

        private List<string> FindFiles(string searchTerm)
        {
            // Replace this with your actual directory path
            string directoryPath = "C:\\Users\\evflo\\Dropbox\\BRYT (1)\\Enrique";
            var files = Directory.GetFiles(directoryPath, $"*{searchTerm}*", SearchOption.AllDirectories).ToList();
            return files;
        }
    }
}
