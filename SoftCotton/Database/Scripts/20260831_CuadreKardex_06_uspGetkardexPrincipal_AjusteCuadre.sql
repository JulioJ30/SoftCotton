-- =====================================================================================
-- Cuadre de Kardex - Script 6 de 6: ajuste puntual en uspGetkardexPrincipal
-- =====================================================================================
-- A pedido del usuario: las filas que provienen de un Cuadre de Kardex (identificables de
-- forma inequivoca porque su proveedor/cliente placeholder es 'AJUSTE' - ver script 1) ya
-- NO deben moverse en las columnas de entrada/salida (cantidad, precio unitario, total en
-- dolares y en soles), ni afectar el saldo de cantidad (saldoCantidad) ni el costo
-- promedio (SaldoPuSoles) del producto. Su UNICO efecto debe ser sumar o restar la
-- cantidad ingresada directamente sobre el total valorizado acumulado (SaldoValorSoles),
-- como una correccion de valorizacion pura, sin tocar unidades ni costo.
--
-- Ademas: el proc ya traia una regla que resetea SaldoValorSoles a 0 en el momento en que
-- el stock real de un producto llega a 0 (para evitar residuos de redondeo). Esa regla
-- borraba tambien el efecto de cualquier Cuadre de Kardex aplicado antes sobre ese
-- producto, en cuanto se vendia/consumia todo el stock real. Ahora, en vez de resetear a
-- 0 literal, se preserva el ajuste neto de cuadre pendiente (@SaldoAjusteCuadre) - para
-- productos sin ningun cuadre, @SaldoAjusteCuadre es siempre 0, asi que el comportamiento
-- no cambia.
--
-- Cualquier fila que NO venga de un cuadre (proveedor distinto de 'AJUSTE') sigue
-- calculandose exactamente igual que antes - este script no cambia ese comportamiento.
--
-- Esta es la UNICA modificacion que se hace sobre un procedimiento del calculo de Kardex
-- en todo este conjunto de cambios; todo lo demas (uspSetGRDetalle, uspSetGRCabecera,
-- uspSetOC, uspSetOCDetalle, uspGetkardexPrincipalOs) permanece intacto.
--
-- Se aplica con ALTER PROCEDURE. Ejecutar despues de los scripts 1 a 5.
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER Proc [dbo].[uspGetkardexPrincipal]
@codNivel varchar(50) = null,
@codCuenta varchar(50) = null,
@codGrupo varchar(50) = null,
@codTalla varchar(50) = null,
@codColor varchar(50) = null,
@fechaIni DATE = null,
@fechafin DATE = null
As
BEGIN
DECLARE @puold decimal(18,10) = 0,
		@contador INT = 0,
		@SaldoCantidad decimal(18,10) = 0,
		@SaldoValorDolares decimal(18,10) = 0,
		@SaldoValoSoles decimal(18,10) = 0,
		@SaldoPuSolesIni decimal(18,10) = 0,
		@PUCalcSoles decimal(18,10) = 0,
		@TipoCambioOld decimal(18,10) = 0,
		-- AGREGADO: acumulado neto de ajustes de Cuadre de Kardex para el producto actual
		@SaldoAjusteCuadre decimal(18,10) = 0;

		DECLARE @inicioYYYYMM NVARCHAR(6);
		DECLARE @finYYYYMM NVARCHAR(6);

		SET @inicioYYYYMM = CONVERT(NVARCHAR(4), YEAR(@fechaIni)) + RIGHT('0' + CONVERT(NVARCHAR(2), MONTH(@fechaIni)), 2);
		SET @finYYYYMM = CONVERT(NVARCHAR(4), YEAR(@fechafin)) + RIGHT('0' + CONVERT(NVARCHAR(2), MONTH(@fechafin)), 2);


		-- CORTE Y COSTURA Y BORDADO | ACABADOS | aAPT
		if @codNivel IN ('06','07','11','12','08','17')
		begin

			exec [dbo].[uspGetkardexPrincipalOs]
				@codNivel ,
				@codCuenta ,
				@codGrupo ,
				@codTalla ,
				@codColor ,
				@fechaIni ,
				@fechafin

			return
		end



	select	ROW_NUMBER() OVER(PARTITION BY (oc.codNivel + '.' + oc.codGrupo + '.' + oc.codTalla + '.' + oc.codColor) ORDER BY grc.fechaEmision ASC,gr.tipoMovimiento ASC) AS orden,
			CONCAT(n.codNivel,'.',NIVEL) tipo,
			(oc.codNivel + '.' + oc.codGrupo + '.' + oc.codTalla + '.' + oc.codColor) as cod,
			(rtrim(ltrim(g.grupo))) as Nombre_Articulo,
			c.descripcion color,
			grc.fechaEmision Fecha_Guia,
			gr.serie,
			iif(gr.numero = '0000000000','SALDO INICIAL',gr.numero)numero,
			pc.codigo codigo_Proveedor,
			pc.razonSocial,
			isnull(fact.serie,'') serie_fact,
			isnull(CAST(fact.numero AS VARCHAR),'') Num_fact,
			mon.monedaSingular Tipo_Moneda,
			mon.idTipoMoneda,
			gr.idDet codigo,
			g.codUM UM,
			isnull(fact.precioUnitario,oc.precioUnitario) PU,
			0 fact_tipo,
			month(grc.fechaEmision) mes,
			oc.cantidad as cantidadOC,
			gr.idEmpresa,
			gr.tipoMovimiento,
			(CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) cantidad,
			cast(0 as decimal(18,10)) PUCalcDolar,
			((CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) * (isnull(fact.precioUnitario,oc.precioUnitario))) TotalDolar,
			cast(0 as decimal(18,10)) PUCalcSoles,
			cast(0 as decimal(18,10)) TotalSoles,
			cast(0 as decimal(18,10)) tipoCambio,
			cast(0 as decimal(18,10)) saldoCantidad,
			cast(0 as decimal(18,10)) SaldoValorDolares,
			cast(0 as decimal(18,10)) SaldoPuSoles,
			cast(0 as decimal(18,10)) SaldoValorSoles,
			cast(0 as decimal(18,10)) SaldoValorSolesant,
			cab.fechaEmision fechaOc,
			factcab.fechaEmision fechaFactura,

			pe.pedido OpPedido ,
			col.descripcion OpColor,
			est.estilo OpEstilo,
			pro.programa OpPrograma

			into #TmpKardex
			from grCab grc
			inner join grDet gr on	gr.serie = grc.serie
								and gr.numero=grc.numero
								and gr.idEmpresa = grc.idEmpresa

								-- AGREGADO
								and gr.destCodigoPC = grc.destCodigoPC
				left join  ocDet oc on gr.idEmpresa = oc.idEmpresa
									and	gr.idDet = oc.idOC
									and gr.idSecuenciaDet = oc.secuencia
				LEFT JOIN [dbo].[facDet] fact on fact.grIdEmpresa = gr.idEmpresa
									and fact.grSerie = gr.serie
									and fact.grNumero = gr.numero
									and fact.grSecuencia = gr.secuencia
									and fact.grTipoOrden = gr.tipoOrden

									-- AGREGADO
									and fact.codigoPC = grc.destCodigoPC
				LEFT JOIN [dbo].[facCab] factcab on factCab.idEmpresa = fact.idEmpresa
										and factCab.serie    = fact.Serie
										and factcab.numero	 = fact.Numero
										and factcab.codigoPC = fact.codigoPC
										-- AGREGADO
										and factcab.codigoPC = grc.destCodigoPC
				inner join ocCab cab on oc.idEmpresa = cab.idEmpresa
									and oc.idOC = cab.idOC

				-- inner join provClientes pc on cab.codigoPC = pc.codigo
				inner join provClientes pc on 	iif(gr.tipoMovimiento = 'E',cab.codigoPC,grc.destCodigoPC )	= 	pc.codigo

				inner join productoServicios p on	oc.codNivel = p.codNivel
												and oc.codGrupo = p.codGrupo
												and oc.codTalla = p.codTalla
												and oc.codColor = p.codColor
				inner join grupos g on	p.codNivel = g.codNivel
									and p.codGrupo = g.codGrupo
				inner join niveles n on g.codNivel = n.codNivel
				inner join tallas t on p.codTalla = t.codTalla
				inner join colores c on p.codColor = c.codColor
				left join tipoMonedas mon on mon.idTipoMoneda = cab.idTipoMoneda
				--left join TMP_HUGO2 vv on factCab.serie    = vv.Serie
				--						and factcab.numero	 = vv.Numero
				--						and factcab.codigoPC = vv.ruc


				-- AGREGADO PEDIDO COLOR
				left join pedidosColor pec
				on pec.idPedidoColor = gr.IdPedidoColor
				left join pedidos pe
				on pe.idPedido = pec.idPedido
				left join colores col
				on col.codColor = pec.codColor
				left join estilos est
				on est.idEstilo = pe.idEstilo
				left join programas pro
				on pro.idPrograma = pe.idPrograma

				where n.codNivel = @codNivel
				and grc.tipoOrden = 'C'
				and (gr.codCuenta = @codCuenta or @codCuenta = '0')
				and (@codGrupo = '' or oc.codGrupo = @codGrupo)
				and (@codTalla = '' or oc.codTalla = @codTalla)
				and (@codColor = '' or oc.codColor = @codColor)
				AND cast(grc.fechaEmision as date) between cast(@fechaIni as date) and cast(@fechaFin as Date)

				-- AGREGADO
				and gr.codCuenta in (
					select codCuenta from cuentas where estado = 1 and FlgMostrarKardex = 1
				)

				--select * from #TmpKardex

				--AND vv.anio+ ''+LEFT(vv.mes, CHARINDEX('.', vv.mes) - 1) BETWEEN @inicioYYYYMM AND @finYYYYMM;

				delete from #TmpKardex where serie = '0003' and numero = 2150;


				select A.*
					   INTO #TmpRecorrido
					   from #TmpKardex A
				where cantidad > 0
				order by cod asc,orden asc
				;


				SET @contador = (select count(1) from #TmpRecorrido);

				declare @c int;

				set @c = 0;

				while @contador > 0
				begin
					declare @orden int = 0,
							@cod varchar(50) = '',
							@pu decimal(18,10) = 0,
							@tipoCambio decimal(18,10) = 0,
							@cantidad decimal(18,10) = 0,
							@TotalDolares decimal(18,10) = 0,
							@TotalSoles decimal(18,10) = 0,
							@SaldoPuSoles decimal(18,10) = 0,
							@tipoMovimiento char(1),
							@fecha_guia date,
							@fechaFactura date,
							@fechaOC date,
							@idTipoMoneda INT,
							--
							@ruc varchar(20),
							@serie_fact varchar(50),
							@num_fact varchar(50),
							-- AGREGADO: identifica filas de Cuadre de Kardex (proveedor placeholder 'AJUSTE')
							@esCuadre bit
							;

					select top(1)	@orden			= orden,
									@cod			= cod,
									@pu				= pu,
									@cantidad		= cantidad,
									@tipoMovimiento = tipoMovimiento ,
									@fecha_guia		= cast(Fecha_Guia as date),
									@fechaOC		= cast(fechaOc as date),
									@TotalDolares	= TotalDolar,
									@idTipoMoneda   = idTipoMoneda,
									@fechaFactura   = fechaFactura,
									@ruc = codigo_Proveedor,
									@serie_fact = serie_fact,
									@num_fact = Num_fact
					 from #TmpRecorrido
					 order by cod asc,orden asc
					 ;

					-- AGREGADO: filas de Cuadre de Kardex
					SET @esCuadre = CASE WHEN LTRIM(RTRIM(ISNULL(@ruc,''))) = 'AJUSTE' THEN 1 ELSE 0 END;

					if @tipoMovimiento = 'E'
					begin
						if @fechaFactura is not null
							begin
								--select @tipoCambio = venta
								--  from [dbo].[tipoCambio] where cast(fecha as date) = cast(@fechaFactura as date);
								  select @tipoCambio = tipoCambio from facCab where trim(serie)=trim(@serie_fact) and numero=trim(@num_fact) and trim(codigoPC) = trim(@ruc)
							end
						else
							begin
								select @tipoCambio = venta
								 from [dbo].[tipoCambio] where cast(fecha as date) = cast(@fecha_guia as date);
							end
					end
					else
					begin
						if @fechaFactura is not null
							begin
								select @tipoCambio = tipoCambio from facCab where trim(serie)=trim(@serie_fact) and numero=trim(@num_fact) and trim(codigoPC) = trim(@ruc)
							end
						else
							begin
								select @tipoCambio = venta
								 from [dbo].[tipoCambio] where cast(fecha as date) = cast(@fecha_guia as date);
							end
					end



					  IF(@idTipoMoneda= 1)
					  BEGIN
						SET @tipoCambio = 1;
						set @TipoCambioOld = 1;
					  END;


					if @orden = 1
					begin
						set @puold = 0;
						set @SaldoCantidad = 0;
						set @SaldoValorDolares =0;
						set @SaldoValoSoles = 0;
						set @SaldoAjusteCuadre = 0;

					end;

					-- AGREGADO: Cuadre de Kardex - no mueve cantidad, precio ni costo promedio;
					-- solo suma/resta la cantidad ingresada directamente sobre el total valorizado.
					-- @SaldoAjusteCuadre lleva el acumulado neto de estos ajustes para el producto
					-- actual, para poder preservarlo aun cuando el stock real llegue a 0 (ver mas abajo).
					if @esCuadre = 1
					begin
						set @puold = 0;
						set @TipoCambioOld = @tipoCambio;
						set @PUCalcSoles = 0;
						set @TotalSoles = 0;
						if @tipoMovimiento = 'E'
						begin
							set @SaldoValoSoles = @SaldoValoSoles + @cantidad;
							set @SaldoAjusteCuadre = @SaldoAjusteCuadre + @cantidad;
						end;
						else
						begin
							set @SaldoValoSoles = @SaldoValoSoles - @cantidad;
							set @SaldoAjusteCuadre = @SaldoAjusteCuadre - @cantidad;
						end;
					end;
					else
						if @tipoMovimiento = 'E'
						begin
							set @puold = @pu;
							set @TipoCambioOld = @tipoCambio;
							set @SaldoCantidad = @SaldoCantidad + @cantidad;
							set @SaldoValorDolares =@SaldoValorDolares + @TotalDolares;
							set @SaldoValoSoles = @SaldoValoSoles + (@TotalDolares * 	@tipoCambio);
							set @PUCalcSoles = ((@TotalDolares * 	@TipoCambioOld)/ @cantidad )
							set @TotalSoles = (@PUCalcSoles * @cantidad );

						end;
						else
						begin
							set @PUCalcSoles = @SaldoPuSolesIni;
							set @SaldoCantidad = @SaldoCantidad - @cantidad ;
							set @SaldoValorDolares =@SaldoValorDolares - @TotalDolares;
							set @TotalSoles = (@PUCalcSoles * @cantidad );
							if(@SaldoCantidad > 0)
							begin
								set @SaldoValoSoles = @SaldoValoSoles -@TotalSoles; --(@TotalDolares * 	@TipoCambioOld);
							end;
							else
							begin
								-- AGREGADO: al llegar el stock a 0 se preserva el ajuste neto de
								-- Cuadre de Kardex pendiente (antes se reseteaba siempre a 0, lo que
								-- borraba el efecto de cualquier cuadre aplicado sobre este producto)
								set @SaldoValoSoles = @SaldoAjusteCuadre;
							end;


						end;

					-- AGREGADO: Cuadre de Kardex - el costo promedio (SaldoPuSoles) no se recalcula
					if @esCuadre = 1
					begin
						set @SaldoPuSoles = @SaldoPuSolesIni;
					end;
					else
					if @orden = 1
					begin
						if @tipoMovimiento = 'E'
						begin
							if(@SaldoCantidad > 0 )
							begin
								set @SaldoPuSoles = (@TotalDolares * @tipoCambio)/@SaldoCantidad;

							end;
							else
							begin
								set @SaldoPuSoles	= 0;
							end;
							set @SaldoPuSolesIni = @SaldoPuSoles;
						end;
						else
						begin
							set @SaldoPuSoles = @SaldoPuSolesIni;
						end;
					end;
					else
					begin
						if @tipoMovimiento = 'E'
						begin
							if(@SaldoCantidad > 0 )
							begin
								set @SaldoPuSoles	=  @SaldoValoSoles/@SaldoCantidad;
							end;
							else
							begin
								set @SaldoPuSoles	= 0;
							end;
						end;
						else
						begin
							if(@SaldoCantidad > 0 )
							begin
								set @SaldoPuSoles = @SaldoPuSolesIni;
							end;
							else
							begin
								set @SaldoPuSoles	= 0;
							end;

						end;
					end;

					if(@SaldoCantidad = 0 )
						begin
							set @SaldoPuSolesIni	=  0;
						end;



					set @c = @c + 1;
					update #TmpKardex set
											PUCalcDolar			= @puold,
											TotalSoles			= @TotalSoles,
											PUCalcSoles			= @PUCalcSoles,
											tipoCambio			= @TipoCambioOld,
											saldoCantidad		= @SaldoCantidad ,
											SaldoValorDolares	= @SaldoValorDolares,
											SaldoPuSoles		= @SaldoPuSoles,
											SaldoValorSoles		= @SaldoValoSoles,
											-- AGREGADO: Cuadre de Kardex no debe mostrar cantidad/total en las columnas de entrada o salida
											cantidad			= CASE WHEN @esCuadre = 1 THEN 0 ELSE cantidad END,
											TotalDolar			= CASE WHEN @esCuadre = 1 THEN 0 ELSE TotalDolar END
					where cod = @cod and orden = @orden;

					set @SaldoPuSolesIni = @SaldoPuSoles;

					delete top(1) from #TmpRecorrido where orden = @orden  and cod= @cod;
					SET @contador = (select count(1) from #TmpRecorrido);
				end;

				select
						orden,				tipo,			cod,			Nombre_Articulo,
						color,				Fecha_Guia,		serie,			numero,
						codigo_Proveedor,	razonSocial,	serie_fact,		Num_fact,
						Tipo_Moneda,		codigo,			UM,				PU,
						fact_tipo,			mes,			tipoMovimiento,
						(CASE tipoMovimiento WHEN 'E' THEN cantidad ELSE 0 END) cantidadDolarE,
						(CASE tipoMovimiento WHEN 'E' THEN PUCalcDolar ELSE 0 END) PUCalcDolarE,
						(CASE tipoMovimiento WHEN 'E' THEN TotalDolar ELSE 0 END) TotalDolarE,
						(CASE WHEN tipoMovimiento = 'S' or tipoMovimiento = 'D' THEN cantidad ELSE 0 END) cantidadDolarS,
						(CASE WHEN tipoMovimiento = 'S' or tipoMovimiento = 'D' THEN PUCalcDolar ELSE 0 END) PUCalcDolarS,
						(CASE WHEN tipoMovimiento = 'S' or tipoMovimiento = 'D' THEN TotalDolar ELSE 0 END) TotalDolarS,
						(CASE tipoMovimiento WHEN 'E' THEN cantidad ELSE 0 END) cantidadSolesE,
						(CASE tipoMovimiento WHEN 'E' THEN PUCalcSoles ELSE 0 END) PUCalcSolesE,
						(CASE tipoMovimiento WHEN 'E' THEN TotalSoles ELSE 0 END) TotalSolesE,
						(CASE WHEN tipoMovimiento = 'S' or tipoMovimiento = 'D' THEN cantidad ELSE 0 END) cantidadSolesS,
						(CASE WHEN tipoMovimiento = 'S' or tipoMovimiento = 'D' THEN PUCalcSoles ELSE 0 END) PUCalcSolesS,
						(CASE WHEN tipoMovimiento = 'S' or tipoMovimiento = 'D' THEN TotalSoles ELSE 0 END) TotalSolesS,
						saldoCantidad,
						SaldoPuSoles,
						SaldoValorSoles,
						tipoCambio,
						0 secuencia,

						OpPedido ,
						OpColor,
						OpEstilo,
						OpPrograma,

						'09' Tipo_Documento,
						(CASE tipoMovimiento WHEN 'E' THEN '02' ELSE '10' END) Tipo_Operacion

						--PUCalcDolar,	TotalDolar,
						--PUCalcSoles,
						--TotalSoles,

						--saldoCantidad,	SaldoValorDolares,
						--	fechaOc
					from #TmpKardex order by cod asc,orden asc ;



				drop table #TmpKardex;
				drop table #TmpRecorrido;
END;
GO
