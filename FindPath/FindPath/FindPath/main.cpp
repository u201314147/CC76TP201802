#include <iostream>

#include "PathFinder.h"

time_t start_time;

int main(int argc, char **argv) {
	setlocale(LC_ALL, "es_ES");

	PathFinder p_finder;

	std::cout <<"Cargando lista de adyacencia...\n\n";

	if(argc < 2)
		p_finder.Load_adylst("adylst.al");
	else{
		p_finder.Load_adylst(argv[1]);
	}

	time(&start_time);
	
	std::cout << "¡LISTO!\n\n";

	std::cout << "Se esta ejecutando el algoritmo. Durante cualquier parte de la ejecucion\ndel mismo, presiones la tecla S para obtener informacion sobre su estado\nactual.\n\n";

	vector<path> p_path = p_finder.Find_path();

	std::cout << "\n!!!!! CAMINO MAS CORTO ENCONTRADO !!!!!\n\n\n";

	print_path(p_path, true);

	std::cout << "\n\nPresione F para continuar.";

	char c;
	while (c = _getch()) {
		if (c == 'f' || c == 'F')
			break;
	}

	return 0;
}