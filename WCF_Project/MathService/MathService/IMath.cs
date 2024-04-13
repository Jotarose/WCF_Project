using System.Runtime.Serialization;
using System.ServiceModel;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

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
        double[] resolverEcuaciones(Tuple tupla);
    }

    /*
     * Son los tipos de datos que se pasaran como parametro a los servicios
     * solo hace falta para datos que no sean de tipo primitivo
     */
    [DataContract]
    public class Tuple
    {
        double[] _data;
        Matrix _equation;
        string _name;

        [DataMember]
        public double[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public Matrix Equation
        { 
            get { return _equation; } 
            set { _equation = value; }
        }
        
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}