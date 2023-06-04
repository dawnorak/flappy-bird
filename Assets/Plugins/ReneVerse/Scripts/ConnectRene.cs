using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectRene : MonoBehaviour
{
    private IEnumerator ConnectReneService(API reneApi)
    {
        var counter = 0;
        var userConnected = false;
        var secondsToIncrement = 1;
        while (counter <= secondsToWait && !userConnected)
        {
            print(counter);
            if (reneApi.IsAuthorized())
            {
                yield return GetUserAssetsAsync(reneApi);
                userConnected = true;
            }

            yield return new WaitForSeconds(secondsToIncrement);
            counter += secondsToIncrement;
        }
    }
}
