using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPrincipalRendaExtra : MonoBehaviour {
    public TextMeshProUGUI txtBoasVindas;
    
    void Start() {
        txtBoasVindas.text = "BEM-VINDO AO CRYSTAL BLAST\\nPRONTO PARA OS R$ 0,25?";
    }

    public void IniciarJogo() {
        SceneManager.LoadScene("CenaJogo"); // Nome da sua cena de raspadinha
    }

    public void AbrirTelegramGrupo() {
        Application.OpenURL("https://t.me/seu_grupo_de_renda_extra");
    }
}
