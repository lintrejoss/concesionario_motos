CREATE TABLE Marcas (
    id_marca INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

insert into Marcas ([nombre])
	values
	('toyota'),
	('mt'),
	('renol'),
	('playstation'),
	('nintendo')

CREATE TABLE Modelos (
    id_modelo  INT identity(1,1) PRIMARY KEY,
    marca INT NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    cilindraje INT,
    anio INT,
    FOREIGN KEY (marca) REFERENCES Marcas(id_marca)
);
INSERT INTO Modelos (marca, nombre, cilindraje, anio)
VALUES
(1, 'Corolla', 1800, 2022),
(1, 'Hilux', 2500, 2023),
(2, 'MT-07', 700, 2021),
(3, 'Captur', 1500, 2020),
(4, 'PS5', NULL, 2023);

CREATE TABLE Repuestos (
    id_repuesto INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    referencia VARCHAR(50) UNIQUE,
    stock INT NOT NULL,
    precio DECIMAL(12,2) NOT NULL
);

INSERT INTO Repuestos (nombre, referencia, stock, precio)
VALUES
('Bujía', 'BUJ123', 100, 15.50),
('Freno de disco', 'FD1001', 50, 200.00),
('Aceite de motor', 'AMO453', 200, 25.00),
('Filtro de aire', 'FA321', 75, 30.00),
('Lámpara delantera', 'LD908', 60, 45.00);

CREATE TABLE Cargos (
    id_cargo INT  identity(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

INSERT INTO Cargos (nombre)
VALUES
('Gerente'),
('Vendedor'),
('Técnico'),
('Contador'),
('Recepcionista');

CREATE TABLE Motos (
    id_moto INT identity(1,1) PRIMARY KEY ,
    modelo INT NOT NULL,
    numero_chasis VARCHAR(50) UNIQUE NOT NULL,
    color VARCHAR(30),
    precio DECIMAL(12,2),
    estado VARCHAR(50) CHECK (estado IN ('Disponible', 'Vendida', 'Reservada')) DEFAULT 'Disponible',
    FOREIGN KEY (modelo) REFERENCES Modelos(id_modelo)
);

INSERT INTO Motos (modelo, numero_chasis, color, precio, estado)
VALUES
(1, 'ABC123456', 'Rojo', 15000.00, 'Disponible'),
(2, 'XYZ654321', 'Negro', 20000.00, 'Disponible'),
(3, 'MT078953', 'Azul', 13000.00, 'Reservada'),
(4, 'PS5123456', 'Blanco', 500.00, 'Vendida'),
(5, 'NT657890', 'Verde', 16000.00, 'Disponible');

CREATE TABLE Clientes (
    id_cliente INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    documento VARCHAR(30) UNIQUE NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100),
    direccion VARCHAR(150)
);

INSERT INTO Clientes (nombre, documento, telefono, email, direccion)
VALUES
('Juan Pérez', '12345678', '555-1234', 'juanperez@email.com', 'Calle Falsa 123'),
('Ana Gómez', '87654321', '555-5678', 'anagomez@email.com', 'Av. Libertador 456'),
('Carlos Ruiz', '11223344', '555-8765', 'carlosruiz@email.com', 'Calle Real 789'),
('Luis Martínez', '22334455', '555-4321', 'luismartinez@email.com', 'Calle Larga 321'),
('Marta López', '99887766', '555-9876', 'martalopez@email.com', 'Calle Nueva 234');

CREATE TABLE Empleados (
    id_empleado INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    documento VARCHAR(30) UNIQUE NOT NULL,
    cargo INT NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100),
    FOREIGN KEY (cargo) REFERENCES Cargos(id_cargo)
);

INSERT INTO Empleados (nombre, documento, cargo, telefono, email)
VALUES
('Pedro Sánchez', '20123456', 1, '555-1234', 'pedrosanchez@email.com'),
('Lucía Fernández', '20987654', 2, '555-5678', 'lucia@email.com'),
('José Gómez', '20456789', 3, '555-8765', 'josegomez@email.com'),
('María García', '20223344', 4, '555-4321', 'mariagarcia@email.com'),
('Carlos Ruiz', '20334455', 5, '555-9876', 'carlosruiz@email.com');

CREATE TABLE Ventas (
    id_venta INT identity(1,1) PRIMARY KEY,
    fecha DATE NOT NULL,
    cliente INT NOT NULL,
    empleado INT NOT NULL,
    moto INT NOT NULL,
    total DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (cliente) REFERENCES Clientes(id_cliente),
    FOREIGN KEY (empleado) REFERENCES Empleados(id_empleado),
    FOREIGN KEY (moto) REFERENCES Motos(id_moto)
);

INSERT INTO Ventas (fecha, cliente, empleado, moto, total)
VALUES
('2023-09-01', 1, 1, 1, 15000.00),
('2023-09-05', 2, 2, 2, 20000.00),
('2023-09-10', 3, 3, 3, 13000.00),
('2023-09-12', 4, 4, 4, 500.00),
('2023-09-15', 5, 5, 5, 16000.00);

CREATE TABLE Detalle_Ventas (
    id_detalle INT identity(1,1) PRIMARY KEY,
    venta INT NOT NULL,
    repuesto INT,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(12,2),
    FOREIGN KEY (venta) REFERENCES Ventas(id_venta) ON DELETE CASCADE,
    FOREIGN KEY (repuesto) REFERENCES Repuestos(id_repuesto)
);

INSERT INTO Detalle_Ventas (venta, repuesto, cantidad, precio_unitario)
VALUES
(1, 1, 2, 15.50),
(2, 2, 1, 200.00),
(3, 3, 3, 25.00),
(4, 4, 1, 45.00),
(5, 5, 5, 30.00);

CREATE TABLE Pagos (
    id_pago INT identity(1,1) PRIMARY KEY,
    venta INT NOT NULL,
    metodo_pago VARCHAR(50) CHECK (metodo_pago IN ('Efectivo', 'Tarjeta', 'Credito')) NOT NULL,
    monto DECIMAL(12,2) NOT NULL,
    fecha DATE NOT NULL,
    FOREIGN KEY (venta) REFERENCES Ventas(id_venta)
);

INSERT INTO Pagos (venta, metodo_pago, monto, fecha)
VALUES
(1, 'Efectivo', 15000.00, '2023-09-01'),
(2, 'Tarjeta', 20000.00, '2023-09-05'),
(3, 'Credito', 13000.00, '2023-09-10'),
(4, 'Efectivo', 500.00, '2023-09-12'),
(5, 'Tarjeta', 16000.00, '2023-09-15');


CREATE TABLE Proveedores (
    id_proveedor INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100)
);

