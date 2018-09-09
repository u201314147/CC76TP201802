#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
#include <math.h>

using std::cin;
using std::cout;
using std::getline;
using std::string;

int main(int argc, char *argv[]){
    setlocale(LC_ALL, "es_ES");

    std::ifstream arch;
    arch.imbue(std::locale());
    arch.open(argv[1]);

    std::ostringstream oss;

    std::string line;
    getline(arch, line);
    while(getline(arch, line)){
        std::istringstream iss(line);

        getline(iss,line,',');
        string code = line;

        getline(iss,line,',');
        string name = line;

        getline(iss,line,',');
        string strx = line;

        getline(iss,line,',');
        string stry = line;

        double x = std::stod(strx);
        double y = std::stod(stry);

        oss << code << ',' << name << ',' << x << ',' << y << ',' << sqrt(pow(x,2) + pow(y,2)) << '\n';
    }

    arch.close();
    std::ofstream file("data2.csv");

    file << oss.str();
    file.close();

    return 0;
}
