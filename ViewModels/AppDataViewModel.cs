using System.Collections.ObjectModel;
using System.Windows.Input;
using AlmacenesPorAhiMaui.Models;

namespace AlmacenesPorAhiMaui.ViewModels;

public class AppDataViewModel : BaseViewModel
{
    public ObservableCollection<Producto> Productos { get; } = new();
    public ObservableCollection<Cliente> Clientes { get; } = new();
    public ObservableCollection<Venta> Ventas { get; } = new();
    public ObservableCollection<Devolucion> Devoluciones { get; } = new();
    public ObservableCollection<Pedido> Pedidos { get; } = new();
    public ObservableCollection<string> TiposDevolucion { get; } = new() { "Reembolso", "Crédito", "Cambio" };

    string _productoCodigo = "";
    string _productoNombre = "";
    string _productoCategoria = "";
    string _productoTalla = "";
    string _productoColor = "";
    string _productoPrecio = "";
    string _productoStock = "";
    string _stockCantidad = "1";
    string _clienteRut = "";
    string _clienteNombre = "";
    string _clienteEmail = "";
    string _clientePreferencia = "";
    string _ventaCliente = "";
    string _ventaCantidad = "1";
    string _devolucionCliente = "";
    string _devolucionCantidad = "1";
    string _devolucionMotivo = "";
    string _tipoDevolucion = "Reembolso";
    string _mensaje = "Sistema listo. Trabajando con listas en memoria.";
    Producto? _productoStockSeleccionado;
    Producto? _productoVentaSeleccionado;
    Producto? _productoDevolucionSeleccionado;

    public AppDataViewModel()
    {
        Productos.Add(new Producto { Codigo = "P001", Nombre = "Polera urbana", Categoria = "Ropa", Talla = "M", Color = "Azul", Precio = 12990, Stock = 18 });
        Productos.Add(new Producto { Codigo = "P002", Nombre = "Zapatillas running", Categoria = "Calzado", Talla = "42", Color = "Negro", Precio = 42990, Stock = 9 });
        Productos.Add(new Producto { Codigo = "P003", Nombre = "Chaqueta outdoor", Categoria = "Ropa", Talla = "L", Color = "Verde", Precio = 59990, Stock = 6 });
        Clientes.Add(new Cliente { Rut = "11.111.111-1", Nombre = "Camila Torres", Email = "camila@correo.cl", Preferencia = "Ropa deportiva" });
        Clientes.Add(new Cliente { Rut = "22.222.222-2", Nombre = "Matías Rojas", Email = "matias@correo.cl", Preferencia = "Calzado" });
        Pedidos.Add(new Pedido { Numero = "PED-1001", Cliente = "Camila Torres", Estado = "Preparación" });
        Pedidos.Add(new Pedido { Numero = "PED-1002", Cliente = "Matías Rojas", Estado = "En reparto" });

        ProductoStockSeleccionado = Productos.FirstOrDefault();
        ProductoVentaSeleccionado = Productos.FirstOrDefault();
        ProductoDevolucionSeleccionado = Productos.FirstOrDefault();

        AgregarProductoCommand = new Command(AgregarProducto);
        AgregarStockCommand = new Command(AgregarStock);
        AgregarClienteCommand = new Command(AgregarCliente);
        RegistrarVentaCommand = new Command(RegistrarVenta);
        RegistrarDevolucionCommand = new Command(RegistrarDevolucion);
        GenerarInformeCommand = new Command(GenerarInforme);
    }

    public ICommand AgregarProductoCommand { get; }
    public ICommand AgregarStockCommand { get; }
    public ICommand AgregarClienteCommand { get; }
    public ICommand RegistrarVentaCommand { get; }
    public ICommand RegistrarDevolucionCommand { get; }
    public ICommand GenerarInformeCommand { get; }

