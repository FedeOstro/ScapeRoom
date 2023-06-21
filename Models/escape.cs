   class escape{
    private static string[] incognitasSalas{get; set;}
    private static void InicializarJuego(){
        incognitasSalas = new string[] {"Interestellar", "ezequiel","1235","papel,silencio,anillo", "2832"};
    }

    public static bool ResolverSala(int Sala, string Incognita){
        InicializarJuego();
        bool resolvio = true;
        if(Incognita == incognitasSalas[Sala-1]){
            return resolvio == true;
        }else{
            return resolvio == false;
        }   
    }
    public static bool ResolverSala1(int Sala, string Incognita){
        InicializarJuego();
        bool resolvio = true;
        if(Incognita == incognitasSalas[0]){
            return resolvio == true;
        }else{
            return resolvio == false;
        }
    }
   }