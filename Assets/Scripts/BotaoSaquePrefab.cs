using UnityEngine;
using UnityEngine.UI;

public class BotaoSaquePrefab : MonoBehaviour {
    public string tipoBanco; // "PIX" ou "PAGBANK"
    
    public void ExecutarClique() {
        Debug.Log("Clicou no botao de " + tipoBanco);
        // Aqui ele chama a tela de digitar o CPF que ja criamos
    }
}
