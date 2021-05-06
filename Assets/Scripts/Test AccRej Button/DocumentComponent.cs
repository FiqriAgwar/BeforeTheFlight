using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class DocumentComponent : ICheckableComponent
// {
//     public DocumentComponentType documentComponentType;
//
//
//     public override bool CheckComponent()
//     {
//         throw new System.NotImplementedException();
//     }
//
//     // Start is called before the first frame update
//     void Start()
//     {
//
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//
//     }
// }

public enum DocumentComponentType
{
    KTPPROVINCE,
    KTPNUMBER,
    KTPNAME,
    KTPCITY,
    KTPPHOTO,
    KTPBIRTHPLACEDATE,

    TICKETNAME,
    TICKETAIRLINE,
    TICKETNUMBER,
    TICKETBOARDINGTIME,
    TICKETSEAT,

    PASSPORTNAME,
    PASSPORTPHOTO,
    PASSPORTBIRTHPLACEDATE,
    PASSPORTHEIGHT,
    PASSPORTCOUNTRY,
    PASSPORTCOUNTRYSIGN
}
