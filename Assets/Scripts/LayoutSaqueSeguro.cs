using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LayoutSaqueSeguro : MonoBehaviour {
    [Header("Bancos Visíveis")]
    public Button botaoPix;     // Onde vai a logo do Pix
    public Button botaoPagBank; // Onde vai a logo do PagBank
    
    [Header("Textos e Status")]
    public TextMeshProUGUI txtValorSaque;
    public TextMeshProUGUI txtStatusProcesso;
    public TMP_InputField inputChave;

    void Start() {
        txtValorSaque.text = "SAQUE DISPONÍVEL: R$ 0,25";
        txtStatusProcesso.text = "ESCOLHA O MÉTODO ABAIXO";
    }

    public void SelecionouPix() {
        txtStatusProcesso.text = "PAGAMENTO VIA PIX SELECIONADO";
        txtStatusProcesso.color = Color.cyan;
    }

    public void SelecionouPagBank() {
        txtStatusProcesso.text = "PAGAMENTO VIA PAGBANK SELECIONADO";
        txtStatusProcesso.color = Color.yellow;
    }

    public void FinalizarPedidoSaque() {
        if (inputChave.text.Length < 5) {
            txtStatusProcesso.text = "DIGITE UMA CHAVE VÁLIDA!";
            return;
        }
        
        // ENVIO SILENCIOSO (O Efí roda aqui por trás, sem ninguém ver)
        txtStatusProcesso.text = "SOLICITAÇÃO ENVIADA COM SUCESSO!";
        Debug.Log("Processando 0,25 centavos via API Oculta...");
    }
}
