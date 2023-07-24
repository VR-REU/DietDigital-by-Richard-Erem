using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreationController : MonoBehaviour
{
    public GameObject maleCharacter;
    public GameObject femaleCharacter;
    public GameObject menuPanel;
    public Button maleButton;
    public Button femaleButton;
    public Button increaseHipScaleButton;
    public Button decreaseHipScaleButton;
    public Button startGameButton;
    public Button sedentaryButton;
    public Button moderatelyActiveButton;
    public Button activeButton;
    public Slider ageSlider;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI hipScaleText;
    public TextMeshProUGUI calorieNeedsText; // Add this line
    public ScaleAdjustment scaleAdjustment;
    public CalorieNeedsCalculator calorieNeedsCalculator;

    private float hipScale = 1.0f;
    private ActivityLevel activityLevel = ActivityLevel.Sedentary;
    private Gender gender = Gender.Male;

    private void Start()
    {
        maleButton.onClick.AddListener(SelectMale);
        femaleButton.onClick.AddListener(SelectFemale);
        increaseHipScaleButton.onClick.AddListener(IncreaseHipScale);
        decreaseHipScaleButton.onClick.AddListener(DecreaseHipScale);
        startGameButton.onClick.AddListener(StartGame);
        sedentaryButton.onClick.AddListener(() => SelectActivityLevel(ActivityLevel.Sedentary));
        moderatelyActiveButton.onClick.AddListener(() => SelectActivityLevel(ActivityLevel.ModeratelyActive));
        activeButton.onClick.AddListener(() => SelectActivityLevel(ActivityLevel.Active));
        ageSlider.onValueChanged.AddListener(UpdateAge);

        SelectMale();
        ageText.text = "Age: " + ageSlider.value.ToString("0");
        hipScaleText.text = "Body Size: " + hipScale.ToString("0.00");
    }

    private void SelectMale()
    {
        maleCharacter.SetActive(true);
        femaleCharacter.SetActive(false);
        gender = Gender.Male;
        UpdateCalorieNeeds();
    }

    private void SelectFemale()
    {
        maleCharacter.SetActive(false);
        femaleCharacter.SetActive(true);
        gender = Gender.Female;
        UpdateCalorieNeeds();
    }

    private void SelectActivityLevel(ActivityLevel level)
    {
        activityLevel = level;
        UpdateCalorieNeeds();
    }

    private void UpdateAge(float age)
    {
        ageText.text = "Age: " + age.ToString("0");
        UpdateCalorieNeeds();
    }

    private void IncreaseHipScale()
    {
        hipScale += 0.1f;
        scaleAdjustment.AdjustHipScale(hipScale, maleCharacter.activeSelf);
        hipScaleText.text = "Body Size: " + hipScale.ToString("0.00");
    }

    private void DecreaseHipScale()
    {
        hipScale -= 0.1f;
        scaleAdjustment.AdjustHipScale(hipScale, maleCharacter.activeSelf);
        hipScaleText.text = "Body Size: " + hipScale.ToString("0.00");
    }

    private void StartGame()
    {
        menuPanel.SetActive(false);
    }

    private void UpdateCalorieNeeds()
    {
        int calorieNeeds = calorieNeedsCalculator.CalculateCalorieNeeds(gender, activityLevel, (int)ageSlider.value);
        calorieNeedsText.text = "Calorie Needs: " + calorieNeeds;
    }
}
