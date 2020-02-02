using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public Image ImagePrefab;
    public Transform ImageHolder;
    List<Image> InventoryImages;

	private void Start()
	{
        InventoryImages = new List<Image>();
	}

	public void PickUp(Sprite s)
    {
        Image img = Instantiate(ImagePrefab);
        img.sprite = s;

        InventoryImages.Add(img);
        img.transform.SetParent(ImageHolder);
        //img.transform.position = new Vector3(0, 0, 0);
        img.transform.localScale = new Vector3(1, 1, 1);
    }

    public void Remove(Sprite s)
    {
        for (int i = 0; i < InventoryImages.Count; i++)
        {
            if(InventoryImages[i].sprite == s)
            {
                Destroy(InventoryImages[i].gameObject);
                break;
            }
        }
    }
}
