using System.Collections.Generic;
using Person;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public List<PersonTest> listOfPerson;
    public StatusButton accButton;
    public StatusButton rejButton;
    private int queueId;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < listOfPerson.Count; i++)
        {
            this.listOfPerson[i].gameObject.SetActive(false);
        }

        this.listOfPerson[0].gameObject.SetActive(true);
        accButton.setPersonToDecide(this.listOfPerson[0]);
        rejButton.setPersonToDecide(this.listOfPerson[0]);
        this.queueId = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.listOfPerson[this.queueId].gameObject.activeSelf == false)
        {
            if (this.queueId + 1 < listOfPerson.Count)
            {
                this.queueId += 1;
                this.listOfPerson[this.queueId].gameObject.SetActive(true);
                accButton.setPersonToDecide(this.listOfPerson[this.queueId]);
                rejButton.setPersonToDecide(this.listOfPerson[this.queueId]);
            }
            else
            {
                Debug.Log("ending");
                //Move to finale
            }
        }
    }

    public PersonTest GetCurrentPerson()
    {
        return this.listOfPerson[this.queueId];
    }
}