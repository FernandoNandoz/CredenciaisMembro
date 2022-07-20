using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteirinhaMembro
{
    class Banco
    {
        public SqlConnection connection = new SqlConnection();

        public void conectar()
        { 

            connection.ConnectionString = ("Data Source=(local);Initial Catalog=membrosCOMADEMAT;Integrated Security=True;");
            connection.Open();
        }

        public void desconectar()
        {
            connection.Close();
        }
    }

    public class Log
    {
        static string codigoLog;

        public static void gerarLog(string descrocao)
        {
            codigoLog = descrocao;

        }

        public static string _retornarLog()
        {
            codigoLog = (DateTime.Now.Minute + ""
                        + DateTime.Now.Hour + ""
                        + DateTime.Now.Day + ""
                        + DateTime.Now.Month + ""
                        + DateTime.Now.Year + ""
                        
                        );

            return codigoLog;
        }
    }

    public class Consulta
    {
        static int idMembro;

        public static void receberID(int ID)
        {
            idMembro = ID;
        }

        public static int _retornarID()
        {
            return idMembro;
        }
    }

    public class UpdateMembro
    {
        static int idMembro;
        static bool methodUpdate;
        static int window = 0;

        public static void receberWindow(int ID, bool methode, int responseWindow)
        {
            idMembro = ID;
            methodUpdate = methode;
            window = responseWindow;
        }

        public static int _retornarIdMembro()
        {
            return idMembro;
        }

        public static bool _retornarMethodUpdate()
        {
            return methodUpdate;
        }

        public static int _retornarWindow()
        {
            return window;
        }
    }
}
