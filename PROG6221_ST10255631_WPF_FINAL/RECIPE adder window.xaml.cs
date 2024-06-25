//**************************************************************START OF IMPORTS*****************************************************//
using PROG6221_ST10255631_WPF.Code;
using System.Windows;
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
        public Recipe NewRecipe { get; private set; }
       
        public RECIPE_adder_window()
        {
            InitializeComponent();
            NewRecipe = new Recipe();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            UnitComboBox.ItemsSource = System.Enum.GetValues(typeof(Recipe.Measurement));
            FoodGroupComboBox.ItemsSource = System.Enum.GetValues(typeof(Recipe.FoodGroups));

            UnitComboBox.SelectedIndex = 0;
            FoodGroupComboBox.SelectedIndex = 0;
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateIngredientInput())
                return;

            Recipe.Ingredient newIngredient = new Recipe.Ingredient
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

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepDescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a step description.");
                return;
            }

            Recipe.Step newStep = new Recipe.Step
            {
                Position = NewRecipe.Steps.Count + 1,
                Description = StepDescriptionTextBox.Text
            };

            NewRecipe.Steps.Add(newStep);

            StepDescriptionTextBox.Clear();
            UpdateStepListDisplay();
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            if (NewRecipe.Ingredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.");
                return;
            }

            if (NewRecipe.Steps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.");
                return;
            }

            NewRecipe.Name = RecipeNameTextBox.Text;
            this.Close();
        }

        private void UpdateIngredientListDisplay()
        {
            IngredientListBox.ItemsSource = null;
            IngredientListBox.ItemsSource = NewRecipe.Ingredients;
        }

        private void UpdateStepListDisplay()
        {
            StepListBox.ItemsSource = null;
            StepListBox.ItemsSource = NewRecipe.Steps;
        }

        private void ClearIngredientInputs()
        {
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            CaloriesTextBox.Clear();
            UnitComboBox.SelectedIndex = -1;
            FoodGroupComboBox.SelectedIndex = -1;
        }

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
        }
    }
}
//**************************************************************END OF FILE**************************************************************//