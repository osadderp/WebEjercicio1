using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bal
{
    public class Bal
    {

        public Task<Respone> calcuate(Request request)
        {
            Respone respone = new Respone();

            respone.entrada = request.lstCasas;
            respone.dias = request.dias;

            List<int> data = new List<int>();
            List<int> dataTemp = new List<int>();

            dataTemp.AddRange(request.lstCasas);




            for (int i = 0; i < request.dias; i++)
            {
                if (dataTemp[1] == 0)
                    data.Add(0);
                else
                    data.Add(1);

                for (int a = 1; a < dataTemp.Count - 1; a++)
                {
                    if (dataTemp[a - 1] == dataTemp[a + 1])
                        data.Add(0);
                    else
                        data.Add(1);
                }

                if (dataTemp[dataTemp.Count - 2] == 0)
                    data.Add(0);
                else
                    data.Add(1);

                dataTemp.Clear();
                dataTemp.AddRange(data);
                data.Clear();

            }

            respone.salida = dataTemp;
            return Task.FromResult(respone);
        }


        public Task<List<int>> calcuate2(RequestP2 request)
        {
            List<int> lstResponse = new List<int>();
            List<int> lstPaquetes = request.lstPaquetes;

            int espacioLibre = request.tamanioCamion - 30;
            var mayorpaquete = lstPaquetes.Max(x => x);
            List<string> pares = new List<string>();
           

            //  lstResponse.Add(mayorpaquete);

            for (int i = 0; i < lstPaquetes.Count; i++)
            {
                for (int a = 0; a < lstPaquetes.Count; a++)
                {
                    if (a != i)
                        pares.Add(lstPaquetes[i] + "," + lstPaquetes[a]);
                }
            }


            foreach (var item in pares)
            {
                if (lstResponse.Count > 1)
                    break;
                if ((Convert.ToInt32(item.Split(",")[0]) + Convert.ToInt32(item.Split(",")[1])) < espacioLibre)
                {
                    lstResponse.Add(Convert.ToInt32(item.Split(",")[0]));
                    lstResponse.Add(Convert.ToInt32(item.Split(",")[1]));
                }
                //if ((item + mayorpaquete) < espacioLibre)
                //{
                //    lstResponse.Add(item);
                //}
            }
            return Task.FromResult(lstResponse);
        }
    }
}
