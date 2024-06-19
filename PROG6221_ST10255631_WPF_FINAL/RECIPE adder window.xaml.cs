using System.Windows;

namespace PROG6221_ST10255631_WPF_FINAL
{
    /// <summary>
    /// Interaction logic for RECIPE_adder_window.xaml
    /// </summary>
    public partial class RECIPE_adder_window : Window
    {
        public RECIPE_adder_window()
        {
            InitializeComponent();
        }

        public void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
