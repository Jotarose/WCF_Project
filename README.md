# WCF_Project

## Descripción

Este proyecto es una solución de ejemplo que implementa un servicio WCF (Windows Communication Foundation) para operaciones matemáticas básicas y su consumo desde diferentes clientes. 
Incluye:

- **MathService**: Servicio WCF que expone operaciones matemáticas como verificación de números primos y suma de tuplas.
- **MathServiceHost**: Aplicación de consola para alojar el servicio WCF.
- **MathClientConsole**: Cliente de consola que consume el servicio WCF.
- **MathClientWPF**: Cliente WPF con interfaz gráfica para interactuar con el servicio.
- **llamadaPython.py**: Script de ejemplo para consumir el servicio desde Python usando SOAP.

## Estructura del Proyecto

```bash
MathService/
├── MathService/            # WCF service project
├── MathClientWPF/          # WPF client for MathService
├── MathServiceHost/
│   └── MathServiceHost/    # WCF service host
├── MathClientConsole/
│   └── MathClientConsole/  # Console client
└── llamadaPython.py        # Example of consumption from Python
````


## Cómo ejecutar

### 1. Compilar la solución

Abre la solución principal en Visual Studio (`MathService/MathService.sln`) y compila todos los proyectos.

### 2. Iniciar el servicio

Ejecuta el proyecto **MathServiceHost** para alojar el servicio WCF. Deberías ver un mensaje indicando que el servicio está en ejecución.

### 3. Probar los clientes

- **MathClientConsole**: Ejecuta el proyecto para probar el consumo desde consola.
- **MathClientWPF**: Ejecuta el proyecto para probar la interfaz gráfica.
- **llamadaPython.py**: Ejecuta el script en Python para probar el consumo externo vía SOAP.

## Operaciones del Servicio

El servicio expone las siguientes operaciones (ver [`IMath`](MathService/MathService/IMath.cs)):

- `Prime(int value)`: Devuelve si un número es primo.
- `sumaInterna(Tuple tupla)`: Suma los valores de una tupla y devuelve el resultado.

## Configuración

- Los endpoints y bindings están configurados en los archivos `App.config` de cada proyecto.
- El servicio está disponible por HTTP y NetTcp en las siguientes direcciones:
  - `http://localhost:80/Design_Time_Addresses/MathService/Math/`
  - `net.tcp://localhost:8082/Math`

Este proyecto es solo para fines educativos y de demostración.
