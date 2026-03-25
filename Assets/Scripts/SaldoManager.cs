using UnityEngine;
using TMPro;

public class SaldoManager : MonoBehaviour {
    public static SaldoManager instance;
    
    [Header("Valores em Dinheiro")]
    public float saldoAtual = 0.00f;
    public TextMeshProUGUI txtSaldoDisplay;

    void Awake() {
        instance = this;
        CarregarDados();
    }

    // Soma o valor (ex: 0.01 por raspadinha)
    public void AdicionarSaldo(float valor) {
        saldoAtual += valor;
        AtualizarInterface();
        SalvarDados();
    }

    public void AtualizarInterface() {
        // Formata para aparecer R$ 0,00 bonito na tela
        txtSaldoDisplay.text = "R$ " + saldoAtual.ToString("F2");
    }

    private void SalvarDados() {
        // Salva o saldo de forma "mascarada" no aparelho
        PlayerPrefs.SetFloat("CH_SD_B1", saldoAtual); 
        PlayerPrefs.Save();
    }

    private void CarregarDados() {
        if (PlayerPrefs.HasKey("CH_SD_B1")) {
            saldoAtual = PlayerPrefs.GetFloat("CH_SD_B1");
            AtualizarInterface();
        }
    }

    public void ResetarSaldoAposSaque() {
        saldoAtual = 0.00f;
        SalvarDados();
        AtualizarInterface();
    }
}
