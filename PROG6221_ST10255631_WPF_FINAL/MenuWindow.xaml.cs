//**************************************************************START OF IMPORTS*****************************************************//
using PROG6221_ST10255631_WPF.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//**************************************************************END OF IMPORTS*****************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: 
// GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]
// Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
// Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.
// tutorialsEU (2021). 🔥 C# GUI Tutorial using WPF | XAML | - Windows Presentation Foundation. [online] YouTube. Available at: https://www.youtube.com/watch?v=oSeYvMEH7jc&t=5129s

// GITHUB LINK: https://github.com/Joshua-shields/PROG6221_ST10255631_WPF_FINAL.git

namespace PROG6221_ST10255631_WPF_FINAL
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        // List to store all recipes
        private List<Recipe> recipes;
        // Variable to store the maximum calories for filtering
        public int maxCalories = 0;
        private ListBox recipeListBox; // Add ListBox property
        public event EventHandler MaxCaloriesChanged;

        // <summary>
        /// Initialises a new instance of the MenuWindow class
        /// </summary>
        /// <param name="recipes">A list of Recipe objects to be displayed in the menu.</param>
        /// <param name="recipeListBox">The ListBox control used to display the recipes.</param>
        /// <param name="owner">The MainWindow that owns this MenuWindow.</param>
        public MenuWindow(List<Recipe> recipes, ListBox recipeListBox, MainWindow owner) 
        {
            InitializeComponent();
            this.recipes = recipes;
            this.recipeListBox = recipeListBox;
            this.Owner = owner; // Set the owner of this window


        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for the Scale Recipe button click
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            TextBox inputBox = new TextBox();   
            if (ShowInputDialog("Enter scaling factor:", inputBox) == true)   // Show input dialog to get scaling factor from user
            {
                double scaleFactor;
                if (double.TryParse(inputBox.Text, out scaleFactor)) // Try to parse the input as a double
                {
                    MessageBox.Show(string.Format("Recipe would be scaled by factor of {0}", scaleFactor));
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a number.");
                }
                //--------------------------------------------------------------------------------------------------------------//
            }
        }

        // <summary>
        /// Event handler for the Set Max Calories button click
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>

        private void SetMaxCalories_Click(object sender, RoutedEventArgs e)
        {

            {
                TextBox inputBox = new TextBox();
                if (ShowInputDialog("Enter maximum calories:", inputBox) == true)
                {
                    if (int.TryParse(inputBox.Text, out int calories))
                    {
                        maxCalories = calories;
                        MaxCaloriesChanged?.Invoke(this, EventArgs.Empty);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a number.");
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for the Clear Recipes button click
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all recipes?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                recipes.Clear();
                Close();

                if (Owner != null) // Check if Owner is not null
                {
                    ((MainWindow)Owner).RecipeListBox.Items.Clear();
                    ((MainWindow)Owner).RefreshRecipeList();
                }
                else
                {
                    // Handle the case where the Owner is null display an error message
                    MessageBox.Show("The MenuWindow was not opened from the MainWindow.");
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------//
      

        /// <summary>
        /// Shows an input dialog with a custom question
        /// </summary>
        /// <param name="question">The question to display in the dialog</param>
        /// <param name="inputTextBox">The TextBox for user input</param>
        /// <returns>True if user clicked OK, false otherwise</returns>
        private bool? ShowInputDialog(string question, TextBox inputTextBox)
        {
            Window inputDialog = new Window(); // Create a new window for the input dialog
            inputDialog.Title = "Input";
            inputDialog.Width = 300;
            inputDialog.Height = 150;

            StackPanel stackPanel = new StackPanel(); // Createing and configure the layout for the message
            TextBlock textBlock = new TextBlock();
            textBlock.Text = question;
            textBlock.Margin = new Thickness(5);
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(inputTextBox);

            Button okButton = new Button(); // Create and configure the OK button
            okButton.Content = "OK";
            okButton.IsDefault = true;
            okButton.Click += (sender, e) => { inputDialog.DialogResult = true; };
            stackPanel.Children.Add(okButton);

            inputDialog.Content = stackPanel; // Put everything into the dialog box and display it

            return inputDialog.ShowDialog();
        }
        //--------------------------------------------------------------------------------------------------------------//
    }
}
//**************************************************************END OF FILE**************************************************************//