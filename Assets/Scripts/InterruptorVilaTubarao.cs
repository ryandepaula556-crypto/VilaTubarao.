using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterruptorVilaTubarao : MonoBehaviour {
    public AutoPlayManager autoPlay; // O script do café que criamos antes
    public TextMeshProUGUI txtBotao;
    private bool roboAtivo = false;

    public void AlternarRobo() {
        roboAtivo = !roboAtivo; // Inverte: se tava desligado, liga.

        if (roboAtivo) {
            autoPlay.enabled = true; // LIGA o automático
            txtBotao.text = "ROBÔ: LIGADO ☕";
            txtBotao.color = Color.green;
            Debug.Log("Vila Tubarão: Pode ir fazer o café, o robô assumiu!");
        } else {
            autoPlay.enabled = false; // DESLIGA o automático
            txtBotao.text = "ROBÔ: DESLIGADO 🛑";
            txtBotao.color = Color.white;
            Debug.Log("Vila Tubarão: Controle manual ativado.");
        }
    }
}
