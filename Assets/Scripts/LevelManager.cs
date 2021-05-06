using Document;
using Person;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private DocumentFactory documentFactory;
    [SerializeField] private PersonManager personManager;

    public void NextCustomer()
    {
        // TODO: Call person manager next person
        personManager.NextPerson();
        // TODO: Setup document
        documentFactory.CreateDocument();
    }
}