using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    public Dictionary<ItemButton, int> cartItems = new Dictionary<ItemButton, int>();
    public CartUIManager cartUIManager;

    public void AddToCart(ItemButton item)
    {
        if (cartItems.ContainsKey(item))
        {
            cartItems[item]++;
        }
        else
        {
            cartItems[item] = 1;
        }
        cartUIManager.UpdateCartUI();
    }

    public void ClearCart() // New method to clear the cart
    {
        cartItems.Clear();
        cartUIManager.UpdateCartUI();
    }

    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (KeyValuePair<ItemButton, int> item in cartItems)
        {
            totalCalories += item.Key.calories * item.Value;
        }
        return totalCalories;
    }

    public float CalculateTotalPrice()
    {
        float totalPrice = 0f;
        foreach (KeyValuePair<ItemButton, int> item in cartItems)
        {
            totalPrice += item.Key.price * item.Value;
        }
        return totalPrice;
    }
}
