using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartUIManager : MonoBehaviour
{
    public ShoppingCart shoppingCart;
    public TextMeshProUGUI cartText;

    private void Start()
    {
        cartText.text = "Items in cart:\n";
    }

    public void UpdateCartUI()
    {
        cartText.text = "Items in cart:\n";
        float totalPrice = 0f;
        int totalCalories = 0;
        foreach (KeyValuePair<ItemButton, int> item in shoppingCart.cartItems)
        {
            cartText.text += item.Key.detailedName + " x" + item.Value + " - $" + (item.Key.price * item.Value).ToString("F2") + "\n"; // Changed itemName to detailedName
            totalPrice += item.Key.price * item.Value;
            totalCalories += item.Key.calories * item.Value;
        }
        cartText.text += "\nTotal price: $" + totalPrice.ToString("F2");
        cartText.text += "\nTotal calories: " + totalCalories;
    }
}
