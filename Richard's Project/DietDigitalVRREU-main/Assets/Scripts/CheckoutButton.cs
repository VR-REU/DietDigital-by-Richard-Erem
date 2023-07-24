using UnityEngine;
using UnityEngine.UI;

public class CheckoutButton : MonoBehaviour
{
    public ShoppingCart shoppingCart;
    public CartUIManager cartUIManager;
    public ScaleAdjustment scaleAdjustment;
    public CharacterCreationController characterCreationController;

    private const float NYC_FOOD_TAX = 0.08875f;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(Checkout);
    }

    public void Checkout()
    {
        int totalCalories = shoppingCart.CalculateTotalCalories();
        float totalPrice = shoppingCart.CalculateTotalPrice();
        float finalPrice = totalPrice + (totalPrice * NYC_FOOD_TAX);

        cartUIManager.cartText.text = "Total calories: " + totalCalories;
        cartUIManager.cartText.text += "\nSubtotal price: $" + totalPrice.ToString("F2");
        cartUIManager.cartText.text += "\nNYC Food Tax: $" + (totalPrice * NYC_FOOD_TAX).ToString("F2");
        cartUIManager.cartText.text += "\nFinal price: $" + finalPrice.ToString("F2");
        cartUIManager.cartText.text += "\nThank you for shopping at DietDigital!";

        bool isMale = characterCreationController.maleCharacter.activeSelf;
        scaleAdjustment.AdjustScale(totalCalories, isMale);
    }
}
