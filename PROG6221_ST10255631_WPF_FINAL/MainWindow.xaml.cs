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
        private List<Recipe> recipes; 

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>(); // Initialize the list
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            RECIPE_adder_window addRecipeWindow = new RECIPE_adder_window();
            addRecipeWindow.ShowDialog();

            if (addRecipeWindow.NewRecipe != null)
            {
                recipes.Add(addRecipeWindow.NewRecipe);
                RecipeListBox.Items.Add(addRecipeWindow.NewRecipe.Name);
            }
        }

        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                int selectedIndex = RecipeListBox.SelectedIndex;
                Recipe selectedRecipe = recipes[selectedIndex];

                Display_recipe_window displayWindow = new Display_recipe_window(selectedRecipe);
                displayWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to view.");
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow(recipes);
            menuWindow.ShowDialog();

            RefreshRecipeList();
        }

        private void RefreshRecipeList()
        {
            RecipeListBox.Items.Clear();
            foreach (var recipe in recipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }
    }
}
//**************************************************************END OF FILE**************************************************************//