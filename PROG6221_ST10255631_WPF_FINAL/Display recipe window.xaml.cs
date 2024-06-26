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
    /// Interaction logic for Display_recipe_window.xaml
    /// </summary>
    public partial class Display_recipe_window : Window
    {
        public Display_recipe_window(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipe(recipe); // Call method to display the recipe
        }
        //--------------------------------------------------------------------------------------------------------------//      

        /// <summary>
        /// Displays the details of a recipe in the window
        /// </summary>
        /// <param name="recipe">The recipe to be displayed</param>

        private void DisplayRecipe(Recipe recipe)
        {
            RecipeNameTextBlock.Text = recipe.Name; // Set the recipe name in the TextBlock

            foreach (var ingredient in recipe.Ingredients) // Add each ingredient to the IngredientsListBox
            {
                IngredientsListBox.Items.Add(ingredient.ToString());
            }

            foreach (var step in recipe.Steps) // Add each step to the StepsListBox
            {
                StepsListBox.Items.Add(step.ToString());
            }
            //--------------------------------------------------------------------------------------------------------------//      
        }
    }
}
//**************************************************************END OF FILE**************************************************************//