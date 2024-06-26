//**************************************************************START OF IMPORTS*****************************************************//
using PROG6221_ST10255631_WPF.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes; // List to store all recipes
        public int maxCalories = 0; // Variable to store the maximum calories for filtering


        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>(); // Initialise the list of recipes
        }
        //--------------------------------------------------------------------------------------------------------------//      

        /// <summary>
        /// Event handler for the Add Recipe button click
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            RECIPE_adder_window addRecipeWindow = new RECIPE_adder_window(); // Create and show the recipe adder window
            addRecipeWindow.ShowDialog();

            if (addRecipeWindow.NewRecipe != null)  // If a new recipe was created adds it to the list and updates 
            {
                recipes.Add(addRecipeWindow.NewRecipe);
                RecipeListBox.Items.Add(addRecipeWindow.NewRecipe.Name);
            }
        }
        //--------------------------------------------------------------------------------------------------------------//      

        /// <summary>
        /// Event handler for the View Recipe button click
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null) // Check if a recipe is selected
            {
                int selectedIndex = RecipeListBox.SelectedIndex;  // Get the selected recipe
                Recipe selectedRecipe = recipes[selectedIndex];

                Display_recipe_window displayWindow = new Display_recipe_window(selectedRecipe); // Create and show the recipe display window
                displayWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to view."); // Show an error message if no recipe is selected
            }
        }
        //--------------------------------------------------------------------------------------------------------------//      

        /// <summary>
        /// Event handler for the Menu button click
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow(recipes, RecipeListBox, this); 
            menuWindow.MaxCaloriesChanged += MenuWindow_MaxCaloriesChanged;
            menuWindow.ShowDialog();
        }
        //--------------------------------------------------------------------------------------------------------------//      
        private void MenuWindow_MaxCaloriesChanged(object sender, EventArgs e)
        {
            // Update maxCalories in MainWindow
            maxCalories = ((MenuWindow)sender).maxCalories;
            RefreshRecipeList();
        }

        /// <summary>
        /// Refreshes the recipe list and sorts the recipe in alphabetical order
        /// </summary>
        public void RefreshRecipeList()
        {
            RecipeListBox.Items.Clear();
            
            var sortedRecipes = recipes.Where(r => r.CalculateTotalCalories() <= maxCalories)
                                      .OrderBy(r => r.Name);

            foreach (var recipe in sortedRecipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
            //--------------------------------------------------------------------------------------------------------------//      
        }
    }
}
//**************************************************************END OF FILE**************************************************************//