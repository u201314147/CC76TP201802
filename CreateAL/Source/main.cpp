#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

#include "CityMap.h"

//Función main para nuestro programa que generará la lista de adyacencia de una base de datos dada.
int main(int argc, char *argv[]){
    setlocale(LC_ALL, "es_ES");

    if(argc == 1){
        std::cout << "ERROR: Ningún archivo envíado." << std::endl;
        return 1;
    }
    else
        std::cout << "Cargando...";

    CityMap cmap;
    cmap.Load_from_csv(argv[1]);

    std::cout << "\n¡LISTO!";
    std::cout << "\n\nConectando ciudades...\n";

    cmap.Connect_cities_by_distance_orig();

    std::cout << "¡LISTO!";
    std::cout << "\n\nExportando...";

    cmap.Export_as_adylst("adylst.al", "metadata.md");

    std::cout << "\n¡LISTO!";

    return 0;
}
