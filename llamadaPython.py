from zeep import Client

# URL del servicio WCF
url = 'http://localhost:80/Design_Time_Addresses/MathService/Math/'

# Crear el cliente SOAP
client = Client(url)

print("Estableciendo conexion con MathService...\n")

numero = 3

print(f"Vamos a hacer una llamada al metodo prime para determinar si el {numero} es primo:")

# Llamar a un método del servicio
resultado = client.service.Prime(numero)

print(f"El {numero}, {resultado} primo.")

