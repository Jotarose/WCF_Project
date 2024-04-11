from zeep import Client
from zeep.exceptions import Fault

# URL del servicio WCF
url = 'http://localhost:80/Design_Time_Addresses/MathService/Math/?wsdl'

try:
    # Crear el cliente SOAP
    client = Client(url)

    print("Estableciendo conexion con MathService...\n")

    numero = 3

    print(f"Vamos a hacer una llamada al metodo prime para determinar si el {numero} es primo:")

    # Llamar al método del servicio
    resultado = client.service.Prime(numero)

    print(f"El numero {numero} {'es' if resultado else 'no es'} primo.")

except Fault as e:
    print(f"Error al llamar al servicio: {e.message}")
except Exception as e:
    print(f"Error general: {str(e)}")

