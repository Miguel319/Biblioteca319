Use Biblioteca319Db

INSERT INTO 
Sucursales(ImagenURL, Direccion, Nombre, Telefono, FechaApertura, Descripcion) 
VALUES 
('/img/sucursales/1.png', 'Calle El Camino #42', 'Biblioteca 319 El Camino', '(809) 111-2222', '1985-01-19', 'El Camino es la sucursal más antigua de la Biblioteca 319. Fue inaugurada en 1985. Dispone de la más extensa variedad de libros de arte, literatura, poesía, historía, psicología y filosofía del área.'),
('/imag/sucursales/2.png', 'Ave Ficticia #243', 'Biblioteca 319 Ficticia', '(829) 777-8888', '1994-02-07', 'Ficticia es la sucursal más antigua de la Biblioteca 319. Contiene una extensa colección de libros de Ciencia Ficción yendo desde autores como Isaac Asimov hasta Margaret Atwood.'),
('/img/sucursales/3.png', 'Carr Espacial #291', 'Biblioteca 319 Espacial', '(809) 333-4444', '2019-04-24', 'Espacial es la más reciente sucursal de la Biblioteca 319. Dispone de una vasta selección de libros de Física, Astrofísica, Mecánica Cuántica y ciencia en general, así como Wi-Fi de alta velocidad totalmente gratis.');
SELECT * FROM Sucursales
GO
INSERT INTO Tarjeta(Creada, Cargos) VALUES 
('2019-01-06', 12.00),
('2019-02-15', 0.00),
('2019-03-28', 0.50),
('2019-04-21', 0.00),
('2019-04-22', 3.50),
('2019-04-25', 1.50),
('2019-04-26', 0.00),
('2019-04-27', 8.00);
SELECT * FROM Tarjeta

GO

INSERT INTO 
Clientes(Direccion, FechaNacimiento, Nombre, SucursalAsociadaId, Apellido, TarjetaId, Telefono) VALUES
('Calle Uva #21', '1994-02-19', 'Pedro', 1, 'Gutiérrez', 1, '(809) 123-4567'),
('Calle Pera #45', '1983-03-27', 'Martha', 2, 'Ortega', 2, '(849) 987-6543'),
('Calle Guineo #79', '1988-09-15', 'Gregorio', 2, 'Fernández', 3, '(809) 456-7890'),
('Calle Mandarina #83', '1998-11-14', 'Alfonso', 3, 'Cuevas', 4, '(829) 123-5696'),
('Calle Naranja #47', '1952-09-16', 'Manuel', 3, 'Brito', 5, '(829) 301-2020'),
('Calle Limón #94', '1994-03-24', 'Ana', 3, 'Pérez', 6, '(829) 123-0203'),
('Calle Cereza #35', '2001-11-23', 'María', 1, 'Andujar', 7, '(809) 452-4506'),
('Calle Melocotón #55', '1981-10-16', 'Pablo', 3, 'Polanco', 8, '(829) 120-1264');
SELECT * FROM Clientes

GO

INSERT INTO Estatus 
(Nombre, Descripcion) VALUES
('Pago', 'Activo (libro o video) pago.'),
('Disponible', 'Activo (libro o video) disponible para ser prestado.'),
('Perdido', 'Activo (libro o video) perdido.'),
('Congelado', 'Activo (libro) no disponible actualmente para ser prestado.')
SELECT * FROM Estatus

GO

