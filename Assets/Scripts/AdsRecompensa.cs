using UnityEngine;
using UnityEngine.Advertisements;

public class AdsRecompensa : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener {
    [SerializeField] string _adUnitId = "Rewarded_Android"; 
    public SaldoManager saldo; // Puxa o saldo que criamos

    public void CarregarAd() {
        Debug.Log("Carregando Anúncio Premiado...");
        Advertisement.Load(_adUnitId, this);
    }

    public void MostrarAd() {
        Debug.Log("Mostrando Anúncio para liberar R$ 0,25...");
        Advertisement.Show(_adUnitId, this);
    }

    // O PULO DO GATO: Se ele assistir até o fim, ganha o bônus
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)) {
            Debug.Log("Anúncio Assistido! Liberando saldo...");
            saldo.AdicionarSaldo(0.05f); // Dá 5 centavos por vídeo assistido
        }
    }

    // Métodos obrigatórios da interface (Vazios para ser leve)
    public void OnUnityAdsAdLoaded(string adUnitId) {}
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message) {}
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message) {}
    public void OnUnityAdsShowStart(string adUnitId) {}
    public void OnUnityAdsShowClick(string adUnitId) {}
}
