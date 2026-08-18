using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer {
    public class County {
        public int countyID;
        public string countryName;
        public County() {
            countyID = -1;
            countryName = "";
        }
        public static DataTable getCountries() {
            return CountriesData.getAllCountries();
        }


    }

}
