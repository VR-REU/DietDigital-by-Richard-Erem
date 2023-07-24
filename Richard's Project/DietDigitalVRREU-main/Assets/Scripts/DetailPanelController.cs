using UnityEngine;
using TMPro; 

public class DetailPanelController : MonoBehaviour
{
    public GameObject detailPanel;
    public TextMeshProUGUI detailText; 

    private void Start()
    {
        detailPanel.SetActive(false);
    }

    public void ShowPanel(FoodButton foodButton)
    {
        detailText.text = "Nutrition Facts:\n"; 
        detailText.text += "Item: " + foodButton.detailedName + "\n"; 
        detailText.text += "Calories: " + foodButton.calories + "\n";
        detailText.text += "Calories from Fat: " + foodButton.caloriesFromFat + "\n";
        detailText.text += "Serving Size: " + foodButton.servingSize + "\n";
        detailText.text += "Total Fat: " + foodButton.totalFat + " g\n";
        detailText.text += "Saturated Fat: " + foodButton.saturatedFat + " g\n";
        detailText.text += "Trans Fat: " + foodButton.transFat + " g\n"; 
        detailText.text += "Cholesterol: " + foodButton.cholesterol + " mg\n"; 
        detailText.text += "Sodium: " + foodButton.sodium + " mg\n"; 
        detailText.text += "Total Carbohydrate: " + foodButton.totalCarbohydrate + " g\n"; 
        detailText.text += "Dietary Fiber: " + foodButton.dietaryFiber + " g\n"; 
        detailText.text += "Sugars: " + foodButton.sugars + " g\n"; 
        detailText.text += "Protein: " + foodButton.protein + " g\n"; 
        detailText.text += "Calcium: " + foodButton.calcium + "\n";
        detailText.text += "Iron: " + foodButton.iron + "\n";
        detailPanel.SetActive(true);
    }

    public void ShowPanel(DrinkButton drinkButton) //Overloaded method for DrinkButton
    {
        detailText.text = "Nutrition Facts:\n"; 
        detailText.text += "Item: " + drinkButton.detailedName + "\n"; 
        detailText.text += "Calories: " + drinkButton.calories + "\n";
        detailText.text += "Calories from Fat: " + drinkButton.caloriesFromFat + "\n";
        detailText.text += "Serving Size: " + drinkButton.servingSize + "\n";
        detailText.text += "Total Fat: " + drinkButton.totalFat + " g\n";
        detailText.text += "Saturated Fat: " + drinkButton.saturatedFat + " g\n";
        detailText.text += "Trans Fat: " + drinkButton.transFat + " g\n"; 
        detailText.text += "Polyunsaturated Fat: " + drinkButton.polyunsaturatedFat + " g\n"; 
        detailText.text += "Monounsaturated Fat: " + drinkButton.monounsaturatedFat + " g\n"; 
        detailText.text += "Cholesterol: " + drinkButton.cholesterol + " mg\n"; 
        detailText.text += "Sodium: " + drinkButton.sodium + " mg\n"; 
        detailText.text += "Total Carbohydrate: " + drinkButton.totalCarbohydrate + " g\n"; 
        detailText.text += "Dietary Fiber: " + drinkButton.dietaryFiber + " g\n"; 
        detailText.text += "Total Sugars: " + drinkButton.totalSugars + " g\n"; 
        detailText.text += "Includes " + drinkButton.addedSugars + "g Added Sugars\n"; 
        detailText.text += "Protein: " + drinkButton.protein + " g\n"; 
        detailText.text += "Vitamin D: " + drinkButton.vitaminD + " mcg\n";
        detailText.text += "Vitamin C: " + drinkButton.vitaminC + " mg\n";
        detailText.text += "Vitamin A: " + drinkButton.vitaminA + " IU\n";
        detailText.text += "Calcium: " + drinkButton.calcium + " mg\n";
        detailText.text += "Iron: " + drinkButton.iron + " mg\n";
        detailText.text += "Potassium: " + drinkButton.potassium + " mg\n";
        detailText.text += "Vitamin E: " + drinkButton.vitaminE + " mg\n";
        detailText.text += "Phosphorus: " + drinkButton.phosphorus + " mg\n";
        detailText.text += "Magnesium: " + drinkButton.magnesium + " mg\n";
        detailPanel.SetActive(true);
    }



    public void HidePanel()
    {
        detailPanel.SetActive(false);
    }
}
