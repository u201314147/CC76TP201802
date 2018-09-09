#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

#include "CityMap.h"

//Función main para nuestro programa que generará la lista de adyacencia de una base de datos dada.
int main(int argc, char *argv[]){
    setlocale(LC_ALL, "es_ES");

    CityMap cmap;

    std::cout << "Loading...";

    if(argc == 1)
        cmap.Load_from_csv("data2.csv");
    else{
        cmap.Load_from_csv(argv[1]);
    }

    std::cout << "\nDONE!";
    std::cout << "\n\nConnecting cities...\n";

    cmap.Connect_cities_by_distance();

    std::cout << "DONE!";
    std::cout << "\n\nExporting...";

    cmap.Export_as_adylst("matrix.al");

    std::cout << "\nDONE!";
}
