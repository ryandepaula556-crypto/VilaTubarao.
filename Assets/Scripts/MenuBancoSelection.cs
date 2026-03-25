using UnityEngine;
using UnityEngine.UI;

public class MenuBancoSelection : MonoBehaviour {
    public Image logoBancoSelecionado;
    public Sprite logoPagBank;
    public Sprite logoPixEfi;

    public void SelecionarPagBank() {
        logoBancoSelecionado.sprite = logoPagBank;
        Debug.Log("PagBank selecionado para o saque de R$ 0,25!");
    }

    public void SelecionarPixEfi() {
        logoBancoSelecionado.sprite = logoPixEfi;
        Debug.Log("Efí/FBI selecionado!");
    }
}
