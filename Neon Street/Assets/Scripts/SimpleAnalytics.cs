using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class SimpleAnalytics : MonoBehaviour
{
    int ultimoNivelAlcanzado = 0;
    float tiempoConVida = 0f;
    int vecesQueMurioPorNivel = 0;
    public class MiEvento : Unity.Services.Analytics.Event
    {
        public MiEvento() : base("PruebaDatos")
        {
        }
            
        public int Nivel_Que_Alcanzo_Antes_De_Morir { set { SetParameter("Yo_Nivel_Que_Alcanzo_Antes_De_Morir", value); } }
        public float Tiempo_Con_Vida { set { SetParameter("Yo_Tiempo_Con_Vida", value); } }
        public int Veces_Que_Murio_Por_Nivel { set { SetParameter("Yo_Veces_Que_Murio_Por_Nivel", value); } }
    }
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log("✓ Analytics inicializado correctamente"); Debug.Log("Presiona ESPACIO para enviar evento");
        }
        catch (System.Exception e) 
        {
            Debug.LogError($"Error inicializando Analytics: {e.Message}");
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnviarEvento();
        }   
    }
    void EnviarEvento()
    {
        try
        {
            var evento = new MiEvento
            {
                Nivel_Que_Alcanzo_Antes_De_Morir = ultimoNivelAlcanzado,
                Tiempo_Con_Vida = tiempoConVida,
                Veces_Que_Murio_Por_Nivel = vecesQueMurioPorNivel
            };
            AnalyticsService.Instance.RecordEvent(evento);
            AnalyticsService.Instance.Flush();
            Debug.Log($"Evento enviado - Tiempo : {Time.time:F1}$");
        }
        catch(System.Exception e)
        {
            Debug.LogError($"Error evniado evento:{e.Message}");
        }
    }
}
