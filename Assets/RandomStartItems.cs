using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class RandomStartItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int maxStarterItems = 4;
        int totalItems = 12;
        int i = 0;
        while (i < maxStarterItems) {
            List<InvItem> notCarried = new List<InvItem>();

            for (int f = 0; f < totalItems; f++) {
                bool carrying = AC.KickStarter.runtimeInventory.IsCarryingItem(f);
                if (!carrying){
                    notCarried.Add(AC.KickStarter.inventoryManager.GetItem(f));
                }
            }

            InvItem item = notCarried[Random.Range(0, notCarried.Count)];
            AC.KickStarter.runtimeInventory.Add(item.id);
            i++;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
