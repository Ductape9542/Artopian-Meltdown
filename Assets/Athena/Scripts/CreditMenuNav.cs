using UnityEngine;

public class CreditMenuNav : MonoBehaviour
{
    [SerializeField] GameObject[] teamArray;
    public int currentTeamate = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTeamate(bool forward)
    {
        if (currentTeamate == teamArray.Length -1 && forward)
        {
            currentTeamate = 0;
        }
        else if(currentTeamate == 0 && !forward)
        {
            currentTeamate = teamArray.Length -1;
        }
        else if(forward)
        {
            currentTeamate++;
        }
        else
        {
            currentTeamate--;
        }

        for(int i = 0; i < teamArray.Length; i++)
        {
            teamArray[i].SetActive(false);
        }

        teamArray[currentTeamate].SetActive(true);
    }
}
