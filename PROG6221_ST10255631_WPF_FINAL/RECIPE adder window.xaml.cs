//**************************************************************START OF IMPORTS*****************************************************//
using PROG6221_ST10255631_WPF.Code;
using System.Windows;
using System.Windows.Ink;
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
    /// Interaction logic for RECIPE_adder_window.xaml
    /// </summary>
    public partial class RECIPE_adder_window : Window
    {
        //store the new recipe being created
        public Recipe NewRecipe { get; private set; }
        //--------------------------------------------------------------------------------------------------------------//

        public RECIPE_adder_window()
        {
            InitializeComponent();
            NewRecipe = new Recipe();
            InitialiseComboBoxes();
            //--------------------------------------------------------------------------------------------------------------//
        }

        // Method to initialise the ComboBoxes with the enum values
        private void InitialiseComboBoxes()
        {
            // Populate the UnitComboBox with Measurement enum values
            UnitComboBox.ItemsSource = System.Enum.GetValues(typeof(Recipe.Measurement));
            FoodGroupComboBox.ItemsSource = System.Enum.GetValues(typeof(Recipe.FoodGroups)); // Populate the FoodGroupComboBox with FoodGroups enum values

            // default selections for ComboBoxes
            UnitComboBox.SelectedIndex = 0;
            FoodGroupComboBox.SelectedIndex = 0;
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for the Add Ingredient button click. Validates input, creates a new ingredient, and adds it to the recipe
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e) // Event handler for the Add Ingredient button click
        {
            if (!ValidateIngredientInput())  // Validate the ingredient input before proceeding
                return;

            Recipe.Ingredient newIngredient = new Recipe.Ingredient   // Create a new Ingredient object with user input
            {
                Name = IngredientNameTextBox.Text,
                Quantity = int.Parse(QuantityTextBox.Text),
                Unit = (Recipe.Measurement)UnitComboBox.SelectedItem,
                Calories = int.Parse(CaloriesTextBox.Text),
                FoodGroup = (Recipe.FoodGroups)FoodGroupComboBox.SelectedItem
            };

            NewRecipe.Ingredients.Add(newIngredient);

            ClearIngredientInputs();
            UpdateIngredientListDisplay();
        }
        //--------------------------------------------------------------------------------------------------------------//

        //// <summary>
        /// Event handler for the Add Step button click. Validates input, creates a new step, and adds it to the recipe
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepDescriptionTextBox.Text)) // Check if the step description is empty
            {
                MessageBox.Show("Please enter a step description.");
                return;
            }

            Recipe.Step newStep = new Recipe.Step // Create a new Step object
            {
                Position = NewRecipe.Steps.Count + 1,
                Description = StepDescriptionTextBox.Text
            };
            // Add the new step to the recipe
            NewRecipe.Steps.Add(newStep);

            // Clear the step description input and update the step list display
            StepDescriptionTextBox.Clear();
            UpdateStepListDisplay();
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Event handler for the Save Recipe button click. Validates the recipe input and saves the recipe if all requirements are met
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)  // Event handler for the Save Recipe button click
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text)) // Validate recipe name
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            if (NewRecipe.Ingredients.Count == 0) // make sure at least one is added 
            {
                MessageBox.Show("Please add at least one ingredient.");
                return;
            }

            if (NewRecipe.Steps.Count == 0) // if its is null then it ask them to add one step 
            {
                MessageBox.Show("Please add at least one step.");
                return;
            }

            NewRecipe.Name = RecipeNameTextBox.Text;
            this.Close();
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Updates the ingredient list display 
        /// </summary>
        private void UpdateIngredientListDisplay()
        {
            IngredientListBox.ItemsSource = null;
            IngredientListBox.ItemsSource = NewRecipe.Ingredients;
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Updates the step list display 
        /// </summary>
        private void UpdateStepListDisplay()
        {
            StepListBox.ItemsSource = null;
            StepListBox.ItemsSource = NewRecipe.Steps;
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Clears all ingredient
        /// </summary>
        private void ClearIngredientInputs()
        {
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            CaloriesTextBox.Clear();
            UnitComboBox.SelectedIndex = -1;
            FoodGroupComboBox.SelectedIndex = -1;
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Validates the ingredient input fields to ensure all required information is provided and in the correct format
        /// </summary>
        /// <returns>True if all inputs are valid, false otherwise.</returns>
        private bool ValidateIngredientInput()
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text))
            {
                MessageBox.Show("Please enter an ingredient name.");
                return false;
            }

            if (!int.TryParse(QuantityTextBox.Text, out _))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return false;
            }

            if (UnitComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a unit.");
                return false;
            }

            if (!int.TryParse(CaloriesTextBox.Text, out _))
            {
                MessageBox.Show("Please enter a valid number of calories.");
                return false;
            }

            if (FoodGroupComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food group.");
                return false;
            }

            return true;
            //--------------------------------------------------------------------------------------------------------------//
        }
    }
}
//**************************************************************END OF FILE**************************************************************//