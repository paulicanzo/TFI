using LPA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPA.Context
{
    public class GeneradorDeProductos
    {
        public static void GenerarDatos(IServiceProvider serviceProvider)
        {
            using (var context = new ProductosDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProductosDbContext>>()))
            {
                // Si existen productos en la base de datos en memoria nos vamos
                if (context.Productos.Any())
                {
                    return;
                }

                context.Productos.AddRange(
                    new Producto
                    {
                        ProductId = 1,
                        ProductName = "Teclado Genius Slimstar 130 Black Usb Garantia Oficial",
                        ProductPrice = 469M,
                        ProductDescription = @"E S P E C I F I C A C I O N E S 
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        • Diseño del Teclado: Estandar
                        • Interfaz: USB
                        • Distribución de Teclado: Español
                        • Estilo de teclas: En bloque
                        • Compatibilidad: Windows 7, 8, 10 o superior
                        • Peso: 555 g
                        • Dimensiones (A x A x P): 439 x 142 x 25 mm",
                        ProductImagePath = "/images/products/da22d2b1-f63f-4c6b-9997-5482f9d2de2e.jpg"
                    }, new Producto
                    {
                        ProductId = 2,
                        ProductName = "Mouse Gamer Razer Deathadder Essential Sensor Optico",
                        ProductPrice = 1675M,
                        ProductDescription = @"A SIMPLE VISTA
                        • Sensor óptico de 6400 ppp reales
                        • Formato ergonómico
                        • 5 botones Hyperesponse
                        • Ciclo de vida de 10 millones de clics
                        • Historial de rendimiento probado

                        ESPECIFICACIONES TECNICAS
                        • Sensor óptico de 6400 ppp reales
                        • Hasta 220 pulgadas por segundo (IPS)/30 G de aceleración
                        • Cinco botones Hyperesponse que pueden programarse individualmente
                        • Ratón con switches mecánicos de Razer™ con un ciclo de vida de hasta 10 millones de clics
                        • Rueda de desplazamiento táctil especial para juegos
                        • Diseño ergonómico para diestros
                        • Tasa de sondeo de 1000 Hz.
                        • Iluminación de un solo color (verde)
                        • Compatible con Razer Synapse 3 (Beta)
                        • Tamaño aproximado: 127 mm (largo) x 73 mm (ancho) x 43 mm(alto)
                        • Peso aproximado(sin cable): 96 g
                        • Longitud del cable: 1,8 m",
                        ProductImagePath = "/images/products/975d75a0-418c-4081-bfb1-e1b4b9427f77.jpg"
                    }, new Producto
                    {
                        ProductId = 3,
                        ProductName = "Apple iPhone XR Dual SIM 64 GB Negro",
                        ProductPrice = 59999.99M,
                        ProductDescription = @"Liberado
                        Procesador Apple A12 Bionic (7 nm) - 3 GB
                        Pantalla 6.1 IPS LCD de 828 x 1792 pixeles
                        Cámara trasera 12MP f / 1.8
                        Cámara delantera 7MP f / 2.2
                        Bateria 2942 mAh con cárga inalámbrica
                        Resistencia al agua y al polvo IP67",
                        ProductImagePath = "/images/products/ced82a19-8c97-4e1c-bc77-9bb5aeba0205.jpg"
                    }, new Producto
                    {
                        ProductId = 4,
                        ProductName = "Auriculares Bluetooth In Ear Instto Insun X S iPhone Android",
                        ProductPrice = 3699.0M,
                        ProductDescription = @"CARACTERISTICAS Y BENEFICIOS
                        Conversaciones bilaterales
                        • Ahora podrás hablar y escuchar por ambos auriculares, con un sonido de alta fidelidad y bajos más potentes.

                        Control táctil
                        • Control táctil integrado, podrás controlar el sonido, reproducciones, atender llamados y más

                        Reducción de sonido externo
                        • El mundo que nos rodea puede ser ruidoso, nuestro inSun XS puede bloquearlo

                        ESPECIFICACIONES
                        • Bluetooth: 5.0
                        • Manos libres: Sí, bilateral
                        • Pantalla de carga: Sí
                        • Batería: Hasta 16 horas
                        • Playlist: 4 horas
                        • Base de carga: 4 cargas adicionales completas
                        • Resistente al sudor: Sí, IPX4
                        • Comandos de voz: Sí
                        • Reducción de sonido: Sí

                        IN THE BOX
                        • inSun XS
                        • USB Cable - Micro USB
                        • Base de carga
                        • 3 pares de goma 
                        • Manual de Uso",
                        ProductImagePath = "/images/products/a40a41c0-506f-4db1-8f7c-0f227b79d249.jpg"
                    }, new Producto
                    {
                        ProductId = 5,
                        ProductName = "Notebook Lenovo N4000 4gb 500gb 15.6 Teclado Español Dvd",
                        ProductPrice = 16399M,
                        ProductDescription = @"NOTEBOOK LENOVO N4000/4GB/500GB/15.6/DVDRW/FREE 
                        Modelo 81HL0019SP

                        -Pantalla: 15.6 1366×768 pixels(HD).LED Mate.
                        - Procesador: Intel® Celeron™ N4000.
                        - Núcleos del procesador: 2 / 2.
                        - Velocidad del procesador: hasta 2.6 GHz.
                        - Sistema operativo: FREE.
                        - Capacidad de almacenamiento: 500 GB.
                        - Tipo de almacenamiento: HD.
                        - Unidad óptica: DVD±RW.
                        - Lector de tarjetas: 4 en 1(SD).
                        - Gráficos: Intel UHD Graphics 600.Compartida.
                        - Memoria RAM: 4GB.
                        - Tecnología de memoria: DDR4 - 2400MHz.
                        - LAN: Gigabit Ethernet.
                        - WiFi: 802.11ac.
                        - Bluetooth: 4.1.
                        - USB: 3(1 USB 3.0 + 1 USB 2.0).
                        - HDMI: 1.
                        - Lector de huellas: No.
                        - Audio: Jack combo auriculares + micro; 2 altavoces.
                        - Teclado: Español.
                        - Batería: 2 celdas(30Wh) 45W.
                        - Dimensiones: 375x253x22.3 mm.
                        - Peso: 1.85 Kg.",
                        ProductImagePath = "/images/products/6e768d48-7753-4a5b-9c32-40f3474cbd81.jpg"
                    }
                   );

                context.SaveChanges();
            }
        }
    }
}
