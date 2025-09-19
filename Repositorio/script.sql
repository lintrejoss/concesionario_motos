create database concesionario

use concesionario

CREATE TABLE Marcas (
    IdMarca INT identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

insert into Marcas ([nombre])
	values
	('toyota'),
	('mt'),
	('renol'),
	('playstation'),
	('nintendo')

CREATE TABLE Modelos (
    IdModelo  INT identity(1,1) PRIMARY KEY,
    MarcaId INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Cilindraje INT,
    A�o INT,
    FOREIGN KEY (MarcaId) REFERENCES Marcas(IdMarca)
);
INSERT INTO Modelos (MarcaId, nombre, cilindraje, a�o)
VALUES
(1, 'Corolla', 1800, 2022),
(1, 'Hilux', 2500, 2023),
(2, 'MT-07', 700, 2021),
(3, 'Captur', 1500, 2020),
(4, 'PS5', 18000, 2023);

CREATE TABLE Repuestos (
    IdRepuesto INT identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Referencia VARCHAR(50) UNIQUE,
    Stock INT NOT NULL,
    Precio DECIMAL(12,2) NOT NULL
);

INSERT INTO Repuestos (nombre, referencia, stock, precio)
VALUES
('Buj�a', 'BUJ123', 100, 15.50),
('Freno de disco', 'FD1001', 50, 200.00),
('Aceite de motor', 'AMO453', 200, 25.00),
('Filtro de aire', 'FA321', 75, 30.00),
('L�mpara delantera', 'LD908', 60, 45.00);

CREATE TABLE Cargos (
    IdCargo INT  identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

INSERT INTO Cargos (nombre)
VALUES
('Gerente'),
('Vendedor'),
('T�cnico'),
('Contador'),
('Recepcionista');

CREATE TABLE Motos (
    IdMoto INT identity(1,1) PRIMARY KEY ,
    ModeloId INT NOT NULL,
    NumeroChasis VARCHAR(50) UNIQUE NOT NULL,
    Color VARCHAR(30),
    Precio DECIMAL(12,2),
    Estado VARCHAR(50) CHECK (estado IN ('Disponible', 'Vendida', 'Reservada')) DEFAULT 'Disponible',
    FOREIGN KEY (modeloId) REFERENCES Modelos(IdModelo)
);

INSERT INTO Motos (ModeloId, NumeroChasis, color, precio, estado)
VALUES
(1, 'ABC123456', 'Rojo', 15000.00, 'Disponible'),
(2, 'XYZ654321', 'Negro', 20000.00, 'Disponible'),
(3, 'MT078953', 'Azul', 13000.00, 'Reservada'),
(4, 'PS5123456', 'Blanco', 500.00, 'Vendida'),
(5, 'NT657890', 'Verde', 16000.00, 'Disponible');

CREATE TABLE Clientes (
    IdCliente INT identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Documento VARCHAR(30) UNIQUE NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Direccion VARCHAR(150)
);

INSERT INTO Clientes (nombre, documento, telefono, email, direccion)
VALUES
('Juan P�rez', '12345678', '555-1234', 'juanperez@email.com', 'Calle Falsa 123'),
('Ana G�mez', '87654321', '555-5678', 'anagomez@email.com', 'Av. Libertador 456'),
('Carlos Ruiz', '11223344', '555-8765', 'carlosruiz@email.com', 'Calle Real 789'),
('Luis Mart�nez', '22334455', '555-4321', 'luismartinez@email.com', 'Calle Larga 321'),
('Marta L�pez', '99887766', '555-9876', 'martalopez@email.com', 'Calle Nueva 234');

CREATE TABLE Empleados (
    IdEmpleado INT identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Documento VARCHAR(30) UNIQUE NOT NULL,
    CargoId INT NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    FOREIGN KEY (CargoId) REFERENCES Cargos(IdCargo)
);

INSERT INTO Empleados (nombre, documento, CargoId, telefono, email)
VALUES
('Pedro S�nchez', '20123456', 1, '555-1234', 'pedrosanchez@email.com'),
('Luc�a Fern�ndez', '20987654', 2, '555-5678', 'lucia@email.com'),
('Jos� G�mez', '20456789', 3, '555-8765', 'josegomez@email.com'),
('Mar�a Garc�a', '20223344', 4, '555-4321', 'mariagarcia@email.com'),
('Carlos Ruiz', '20334455', 5, '555-9876', 'carlosruiz@email.com');

CREATE TABLE Ventas (
    IdVenta INT identity(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    ClienteId INT NOT NULL,
    EmpleadoId INT NOT NULL,
    MotoId INT NOT NULL,
    total DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(IdEmpleado),
    FOREIGN KEY (MotoId) REFERENCES Motos(IdMoto)
);

INSERT INTO Ventas (fecha, ClienteId, EmpleadoId, MotoId, total)
VALUES
('2023-09-01', 1, 1, 1, 15000.00),
('2023-09-05', 2, 2, 2, 20000.00),
('2023-09-10', 3, 3, 3, 13000.00),
('2023-09-12', 4, 4, 4, 500.00),
('2023-09-15', 5, 5, 5, 16000.00);

CREATE TABLE Detalle_Ventas (
    IdDetalle INT identity(1,1) PRIMARY KEY,
    VentaId INT NOT NULL,
    RepuestoId INT,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(12,2),
    FOREIGN KEY (VentaId) REFERENCES Ventas(IdVenta),
    FOREIGN KEY (RepuestoId) REFERENCES Repuestos(IdRepuesto)
);

INSERT INTO Detalle_Ventas (VentaId, RepuestoId, cantidad, PrecioUnitario)
VALUES
(1, 1, 2, 15.50),
(2, 2, 1, 200.00),
(3, 3, 3, 25.00),
(4, 4, 1, 45.00),
(5, 5, 5, 30.00);

CREATE TABLE Pagos (
    IdPago INT identity(1,1) PRIMARY KEY,
    VentaId INT NOT NULL,
    MetodoPago VARCHAR(50) CHECK (MetodoPago IN ('Efectivo', 'Tarjeta', 'Credito')) NOT NULL,
    Monto DECIMAL(12,2) NOT NULL,
    Fecha DATE NOT NULL,
    FOREIGN KEY (VentaId) REFERENCES Ventas(IdVenta)
);

INSERT INTO Pagos (VentaId, MetodoPago, monto, fecha)
VALUES
(1, 'Efectivo', 15000.00, '2023-09-01'),
(2, 'Tarjeta', 20000.00, '2023-09-05'),
(3, 'Credito', 13000.00, '2023-09-10'),
(4, 'Efectivo', 500.00, '2023-09-12'),
(5, 'Tarjeta', 16000.00, '2023-09-15');


CREATE TABLE Proveedores (
    IdProveedor INT identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100)
);

INSERT INTO Proveedores (nombre, telefono, email)
VALUES
('Proveedor A', '555-0001', 'proveedora@email.com'),
('Proveedor B', '555-0002', 'proveedorb@email.com'),
('Proveedor C', '555-0003', 'proveedorc@email.com'),
('Proveedor D', '555-0004', 'proveedord@email.com'),
('Proveedor E', '555-0005', 'proveedore@email.com');

CREATE TABLE Compras (
    IdCompra INT identity(1,1) PRIMARY KEY,
    ProveedorId INT NOT NULL,
    Fecha DATE NOT NULL,
    Total DECIMAL(12,2),
    FOREIGN KEY (ProveedorId) REFERENCES Proveedores(IdProveedor)
);

INSERT INTO Compras (ProveedorId, fecha, total)
VALUES
(1, '2023-09-01', 5000.00),
(2, '2023-09-05', 7500.00),
(3, '2023-09-10', 12000.00),
(4, '2023-09-12', 1500.00),
(5, '2023-09-15', 9000.00);

CREATE TABLE Detalle_Compras (
    IdDetalle INT identity(1,1) PRIMARY KEY ,
    CompraId INT NOT NULL,
    RepuestoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(12,2),
    FOREIGN KEY (CompraId) REFERENCES Compras(IdCompra),
    FOREIGN KEY (RepuestoId) REFERENCES Repuestos(IdRepuesto)
);

INSERT INTO Detalle_Compras (CompraId, RepuestoId, cantidad, PrecioUnitario)
VALUES
(1, 1, 10, 15.50),
(2, 2, 5, 200.00),
(3, 3, 20, 25.00),
(4, 4, 2, 45.00),
(5, 5, 15, 30.00);

CREATE TABLE Servicios (
    IdServicio INT identity(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CostoBase DECIMAL(12,2)
);

INSERT INTO Servicios (nombre, CostoBase)
VALUES
('Cambio de aceite', 50.00),
('Revisi�n general', 100.00),
('Cambio de frenos', 200.00),
('Reemplazo de llantas', 150.00),
('Alineaci�n y balanceo', 75.00);


CREATE TABLE Orden_Servicios (
    IdOrden INT identity(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    MotoId INT NOT NULL,
    EmpleadoId INT NOT NULL, 
    ServicioId INT NOT NULL,
    Fecha DATE NOT NULL,
    CostoTotal DECIMAL(12,2),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (MotoId) REFERENCES Motos(IdMoto),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(IdEmpleado),
    FOREIGN KEY (ServicioId) REFERENCES Servicios(IdServicio)
);

INSERT INTO Orden_Servicios (ClienteId, MotoId, EmpleadoId, ServicioId, fecha, CostoTotal)
VALUES
(1, 1, 1, 1, '2023-09-01', 50.00),
(2, 2, 2, 2, '2023-09-05', 100.00),
(3, 3, 3, 3, '2023-09-10', 200.00),
(4, 4, 4, 4, '2023-09-12', 150.00),
(5, 5, 5, 5, '2023-09-15', 75.00);