    public string ProductoCodigo { get => _productoCodigo; set => SetProperty(ref _productoCodigo, value); }
    public string ProductoNombre { get => _productoNombre; set => SetProperty(ref _productoNombre, value); }
    public string ProductoCategoria { get => _productoCategoria; set => SetProperty(ref _productoCategoria, value); }
    public string ProductoTalla { get => _productoTalla; set => SetProperty(ref _productoTalla, value); }
    public string ProductoColor { get => _productoColor; set => SetProperty(ref _productoColor, value); }
    public string ProductoPrecio { get => _productoPrecio; set => SetProperty(ref _productoPrecio, value); }
    public string ProductoStock { get => _productoStock; set => SetProperty(ref _productoStock, value); }
    public string StockCantidad { get => _stockCantidad; set => SetProperty(ref _stockCantidad, value); }
    public Producto? ProductoStockSeleccionado { get => _productoStockSeleccionado; set => SetProperty(ref _productoStockSeleccionado, value); }
    public string ClienteRut { get => _clienteRut; set => SetProperty(ref _clienteRut, value); }
    public string ClienteNombre { get => _clienteNombre; set => SetProperty(ref _clienteNombre, value); }
    public string ClienteEmail { get => _clienteEmail; set => SetProperty(ref _clienteEmail, value); }
    public string ClientePreferencia { get => _clientePreferencia; set => SetProperty(ref _clientePreferencia, value); }
    public Producto? ProductoVentaSeleccionado { get => _productoVentaSeleccionado; set => SetProperty(ref _productoVentaSeleccionado, value); }
    public string VentaCliente { get => _ventaCliente; set => SetProperty(ref _ventaCliente, value); }
    public string VentaCantidad { get => _ventaCantidad; set => SetProperty(ref _ventaCantidad, value); }
    public Producto? ProductoDevolucionSeleccionado { get => _productoDevolucionSeleccionado; set => SetProperty(ref _productoDevolucionSeleccionado, value); }
    public string DevolucionCliente { get => _devolucionCliente; set => SetProperty(ref _devolucionCliente, value); }
    public string DevolucionCantidad { get => _devolucionCantidad; set => SetProperty(ref _devolucionCantidad, value); }
    public string DevolucionMotivo { get => _devolucionMotivo; set => SetProperty(ref _devolucionMotivo, value); }
    public string TipoDevolucion { get => _tipoDevolucion; set => SetProperty(ref _tipoDevolucion, value); }
    public string Mensaje { get => _mensaje; set => SetProperty(ref _mensaje, value); }

    public string TotalStock => Productos.Sum(p => p.Stock).ToString();
    public string TotalVentas => Ventas.Sum(v => v.Total).ToString("$#,0");
    public string TotalDevoluciones => Devoluciones.Count.ToString();
    public string TotalClientes => Clientes.Count.ToString();

    void RefrescarIndicadores()
    {
        OnPropertyChanged(nameof(TotalStock));
        OnPropertyChanged(nameof(TotalVentas));
        OnPropertyChanged(nameof(TotalDevoluciones));
        OnPropertyChanged(nameof(TotalClientes));
    }

