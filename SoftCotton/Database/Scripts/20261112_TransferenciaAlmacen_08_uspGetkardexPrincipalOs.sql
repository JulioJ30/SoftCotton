-- =====================================================================================
-- Transferencia entre Almacenes - Script 8 de 9: uspGetkardexPrincipalOs
-- =====================================================================================
-- Agrega al Kardex las transferencias entre almacenes, con la MISMA estructura de filas
-- que las guias, para los niveles por Orden de Servicio (06, 07, 08, 11, 12, 17), que
-- uspGetkardexPrincipal deriva a este procedimiento.
--
-- Cambios (todos marcados con "AGREGADO: Transferencia entre almacenes"):
--   1. Columna interna esTransferencia (0 en las filas de guias).
--   2. INSERT de 2 filas por linea de transferencia activa (salida origen / ingreso destino)
--      y renumeracion del orden por producto.
--   3. En el bucle, las filas de transferencia son informativas: se muestran al costo
--      promedio vigente y NO cambian saldo de cantidad, valor ni costo promedio. Por eso el
--      Kardex de cualquier producto da exactamente el mismo saldo que antes.
--   4. Tipo_Operacion '11' (transferencia entre almacenes) para esas filas.
--
-- Cuerpo base: definicion vigente en la base. Si en produccion el procedimiento cambio
-- despues, compare antes de ejecutar.
--
-- Requiere el script 2.
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER Proc [dbo].[uspGetkardexPrincipalOs]
@codNivel varchar(50),
@codCuenta varchar(50),
@codGrupo varchar(50),
@codTalla varchar(50),
@codColor varchar(50),
@fechaIni DATE,
@fechafin DATE
As
BEGIN
DECLARE @puold decimal(18,10) = 0,
		@contador INT = 0,
		@SaldoCantidad decimal(18,10) = 0,
		@SaldoValorDolares decimal(18,10) = 0,
		@SaldoValoSoles decimal(18,10) = 0,
		@SaldoPuSolesIni decimal(18,10) = 0,
		@PUCalcSoles decimal(18,10) = 0,
		@TipoCambioOld decimal(18,10) = 0;

		DECLARE @inicioYYYYMM NVARCHAR(6);
		DECLARE @finYYYYMM NVARCHAR(6);

		SET @inicioYYYYMM = CONVERT(NVARCHAR(4), YEAR(@fechaIni)) + RIGHT('0' + CONVERT(NVARCHAR(2), MONTH(@fechaIni)), 2);
		SET @finYYYYMM = CONVERT(NVARCHAR(4), YEAR(@fechafin)) + RIGHT('0' + CONVERT(NVARCHAR(2), MONTH(@fechafin)), 2);




		select
			ROW_NUMBER() OVER(PARTITION BY (tbl.cod) ORDER BY tbl.Fecha_Guia ASC,tbl.tipoMovimiento ASC) AS Orden,
			tbl.*

			into #TmpKardex
		from 
		(
			select	
			
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

				case when @codNivel = '17' 
					then isnull(gr.PrecioGr ,0)
				else
					isnull(fact.precioUnitario,oc.precioUnitario) 
				end PU,

				--isnull(fact.precioUnitario,oc.precioUnitario) PU,

				0 fact_tipo,
				month(grc.fechaEmision) mes,
				oc.cantidad as cantidadOC,
				gr.idEmpresa,
				gr.tipoMovimiento,
				(CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) cantidad,
				cast(0 as decimal(18,10)) PUCalcDolar,

				
				case when @codNivel = '17' 
					then 
						((CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) * (isnull(gr.PrecioGr,0)) )
				else
					((CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) * (isnull(fact.precioUnitario,oc.precioUnitario))) 
				end TotalDolar,

				--((CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) * (isnull(fact.precioUnitario,oc.precioUnitario))) TotalDolar,


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
				gr.secuencia,


				
				pe.pedido OpPedido ,
				col.descripcion OpColor,
				est.estilo OpEstilo,
				pro.programa OpPrograma,
				cast(0 as bit) esTransferencia -- AGREGADO: Transferencia entre almacenes
			
				from grCab grc 
				inner join grDet gr on	gr.serie = grc.serie
									and gr.numero=grc.numero
									and gr.idEmpresa = grc.idEmpresa

									-- AGREGADO
									and gr.destCodigoPC = grc.destCodigoPC

					left join  osDet oc on gr.idEmpresa = oc.idEmpresa
										and	gr.idDet = oc.idOs
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

					inner join osCab cab on oc.idEmpresa = cab.idEmpresa 
										and oc.idOS = cab.idOS

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
					and grc.tipoOrden = 'S'
					and (gr.codCuenta = @codCuenta or @codCuenta = '0')
					and (@codGrupo = '' or oc.codGrupo = @codGrupo)
					and (@codTalla = '' or oc.codTalla = @codTalla)
					and (@codColor = '' or oc.codColor = @codColor)
					AND cast(grc.fechaEmision as date) between cast(@fechaIni as date) and cast(@fechaFin as Date)


					and gr.codCuenta in (
						select codCuenta from cuentas where estado = 1 and FlgMostrarKardex = 1
					)

					union all

					-- SALIDA GUIAS
					select	
		--ROW_NUMBER() OVER(PARTITION BY (oc.codNivel + '.' + oc.codGrupo + '.' + oc.codTalla + '.' + oc.codColor) ORDER BY grc.fechaEmision ASC) AS orden,			
			CONCAT(n.codNivel,'.',NIVEL) tipo,		
			(oc.codNivel + '.' + oc.codGrupo + '.' + oc.codTalla + '.' + oc.codColor) as cod,
			(rtrim(ltrim(g.grupo))) as Nombre_Articulo,
			c.descripcion color,
			grc.fechaEmision Fecha_Guia,
			gr.serie,
			iif(gr.numero = '0000000000','SALDO INICIAL',gr.numero)numero,
			pc.codigo codigo_Proveedor,
			pc.razonSocial,
			'' serie_fact,
			'' Num_fact,
			'Dolar' Tipo_Moneda,
			0 idTipoMoneda,
			0 codigo,
			g.codUM UM,
			isnull(gr.Precio,0) PU,
			0 fact_tipo,
			month(grc.fechaEmision) mes,
			oc.cantidad as cantidadOC,
			gr.idEmpresa,
			'S' tipoMovimiento,
			(CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) cantidad,
			cast(0 as decimal(18,10)) PUCalcDolar,
			((CASE WHEN gr.cantidadIngresada < 0 THEN gr.cantidadIngresada * -1 ELSE gr.cantidadIngresada END) * (isnull(gr.Precio,oc.precioUnitario))) TotalDolar,
			cast(0 as decimal(18,10)) PUCalcSoles,
			cast(0 as decimal(18,10)) TotalSoles,
			cast(0 as decimal(18,10)) tipoCambio,
			cast(0 as decimal(18,10)) saldoCantidad,
			cast(0 as decimal(18,10)) SaldoValorDolares,
			cast(0 as decimal(18,10)) SaldoPuSoles,
			cast(0 as decimal(18,10)) SaldoValorSoles,
			cast(0 as decimal(18,10)) SaldoValorSolesant,
			cab.fechaEmision fechaOc,
			null fechaFactura,
			gr.Secuencia,

			'' OpPedido ,
			'' OpColor,
			'' OpEstilo,
			'' OpPrograma,
				cast(0 as bit) esTransferencia -- AGREGADO: Transferencia entre almacenes

			--*


			--into #TmpKardex
			from grCabExportacion grc 
			inner join grDetExportacion gr on	gr.serie = grc.serie
								and gr.numero=grc.numero
								and gr.idEmpresa = grc.idEmpresa
				left join TmpProductosCodigoExportacion tmp
				on tmp.Serie = gr.Serie
				and tmp.Numero =  gr.numero
				and trim(tmp.codSistema) = trim(gr.codProducto)
				left join colores col
				on trim(col.descripcion) = tmp.Color

				left join grupos g on	
				 g.codNivel = '07'  
				and 
				SUBSTRING(g.grupo, CHARINDEX('SC-',g.grupo) + 3,  CHARINDEX(' ',g.grupo + ' ', CHARINDEX('SC-', g.grupo) + 3) - CHARINDEX('SC-', g.grupo) - 3)  = trim(tmp.Op)
				left  join productoServicios p on	g.codNivel = p.codNivel
												and g.codGrupo = p.codGrupo
												--and oc.codTalla = p.codTalla
												and col.codColor = p.codColor
				left join 	osDet oc on 
				gr.idEmpresa = oc.idEmpresa
				and oc.codNivel = p.codNivel
				and oc.codGrupo = p.codGrupo
				and oc.codTalla = p.codTalla
				and oc.codColor = p.codColor
				


				--LEFT JOIN [dbo].[facDet] fact on fact.grIdEmpresa = gr.idEmpresa
				--					and fact.grSerie = gr.serie
				--					and fact.grNumero = gr.numero
				--					and fact.grSecuencia = gr.secuencia
				--					and fact.grTipoOrden = gr.tipoOrden
				--LEFT JOIN [dbo].[facCab] factcab on factCab.idEmpresa = fact.idEmpresa 
				--						and factCab.serie    = fact.Serie	 
				--						and factcab.numero	 = fact.Numero
				--						and factcab.codigoPC = fact.codigoPC
				inner join osCab cab on oc.idEmpresa = cab.idEmpresa 
									and oc.idOS = cab.idOS

			
				inner join provClientes pc on 	grc.destCodigoPC 	= 	pc.codigo
									
				--inner join productoServicios p on	oc.codNivel = p.codNivel
				--								and oc.codGrupo = p.codGrupo
				--								and oc.codTalla = p.codTalla
				--								and oc.codColor = p.codColor
				
				inner join niveles n on g.codNivel = n.codNivel
				inner join tallas t on p.codTalla = t.codTalla
				inner join colores c on p.codColor = c.codColor
				--left join tipoMonedas mon on mon.idTipoMoneda = cab.idTipoMoneda
				--left join TMP_HUGO2 vv on factCab.serie    = vv.Serie	 
				--						and factcab.numero	 = vv.Numero
				--						and factcab.codigoPC = vv.ruc
				where n.codNivel = @codNivel
					--and grc.tipoOrden = 'S'
					--and (gr.codCuenta = @codCuenta or @codCuenta = '0')
					and (@codGrupo = '' or oc.codGrupo = @codGrupo)
					and (@codTalla = '' or oc.codTalla = @codTalla)
					and (@codColor = '' or oc.codColor = @codColor)
					AND cast(grc.fechaEmision as date) between cast(@fechaIni as date) and cast(@fechaFin as Date)

				


				)tbl

			

				-- =====================================================================
				-- AGREGADO: Transferencia entre almacenes (TransferenciaAlmacenCab/Det)
				-- Cada linea de una transferencia activa genera 2 filas: salida ('S') del
				-- almacen origen e ingreso ('E') al almacen destino, por la misma cantidad.
				-- Son movimientos internos: NO cambian el saldo de cantidad, el valor ni el
				-- costo promedio del producto (ver bloque esTransferencia en el bucle). Se
				-- ubican al final del dia, despues de los movimientos reales.
				-- serie TRA/DEV + numero = N de transferencia; codigo_Proveedor = 'ALM ' +
				-- almacen que sale (S) o que recibe (E). Tipo de operacion SUNAT '11'.
				-- =====================================================================
				insert into #TmpKardex (
					Orden, tipo, cod, Nombre_Articulo, color, Fecha_Guia, serie, numero,
					codigo_Proveedor, razonSocial, serie_fact, Num_fact, Tipo_Moneda, idTipoMoneda,
					codigo, UM, PU, fact_tipo, mes, cantidadOC, idEmpresa, tipoMovimiento, cantidad,
					PUCalcDolar, TotalDolar, PUCalcSoles, TotalSoles, tipoCambio, saldoCantidad,
					SaldoValorDolares, SaldoPuSoles, SaldoValorSoles, SaldoValorSolesant,
					fechaOc, fechaFactura,
					secuencia,
					OpPedido, OpColor, OpEstilo, OpPrograma, esTransferencia)
				select
					0,
					CONCAT(n.codNivel, '.', n.NIVEL),
					(td.codNivel + '.' + td.codGrupo + '.' + td.codTalla + '.' + td.codColor),
					(rtrim(ltrim(g.grupo))),
					c.descripcion,
					tc.FechaTransferencia,
					iif(tc.TipoTransferencia = 'D', 'DEV', 'TRA'),
					right('0000000000' + cast(tc.IdTransferencia as varchar(10)), 10),
					'ALM ' + iif(m.tipoMovimiento = 'S', tc.CodAlmacenOrigen, tc.CodAlmacenDestino),
					left(concat(iif(tc.TipoTransferencia = 'D', 'DEVOLUCION ', 'TRANSFERENCIA '),
								coalesce(nullif(rtrim(ao.tResumido), ''), ao.Descripcion), ' > ',
								coalesce(nullif(rtrim(ad.tResumido), ''), ad.Descripcion)), 60),
					'', '', '', null,
					tc.IdTransferencia,
					g.codUM,
					0, 0, month(tc.FechaTransferencia), 0, 1,
					m.tipoMovimiento,
					td.Cantidad,
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0,
					tc.FechaTransferencia, null,
					0,
					'', '', '', '', cast(1 as bit)
				from TransferenciaAlmacenCab tc
				inner join TransferenciaAlmacenDet td on td.IdTransferencia = tc.IdTransferencia
				inner join AreasAlmacen ao on ao.Codigo = tc.CodAlmacenOrigen
				inner join AreasAlmacen ad on ad.Codigo = tc.CodAlmacenDestino
				inner join productoServicios p on p.codNivel = td.codNivel
												and p.codGrupo = td.codGrupo
												and p.codTalla = td.codTalla
												and p.codColor = td.codColor
				inner join grupos g on g.codNivel = p.codNivel and g.codGrupo = p.codGrupo
				inner join niveles n on n.codNivel = g.codNivel
				inner join tallas t on t.codTalla = p.codTalla
				inner join colores c on c.codColor = p.codColor
				cross apply (values ('S'), ('E')) m(tipoMovimiento)
				where tc.Estado = 'A'
				and n.codNivel = @codNivel
				and (td.codCuenta = @codCuenta or @codCuenta = '0')
				and (@codGrupo = '' or td.codGrupo = @codGrupo)
				and (@codTalla = '' or td.codTalla = @codTalla)
				and (@codColor = '' or td.codColor = @codColor)
				and tc.FechaTransferencia between cast(@fechaIni as date) and cast(@fechaFin as date)
				and td.codCuenta in (
					select codCuenta from cuentas where estado = 1 and FlgMostrarKardex = 1
				);

				-- AGREGADO: Transferencia entre almacenes - renumera el orden por producto.
				-- Los movimientos reales conservan su orden relativo (se ordena por el orden
				-- original); las transferencias van al final de su dia (salida y luego ingreso).
				if @@ROWCOUNT > 0
				begin
					;with x as (
						select Orden, row_number() over (partition by cod
							order by Fecha_Guia asc, esTransferencia asc, Orden asc, codigo asc, tipoMovimiento desc) as rn
						from #TmpKardex
					)
					update x set Orden = rn;
				end;

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
							-- AGREGADO: Transferencia entre almacenes
							@esTransferencia bit
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
									@num_fact = Num_fact,
									@esTransferencia = esTransferencia -- AGREGADO
					 from #TmpRecorrido
					 order by cod asc,orden asc 
					 ;

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

					  if @codNivel = '17'
					  begin
						set @tipoCambio = 1
					  end 


					if @orden = 1
					begin
						set @puold = 0;
						set @SaldoCantidad = 0;
						set @SaldoValorDolares =0;
						set @SaldoValoSoles = 0;

					end;
					-- AGREGADO: Transferencia entre almacenes - fila informativa: no mueve saldo de
					-- cantidad, valor ni costo promedio. Se muestra al costo promedio vigente
					-- (en la primera fila del rango no hay costo previo: se muestra en 0).
					if @esTransferencia = 1
					begin
						set @PUCalcSoles = iif(@orden = 1, 0, @SaldoPuSolesIni);
						set @TotalSoles = @PUCalcSoles * @cantidad;
						set @SaldoPuSoles = @PUCalcSoles;
					end
					else
					begin -- AGREGADO: inicio movimientos reales (logica original sin cambios)

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
								set @SaldoValoSoles = 0;
							end;
							
							
						end;
					
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

					end; -- AGREGADO: fin movimientos reales

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
											SaldoValorSoles		= @SaldoValoSoles
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
						--PUCalcDolar,	TotalDolar,	
						--PUCalcSoles,	
						--TotalSoles,	
						
						--saldoCantidad,	SaldoValorDolares,	
						--	fechaOc
						secuencia,

						OpPedido ,
						OpColor,
						OpEstilo,
						OpPrograma,
						'09' Tipo_Documento,
						(CASE WHEN esTransferencia = 1 THEN '11' WHEN tipoMovimiento = 'E' THEN '02' ELSE '10' END) Tipo_Operacion -- AGREGADO: '11' transferencia entre almacenes

					from #TmpKardex order by cod asc,orden asc ;



				drop table #TmpKardex;
				drop table #TmpRecorrido;
END;
GO
