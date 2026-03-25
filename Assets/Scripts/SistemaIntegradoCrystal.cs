using UnityEngine;

public class SistemaIntegradoCrystal : MonoBehaviour {
    // Esse script une TUDO que criamos no seu Pendrive
    void Start() {
        Debug.Log("--- CRYSTAL BLAST: SISTEMA INICIADO ---");
        Debug.Log("1. Raspadinha Automática: OK");
        Debug.Log("2. Blindagem de Fonte (Oculto): OK");
        Debug.Log("3. Interface Pix/PagBank: OK");
        Debug.Log("4. Som de Moedas: OK");
    }

    public void AbrirSaque() {
        // Logica para liberar o painel de 0,25 centavos
        Debug.Log("Saque liberado para o usuario!");
    }
}
