using UnityEngine;
using UnityEngine.UI;

public class HouseInteraction : MonoBehaviour
{
    public Image currentTool;
    public Sprite brosse;
    public Sprite extincteur;
    public Sprite cle;
    public Sprite epuisette;
    public Inventory playerInventory;
    public Image handSlot;
   public void equip_Balais_Brosse() //Permet d'�quiper le balais brosse
    {
        currentTool.gameObject.SetActive(true);
        Debug.Log("Balais brosse �quip�");
        currentTool.sprite = brosse; //Change l'outil pour brosse
        handSlot.sprite = brosse; //Affichage slot main
        handSlot.gameObject.SetActive(true);
        playerInventory.activeItem = "brosse";
    }

    public void equip_Epuisette()
    {
        Debug.Log("Epuisette �quip�e");
        currentTool.gameObject.SetActive(true);
        currentTool.sprite = epuisette; //Change l'outil pour epuisette
        handSlot.sprite = epuisette; //Affichage slot main
        handSlot.gameObject.SetActive(true);
        playerInventory.activeItem = "epuisette";
    }

    public void equip_Cle()
    {
        Debug.Log("Cl� �quip�e");
        currentTool.gameObject.SetActive(true);
        currentTool.sprite = cle; //Change l'outil actuel pour anti-pi�ge
        handSlot.sprite = cle; //Affichage slot main
        handSlot.gameObject.SetActive(true);
        playerInventory.activeItem = "cle";
    }

    public void equip_Extincteur()
    {
        Debug.Log("Extincteur �quip�");
        currentTool.gameObject.SetActive(true);
        currentTool.sprite = extincteur; //Change l'outil actuel pour extincteur
        handSlot.sprite = extincteur; //Affichage slot main
        handSlot.gameObject.SetActive(true);
        playerInventory.activeItem = "extincteur";
    }
}
