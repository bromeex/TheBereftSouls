using System;
using Terraria;

namespace TheBereftSouls.Common.Systems;

public readonly struct RecipeMod
{
    private readonly Action<Recipe> _mod;

    private RecipeMod(Action<Recipe> mod) => _mod = mod;

    internal void Modify(Recipe recipe) => _mod(recipe);

    public static RecipeMod AddItem(int itemId, int stack = 1) =>
        new((Recipe recipe) => recipe.AddIngredient(itemId, stack));

    public static RecipeMod RemoveItem(int itemId) =>
        new((Recipe recipe) => recipe.RemoveIngredient(itemId));

    public static RecipeMod ReplaceItem(int origId, int newId) =>
        RemoveItem(origId).Then(AddItem(newId));

    public static RecipeMod AddDecraftCondition(Condition condition) =>
        new((Recipe recipe) => recipe.AddDecraftCondition(condition));

    public RecipeMod Then(RecipeMod other) => Chain(this, other);

    public RecipeMod If(Func<Recipe, bool> condition) => Condition(this, condition);

    ///<remarks>
    /// causes all previous actions to happen to a clone of the recipe, instead of the original recipe.
    /// if you only want to create a clone under a certain condition, make sure to call If after AsAltRecipe.
    /// calling Then after AsAltRecipe will cause further modifications to be applied to the original.
    ///</remarks>
    public RecipeMod AsAltRecipe() => ApplyToClone(this);

    private static RecipeMod Condition(RecipeMod mod, Func<Recipe, bool> condition) =>
        new(
            (Recipe recipe) =>
            {
                if (condition(recipe))
                    mod.Modify(recipe);
            }
        );

    private static RecipeMod Chain(RecipeMod first, RecipeMod second) =>
        new(
            (Recipe recipe) =>
            {
                first.Modify(recipe);
                second.Modify(recipe);
            }
        );

    private static RecipeMod ApplyToClone(RecipeMod origin) =>
        new(
            (Recipe recipe) =>
            {
                Recipe newRecipe = recipe.Clone();
                newRecipe.Register();
                newRecipe.SortAfter(recipe);
                origin.Modify(newRecipe);
            }
        );
}
