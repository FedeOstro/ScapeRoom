   class escape{
    private static string[] incognitasSalas{get; set;}
    private static void InicializarJuego(){
        incognitasSalas = new string[] {"true", "ezequiel","1235","true", "2832"};
    }

    public static bool ResolverSala(int Sala, string Incognita){
        InicializarJuego();
        bool resolvio = true;
        if(Incognita == incognitasSalas[Sala]){
            return resolvio == true;
        }else{
            return resolvio == false;
        }   
    }
    
   }