using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemButton : MonoBehaviour
{
    public string itemName;
    public string detailedName; 
    public int calories; 
    public float price;
    protected bool canAdd = true;
    public ShoppingCart shoppingCart;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(AddToCartWrapper);
    }

    public virtual void AddToCart()
    {
        if (canAdd)
        {
            shoppingCart.AddToCart(this);
            StartCoroutine(PreventDoubleClick());
        }
    }

    protected IEnumerator PreventDoubleClick()
    {
        canAdd = false;
        yield return new WaitForSeconds(0.1f);
        canAdd = true;
    }

    // This method calls the AddToCart method
    public void AddToCartWrapper()
    {
        AddToCart();
    }
}
