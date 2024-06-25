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


namespace PROG6221_ST10255631_WPF_FINAL
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private List<Recipe> recipes;
        private int maxCalories = 0;

        public MenuWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            TextBox inputBox = new TextBox();
            if (ShowInputDialog("Enter scaling factor:", inputBox) == true)
            {
                double scaleFactor;
                if (double.TryParse(inputBox.Text, out scaleFactor))
                {
                    MessageBox.Show(string.Format("Recipe would be scaled by factor of {0}", scaleFactor));
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a number.");
                }
            }
        }

        private void SetMaxCalories_Click(object sender, RoutedEventArgs e)
        {

            { 
                TextBox inputBox = new TextBox();
                if (ShowInputDialog("Enter maximum calories:", inputBox) == true)
                {
                    int calories;
                    if (int.TryParse(inputBox.Text, out calories))
                    {
                        maxCalories = calories;
                        
                        var filteredRecipes = recipes.Where(recipe => recipe.CalculateTotalCalories() <= maxCalories).ToList();
                        MessageBox.Show(string.Format("Maximum calories set to {0}", maxCalories));
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a number.");
                    }
                }
            }

        }

        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all recipes?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                recipes.Clear();
                Close();
            }
        }

        private bool? ShowInputDialog(string question, TextBox inputTextBox)
        {
            Window inputDialog = new Window();
            inputDialog.Title = "Input";
            inputDialog.Width = 300;
            inputDialog.Height = 150;

            StackPanel stackPanel = new StackPanel();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = question;
            textBlock.Margin = new Thickness(5);
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(inputTextBox);

            Button okButton = new Button();
            okButton.Content = "OK";
            okButton.IsDefault = true;
            okButton.Click += (sender, e) => { inputDialog.DialogResult = true; };
            stackPanel.Children.Add(okButton);

            inputDialog.Content = stackPanel;

            return inputDialog.ShowDialog();
        }
    }
}
    