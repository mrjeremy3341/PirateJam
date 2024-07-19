using UnityEngine;

public class ComboReader : MonoBehaviour
{
    public class Combo
    {
        public KeyCode firstKey;
        public KeyCode secondKey;

        public void Clear()
        {
            firstKey = KeyCode.None;
            secondKey = KeyCode.None;
        }
    }

    Combo currentCombo = new Combo();

    bool isListeningForCombo;
    float comboTimer;
    float comboTimeout = 0.5f;

    void Update()
    {
        if (isListeningForCombo)
        {
            HandleSecondKey();
        }
        else
        {
            HandleFirstKey();
        }

        UpdateTimer();
    }

    void HandleFirstKey()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentCombo.firstKey = KeyCode.Q;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                currentCombo.firstKey = KeyCode.E;
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                currentCombo.firstKey = KeyCode.R;
            }

            isListeningForCombo = true;
            comboTimer = 0f;
        }
    }

    void HandleSecondKey()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentCombo.secondKey = KeyCode.Q;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                currentCombo.secondKey = KeyCode.E;
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                currentCombo.secondKey = KeyCode.R;
            }

            ExecuteCombo();
        }
    }

    void UpdateTimer()
    {
        if (isListeningForCombo)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer > comboTimeout)
            {
                Debug.Log("Combo timed out!");
                ClearCombo();
            }
        }
    }

    void ExecuteCombo()
    {
        Debug.Log(currentCombo.firstKey.ToString() + " + " + currentCombo.secondKey.ToString());
        ClearCombo();
    }

    void ClearCombo()
    {
        currentCombo.Clear();
        isListeningForCombo = false;
        comboTimer = 0f;
    }
}
