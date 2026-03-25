using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class IntegradorBancos : MonoBehaviour {
    [Header("Configuração de Imagens")]
    public Sprite logoPixOficial;    
    public Sprite logoPagBankOficial; 
    public Image displayBancoSelecionado;
    public GameObject painelConfirmaSaque;

    [Header("Automação de Pagamento (Sigilo Ryan)")]
    // SEU TOKEN DO PAGBANK INJETADO NO CÓDIGO
    private string tokenMestre = "dc840163-c265-4228-a163-9366da4676c1b9bcc00c47ddbf08da4d8521ac47a9283b6b-2891-4486-9a6e-d8fe1662f809";
    private string valorSaque = "0.25";

    public void AtivarPix() {
        displayBancoSelecionado.sprite = logoPixOficial;
        Debug.Log("Modo Pix Ativado!");
        AbrirMenu();
    }

    public void AtivarPagBank() {
        displayBancoSelecionado.sprite = logoPagBankOficial;
        Debug.Log("Modo PagBank Ativado!");
        AbrirMenu();
    }

    void AbrirMenu() {
        painelConfirmaSaque.SetActive(true);
    }

    // O RESTO QUE FALTAVA: A FUNÇÃO QUE PAGA O JOGADOR!
    public void ConfirmarSaque(string chavePixDestino) {
        StartCoroutine(EnviarPixAutomatico(chavePixDestino));
    }

    IEnumerator EnviarPixAutomatico(string chave) {
        string url = "https://api.pagseguro.com/pix/pay";
        
        WWWForm form = new WWWForm();
        form.AddField("value", valorSaque);
        form.AddField("destination_alias", chave);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form)) {
            // Usa o Token que você gerou para autorizar o banco
            www.SetRequestHeader("Authorization", "Bearer " + tokenMestre);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("SISTEMA: Pix de R$ 0,25 enviado com sucesso!");
            } else {
                Debug.Log("ERRO: Falha no Token ou Saldo Insuficiente.");
            }
        }
    }
}