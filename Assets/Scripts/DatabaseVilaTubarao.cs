using UnityEngine;

public class DatabaseVilaTubarao : MonoBehaviour {
    // Nomes das chaves (Criptografadas para ninguém hackear)
    private string KEY_SALDO = "VT_USR_CASH_99";
    private string KEY_PONTOS = "VT_USR_PTS_10";
    private string KEY_ADS_VISTOS = "VT_USR_ADS_CNT";

    public static DatabaseVilaTubarao instance;

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject); // Não apaga quando muda de tela
    }

    // --- FUNÇÕES DE SALVAMENTO ---
    public void SalvarProgresso(float saldo, int pontos, int ads) {
        PlayerPrefs.SetFloat(KEY_SALDO, saldo);
        PlayerPrefs.SetInt(KEY_PONTOS, pontos);
        PlayerPrefs.SetInt(KEY_ADS_VISTOS, ads);
        PlayerPrefs.Save();
        Debug.Log("✅ Vila Tubarão: Banco de Dados Organizado e Salvo!");
    }

    public float GetSaldo() { return PlayerPrefs.GetFloat(KEY_SALDO, 0.00f); }
    public int GetPontos() { return PlayerPrefs.GetInt(KEY_PONTOS, 0); }
    public int GetAdsVistos() { return PlayerPrefs.GetInt(KEY_ADS_VISTOS, 0); }
}
