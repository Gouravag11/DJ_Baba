using System.Windows;

namespace DJ_Baba
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToDJBabaActivity_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the activity page and show it
            DJBabaActivity activityPage = new DJBabaActivity();
            activityPage.Show();

            // Hide this window instead of closing it
            this.Hide();
        }
    }
}
