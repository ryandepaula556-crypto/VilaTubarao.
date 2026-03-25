using UnityEngine;
using System;

public class AntiFraudeManager : MonoBehaviour {
    public GameMasterRendaExtra gameMaster;
    
    // Tempo de espera entre saques (ex: 24 horas)
    private int horasEspera = 24;

    public bool PodeSacar() {
        // 1. Verifica se tem os pontos
        if (gameMaster.pontos < 100) return false;

        // 2. Verifica se ja sacou hoje (baseado no relogio do celular)
        if (PlayerPrefs.HasKey("UltimoSaque")) {
            DateTime ultimo = DateTime.Parse(PlayerPrefs.GetString("UltimoSaque"));
            if ((DateTime.Now - ultimo).TotalHours < horasEspera) {
                Debug.Log("ERRO: Voce ja sacou hoje! Volte amanha.");
                return false;
            }
        }
        return true;
    }

    public void RegistrarSaqueSucesso() {
        PlayerPrefs.SetString("UltimoSaque", DateTime.Now.ToString());
        gameMaster.pontos = 0; // Reseta os pontos apos o saque
    }
}