    void AgregarProducto()
    {
        if (string.IsNullOrWhiteSpace(ProductoNombre) ||
            !decimal.TryParse(ProductoPrecio, out var precio) || precio < 0 ||
            !int.TryParse(ProductoStock, out var stock) || stock < 0)
        {
            Mensaje = "Producto inválido: ingresa nombre, precio válido y stock inicial.";
            return;
        }

        var codigo = string.IsNullOrWhiteSpace(ProductoCodigo) ? $"P{Productos.Count + 1:000}" : ProductoCodigo.Trim().ToUpper();
        if (Productos.Any(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
        {
            Mensaje = "Producto inválido: el código ya existe en el inventario.";
            return;
        }

        var nuevoProducto = new Producto
        {
            Codigo = codigo,
            Nombre = ProductoNombre.Trim(),
            Categoria = ProductoCategoria.Trim(),
            Talla = ProductoTalla.Trim(),
            Color = ProductoColor.Trim(),
            Precio = precio,
            Stock = stock
        };

        Productos.Add(nuevoProducto);
        ProductoStockSeleccionado = nuevoProducto;
        ProductoVentaSeleccionado = nuevoProducto;
        ProductoDevolucionSeleccionado = nuevoProducto;
        ProductoCodigo = ProductoNombre = ProductoCategoria = ProductoTalla = ProductoColor = ProductoPrecio = ProductoStock = string.Empty;
        Mensaje = "Producto nuevo registrado. La lista observable se actualizó automáticamente.";
        RefrescarIndicadores();
    }

    void AgregarStock()
    {
        var producto = ProductoStockSeleccionado;
        if (producto == null || !int.TryParse(StockCantidad, out var cantidad) || cantidad <= 0)
        {
            Mensaje = "Reposición no procesada: selecciona un producto e ingresa una cantidad mayor a cero.";
            return;
        }

        producto.Stock += cantidad;
        StockCantidad = "1";
        Mensaje = $"Stock actualizado: se agregaron {cantidad} unidad(es) a {producto.Nombre}.";
        RefrescarProducto(producto);
        RefrescarIndicadores();
    }

    void AgregarCliente()
    {
        if (string.IsNullOrWhiteSpace(ClienteNombre) || string.IsNullOrWhiteSpace(ClienteRut) || string.IsNullOrWhiteSpace(ClienteEmail))
        {
            Mensaje = "Cliente inválido: ingresa RUT, nombre y email.";
            return;
        }

        if (Clientes.Any(c => c.Rut.Equals(ClienteRut.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            Mensaje = "Cliente inválido: ya existe un cliente con ese RUT.";
            return;
        }

        Clientes.Add(new Cliente
        {
            Rut = ClienteRut.Trim(),
            Nombre = ClienteNombre.Trim(),
            Email = ClienteEmail.Trim(),
            Preferencia = ClientePreferencia.Trim()
        });
        ClienteRut = ClienteNombre = ClienteEmail = ClientePreferencia = string.Empty;
        Mensaje = "Cliente registrado en la lista observable.";
        RefrescarIndicadores();
    }

    void RegistrarVenta()
    {
        var producto = ProductoVentaSeleccionado;
        if (producto == null || !int.TryParse(VentaCantidad, out var cantidad) || cantidad <= 0)
        {
            Mensaje = "Venta no procesada: selecciona un producto e ingresa una cantidad válida.";
            return;
        }

        if (producto.Stock < cantidad)
        {
            Mensaje = $"Venta no procesada: stock insuficiente. {producto.Nombre} tiene {producto.Stock} unidad(es).";
            return;
        }

        producto.Stock -= cantidad;
        Ventas.Insert(0, new Venta
        {
            Folio = $"V-{Ventas.Count + 1:0000}",
            Producto = producto.Nombre,
            Cliente = string.IsNullOrWhiteSpace(VentaCliente) ? "Cliente general" : VentaCliente.Trim(),
            Cantidad = cantidad,
            Total = producto.Precio * cantidad
        });
        VentaCliente = string.Empty;
        VentaCantidad = "1";
        Mensaje = $"Venta registrada. Se descontaron {cantidad} unidad(es) de {producto.Nombre}.";
        RefrescarProducto(producto);
        RefrescarIndicadores();
    }

    void RegistrarDevolucion()
    {
        var producto = ProductoDevolucionSeleccionado;
        if (producto == null || !int.TryParse(DevolucionCantidad, out var cantidad) || cantidad <= 0)
        {
            Mensaje = "Devolución no procesada: selecciona un producto e ingresa una cantidad válida.";
            return;
        }

        producto.Stock += cantidad;
        Devoluciones.Insert(0, new Devolucion
        {
            Codigo = $"D-{Devoluciones.Count + 1:0000}",
            Producto = producto.Nombre,
            Cliente = string.IsNullOrWhiteSpace(DevolucionCliente) ? "Cliente general" : DevolucionCliente.Trim(),
            Cantidad = cantidad,
            TipoProceso = TipoDevolucion,
            Motivo = DevolucionMotivo.Trim()
        });
        DevolucionCliente = DevolucionMotivo = string.Empty;
        DevolucionCantidad = "1";
        Mensaje = $"Devolución registrada. Se sumaron {cantidad} unidad(es) al stock de {producto.Nombre}.";
        RefrescarProducto(producto);
        RefrescarIndicadores();
    }

    void GenerarInforme()
    {
        Mensaje = $"Informe: {Productos.Count} productos, {TotalStock} unidades, {Clientes.Count} clientes, ventas acumuladas {TotalVentas}, devoluciones {Devoluciones.Count}.";
    }

    void RefrescarProducto(Producto producto)
    {
        var index = Productos.IndexOf(producto);
        if (index >= 0)
        {
            Productos.RemoveAt(index);
            Productos.Insert(index, producto);
        }
    }
}
