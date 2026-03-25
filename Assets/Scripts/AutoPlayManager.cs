using UnityEngine;
using System.Collections;

public class AutoPlayManager : MonoBehaviour {
    public GameMasterRendaExtra gameMaster;
    public SaldoManager saldoManager;
    public UnityAdsManager adsManager;

    [Header("Configuração do Café")]
    public float intervaloRaspada = 3.0f; // 3 segundos entre cada acerto
    private bool estaRodando = true;

    void Start() {
        StartCoroutine(CicloAutomatico());
    }

    IEnumerator CicloAutomatico() {
        while (estaRodando) {
            yield return new WaitForSeconds(intervaloRaspada);

            // 1. Simula que o usuário raspou e ganhou pontos
            gameMaster.pontos += 10; 
            
            // 2. Toca o som de moeda (usando o Singleton que criamos)
            if(SomManager.instance != null) SomManager.instance.TocarMoeda();

            // 3. Adiciona um valor pequeno ao saldo real
            saldoManager.AdicionarSaldo(0.01f);

            Debug.Log("Automático: Raspada concluída! Saldo atualizado.");

            // 4. Se bater 50 pontos, mostra um anúncio rápido para pagar o Pix
            if (gameMaster.pontos % 50 == 0) {
                adsManager.MostrarVideoRecompensa();
            }

            // Para se chegar em 100 (Pronto para o Pix)
            if (gameMaster.pontos >= 100) {
                Debug.Log("CAFÉ PRONTO! Saldo de R$ 0,25 atingido.");
                // Opcional: estaRodando = false; // Se quiser que pare no 100
            }
        }
    }
}
