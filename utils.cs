using FloodFill2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comparlize
{
    
   
  
    class utils
    {
        

        //QU - 1
        public int exact(string[] ar,int num)
        {
            int count = 0;
            for(int i=0; i< ar.Length; ++i)
            {
                if (ar[i].Length == num) count++;
            }
            return count;
        }

         

    }
    //qu - 2
   
        class ccar
        {
            string license;
            bool hadaccident;
            int price;
            private bool Range(int max , int min)
            {
                return max > price && min < price ?true:false;
            }

        }
        class allcar
        {
            ccar[] ar;
            int num;

            private bool adddcar(ccar cn)
            {
                if(num < ar.Length)
                {
                    ar[num++] = cn;
                    return true;
                }
                return false;
            }
        }
    }
   //qu - 4
   //l (1) - true
   //ou (2) - (222,5) its return false when they numbers are diffrents 
   // k(3) - the function get 2 numbers , x00 , 00y check if x%2 == y%2
  
    

   