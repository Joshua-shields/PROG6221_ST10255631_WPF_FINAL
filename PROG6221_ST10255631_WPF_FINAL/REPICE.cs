using System;
using System.Collections.Generic;

namespace PROG6221_ST10255631_WPF.Code
{
    /// <summary>
    /// Represents a recipe with ingredients and steps.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the list of ingredients for the recipe.
        /// </summary>
        public List<Ingredient> Ingredients { get; }

        /// <summary>
        /// Gets the list of steps for the recipe.
        /// </summary>
        public List<Step> Steps { get; }

        /// <summary>
        /// Calculates the total calories for the recipe.
        /// </summary>
        /// <returns>The total calories.</returns>
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        /// <summary>
        /// Represents a single ingredient in a recipe.
        /// </summary>
        public class Ingredient
        {
            /// <summary>
            /// Gets or sets the name of the ingredient.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the quantity of the ingredient.
            /// </summary>
            public int Quantity { get; set; }

            /// <summary>
            /// Gets or sets the unit of measurement for the ingredient.
            /// </summary>
            public Measurement Unit { get; set; }

            /// <summary>
            /// Gets or sets the number of calories per serving of the ingredient.
            /// </summary>
            public int Calories { get; set; }

            /// <summary>
            /// Gets or sets the food group the ingredient belongs to.
            /// </summary>
            public FoodGroups FoodGroup { get; set; }

            /// <summary>
            /// Returns a string representation of the ingredient.
            /// </summary>
            /// <returns>A string representation of the ingredient.</returns>
            public override string ToString()
            {
                return $"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})";
            }
        }

        /// <summary>
        /// Represents a single step in a recipe.
        /// </summary>
        public class Step
        {
            /// <summary>
            /// Gets or sets the position of the step in the recipe.
            /// </summary>
            public int Position { get; set; }

            /// <summary>
            /// Gets or sets the description of the step.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Returns a string representation of the step.
            /// </summary>
            /// <returns>A string representation of the step.</returns>
            public override string ToString()
            {
                return $"{Position}. {Description}";
            }
        }

        /// <summary>
        /// Enumeration of common cooking measurements.
        /// </summary>
        public enum Measurement
        {
            Teaspoon,
            Tablespoon,
            Cup,
            Pint,
            Quart,
            Gallon,
            Milliliter,
            Liter,
            Gram,
            Kilogram,
            Ounce,
            Pound
        }

        /// <summary>
        /// Enumeration of food groups.
        /// </summary>
        public enum FoodGroups
        {
            Protein,
            Carbohydrates,
            Fats,
            Fruits,
            Vegetables,
            Dairy,
            Sweets
               
        }
    }
}