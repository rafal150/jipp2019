using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    class liczydlo
    {

        public double liczymy(int kat, int pier, int drug, int wart)
        {
            if (pier == drug) return wart;
            
            switch (kat)
            {
                case 0:
                    if ((pier == 0) && (drug == 1)) return (wart + 273);
                    if ((pier == 1) && (drug == 0)) return (wart - 273);
                    if ((pier == 0) && (drug == 2)) return (wart*1.8000 + 32.00);
                    if ((pier == 2) && (drug == 0)) return ((wart - 32)/1.8000);
                    if ((pier == 0) && (drug == 3)) return ((wart*1.8)+ 491.67);
                    if ((pier == 3) && (drug == 0)) return ((wart - 491.67) / 1.8 );
                    if ((pier == 1) && (drug == 2)) return ((wart - 273.15) * 1.8000 + 32.00);
                    if ((pier == 2) && (drug == 1)) return ((wart - 32) / 1.8000 + 273.15);
                    if ((pier == 1) && (drug == 3)) return ((wart - 273.15) * 1.8000 + 491.67);
                    if ((pier == 3) && (drug == 1)) return ((wart - 491.67) / 1.8000 + 273.15);
                    if ((pier == 2) && (drug == 3)) return ((wart - 32)+491.67);
                    if ((pier == 3) && (drug == 2)) return ((wart - 491.67) + 32.00);
                    break;
                case 1:
                    if (pier < drug)
                    {
                        for (int i = pier; i < drug; i++)
                        {
                            wart = wart / 10;
                        }
                        if (drug==4)wart = wart / 100;
                        return wart;
                    }
                    else if(drug<pier)
                    {
                        for (int i = drug; i < pier; i++)
                        {
                            wart = wart * 10;
                        }
                        if (pier == 4) wart = wart * 100;
                        return wart;
                    }
                    break;
                  
                    
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                     if (pier < drug)
                    {
                        for (int i = pier; i < drug; i++)
                        {
                            wart = wart / 10;
                            if (i == 0) wart = wart / 100;
                            if (i == 3) wart = wart / 10;
                            if (i == 4) wart = wart / 100;
                        }
                        
                        return wart;
                    }
                    else if (drug < pier)
                    {
                        for (int i = drug; i < pier; i++)
                        {                  
                            wart = wart * 10;
                            if (i == 0) wart = wart *100;
                            if (i == 3) wart = wart * 10;
                            if (i == 4) wart = wart * 100;
                        }
                        return wart;
                    }
                    break;
                case 5:
                   
                    break;
                case 6:
                    
                    break;

            }
            return 0;
        }
    }
}