INSERT INTO Proveedores (nombre, telefono, email)
VALUES
('Proveedor A', '555-0001', 'proveedora@email.com'),
('Proveedor B', '555-0002', 'proveedorb@email.com'),
('Proveedor C', '555-0003', 'proveedorc@email.com'),
('Proveedor D', '555-0004', 'proveedord@email.com'),
('Proveedor E', '555-0005', 'proveedore@email.com');

CREATE TABLE Compras (
    id_compra INT identity(1,1) PRIMARY KEY,
    proveedor INT NOT NULL,
    fecha DATE NOT NULL,
    total DECIMAL(12,2),
    FOREIGN KEY (proveedor) REFERENCES Proveedores(id_proveedor)
);

INSERT INTO Compras (proveedor, fecha, total)
VALUES
(1, '2023-09-01', 5000.00),
(2, '2023-09-05', 7500.00),
(3, '2023-09-10', 12000.00),
(4, '2023-09-12', 1500.00),
(5, '2023-09-15', 9000.00);

CREATE TABLE Detalle_Compras (
    id_detalle INT identity(1,1) PRIMARY KEY ,
    compra INT NOT NULL,
    repuesto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(12,2),
    FOREIGN KEY (compra) REFERENCES Compras(id_compra),
    FOREIGN KEY (repuesto) REFERENCES Repuestos(id_repuesto)
);

INSERT INTO Detalle_Compras (compra, repuesto, cantidad, precio_unitario)
VALUES
(1, 1, 10, 15.50),
(2, 2, 5, 200.00),
(3, 3, 20, 25.00),
(4, 4, 2, 45.00),
(5, 5, 15, 30.00);

CREATE TABLE Servicios (
    id_servicio INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    costo_base DECIMAL(12,2)
);

INSERT INTO Servicios (nombre, costo_base)
VALUES
('Cambio de aceite', 50.00),
('Revisión general', 100.00),
('Cambio de frenos', 200.00),
('Reemplazo de llantas', 150.00),
('Alineación y balanceo', 75.00);


CREATE TABLE Orden_Servicios (
    id_orden INT identity(1,1) PRIMARY KEY,
    cliente INT NOT NULL,
    moto INT NOT NULL,
    empleado INT NOT NULL, 
    servicio INT NOT NULL,
    fecha DATE NOT NULL,
    costo_total DECIMAL(12,2),
    FOREIGN KEY (cliente) REFERENCES Clientes(id_cliente),
    FOREIGN KEY (moto) REFERENCES Motos(id_moto),
    FOREIGN KEY (empleado) REFERENCES Empleados(id_empleado),
    FOREIGN KEY (servicio) REFERENCES Servicios(id_servicio)
);

INSERT INTO Orden_Servicios (cliente, moto, empleado, servicio, fecha, costo_total)
VALUES
(1, 1, 1, 1, '2023-09-01', 50.00),
(2, 2, 2, 2, '2023-09-05', 100.00),
(3, 3, 3, 3, '2023-09-10', 200.00),
(4, 4, 4, 4, '2023-09-12', 150.00),
(5, 5, 5, 5, '2023-09-15', 75.00);
