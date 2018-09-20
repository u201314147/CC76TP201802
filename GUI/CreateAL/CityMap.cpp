#include "CityMap.h"

#include <string>
#include <sstream>
#include <iostream>

using std::getline;
using std::istringstream;
using std::ostringstream;

CityMap::CityMap(){}


void CityMap::Connect_cities_by_distance(){
    for(vector<City>::size_type i = 0; i < (number_cities - 4); ++i){
        for(int j = 1; j <= 4; ++j)
            map_cities[i].Connect_with_city(map_cities[i+j]);

        if(i % 1000 == 0)
            std::cout << "Processed: " << i << " cities." << '\n';
    }

    for(vector<City>::size_type i = number_cities - 1; i >= (number_cities - 4); --i){
        for(int j = 1; j <= 4; ++j)
            map_cities[i].Connect_with_city(map_cities[i-j]);
    }
}

void CityMap::Load_from_csv(string filename){
	setlocale(LC_ALL, "es_ES");

    ifstream *file = new ifstream;
    file->imbue(std::locale());
    file->open(filename);

    Load_from_csv(file);
}

void CityMap::Load_from_csv(ifstream *file){
    string line;

    while(getline(*file, line)){
        istringstream iss(line);

        getline(iss,line,',');
        string code = line;

        getline(iss,line,',');
        string name = line;

        getline(iss,line,',');
        string x = line;

        getline(iss,line,',');
        string y = line;

        getline(iss,line,',');
        string d = line;

        ++number_cities;
        map_cities.push_back(City(std::stoi(code), name, std::stod(x), std::stod(y), std::stod(d)));
    }

	file->close();
	delete file;
}

void CityMap::Export_as_adylst(string filename){
    ofstream file(filename);

    ostringstream data;
    for(City c : map_cities){
        data << c.Get_code() << ';';
        data << c.Get_name() << ';';

        vector<int> c_list = c.Get_connected_cities();
        vector<double> d_list = c.Get_connected_distances();

        for(int i = 0; i < 4; ++i){
            data << c_list[i] << ',' << d_list[i] << ';';
        }

        data << '\n';
    }

    file << data.str();
    file.close();
}