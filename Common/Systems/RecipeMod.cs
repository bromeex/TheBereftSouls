using System;
using Terraria;
using Terraria.ModLoader;

namespace TheBereftSouls.Common.Systems;

public delegate bool RecipeCondition(Recipe recipe);

public readonly struct RecipeMod
{
    private readonly Action<Recipe> _mod;

    internal RecipeMod(Action<Recipe> mod) => _mod = mod;

    internal void Modify(Recipe recipe) => _mod(recipe);

    public static ChainableRecipeMod NoOp => new((_) => { });

    public static ChainableRecipeMod AddItem(int itemId, int stack = 1) =>
        new((Recipe recipe) => recipe.AddIngredient(itemId, stack));

    public static ChainableRecipeMod AddItem(ModItem item, int stack = 1) =>
        new((Recipe recipe) => recipe.AddIngredient(item, stack));

    public static ChainableRecipeMod AddItem<T>(int stack = 1)
        where T : ModItem => new((Recipe recipe) => recipe.AddIngredient<T>(stack));

    public static ChainableRecipeMod RemoveItem(int itemId) =>
        new((Recipe recipe) => recipe.RemoveIngredient(itemId));

    public static ChainableRecipeMod ReplaceItem(int origId, int newId) =>
        new(
            (Recipe recipe) =>
            {
                if (!recipe.TryGetIngredient(origId, out Item orig))
                    return;
                recipe.RemoveIngredient(origId);
                recipe.AddIngredient(newId, orig.stack);
            }
        );

    public static ChainableRecipeMod AddTile(int tileId) =>
        new((Recipe recipe) => recipe.AddTile(tileId));

    public static ChainableRecipeMod AddTile(ModTile tile) =>
        new((Recipe recipe) => recipe.AddTile(tile));

    public static ChainableRecipeMod AddTile<T>()
        where T : ModTile => new((Recipe recipe) => recipe.AddTile<T>());

    public static ChainableRecipeMod AddDecraftCondition(Condition condition) =>
        new((Recipe recipe) => recipe.AddDecraftCondition(condition));

    // Clone the recipe and modifies each resulting recipe using a different option.
    public static RecipeMod Branch(RecipeMod option1, RecipeMod option2) =>
        new(
            (Recipe recipe) =>
            {
                Recipe newRecipe = recipe.Clone();
                newRecipe.Register();
                newRecipe.SortAfter(recipe);
                option1.Modify(recipe);
                option2.Modify(newRecipe);
            }
        );

    public static RecipeMod Disable() => new((Recipe recipe) => recipe.DisableRecipe());

    public static RecipeMod Custom(Action<Recipe> action) => new(action);

    public static RecipeMod If(
        RecipeCondition condition,
        RecipeMod then,
        RecipeMod? @else = null
    ) =>
        new(
            (Recipe recipe) =>
            {
                if (condition(recipe))
                    then.Modify(recipe);
                else
                    @else?.Modify(recipe);
            }
        );
}

/*
A wrapper class with chaining operations.
The distinction exists to avoid ambiguities when chaining after operations like Branch.
We want to prevent RecipeMod.Branch(..., ...).AddItem(...).
Since it can be unintuitive which of the recipes the AddItem applies to.
*/
public readonly struct ChainableRecipeMod
{
    private readonly RecipeMod _mod;

    internal ChainableRecipeMod(Action<Recipe> mod) => _mod = new(mod);

    // convert unchainable to chainable. should only be used internally.
    private ChainableRecipeMod(RecipeMod mod) => _mod = mod;

    internal void Modify(Recipe recipe) => _mod.Modify(recipe);

    public ChainableRecipeMod AddItem(int itemId, int stack = 1) =>
        Chain(this, RecipeMod.AddItem(itemId, stack));

    public ChainableRecipeMod AddItem(ModItem item, int stack = 1) =>
        Chain(this, RecipeMod.AddItem(item, stack));

    public ChainableRecipeMod AddItem<T>(int stack = 1)
        where T : ModItem => Chain(this, RecipeMod.AddItem<T>(stack));

    public ChainableRecipeMod ReplaceItem(int origId, int newId) =>
        Chain(this, RecipeMod.ReplaceItem(origId, newId));

    public ChainableRecipeMod AddTile(int tileId) => Chain(this, RecipeMod.AddTile(tileId));

    public ChainableRecipeMod AddTile(ModTile tile) => Chain(this, RecipeMod.AddTile(tile));

    public ChainableRecipeMod AddTile<T>()
        where T : ModTile => Chain(this, RecipeMod.AddTile<T>());

    public RecipeMod Branch(RecipeMod option1, RecipeMod option2) =>
        Chain(this, RecipeMod.Branch(option1, option2));

    public RecipeMod Custom(Action<Recipe> action) => Chain(this, RecipeMod.Custom(action));

    public RecipeMod If(RecipeCondition condition, RecipeMod then, RecipeMod? @else = null) =>
        Chain(this, RecipeMod.If(condition, then, @else));

    private static RecipeMod Chain(ChainableRecipeMod first, RecipeMod second) =>
        new(
            (Recipe recipe) =>
            {
                first.Modify(recipe);
                second.Modify(recipe);
            }
        );

    // re-chainable variant
    private static ChainableRecipeMod Chain(ChainableRecipeMod first, ChainableRecipeMod second) =>
        new(Chain(first, second._mod));

    public static implicit operator RecipeMod(ChainableRecipeMod r) => r._mod;
}
