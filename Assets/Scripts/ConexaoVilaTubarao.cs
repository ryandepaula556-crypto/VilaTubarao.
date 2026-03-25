using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ConexaoVilaTubarao : MonoBehaviour {
    // COLOQUE O LINK DO SEU SITE AQUI (Onde voce subiu o PHP)
    private string urlServidor = "https://seusite.com/CofrePagamento.php";

    public IEnumerator EnviarPedidoPix(string chavePix) {
        WWWForm form = new WWWForm();
        form.AddField("chave", chavePix);
        form.AddField("valor", "0.25");

        using (UnityWebRequest www = UnityWebRequest.Post(urlServidor, form)) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Vila Tubarão: Pix de 0,25 solicitado com sucesso!");
            } else {
                Debug.Log("Erro no Servidor: " + www.error);
            }
        }
    }
}
