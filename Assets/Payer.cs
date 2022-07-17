using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Payer : MonoBehaviour
{
    private int balance;
    public string status;
    public Text MyBalance;
    public void Pay()
    {
        Application.OpenURL("www.lovlebook.ru/pay.php");
    }

   
   public  void CheckPay()
    {
   
       
        StartCoroutine("LoadJson");
    }



   private IEnumerator LoadJson()
   {
       using (WWW www = new WWW("www.lovlebook.ru/check_pay.php"))
       {
           yield return www;
       }

       ;
       UnityWebRequest request = UnityWebRequest.Get("https://lovlebook.ru/j.json");
       yield return request.SendWebRequest();
       Debug.Log(request.downloadHandler.text);
       status = request.downloadHandler.text;
       if (status == @"{""Name"":""succeeded""}")
       {
           balance += 10;
           MyBalance.text = balance.ToString();
       }
   }
}
