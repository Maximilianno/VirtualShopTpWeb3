function Category_SelectedIndexChanged() {
        var valueSelected = $('#MainContent_ElegirCategoria_category').val();
        $.support.cors = true;
        var htmlString = "<div class='shops' id = 'divTablaTienda'>";
        $.ajax({
            type: "POST",
            url: "http://localhost:56475/Service1.asmx/ObtenerTiendasPorCategoria",
            data: "{'idCategoria':'" + valueSelected + "'}",
            async: true,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                $.each(response.d, function (i, item) {
                    htmlString += "<div class='column' >";
                    htmlString += "<p class='title' >" + item.RazonSocial + "</p>";
                    htmlString += "<a href='#' onClick='javascript: ProductosPorTiendaCategoria(" + item.Id + "," + valueSelected + ",\"" + item.Email + "\");' ><img alt='' src='../photos/" + item.Email + "/" + item.Imagen + "'  class='imgCol' /></a>";
                    htmlString += "</div>";
                });
                htmlString += "</div>";
                $('#dvTablaTienda').html(htmlString);
            },
            error: function (error) {
                alert("Error" + error);
            }
        });

    }

    function ProductosPorTiendaCategoria(idTienda,idCategoria) {
        var valueSelected = $('#MainContent_ElegirCategoria_category').val();
        $.support.cors = true;
        var htmlString = "<div class='shops' id = 'divTablaTienda'>";
        $.ajax({
            type: "POST",
            url: "http://localhost:56475/Service1.asmx/ProductosPorTiendaCategoria",
            data: "{'idTienda':'" + idTienda + "','idCategoria':'" + idCategoria + "'}",
            async: true,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                $.each(response.d, function (i, item) {
                    htmlString += "<div class='column' >";
                    htmlString += "<p class='title' >" + item.Nombre + "</p>";
                    htmlString += "<a href='#' onClick='javascript: Producto(" + item.ID + "," + idTienda + ")' ><img alt='' src='../photos/" + idTienda + "/" + item.Imagen + "'  class='imgCol' /></a>";
                    htmlString += "</div>";
                });
                htmlString += "</div>";
                $('#dvTablaTienda').html(htmlString);
            },
            error: function (error) {
                alert("Error" + error);
            }
        });

    }

    function Producto(idProducto,idTienda,ok) {
        var valueSelected = $('#MainContent_ElegirCategoria_category').val();
        var htmlString = "";
        $.support.cors = true;
        
        if (ok == 'S') {
            htmlString += "<h2 class = 'alert_success'>Su pedido fue procesado correctamente.</h2>";
        }
        else if (ok == 'N') {
            htmlString += "<h2 class = 'alert_error'>Ha ocurrido un error al procesar su venta.</h2>";
        }
        htmlString += "<div class='division'>";

        $.ajax({
            type: "POST",
            url: "http://localhost:56475/Service1.asmx/Producto",
            data: "{'idProducto':'" + idProducto + "'}",
            async: true,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                $.each(response.d, function (i, item) {
                    htmlString += "<div class='controlers'>";
                    htmlString += "<span class='title' >" + item.Nombre + "</span>";
                    htmlString += "<span class='description'>" + item.Descripcion + "</span>";
                    htmlString += "<span class= 'precio'>Precio $" + item.Precio + "</span>";
                    if (eval(item.Stock) > 0) {
                        htmlString += "<span class= 'precio'>Stock " + item.Stock + "</span>";
                        htmlString += "<span><label>Email Comprador:</label><input type = 'text' id= 'emailCliente'/><label>*</label><br/>";
                        htmlString += "<label>Cantidad:</label><input type = 'text' id= 'cantidad'/><label>*</label><br/></span>";
                        htmlString += "<span><a href='#' class='boton' onClick = 'javascript: Venta(" + item.idTienda + ",document.getElementById(\"emailCliente\").value," + idProducto + ",parseFloat(" + item.Precio + "),document.getElementById(\"cantidad\").value);'>Comprar</a></span>";
                        htmlString += "<div id = 'dvResCompra'></div>";
                    }
                    else {
                        htmlString += '<h5>Actualmente no stock disponible para el producto solicitado.</h5>'
                    }
                    htmlString += "<p><a href='#' onClick = 'javascript: ProductosPorTiendaCategoria(" + item.idTienda + "," + item.IdCategoria + ")'><img class='back' src='../img/icn_jump_back.png'/>Volver</a></p>";
                    htmlString += "</div>";
                    htmlString += "<img class='imgDescription'  alt='" + item.Nombre + "' src='../photos/" + idTienda + "/" + item.Imagen + "'  class='imgCol' />";

                });
                htmlString += "</div>";
                $('#dvTablaTienda').html(htmlString);
            },
            error: function (error) {
                alert("Error" + error);
            }
        });

    }
    function Venta(idTienda, email, idProducto, precioUnit, cant) {
        $.support.cors = true;
        var htmlString = "<div>";
        $.ajax({
            type: "POST",
            url: "http://localhost:56475/Service1.asmx/Venta",
            data: "{'IdTienda':'" + idTienda + "','Email':'" + email + "','IdProducto':'" + idProducto + "','PrecioUnitario':'" + precioUnit + "','Cantidad':'" + cant + "'}",
            async: true,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == "OK") {
                    Producto(idProducto, idTienda, "S");
                }
                else {
                    Producto(idProducto, idTienda, "N");
                }
                htmlString += "</div>";
                $('#dvResCompra').html(htmlString);
            },
            error: function (error) {
                alert("Error" + error);
            }
        });

    }
