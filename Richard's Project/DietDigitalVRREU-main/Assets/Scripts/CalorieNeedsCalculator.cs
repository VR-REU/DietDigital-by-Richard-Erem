using UnityEngine;

public class CalorieNeedsCalculator : MonoBehaviour
{
    public CalorieNeedsData data;

    public int CalculateCalorieNeeds(Gender gender, ActivityLevel activityLevel, int age)
    {
        return data.GetCalorieNeeds(age, gender, activityLevel);
    }
}
