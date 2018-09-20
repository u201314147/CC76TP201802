#include "UI.h"

using namespace System;
using namespace System::Windows::Forms;

[STAThreadAttribute]
int Main(array<String^>^ args) {

	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(true);
	CreateAL::UI ^form = gcnew CreateAL::UI();
	Application::Run(form);

	delete form;

	/*
	setlocale(LC_ALL, "es_ES");

	CityMap cmap;

	std::cout << "Loading...";

	if(argc == 1)
	cmap.Load_from_csv("data2.csv");
	else{
	cmap.Load_from_csv(argv[1]);

	std::cout << "\nDONE!";
	std::cout << "\n\nConnecting cities...\n";

	cmap.Connect_cities_by_distance();

	std::cout << "DONE!";
	std::cout << "\n\nExporting...";

	cmap.Export_as_adylst("matrix.al");

	std::cout << "\nDONE!";
	*/

	return 0;
}
