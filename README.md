# Proyecto-Final-AP1
Prestamos JDS SRL. es un Programa dedicado a brindar servicios de financieros a la comunidad necesitada. 
Nuestra misión es garantizar un servicio de calidad fundamentado en la eficiencia y transparencia utilizando tecnología; 
siempre con un principio humano, leal y de efectividad en nuestra gente.
# Login
Aquí es donde los usuarios registrados podrán acceder al programa y poder registrar y consultar las diferentes operaciones que ofrece el programa.

En caso de ser la primera vez deberá ingresar el usuario que existe por defecto.


![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/Login.jpeg)


Usuario: Diego Contraseña: 1234 Este usuario solo servirá para crear otros usuarios por ende su único uso será para crear usuarios personalizados.
# Registros 
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/Registros.jpeg)
# Introducción Básica a los registros
Al estar en un registro hay ciertas operaciones que se podrán hacer en todos los registros:

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/1234Registro.jpeg)

1.	Nuevo: Esta acción se usa para limpiar los elementos de todos los campos, excelente para empezar a crear o buscar un usuario de nuevo.
2.	Guardar: Esta operación sirve para registrar nuevos objetos en el sistema. En caso de existir uno con el mismo identificador (ID), se modificará el objeto original en base a los nuevos datos ingresados (Aunque no en todos los casos). Teniendo en cuenta que solo se guardara si se encuentra debidamente completado.
3.	Buscar: Este se encarga de que mediante el identificador (ID) se verifique si existe en el sistema para ser traído para su posible modificación o eliminación.
4.	Eliminar: Después de buscar el objeto esta opción se encargará de eliminarlo del sistema si existe

# Registro De Usuarios

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/UsuarioR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los usuarios que se utilizarán para hacer las diferentes modificaciones del sistema. 
Los Usuarios cuentan con tres niveles de Permiso:

Permiso 1: solo pueden acceder a los registros y modificar los datos

Permiso 2: pueden acceder a todos los registros y eliminar datos.

Permiso 3: pueden acceder a todos los registros y agregar datos.

Usuarios también cuenta con diferentes roles que se le asigna dependiendo del usuario.

# Registros de Clientes
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/ClientesR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los clientes que se utilizarán para realizar los préstamos en el sistema.

Cliente cuenta con elegir el tipo de sexo, estado civil que se encuentra el cliente y el tipo de casa que posee.
# Registro Prestamos

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/PretsmosR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los préstamos que se realizaron en el sistema. 

Prestamos cuenta con un ComboBox para elegir entre los clientes que ya están registrados en el sistema y así llevar a cabo
la toma del prestamos con su monto, la cantidad de cuotas en que pagara y el interés. 

En este sistema el interés y el pago son capitalizable mensualmente y con esa matemática se llevan a cabo los cálculos.

Posee un detalle del cual contiene cuando debe realizar el pago de la cuota, el valor de la cuota que deberá pagar, 
capital del prestamos, interés, balance del interés, balance del capital y balance total; Detallando hasta el número de cuotas 
que realizará el cliente para pagar el préstamo.

Teniendo en cuenta que se debe registrar un cliente para poner realizar el préstamo..

# Registro De Negocios

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/nEGOCIOR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los 
negocios de los clientes que poseen un negocio o que trabajen en una empresa. 

Negocio posee un ComboBox donde se podrá elegir entre los diferentes clientes que están registrados 
en el sistema para asignarle a quien pertenece cada negocio.

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/Negociotipo.jpeg)

Al igual que podrá especificar el tipo negocio que es mediante un comboBox con las opciones correspondientes

# Registro De Cobro
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/cobrosR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los cobros de los préstamos
que se realizan en el sistema. 

El registro de cobro se encarga de realizar pagos a los prestamos seleccionados 
con respecto a al balance actual y a la mora.

El pago afecta al balance del préstamo y a la mora de este.

# Registro De Garantes
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/garanresR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los garantes que le pertenece a cada cliente para realizar el préstamo.

# Registro De Moras
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/MorasR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar las moras de los clientes que tienen cuotas atrasadas. 

Moras posee un ComboBox donde se podrá elegir entre los diferentes clientes que están
registrados en el sistema para asignarle a quien pertenece cada negocio.

El monto del valor de la mora asignado afecta el balance del préstamo.

# Registros de Permisos
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/PermisosR.jpeg)

En este apartado se podrán crear, modificar, buscar y eliminar los permisos de los usuarios tendrán acceso al sistema. 
Permisos posee un campo que cuenta las veces que un permiso es asignado a un usuario.

Los registros Roles, Sexo, Estados Civiles y Tipo de Vivienda.

Estos registros están asignados mediante el onModelCreating, pero poseen sus registros para crear, modificar, buscar y eliminar otros de estos tipos de registros.

# Consultas
![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/Consultas.jpeg)

# Introducción a Las consultas

El objetivo principal de estas ventanas es poder ver todos los elementos almacenados en el sistema, poder filtrar la información, 
ya sea para buscar un elemento en específico como para comparar información.

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/C1234.jpeg)


1.	Filtrado de fechas: Permite buscar objetos desde una fecha de origen hasta una fecha límite.
2.	Filtro: Una barra de selección que permite elegir en base a que se comparara el criterio de búsqueda..
3.	Criterio: Un elemento que sirve para buscar un elemento en base a algo en común.
4.	Botón de búsqueda: Al presionarlo, realiza la búsqueda en base a los criterios seleccionados.

# TODAS LAS CONSULTAS

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/CPrestamos.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/WhatsApp%20Image%202021-11-29%20at%2017.38.35.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/detalleUsuario.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/detallePrestamos.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/WhatsApp%20Image%202021-11-29%20at%2017.38.47.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/GaranteC.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/WhatsApp%20Image%202021-11-29%20at%2017.38.53.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/WhatsApp%20Image%202021-11-29%20at%2017.39.02.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/WhatsApp%20Image%202021-11-29%20at%2017.39.11.jpeg)

![](https://raw.githubusercontent.com/JuniorBaez-ux/Proyecto-Final-AP1/master/Resources/WhatsApp%20Image%202021-11-29%20at%2017.39.17.jpeg)
