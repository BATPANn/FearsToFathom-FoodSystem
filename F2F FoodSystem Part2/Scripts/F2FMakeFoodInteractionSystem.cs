using UnityEngine;
using UnityEngine.UI;

public class F2FMakeFoodInteractionSystem : MonoBehaviour
{


    public GameObject WholeCanvasPack_GO;

    public GameObject Pepper_GO;
    public GameObject Salt_GO;

    public GameObject[] Eggs_GO;

    public GameObject[] BrokenEggs_GO;

    private bool CanInteract = true;

    public F2FMakeFoodInventory InventoryScript;

    public GameObject EggPack_GO;

    public Toggle EggsToggle;
    public Toggle SaltToggle;
    public Toggle PepperToggle;
    public Text EggsText;

    private bool HandIsFull = false;

    


    // Update is called once per frame
    void Update()
    {


        if(CanInteract == true)
        {


            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3f))
            {


                if (hit.collider.CompareTag("Pan"))
                {

                    if (WholeCanvasPack_GO.activeSelf == false)
                    {

                        WholeCanvasPack_GO.SetActive(true);

                    }

                    if(Input.GetMouseButtonDown(0) && HandIsFull == true)
                    {


                        PlaceStuffVoid();


                    }



                }
                else if (hit.collider.CompareTag("Eggs"))
                {

                    if (WholeCanvasPack_GO.activeSelf == true)
                    {

                        WholeCanvasPack_GO.SetActive(false);


                    }

                    if (Input.GetMouseButtonDown(0) && HandIsFull == false)
                    {

                        // take eggs
                        TakeEggsVoid();


                    }



                }
                else if (hit.collider.CompareTag("Salt"))
                {

                    if (WholeCanvasPack_GO.activeSelf == true)
                    {

                        WholeCanvasPack_GO.SetActive(false);


                    }

                    if (Input.GetMouseButtonDown(0) && HandIsFull == false)
                    {

                        TakeSaltVoid();


                    }



                }
                else if (hit.collider.CompareTag("Pepper"))
                {

                    if (WholeCanvasPack_GO.activeSelf == true)
                    {

                        WholeCanvasPack_GO.SetActive(false);


                    }

                    if (Input.GetMouseButtonDown(0) && HandIsFull == false)
                    {

                        TakePepperVoid();


                    }


                }
                else
                {

                    if (WholeCanvasPack_GO.activeSelf == true)
                    {

                        WholeCanvasPack_GO.SetActive(false);


                    }



                }



            }
            else
            {


                if(WholeCanvasPack_GO.activeSelf == true)
                {

                    WholeCanvasPack_GO.SetActive(false);


                }
                


            }




        }


        
    }






    private void TakeEggsVoid()
    {


        HandIsFull = true;

        // take eggs

        if(InventoryScript.NumberofEggs == 0)
        {


            InventoryScript.NumberofEggs = 1;
            Eggs_GO[0].SetActive(false);


        }
        else if(InventoryScript.NumberofEggs == 1)
        {

            InventoryScript.NumberofEggs = 2;
            Eggs_GO[1].SetActive(false);
            EggPack_GO.SetActive(false);

        }


        


    }


    private void TakeSaltVoid()
    {

        HandIsFull = true;

        InventoryScript.HaveSalt = true;
        Salt_GO.SetActive(false);

    }

    private void TakePepperVoid()
    {

        HandIsFull = true;


        InventoryScript.HavePepper = true;
        Pepper_GO.SetActive(false);


    }

    private void PlaceStuffVoid()
    {

        HandIsFull = false;


        if(InventoryScript.HavePepper == true)
        {

            InventoryScript.HavePepper = false;

            PepperToggle.isOn = true;


        }

        if(InventoryScript.HaveSalt == true)
        {

            InventoryScript.HaveSalt = false;

            SaltToggle.isOn = true;


        }

        if(InventoryScript.NumberofEggs == 1)
        {

            BrokenEggs_GO[0].SetActive(true);
            EggsText.text = "Eggs(1/2)";


        }
        else if(InventoryScript.NumberofEggs == 2)
        {

            BrokenEggs_GO[1].SetActive(true);
            EggsText.text = "Eggs(2/2)";
            EggsToggle.isOn = true;

        }




    }


}
