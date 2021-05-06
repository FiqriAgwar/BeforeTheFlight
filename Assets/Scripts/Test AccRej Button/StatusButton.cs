using Person;
using UnityEngine;

public class StatusButton : MonoBehaviour
{
    [SerializeField] private bool status;
    private PersonTest personToDecide;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setPersonToDecide(PersonTest person)
    {
        this.personToDecide = person;
    }

    private void OnMouseDown()
    {
        this.personToDecide.setIsAccepted(status);
        this.personToDecide.gameObject.SetActive(false);
    }
}