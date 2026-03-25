using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameMasterRendaExtra : MonoBehaviour {
    public TextMeshProUGUI txtPontos;
    public AudioSource emissorSom;
    public AudioClip somMoeda;
    public GameObject painelSaque;
    private float pontos = 0;

    void Start() {
        painelSaque.SetActive(false);
        StartCoroutine(AutoPlayTurbo());
    }

    IEnumerator AutoPlayTurbo() {
        while (pontos < 100) {
            yield return new WaitForSeconds(1.2f); // Velocidade da Raspadinha
            float ganho = Random.Range(10f, 26f); // Pula pontos: 10, 25, 40...
            pontos += ganho;
            if (pontos > 100) pontos = 100;
            
            txtPontos.text = Mathf.FloorToInt(pontos).ToString();
            if (emissorSom && somMoeda) emissorSom.PlayOneShot(somMoeda);
        }
        LiberarSaque();
    }

    void LiberarSaque() {
        painelSaque.SetActive(true); // Abre o menu de R$ 0,25
        Debug.Log("Saque de R$ 0,25 Disponível para o Grupo!");
    }

    public void OnClickSaquePix() {
        // Integração com Efí/FBI aqui
        pontos = 0;
        txtPontos.text = "0";
        painelSaque.SetActive(false);
        StartCoroutine(AutoPlayTurbo());
    }
}