INSERT INTO Activos
(Discriminator, Costo, UbicacionId, EstatusId, Autor, IndiceDewey, ISBN, Titulo, Anio, Director, ImagenUrl, NumCopias) VALUES
('Libro', 18.00, 2, 2, 'Jordan Peterson', '823.123', '9781525105817', 'Mapas de significado', 1999, NULL, '/img/mapas.png', 1),
('Libro', 18.00, 3, 2, 'Jordan Peterson', '822.133', '9781519115077', '12 Reglas Para la Vida', 2018, NULL, '/imag/docereglas.png', 1),
('Libro', 12.99, 2, 2, 'Gregg McKeown', '821.153', '9780746062140', 'Esencialismo', 2011, NULL, '/img/esencialismo.png', 1),
('Libro', 24.00, 2, 2, 'Erich Neumann', '822.556', '9788854139343', 'Los orígenes e historia de la conciencia', 1949, NULL, '/img/conciencia.png', 3),
('Libro', 11.00, 3, 2, 'Fiódor Dostoyevski', '820.119', '9780758734209', 'Crimen y castigo',1866, NULL, '/img/crimen.png', 2),
('Libro', 18.00, 3, 2, 'Carl Gustav Jung', '821.526', '9781623751905', 'Los complejos y el inconsciente', 1933, NULL, '/img/complejos.png', 4),
('Libro', 12.99, 2, 2, 'Viktor Frankl', '822.436', '9780670509376', 'El hombre en busca de sentido', 1946, NULL, '/img/sentido.png', 1),
('Libro', 16.00, 2, 2, 'León Tolstói', '821.325', '9780552987254', 'Guerra y paz', 1869, NULL, '/img/guerra.png', 2),
('Libro', 11.00, 1, 2, 'Margaret Atwood', '822.888', '9781905074525', 'El cuento de la criada', 19985, NULL, '/img/cuento.png', 1),
('Libro', 11.99, 1, 2, 'Isaac Asimov',	'820.298', '9780151196307', 'Yo, Robot', 1992, NULL, '/img/robot.png', 2),
('Libro', 12.50, 1, 2, 'Philic K. Dick', '821.544', '9789631480563', 'Ubik', 1969, NULL, '/img/ubik.png', 1),
('Libro', 22.00, 1, 2, 'Walter Lewin', '821.444', '9788702163452', 'Por el amor a la Física', 2011, NULL, '/img/fisica.png', 1),
('Libro', 13.50, 1, 2, 'Bill Bryson', '820.111', '9780795426812', 'Una breve historia de caso todo', 2003, NULL, '/img/todo.png', 5),
('Libro', 13.50, 1, 2, 'Neil deGrasse Tyson', '820.111', '9895395460807', 'Astrofísica para la gente con prisas', 2017, NULL, '/img/astrofisica.png', 5),
('Libro', 13.50, 1, 2, 'Stephen Hawking', '820.111', '9553795460838', 'Breve historia del tiempo', 1998, NULL, '/img/tiempo.png', 5),
('Libro', 13.50, 1, 2, 'Brian Greene', '820.111', '9780667760846', 'El universo elegante', 199, NULL, '/img/universo.png', 5),
('Libro', 13.50, 1, 2, 'Kip Thone', '820.111', '9780795880479', 'Agujeros negros y tiempo curvo', 1994, NULL, '/img/agujero.png', 5),
('Libro', 13.50, 1, 2, 'Edgar Allan Poe', '820.111', '9780795730598', 'El corazón delatador', 1843, NULL, '/img/corazon.png', 5),
('Libro', 13.50, 1, 2, 'Walt Whitman', '820.111', '9780794808495', 'Canto de mí mismo', 1855, NULL, '/img/canto.png', 5),
('Libro', 13.50, 1, 2, 'Sylvia Plath', '820.111', '9780506863460', 'La campana de cristal', 1963, NULL, '/img/campana.png', 5),

('Video', 24.00, 1, 2, NULL, NULL, NULL, 'Avengers: Endgame',	2019, 'Anthony Russo', '/img/avanger.png', 1),
('Video', 30.00, 1, 2, NULL, NULL, NULL, 'Duro de matar',	1988, 'John McTiernan', '/img/duro.png', 1),
('Video', 28.00, 2, 2, NULL, NULL, NULL, 'Matrix',	1999, 'Lana Wachowski', '/img/matrix.png', 1),
('Video', 23.00, 2, 2, NULL, NULL, NULL, 'Identidad desconocida',	2002, 'Doug Liman', '/img/identidad.png', 1),
('Video', 17.99, 2, 2, NULL, NULL, NULL, 'Gladiador', 2000, 'Ridley Scott', '/img/gladiador.png', 1),
('Video', 18.00, 3, 2, NULL, NULL, NULL, 'Náufrago',	2000, 'Robert Zemeckis', '/img/naufrago.png', 1);

GO

SELECT * FROM Activos


Update Activos
Set ImagenUrl = '/img/docereglas.png'
WHERE ImagenUrl = '/imag/docereglas.png'

GO
UPDATE Activos
SET Titulo = 'El corazón delator'
WHERE Titulo = 'El corazón delatador'


INSERT INTO SucursalHoras(SucursalId, HoraCierre, DiaSemana, HoraApertura) VALUES 
(1, 14, 1, 7),
(1, 18, 2, 7),
(1, 18, 3, 7),
(1, 18, 4, 7),
(1, 18, 5, 7),
(1, 18, 6, 7),
(1, 14, 7, 7),

(2, 20, 1, 6),
(2, 20, 2, 6),
(2, 20, 3, 6),
(2, 20, 4, 6),
(2, 20, 5, 6),
(2, 20, 6, 6),
(2, 20, 7, 6),

(3, 22, 1, 5),
(3, 18, 2, 5),
(3, 18, 3, 5),
(3, 18, 4, 5),
(3, 18, 5, 5),
(3, 22, 6, 5),
(3, 22, 7, 5)