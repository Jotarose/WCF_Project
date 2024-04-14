using System.Runtime.Serialization;
using System.ServiceModel;
using MathNet.Numerics.LinearAlgebra;



namespace MathService
{
    /*
     * ServiceContract es una clase (en este caso interfaz), que proporciona servicios
     */

    [ServiceContract]
    public interface IMath
    {
        /*
         * OperationContract son los servicios que tiene la clase, implementados 
         * como metodos
         */

        [OperationContract]
        bool Prime(int value);

        [OperationContract]
        Tuple sumaInterna(Tuple tupla);

        [OperationContract]
        double[] resolverEcuaciones(double[] matrix, double[] doubles);
    }

    /*
     * Son los tipos de datos que se pasaran como parametro a los servicios
     * solo hace falta para datos que no sean de tipo primitivo
     */
    [DataContract]
    public class Tuple
    {
        double[] _data;
        string _name;

        [DataMember]
        public double[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
       
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}