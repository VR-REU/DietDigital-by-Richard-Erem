using UnityEngine;

public class ScaleAdjustment : MonoBehaviour
{
    public Transform maleModelHips;
    public Transform femaleModelHips;
    public float baseCalorieCountMale = 2500; // Base calorie count for males
    public float baseCalorieCountFemale = 2000; // Base calorie count for females
    public float incrementValue = 0.1f;
    public float minCalorieCount = 1000;

    public void AdjustScale(float calorieCount, bool isMale)
    {
        float baseCalorieCount = isMale ? baseCalorieCountMale : baseCalorieCountFemale; // Choose the base calorie count based on gender

        float calorieDifference = calorieCount - baseCalorieCount;
        float incrementCount = Mathf.Round(calorieDifference / 2400);
        float finalIncrement = incrementCount * incrementValue;

        if (calorieCount < minCalorieCount)
        {
            finalIncrement = -incrementValue * (minCalorieCount - calorieCount) / 2400;
        }

        Vector3 newScale;
        if (isMale)
        {
            newScale = maleModelHips.localScale;
            newScale.x += finalIncrement;
            maleModelHips.localScale = newScale;
        }
        else
        {
            newScale = femaleModelHips.localScale;
            newScale.x += finalIncrement;
            femaleModelHips.localScale = newScale;
        }
    }

    public void AdjustHipScale(float scale, bool isMale)
    {
        Vector3 newScale;
        if (isMale)
        {
            newScale = maleModelHips.localScale;
            newScale.x = scale;
            maleModelHips.localScale = newScale;
        }
        else
        {
            newScale = femaleModelHips.localScale;
            newScale.x = scale;
            femaleModelHips.localScale = newScale;
        }
    }
}
