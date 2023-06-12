   class escape{
    private static string[] incognitasSalas{get; set;}
     private static int estadoJuego{get; set;}
    private static void InicializarJuego(){
        incognitasSalas = new string[] {"true", "ezequiel","true","true"};
        estadoJuego = 1;
    }
    public static int GetEstadoJuego(){
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        InicializarJuego();
        if(Sala == estadoJuego){
            if(Incognita == incognitasSalas[estadoJuego]){
                return true;
                 estadoJuego++;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }
   }