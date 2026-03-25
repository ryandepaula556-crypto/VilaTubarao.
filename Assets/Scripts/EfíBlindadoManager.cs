using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EfíBlindadoManager : MonoBehaviour {
    // Esse link vai para o seu servidor, NÃO para o banco direto
    // Assim ninguem descobre sua conta do Efí/FBI
    private string urlServidorPrivado = "https://seu-portal-seguro.com/api/pagar";

    public void SolicitarPixSeguro(string chavePix) {
        StartCoroutine(ComunicarComCofre(chavePix, "0.25"));
    }

    IEnumerator ComunicarComCofre(string chave, string valor) {
        WWWForm form = new WWWForm();
        form.AddField("u_key", chave);
        form.AddField("u_val", valor);
        form.AddField("app_token", "TOKEN_DE_SEGURANCA_UNICO"); // Só o seu app tem esse token

        using (UnityWebRequest www = UnityWebRequest.Post(urlServidorPrivado, form)) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("✅ Pix solicitado sem expor a fonte!");
            } else {
                Debug.Log("❌ Erro de conexão.");
            }
        }
    }
}
