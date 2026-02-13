using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using SoftCotton.Model.ReferralGuide;
using Excel = Microsoft.Office.Interop.Excel;



namespace SoftCotton.Util
{
    public static class ExcelReport
    {

        public static void GetExcelReport<T>(string rutaArchivo, ExcelReportTitulo[] tituloArray, List<T> contenidoArray)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hoja 1");

                // Titulo
                for (int i = 0; i < tituloArray.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = tituloArray[i].titulo.ToString();
                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
                    worksheet.Cell(1, i + 1).Style.Font.FontColor = tituloArray[i].foreColor;
                }

                IXLRange rangeTitulo = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, tituloArray.Length).Address);

                rangeTitulo.Style.Font.Bold = true;
                rangeTitulo.Style.Border.OutsideBorder = XLBorderStyleValues.Medium; ;


                // Contenido
                int columnIndex = 1;
                int rowIndex = 2;
                foreach (T t in contenidoArray)
                {
                    foreach (PropertyInfo info in typeof(T).GetProperties())
                    {

                        if (info.PropertyType.Name.ToUpper().StartsWith("INT"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 0;
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("DECIMAL"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 4;
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("STRING"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("CHAR"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                        }

                        worksheet.Cell(rowIndex, columnIndex).Value = (info.GetValue(t, null) ?? DBNull.Value);


                        columnIndex++;
                    }

                    rowIndex++;
                    columnIndex = 1;
                }

                //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                //foreach (var item in worksheet.ColumnsUsed())
                //{
                //    item.AdjustToContents();
                //}

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(rutaArchivo);
            }
        }

        public static void GetExcelReportKardex<T>(string rutaArchivo, ExcelReportTitulo[] tituloArray, List<T> contenidoArray)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Hoja 1");


                    worksheet.Cell(2, 25).Value = "ENTRADA S/.";
                    worksheet.Cell(2, 25).Style.Fill.BackgroundColor = tituloArray[21].backgroundColor;
                    worksheet.Cell(2, 25).Style.Font.FontColor = tituloArray[21].foreColor;
                    worksheet.Cell(2, 25).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("Y2:AA2").Merge();
                    worksheet.Cell(2, 28).Value = "SALIDA S/.";
                    worksheet.Cell(2, 28).Style.Fill.BackgroundColor = tituloArray[24].backgroundColor;
                    worksheet.Cell(2, 28).Style.Font.FontColor = tituloArray[24].foreColor;
                    worksheet.Cell(2, 28).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("AB2:AD2").Merge();

                    worksheet.Cell(2, 31).Value = "SALDO S/.";
                    worksheet.Cell(2, 31).Style.Fill.BackgroundColor = tituloArray[27].backgroundColor;
                    worksheet.Cell(2, 31).Style.Font.FontColor = tituloArray[27].foreColor;
                    worksheet.Cell(2, 31).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("AE2:AG2").Merge();
                    //worksheet.Cell(2, 30).Value = "SALIDA S/.";
                    //worksheet.Cell(2, 30).Style.Fill.BackgroundColor = tituloArray[30].backgroundColor;
                    //worksheet.Cell(2, 30).Style.Font.FontColor = tituloArray[30].foreColor;
                    //worksheet.Cell(2, 30).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    //worksheet.Range("AD2:AF2").Merge();
                    //worksheet.Cell(2, 33).Value = "SALDO S/.";
                    //worksheet.Cell(2, 33).Style.Fill.BackgroundColor = tituloArray[33].backgroundColor;
                    //worksheet.Cell(2, 33).Style.Font.FontColor = tituloArray[33].foreColor;
                    //worksheet.Cell(2, 33).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    //worksheet.Range("AG2:AI2").Merge();
                    // Titulo
                    for (int i = 0; i < tituloArray.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = tituloArray[i].titulo.ToString();
                        worksheet.Cell(3, i + 1).Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
                        worksheet.Cell(3, i + 1).Style.Font.FontColor = tituloArray[i].foreColor;
                    }

                    //IXLRange rangeTitulo = worksheet.Range(worksheet.Cell(2, 1).Address, worksheet.Cell(2, tituloArray.Length).Address);

                    //rangeTitulo.Style.Font.Bold = true;
                    //rangeTitulo.Style.Border.OutsideBorder = XLBorderStyleValues.Medium; ;


                    // Contenido
                    int columnIndex = 1;
                    int rowIndex = 4;
                    int rowInicial = 4;
                    string valorCodigo = "";
                    foreach (T t in contenidoArray)
                    {
                        foreach (PropertyInfo info in typeof(T).GetProperties())
                        {
                            if (rowIndex > 4)
                            {
                                if (columnIndex == 1)
                                {
                                    var valorparticion = Convert.ToInt32(info.GetValue(t, null) ?? DBNull.Value);
                                    if (valorparticion == 1)
                                    {
                                        worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                                        worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1); 
                                        worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                                        worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Font.FontColor = XLColor.Black;
                                        worksheet.Cell(rowIndex, columnIndex).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                        //Total Saldo
                                        worksheet.Cell(rowIndex, 33).FormulaA1 = "AG" + (rowIndex - 1) ;
                                        //Cantidad Saldo 
                                        worksheet.Cell(rowIndex, 31).FormulaA1 = "AE" + (rowIndex - 1) ;
                                        //Total De Cantidades Entradas
                                        worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";
                                        //Total de Cantidades de Salidas
                                        worksheet.Cell(rowIndex, 28).FormulaA1 = "SUM(AB" + rowInicial + ":AB" + (rowIndex - 1) + ")";
                                        //Total de Saldos Entrada 
                                        worksheet.Cell(rowIndex, 27).FormulaA1 = "SUM(AA" + rowInicial + ":AA" + (rowIndex - 1) + ")";
                                        //Total de Saldos Salida
                                        worksheet.Cell(rowIndex, 30).FormulaA1 = "SUM(AD" + rowInicial + ":AD" + (rowIndex - 1) + ")";
                                        worksheet.Range("D" + rowIndex + ":X" + rowIndex).Merge();
                                        rowIndex++;
                                        rowInicial = rowIndex;
                                    }
                                }
                                else if (columnIndex == 3)
                                {
                                    valorCodigo = Convert.ToString(info.GetValue(t, null) ?? DBNull.Value);
                                }
                            }


                            if (info.PropertyType.Name.ToUpper().StartsWith("INT"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 0;
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("DECIMAL"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 4;
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("STRING"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("CHAR"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("DATE"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "dd/mm/yyyy";
                            }

                            worksheet.Cell(rowIndex, columnIndex).Value = (info.GetValue(t, null) ?? DBNull.Value);


                            columnIndex++;
                        }

                        rowIndex++;
                        columnIndex = 1;
                    }



                    worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                    worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                    //Total Saldo
                    worksheet.Cell(rowIndex, 33).FormulaA1 = "AG" + (rowIndex - 1);
                    //Cantidad Saldo 
                    worksheet.Cell(rowIndex, 31).FormulaA1 = "AE" + (rowIndex - 1);
                    //Total De Cantidades Entradas
                    worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";
                    //Total de Cantidades de Salidas
                    worksheet.Cell(rowIndex, 28).FormulaA1 = "SUM(AB" + rowInicial + ":AB" + (rowIndex - 1) + ")";
                    //Total de Saldos Entrada 
                    worksheet.Cell(rowIndex, 27).FormulaA1 = "SUM(AA" + rowInicial + ":AA" + (rowIndex - 1) + ")";
                    //Total de Saldos Salida
                    worksheet.Cell(rowIndex, 30).FormulaA1 = "SUM(AD" + rowInicial + ":AD" + (rowIndex - 1) + ")";


                    worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Font.FontColor = XLColor.Black;
                    worksheet.Range("D" + rowIndex + ":X" + rowIndex).Merge();
                    worksheet.Columns().AdjustToContents();

                    //worksheet.Range("A" + (rowIndex + 2) + ":AC" + (rowIndex + 2)).Style.Fill.BackgroundColor = XLColor.DarkSeaGreen;
                    //worksheet.Range("A" + (rowIndex + 2) + ":AC" + (rowIndex + 2)).Style.Font.FontColor = XLColor.Black;
                    //worksheet.Cell(rowIndex, 29).FormulaA1 = "SUM(AC4:AC"+(rowIndex +2) +")";
                    //worksheet.Cell(rowIndex, 21).FormulaA1 = "SUM(U4:U"+(rowIndex +2) +")";
                    //worksheet.Cell(rowIndex, 23).FormulaA1 = "SUM(W4:W"+(rowIndex +2) +")";
                    //worksheet.Cell(rowIndex, 26).FormulaA1 = "SUM(Z4:Z"+(rowIndex +2) +")";
                    //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    //foreach (var item in worksheet.ColumnsUsed())
                    //{
                    //    item.AdjustToContents();
                    //}

                    //worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(rutaArchivo);
                }
            }
            catch
            {
            }
            
        }

        public static void GetExcelReportKardexParaPdf<T>(string rutaArchivo, ExcelReportTitulo[] tituloArray, List<T> contenidoArray)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Hoja 1");


                    worksheet.Cell(2, 25).Value = "ENTRADA S/.";
                    worksheet.Cell(2, 25).Style.Fill.BackgroundColor = tituloArray[21].backgroundColor;
                    worksheet.Cell(2, 25).Style.Font.FontColor = tituloArray[21].foreColor;
                    worksheet.Cell(2, 25).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("Y2:AA2").Merge();
                    worksheet.Cell(2, 28).Value = "SALIDA S/.";
                    worksheet.Cell(2, 28).Style.Fill.BackgroundColor = tituloArray[24].backgroundColor;
                    worksheet.Cell(2, 28).Style.Font.FontColor = tituloArray[24].foreColor;
                    worksheet.Cell(2, 28).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("AB2:AD2").Merge();

                    worksheet.Cell(2, 31).Value = "SALDO S/.";
                    worksheet.Cell(2, 31).Style.Fill.BackgroundColor = tituloArray[27].backgroundColor;
                    worksheet.Cell(2, 31).Style.Font.FontColor = tituloArray[27].foreColor;
                    worksheet.Cell(2, 31).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("AE2:AG2").Merge();
 
                    // Titulo
                    for (int i = 0; i < tituloArray.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = tituloArray[i].titulo.ToString();
                        worksheet.Cell(3, i + 1).Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
                        worksheet.Cell(3, i + 1).Style.Font.FontColor = tituloArray[i].foreColor;
                    }


                    // Contenido
                    int columnIndex = 1;
                    int rowIndex = 4;
                    int rowInicial = 4;
                    string valorCodigo = "";
                    foreach (T t in contenidoArray)
                    {
                        foreach (PropertyInfo info in typeof(T).GetProperties())
                        {
                            if (rowIndex > 4)
                            {
                                if (columnIndex == 1)
                                {
                                    var valorparticion = Convert.ToInt32(info.GetValue(t, null) ?? DBNull.Value);
                                    if (valorparticion == 1)
                                    {
                                        worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                                        worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                                        worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                                        worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Font.FontColor = XLColor.Black;
                                        worksheet.Cell(rowIndex, columnIndex).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                        //Total Saldo
                                        worksheet.Cell(rowIndex, 33).FormulaA1 = "AG" + (rowIndex - 1);
                                        //Cantidad Saldo 
                                        worksheet.Cell(rowIndex, 31).FormulaA1 = "AE" + (rowIndex - 1);
                                        //Total De Cantidades Entradas
                                        worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";
                                        //Total de Cantidades de Salidas
                                        worksheet.Cell(rowIndex, 28).FormulaA1 = "SUM(AB" + rowInicial + ":AB" + (rowIndex - 1) + ")";
                                        //Total de Saldos Entrada 
                                        worksheet.Cell(rowIndex, 27).FormulaA1 = "SUM(AA" + rowInicial + ":AA" + (rowIndex - 1) + ")";
                                        //Total de Saldos Salida
                                        worksheet.Cell(rowIndex, 30).FormulaA1 = "SUM(AD" + rowInicial + ":AD" + (rowIndex - 1) + ")";
                                        worksheet.Range("D" + rowIndex + ":X" + rowIndex).Merge();
                                        rowIndex++;
                                        rowInicial = rowIndex;
                                    }
                                }
                                else if (columnIndex == 3)
                                {
                                    valorCodigo = Convert.ToString(info.GetValue(t, null) ?? DBNull.Value);
                                }
                            }


                            if (info.PropertyType.Name.ToUpper().StartsWith("INT"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 0;
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("DECIMAL"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 4;
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("STRING"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("CHAR"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("DATE"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "dd/mm/yyyy";
                            }

                            worksheet.Cell(rowIndex, columnIndex).Value = (info.GetValue(t, null) ?? DBNull.Value);


                            columnIndex++;
                        }

                        rowIndex++;
                        columnIndex = 1;
                    }



                    worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                    worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                    //Total Saldo
                    worksheet.Cell(rowIndex, 33).FormulaA1 = "AG" + (rowIndex - 1);
                    //Cantidad Saldo 
                    worksheet.Cell(rowIndex, 31).FormulaA1 = "AE" + (rowIndex - 1);
                    //Total De Cantidades Entradas
                    worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";
                    //Total de Cantidades de Salidas
                    worksheet.Cell(rowIndex, 28).FormulaA1 = "SUM(AB" + rowInicial + ":AB" + (rowIndex - 1) + ")";
                    //Total de Saldos Entrada 
                    worksheet.Cell(rowIndex, 27).FormulaA1 = "SUM(AA" + rowInicial + ":AA" + (rowIndex - 1) + ")";
                    //Total de Saldos Salida
                    worksheet.Cell(rowIndex, 30).FormulaA1 = "SUM(AD" + rowInicial + ":AD" + (rowIndex - 1) + ")";


                    worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    worksheet.Range("A" + rowIndex + ":AG" + rowIndex).Style.Font.FontColor = XLColor.Black;
                    worksheet.Range("D" + rowIndex + ":X" + rowIndex).Merge();
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(rutaArchivo);
                }
            }
            catch
            {
            }

        }


        public static string GenerarKardexDirectoAPdf_Old<T>(string rutaPdf,ExcelReportTitulo[] tituloArray,List<T> contenidoArray, TituloPdf titulopdf)
        {
            // 👉 Excel temporal (misma ruta, nombre oculto)
            string carpeta = Path.GetDirectoryName(rutaPdf);
            string nombreTemp = Guid.NewGuid().ToString();
            string rutaExcelTemp = Path.Combine(carpeta, nombreTemp + ".xlsx");

            // =============================
            // 1️⃣ CREAR EXCEL (ClosedXML)
            // =============================
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hoja 1");


                int filaEncabezado = 1;

                // ENCABEZADO

                // Etiquetas
                worksheet.Cell(filaEncabezado, 3).Value = "PERIODO:";
                worksheet.Cell(filaEncabezado + 1, 3).Value = "RUC:";
                worksheet.Cell(filaEncabezado + 2, 3).Value = "APELLIDOS Y NOMBRES, DENOMINACIÓN O RAZÓN SOCIAL:";
                worksheet.Cell(filaEncabezado + 3, 3).Value = "ESTABLECIMIENTO (1):";
                worksheet.Cell(filaEncabezado + 4, 3).Value = "CÓDIGO DE LA EXISTENCIA:";
                worksheet.Cell(filaEncabezado + 5, 3).Value = "TIPO (TABLA 5):";
                worksheet.Cell(filaEncabezado + 6, 3).Value = "DESCRIPCIÓN:";
                worksheet.Cell(filaEncabezado + 7, 3).Value = "CÓDIGO DE LA UNIDAD DE MEDIDA (TABLA 6):";
                worksheet.Cell(filaEncabezado + 8, 3).Value = "MÉTODO DE VALUACIÓN:";

                // Valores ficticios
                worksheet.Cell(filaEncabezado, 4).Value = titulopdf.Periodo;
                worksheet.Cell(filaEncabezado + 1, 4).Value = titulopdf.Ruc;
                worksheet.Cell(filaEncabezado + 2, 4).Value = titulopdf.RazonSocial;
                worksheet.Cell(filaEncabezado + 3, 4).Value = titulopdf.Establecimiento;
                worksheet.Cell(filaEncabezado + 4, 4).Value = titulopdf.CodigoExistencia;
                worksheet.Cell(filaEncabezado + 5, 4).Value = titulopdf.Tipo;
                worksheet.Cell(filaEncabezado + 6, 4).Value = titulopdf.TipoDescripcion;
                worksheet.Cell(filaEncabezado + 7, 4).Value = titulopdf.CodigoUnidadMedida;
                worksheet.Cell(filaEncabezado + 8, 4).Value = titulopdf.MetodoEvaluacion;

                // END ENCABEZADO

                // Estilo
                worksheet.Range("C1:C9").Style.Font.Bold = true;
                worksheet.Range("C1:O9").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;



                worksheet.Cell(10, 11).Value = "ENTRADA S/.";
                worksheet.Cell(10, 11).Style.Fill.BackgroundColor = tituloArray[6].backgroundColor;
                worksheet.Cell(10, 11).Style.Font.FontColor = tituloArray[6].foreColor;
                worksheet.Cell(10, 11).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("K10:M10").Merge();
                worksheet.Cell(10, 14).Value = "SALIDA S/.";
                worksheet.Cell(10, 14).Style.Fill.BackgroundColor = tituloArray[6].backgroundColor;
                worksheet.Cell(10, 14).Style.Font.FontColor = tituloArray[6].foreColor;
                worksheet.Cell(10, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("N10:P10").Merge();

                worksheet.Cell(10, 17).Value = "SALDO S/.";
                worksheet.Cell(10, 17).Style.Fill.BackgroundColor = tituloArray[6].backgroundColor;
                worksheet.Cell(10, 17).Style.Font.FontColor = tituloArray[6].foreColor;
                worksheet.Cell(10, 17).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("Q10:S10").Merge();

                // Titulo
                for (int i = 0; i < tituloArray.Length; i++)
                {
                    worksheet.Cell(11, i + 1).Value = tituloArray[i].titulo.ToString();
                    worksheet.Cell(11, i + 1).Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
                    worksheet.Cell(11, i + 1).Style.Font.FontColor = tituloArray[i].foreColor;
                }


                // Contenido
                int columnIndex = 1;
                //int rowIndex = 4;
                //int rowInicial = 4;
                int rowIndex = 12; // antes era 4
                int rowInicial = 12;
                string valorCodigo = "";
                var filasTotalesItems = new List<int>();

                foreach (T t in contenidoArray)
                {
                    foreach (PropertyInfo info in typeof(T).GetProperties())
                    {
                        if (rowIndex > 12)
                        {
                            if (columnIndex == 1)
                            {
                                var valorparticion = Convert.ToInt32(info.GetValue(t, null) ?? DBNull.Value);
                                if (valorparticion == 1)
                                {
                                    worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                                    worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                                    worksheet.Range("A" + rowIndex + ":S" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                                    worksheet.Range("A" + rowIndex + ":S" + rowIndex).Style.Font.FontColor = XLColor.Black;
                                    worksheet.Cell(rowIndex, columnIndex).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    //Total Saldo
                                    worksheet.Cell(rowIndex, 19).FormulaA1 = "S" + (rowIndex - 1);
                                    //Cantidad Saldo 
                                    worksheet.Cell(rowIndex, 18).FormulaA1 = "Q" + (rowIndex - 1);
                                    //Total De Cantidades Entradas
                                    worksheet.Cell(rowIndex, 11).FormulaA1 = "SUM(K" + rowInicial + ":K" + (rowIndex - 1) + ")";
                                    //Total de Cantidades de Salidas
                                    worksheet.Cell(rowIndex, 14).FormulaA1 = "SUM(N" + rowInicial + ":N" + (rowIndex - 1) + ")";
                                    //Total de Saldos Entrada 
                                    worksheet.Cell(rowIndex, 13).FormulaA1 = "SUM(M" + rowInicial + ":M" + (rowIndex - 1) + ")";
                                    //Total de Saldos Salida
                                    worksheet.Cell(rowIndex, 16).FormulaA1 = "SUM(P" + rowInicial + ":P" + (rowIndex - 1) + ")";
                                    worksheet.Range("D" + rowIndex + ":J" + rowIndex).Merge();

                                    filasTotalesItems.Add(rowIndex);

                                    rowIndex++;
                                    rowInicial = rowIndex;
                                }
                            }
                            else if (columnIndex == 3)
                            {
                                valorCodigo = Convert.ToString(info.GetValue(t, null) ?? DBNull.Value);
                            }
                        }


                        if (info.PropertyType.Name.ToUpper().StartsWith("INT"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 0;
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("DECIMAL"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 4;
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("STRING"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("CHAR"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                        }
                        else if (info.PropertyType.Name.ToUpper().StartsWith("DATE"))
                        {
                            worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "dd/mm/yyyy";
                        }

                        worksheet.Cell(rowIndex, columnIndex).Value = (info.GetValue(t, null) ?? DBNull.Value);


                        columnIndex++;
                    }

                    rowIndex++;
                    columnIndex = 1;
                }



                worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                //Total Saldo
                worksheet.Cell(rowIndex, 19).FormulaA1 = "S" + (rowIndex - 1);
                //Cantidad Saldo 
                worksheet.Cell(rowIndex, 18).FormulaA1 = "Q" + (rowIndex - 1);
                //Total De Cantidades Entradas
                worksheet.Cell(rowIndex, 11).FormulaA1 = "SUM(K" + rowInicial + ":K" + (rowIndex - 1) + ")";
                //Total de Cantidades de Salidas
                worksheet.Cell(rowIndex, 14).FormulaA1 = "SUM(N" + rowInicial + ":N" + (rowIndex - 1) + ")";
                //Total de Saldos Entrada 
                worksheet.Cell(rowIndex, 13).FormulaA1 = "SUM(M" + rowInicial + ":M" + (rowIndex - 1) + ")";
                //Total de Saldos Salida
                worksheet.Cell(rowIndex, 16).FormulaA1 = "SUM(P" + rowInicial + ":P" + (rowIndex - 1) + ")";


                worksheet.Range("A" + rowIndex + ":S" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                worksheet.Range("A" + rowIndex + ":S" + rowIndex).Style.Font.FontColor = XLColor.Black;
                worksheet.Range("D" + rowIndex + ":J" + rowIndex).Merge();

                filasTotalesItems.Add(rowIndex);
                rowIndex++;

                worksheet.Cell(rowIndex, 2).Value = "TOTAL GENERAL";
                worksheet.Range("A" + rowIndex + ":S" + rowIndex)
                    .Style.Fill.BackgroundColor = XLColor.DarkBlue;
                worksheet.Range("A" + rowIndex + ":S" + rowIndex)
                    .Style.Font.FontColor = XLColor.White;
                worksheet.Range("A" + rowIndex + ":S" + rowIndex)
                    .Style.Font.Bold = true;

                worksheet.Range("D" + rowIndex + ":J" + rowIndex).Merge();

                // Construir fórmula SUM manual
                string filas = string.Join(",", filasTotalesItems);

                // Entradas
                worksheet.Cell(rowIndex, 11).FormulaA1 = $"SUM(K{string.Join(",K", filasTotalesItems)})";

                // Salidas
                worksheet.Cell(rowIndex, 14).FormulaA1 = $"SUM(N{string.Join(",N", filasTotalesItems)})";

                // Totales entrada
                worksheet.Cell(rowIndex, 13).FormulaA1 = $"SUM(M{string.Join(",M", filasTotalesItems)})";

                // Totales salida
                worksheet.Cell(rowIndex, 16).FormulaA1 = $"SUM(P{string.Join(",P", filasTotalesItems)})";

                // Cantidad saldo
                worksheet.Cell(rowIndex, 18).FormulaA1 = $"SUM(Q{string.Join(",Q", filasTotalesItems)})";

                // Total saldo
                worksheet.Cell(rowIndex, 19).FormulaA1 = $"SUM(S{string.Join(",S", filasTotalesItems)})";


                worksheet.Column(11).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(13).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(14).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(16).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(18).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Column(19).Style.NumberFormat.Format = "#,##0.00";




                //worksheet.Columns().AdjustToContents();
                worksheet.ColumnsUsed().AdjustToContents();


                // 🔥 Repetir encabezado
                worksheet.PageSetup.SetRowsToRepeatAtTop(1, 11);

                // Centrar
                worksheet.PageSetup.CenterHorizontally = true;

                // Márgenes
                worksheet.PageSetup.Margins.Left = 0.3;
                worksheet.PageSetup.Margins.Right = 0.3;
                worksheet.PageSetup.Margins.Top = 0.5;
                worksheet.PageSetup.Margins.Bottom = 0.5;


                // Por las siguientes líneas, usando los códigos de campo de Excel:
                worksheet.PageSetup.Header.Right.AddText("&P");
                worksheet.PageSetup.Header.Right.AddText(" de ");
                worksheet.PageSetup.Header.Right.AddText("&N");


                workbook.SaveAs(rutaExcelTemp);
            }

            // =============================
            // 2️⃣ CONVERTIR A PDF (Interop)
            // =============================
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbookInterop = excelApp.Workbooks.Open(rutaExcelTemp);
            Excel.Worksheet sheet = workbookInterop.ActiveSheet;

            sheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            sheet.PageSetup.Zoom = false;
            sheet.PageSetup.FitToPagesWide = 1;
            sheet.PageSetup.FitToPagesTall = false;

            workbookInterop.ExportAsFixedFormat(
                Excel.XlFixedFormatType.xlTypePDF,
                rutaPdf
            );

            workbookInterop.Close(false);
            excelApp.Quit();

            // =============================
            // 3️⃣ LIMPIEZA
            // =============================
            //File.Delete(rutaExcelTemp);

            return rutaPdf;
        }

        //public static string GenerarKardexDirectoAPdf<T>(
        //string rutaPdf,
        //ExcelReportTitulo[] tituloArray,
        //List<T> contenidoArray,
        //TituloPdf titulopdf)
        //    {
        //        string carpeta = Path.GetDirectoryName(rutaPdf);
        //        string rutaExcelTemp = Path.Combine(carpeta, Guid.NewGuid() + ".xlsx");

        //        // Cache reflection (🔥 clave rendimiento)
        //        var props = typeof(T).GetProperties();

        //        using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
        //        {
        //            var ws = workbook.Worksheets.Add("Hoja 1");

        //            //---------------------------------------------------
        //            // ENCABEZADO (sin cambios funcionales)
        //            //---------------------------------------------------
        //            int f = 1;

        //            string[] labels =
        //            {
        //        "PERIODO:",
        //        "RUC:",
        //        "APELLIDOS Y NOMBRES, DENOMINACIÓN O RAZÓN SOCIAL:",
        //        "ESTABLECIMIENTO (1):",
        //        "CÓDIGO DE LA EXISTENCIA:",
        //        "TIPO (TABLA 5):",
        //        "DESCRIPCIÓN:",
        //        "CÓDIGO DE LA UNIDAD DE MEDIDA (TABLA 6):",
        //        "MÉTODO DE VALUACIÓN:"
        //    };

        //            string[] values =
        //            {
        //        titulopdf.Periodo,
        //        titulopdf.Ruc,
        //        titulopdf.RazonSocial,
        //        titulopdf.Establecimiento,
        //        titulopdf.CodigoExistencia,
        //        titulopdf.Tipo,
        //        titulopdf.TipoDescripcion,
        //        titulopdf.CodigoUnidadMedida,
        //        titulopdf.MetodoEvaluacion
        //    };

        //            for (int i = 0; i < labels.Length; i++)
        //            {
        //                ws.Cell(f + i, 3).Value = labels[i];
        //                ws.Cell(f + i, 4).Value = values[i];
        //            }

        //            ws.Range("C1:C9").Style.Font.Bold = true;

        //            //---------------------------------------------------
        //            // TITULOS
        //            //---------------------------------------------------
        //            for (int i = 0; i < tituloArray.Length; i++)
        //            {
        //                var cell = ws.Cell(11, i + 1);
        //                cell.Value = tituloArray[i].titulo;
        //                cell.Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
        //                cell.Style.Font.FontColor = tituloArray[i].foreColor;
        //            }

        //            //---------------------------------------------------
        //            // CONTENIDO (🔥 ultra optimizado)
        //            //---------------------------------------------------
        //            int row = 12;

        //            foreach (var item in contenidoArray)
        //            {
        //                for (int col = 0; col < props.Length; col++)
        //                {
        //                    ws.Cell(row, col + 1).Value =
        //                        props[col].GetValue(item);
        //                }

        //                row++;
        //            }

        //            //---------------------------------------------------
        //            // Ajuste ligero (🔥 NO global)
        //            //---------------------------------------------------
        //            ws.Columns(1, tituloArray.Length)
        //              .AdjustToContents(1, 50);

        //            //---------------------------------------------------
        //            // Config impresión
        //            //---------------------------------------------------
        //            ws.PageSetup.SetRowsToRepeatAtTop(1, 11);
        //            ws.PageSetup.CenterHorizontally = true;

        //            workbook.SaveAs(rutaExcelTemp);
        //        }

        //        //---------------------------------------------------
        //        // PDF (Interop seguro)
        //        //---------------------------------------------------
        //        Excel.Application excel = null;
        //        Excel.Workbook wb = null;

        //        try
        //        {
        //            excel = new Excel.Application
        //            {
        //                ScreenUpdating = false,
        //                DisplayAlerts = false
        //            };

        //            wb = excel.Workbooks.Open(rutaExcelTemp);

        //            Excel.Worksheet sheet = wb.ActiveSheet;

        //            sheet.PageSetup.Orientation =
        //                Excel.XlPageOrientation.xlLandscape;

        //            sheet.PageSetup.Zoom = false;
        //            sheet.PageSetup.FitToPagesWide = 1;

        //            wb.ExportAsFixedFormat(
        //                Excel.XlFixedFormatType.xlTypePDF,
        //                rutaPdf);
        //        }
        //        finally
        //        {
        //            wb?.Close(false);
        //            excel?.Quit();

        //            Marshal.ReleaseComObject(wb);
        //            Marshal.ReleaseComObject(excel);

        //            GC.Collect();
        //            GC.WaitForPendingFinalizers();
        //        }

        //        File.Delete(rutaExcelTemp);

        //        return rutaPdf;
        //    }



        public static string GenerarKardexDirectoAPdf<T>(
            string rutaPdf,
            ExcelReportTitulo[] tituloArray,
            List<T> contenidoArray,
            TituloPdf titulopdf)
        {
            string carpeta = Path.GetDirectoryName(rutaPdf);
            string rutaExcelTemp = Path.Combine(carpeta, Guid.NewGuid() + ".xlsx");

            var props = typeof(T).GetProperties();

            using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var ws = workbook.Worksheets.Add("Kardex");

                decimal accK = 0;
                decimal accM = 0;
                decimal accN = 0;
                decimal accP = 0;

                decimal saldoQ = 0;
                decimal saldoS = 0;

                //------------------------------------------------
                // ENCABEZADO
                //------------------------------------------------
                string[] labels =
                {
                    "PERIODO:",
                    "RUC:",
                    "RAZÓN SOCIAL:",
                    "ESTABLECIMIENTO:",
                    "CÓDIGO EXISTENCIA:",
                    "TIPO:",
                    "DESCRIPCIÓN:",
                    "UNIDAD MEDIDA:",
                    "MÉTODO VALUACIÓN:"
                };

                string[] values =
                {
                    titulopdf.Periodo,
                    titulopdf.Ruc,
                    titulopdf.RazonSocial,
                    titulopdf.Establecimiento,
                    titulopdf.CodigoExistencia,
                    titulopdf.Tipo,
                    titulopdf.TipoDescripcion,
                    titulopdf.CodigoUnidadMedida,
                    titulopdf.MetodoEvaluacion
                };

                for (int i = 0; i < labels.Length; i++)
                {
                    ws.Cell(i + 1, 3).Value = labels[i];
                    ws.Cell(i + 1, 4).Value = values[i];
                }

                ws.Range("C1:C9").Style.Font.Bold = true;

                //------------------------------------------------
                // TITULOS
                //------------------------------------------------
                for (int i = 0; i < tituloArray.Length; i++)
                {
                    var c = ws.Cell(11, i + 1);
                    c.Value = tituloArray[i].titulo;
                    c.Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
                    c.Style.Font.FontColor = tituloArray[i].foreColor;
                }

                //------------------------------------------------
                // CONTENIDO + TOTALES
                //------------------------------------------------
                int row = 12;
                int bloqueInicio = row;
                var filasTotales = new List<int>();

                bool primerItem = true;

                foreach (var item in contenidoArray)
                {
                    int particion = Convert.ToInt32(props[0].GetValue(item) ?? 0);

                    //------------------------------------------------
                    // 👉 SI EMPIEZA NUEVO BLOQUE → cerrar anterior
                    //------------------------------------------------
                    if (!primerItem && particion == 1)
                    {
                        int totalRow = row;

                        ws.Cell(totalRow, 2).Value = "TOTAL";

                        ws.Cell(totalRow, 11).FormulaA1 =
                            $"SUM(K{bloqueInicio}:K{row - 1})";

                        ws.Cell(totalRow, 14).FormulaA1 =
                            $"SUM(N{bloqueInicio}:N{row - 1})";

                        ws.Cell(totalRow, 13).FormulaA1 =
                            $"SUM(M{bloqueInicio}:M{row - 1})";

                        ws.Cell(totalRow, 16).FormulaA1 =
                            $"SUM(P{bloqueInicio}:P{row - 1})";

                        ws.Cell(totalRow, 17).FormulaA1 = $"Q{row - 1}";
                        ws.Cell(totalRow, 19).FormulaA1 = $"S{row - 1}";


                        ws.Range($"A{totalRow}:S{totalRow}")
                            .Style.Fill.BackgroundColor = XLColor.LightBlue;


                        filasTotales.Add(totalRow);

                        //decimal valK = ws.Cell(totalRow, 11).GetValue<decimal>();
                        //decimal valM = ws.Cell(totalRow, 13).GetValue<decimal>();
                        //decimal valN = ws.Cell(totalRow, 14).GetValue<decimal>();
                        //decimal valP = ws.Cell(totalRow, 16).GetValue<decimal>();

                        //accK += valK;
                        //accM += valM;
                        //accN += valN;
                        //accP += valP;

                        //// saldo final = último bloque
                        //saldoQ += ws.Cell(totalRow, 17).GetValue<decimal>();
                        //saldoS += ws.Cell(totalRow, 19).GetValue<decimal>();

                        row++;
                        bloqueInicio = row;
                    }

                    //------------------------------------------------
                    // escribir fila normal
                    //------------------------------------------------
                    int col = 1;

                    foreach (var p in props)
                    {
                        ws.Cell(row, col).Value = p.GetValue(item);
                        col++;
                    }

                    row++;
                    primerItem = false;
                }

                //------------------------------------------------
                // 👉 cerrar último bloque
                //------------------------------------------------
                int totalFinal = row;

                ws.Cell(totalFinal, 2).Value = "TOTAL";

                ws.Cell(totalFinal, 11).FormulaA1 =
                    $"SUM(K{bloqueInicio}:K{row - 1})";

                ws.Cell(totalFinal, 14).FormulaA1 =
                    $"SUM(N{bloqueInicio}:N{row - 1})";

                ws.Cell(totalFinal, 13).FormulaA1 =
                    $"SUM(M{bloqueInicio}:M{row - 1})";

                ws.Cell(totalFinal, 16).FormulaA1 =
                    $"SUM(P{bloqueInicio}:P{row - 1})";

                ws.Cell(totalFinal, 17).FormulaA1 = $"Q{row - 1}";
                ws.Cell(totalFinal, 19).FormulaA1 = $"S{row - 1}";


                ws.Range($"A{totalFinal}:S{totalFinal}")
                    .Style.Fill.BackgroundColor = XLColor.LightBlue;


                filasTotales.Add(totalFinal);

                //decimal valK2 = ws.Cell(totalFinal, 11).GetValue<decimal>();
                //decimal valM2 = ws.Cell(totalFinal, 13).GetValue<decimal>();
                //decimal valN2 = ws.Cell(totalFinal, 14).GetValue<decimal>();
                //decimal valP2 = ws.Cell(totalFinal, 16).GetValue<decimal>();

                //accK += valK2;
                //accM += valM2;
                //accN += valN2;
                //accP += valP2;

                // saldo final = último bloque
                //saldoQ = ws.Cell(totalFinal, 17).GetValue<decimal>();
                //saldoS = ws.Cell(totalFinal, 19).GetValue<decimal>();

                row++;

                string formatoNumero = "#,##0.###";

                ws.Column(11).Style.NumberFormat.Format = formatoNumero;
                ws.Column(12).Style.NumberFormat.Format = formatoNumero;
                ws.Column(13).Style.NumberFormat.Format = formatoNumero;

                ws.Column(14).Style.NumberFormat.Format = formatoNumero;
                ws.Column(15).Style.NumberFormat.Format = formatoNumero;
                ws.Column(16).Style.NumberFormat.Format = formatoNumero;

                ws.Column(17).Style.NumberFormat.Format = formatoNumero;
                ws.Column(18).Style.NumberFormat.Format = formatoNumero;
                ws.Column(19).Style.NumberFormat.Format = formatoNumero;


                //------------------------------------------------
                // 👉 TOTAL GENERAL
                //------------------------------------------------
                //int generalRow = row;

                //ws.Cell(generalRow, 2).Value = "TOTAL GENERAL";

                //ws.Cell(generalRow, 11).Value = accK;
                //ws.Cell(generalRow, 13).Value = accM;
                //ws.Cell(generalRow, 14).Value = accN;
                //ws.Cell(generalRow, 16).Value = accP;

                //ws.Cell(generalRow, 17).Value = saldoQ;
                //ws.Cell(generalRow, 19).Value = saldoS;

                //ws.Range($"A{generalRow}:S{generalRow}")
                //    .Style.Fill.BackgroundColor = XLColor.DarkBlue;

                //ws.Range($"A{generalRow}:S{generalRow}")
                //    .Style.Font.FontColor = XLColor.White;

                //row++;


                //------------------------------------------------
                // COLUMNAS + IMPRESIÓN
                //------------------------------------------------
                ws.Columns(1, tituloArray.Length)
                  .AdjustToContents(1, 80);

                ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                ws.PageSetup.PagesWide = 1;
                ws.PageSetup.PagesTall = 0;
                ws.PageSetup.SetRowsToRepeatAtTop(1, 11);

                workbook.SaveAs(rutaExcelTemp);
            }

            //------------------------------------------------
            // EXPORTAR PDF
            //------------------------------------------------
            Excel.Application excel = new Excel.Application
            {
                ScreenUpdating = false,
                DisplayAlerts = false
            };

            var wb = excel.Workbooks.Open(rutaExcelTemp);
            var sheet = wb.ActiveSheet;

            sheet.PageSetup.Zoom = false;
            sheet.PageSetup.FitToPagesWide = 1;

            wb.ExportAsFixedFormat(
                Excel.XlFixedFormatType.xlTypePDF,
                rutaPdf);

            wb.Close(false);
            excel.Quit();

            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(excel);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            File.Delete(rutaExcelTemp);

            return rutaPdf;
        }


        public static void GetExcelReportKardexValorizado<T>(string rutaArchivo, ExcelReportTitulo[] tituloArray, List<T> contenidoArray,string periodo,string nivel )
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Hoja 1");

                    //// Obtener el directorio base de la aplicación
                    //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    //// Ruta relativa a la carpeta dentro de la solución
                    //string relativePath = @"Resources\icono-oc.jpg"; // Ajusta según la estructura de tu proyecto

                    //// Construir la ruta completa
                    //string fullPath = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));

                    //// Leer la imagen desde el archivo
                    //var image = worksheet.AddPicture(fullPath)
                    //                     .MoveTo(worksheet.Cell("A1"))
                    //                     .Scale(0.8);

                    //worksheet.Column("A").Width = 20;

                    // AGREGAMOS TITULO
                    worksheet.Cell(1, 1).Value = "FORMATO 13.1: \"REGISTRO DE INVENTARIO PERMANENTE VALORIZADO - DETALLE DEL INVENTARIO VALORIZADO\"";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                    worksheet.Range("A1:E1").Merge();



                    worksheet.Cell(2, 1).Value = $"Periodo: {periodo}";
                    worksheet.Cell(2, 1).Style.Font.Bold = true;
                    worksheet.Cell(2, 1).Style.Font.FontSize = 14;
                    worksheet.Range("A2:E2").Merge();


                    worksheet.Cell(3, 1).Value = $"Ruc: 2056369465 - Razon Social: SOFT COTTON SOURCING SAC ";
                    worksheet.Cell(3, 1).Style.Font.Bold = true;
                    worksheet.Cell(3, 1).Style.Font.FontSize = 14;
                    worksheet.Range("A3:E3").Merge();


                    worksheet.Cell(4, 1).Value = $"Establecimiento: UNICO";
                    worksheet.Cell(4, 1).Style.Font.Bold = true;
                    worksheet.Cell(4, 1).Style.Font.FontSize = 14;
                    worksheet.Range("A4:E4").Merge();



                    worksheet.Cell(5, 1).Value = $"Código de la existencia: {nivel}";
                    worksheet.Cell(5, 1).Style.Font.Bold = true;
                    worksheet.Cell(5, 1).Style.Font.FontSize = 14;
                    worksheet.Range("A5:E5").Merge();


                    //worksheet.Cell(5, 4).Value = $"Metodo de Evaluación: PROMEDIO";




                    int inicioFilas = 5;

                    worksheet.Cell(inicioFilas, 23).Value = "ENTRADA S/.";  
                    worksheet.Cell(inicioFilas, 23).Style.Fill.BackgroundColor = tituloArray[23].backgroundColor;
                    worksheet.Cell(inicioFilas, 23).Style.Font.FontColor = tituloArray[23].foreColor;
                    worksheet.Cell(inicioFilas, 23).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range($"W{inicioFilas}:Y{inicioFilas}").Merge();

                    worksheet.Cell(inicioFilas, 26).Value = "SALIDA S/.";
                    worksheet.Cell(inicioFilas, 26).Style.Fill.BackgroundColor = tituloArray[26].backgroundColor;
                    worksheet.Cell(inicioFilas, 26).Style.Font.FontColor = tituloArray[26].foreColor;
                    worksheet.Cell(inicioFilas, 26).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range($"Z{inicioFilas}:AB{inicioFilas}").Merge();

                    worksheet.Cell(inicioFilas, 29).Value = "SALDO S/.";
                    worksheet.Cell(inicioFilas, 29).Style.Fill.BackgroundColor = tituloArray[29].backgroundColor;
                    worksheet.Cell(inicioFilas, 29).Style.Font.FontColor = tituloArray[29].foreColor;
                    worksheet.Cell(inicioFilas, 29).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range($"AC{inicioFilas}:AE{inicioFilas}").Merge();


                    inicioFilas++;

                    // Titulo
                    for (int i = 0; i < tituloArray.Length; i++)
                    {
                        worksheet.Cell(inicioFilas, i + 1).Value = tituloArray[i].titulo.ToString();
                        worksheet.Cell(inicioFilas, i + 1).Style.Fill.BackgroundColor = tituloArray[i].backgroundColor;
                        worksheet.Cell(inicioFilas, i + 1).Style.Font.FontColor = tituloArray[i].foreColor;
                    }

                    // Contenido
                    int columnIndex = 1;

                    int rowIndexIniciaL = 7;
                    int rowIndex = inicioFilas + 1;
                    int rowInicial = inicioFilas + 1;
                    string valorCodigo = "";
                    foreach (T t in contenidoArray)
                    {
                        foreach (PropertyInfo info in typeof(T).GetProperties())
                        {
                            if (rowIndex > rowIndexIniciaL)
                            {
                                if (columnIndex == 1)
                                {
                                    var valorparticion = Convert.ToInt32(info.GetValue(t, null) ?? DBNull.Value);
                                    if (valorparticion == 1)
                                    {
                                        //worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                                        //worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                                        //worksheet.Range("A" + rowIndex + ":AE" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                                        worksheet.Range("A" + rowIndex + ":AE" + rowIndex).Style.Font.FontColor = XLColor.Black;
                                        worksheet.Cell(rowIndex, columnIndex).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                        ////Total Saldo
                                        //worksheet.Cell(rowIndex, 31).FormulaA1 = "AE" + (rowIndex - 1);
                                        ////Cantidad Saldo 
                                        //worksheet.Cell(rowIndex, 29).FormulaA1 = "AC" + (rowIndex - 1);

                                        ////Total De Cantidades Entradas
                                        //worksheet.Cell(rowIndex, 23).FormulaA1 = "SUM(W" + rowInicial + ":W" + (rowIndex - 1) + ")";
                                        ////Total de Cantidades de Salidas
                                        //worksheet.Cell(rowIndex, 26).FormulaA1 = "SUM(Z" + rowInicial + ":Z" + (rowIndex - 1) + ")";

                                        ////Total de Saldos Entrada 
                                        //worksheet.Cell(rowIndex, 22).FormulaA1 = "SUM(U" + rowInicial + ":U" + (rowIndex - 1) + ")";
                                        ////Total de Saldos Salida
                                        //worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";
                                        worksheet.Range("A" + rowIndex + ":AE" + rowIndex).Merge();
                                        rowIndex++;
                                        rowInicial = rowIndex;
                                    }
                                }
                                else if (columnIndex == 3)
                                {
                                    valorCodigo = Convert.ToString(info.GetValue(t, null) ?? DBNull.Value);
                                }
                            }


                            if (info.PropertyType.Name.ToUpper().StartsWith("INT"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 0;
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("DECIMAL"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.NumberFormatId = 4;
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("STRING"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("CHAR"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "@";
                            }
                            else if (info.PropertyType.Name.ToUpper().StartsWith("DATE"))
                            {
                                worksheet.Cell(rowIndex, columnIndex).Style.NumberFormat.Format = "dd/mm/yyyy";
                            }

                            var valor = (info.GetValue(t, null) ?? DBNull.Value);
                            worksheet.Cell(rowIndex, columnIndex).Value = valor;


                            columnIndex++;
                        }

                        rowIndex++;
                        columnIndex = 1;
                    }



                    //worksheet.Cell(rowIndex, 2).Value = "TOTAL ";
                    //worksheet.Cell(rowIndex, 3).FormulaA1 = "C" + (rowIndex - 1);
                    ////Total Saldo
                    //worksheet.Cell(rowIndex, 31).FormulaA1 = "AE" + (rowIndex - 1);
                    ////Cantidad Saldo 
                    //worksheet.Cell(rowIndex, 29).FormulaA1 = "AC" + (rowIndex - 1);

                    ////Total De Cantidades Entradas
                    //worksheet.Cell(rowIndex, 23).FormulaA1 = "SUM(W" + rowInicial + ":W" + (rowIndex - 1) + ")";
                    ////Total de Cantidades de Sa lidas
                    //worksheet.Cell(rowIndex, 26).FormulaA1 = "SUM(Z" + rowInicial + ":Z" + (rowIndex - 1) + ")";
                    ////Total de Saldos Entrada 
                    //worksheet.Cell(rowIndex, 22).FormulaA1 = "SUM(U" + rowInicial + ":U" + (rowIndex - 1) + ")";
                    ////Total de Saldos Salida
                    //worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";

                    ////worksheet.Cell(rowIndex, 23).FormulaA1 = "SUM(W" + rowInicial + ":W" + (rowIndex - 1) + ")";
                    //////Total de Cantidades de Salidas
                    ////worksheet.Cell(rowIndex, 26).FormulaA1 = "SUM(Z" + rowInicial + ":Z" + (rowIndex - 1) + ")";

                    //////Total de Saldos Entrada 
                    ////worksheet.Cell(rowIndex, 22).FormulaA1 = "SUM(U" + rowInicial + ":U" + (rowIndex - 1) + ")";
                    //////Total de Saldos Salida
                    ////worksheet.Cell(rowIndex, 25).FormulaA1 = "SUM(Y" + rowInicial + ":Y" + (rowIndex - 1) + ")";


                    //worksheet.Range("A" + rowIndex + ":AE" + rowIndex).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    //worksheet.Range("A" + rowIndex + ":AE" + rowIndex).Style.Font.FontColor = XLColor.Black;
                    //worksheet.Range("D" + rowIndex + ":V" + rowIndex).Merge();
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(rutaArchivo);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }


        public static void ExportarGuiaRemision(string rutaArchivo, GetGR2_CabeceraXCod cabecera, List<GetGR3_DetalleXCod> detalle)
        {
            using (var workbook = new XLWorkbook())
            {
                int index = 0;
                double cantidadTotal = 0;
                var worksheet = workbook.Worksheets.Add("Hoja 1");

                worksheet.SheetView.SetView(XLSheetViewOptions.PageBreakPreview);
                
                worksheet.Range("A1:Q200").Style.Font.FontSize = 15;
                worksheet.ShowGridLines = false;

                worksheet.Column(1).Width = 2;      // A
                worksheet.Column(2).Width = 2;      // B
                worksheet.Column(3).Width = 20;     // C
                worksheet.Column(4).Width = 14;     // D
                worksheet.Column(5).Width = 2;      // E
                worksheet.Column(6).Width = 10;     // F
                worksheet.Column(7).Width = 10;     // G
                worksheet.Column(8).Width = 4;      // H
                worksheet.Column(9).Width = 4;      // I
                worksheet.Column(10).Width = 10;    // J
                worksheet.Column(11).Width = 5;     // K
                worksheet.Column(12).Width = 5;     // L
                worksheet.Column(13).Width = 10;     // M
                worksheet.Column(14).Width = 15;    // N
                worksheet.Column(15).Width = 20;    // O

                worksheet.Row(6).Height = 38;
                worksheet.Row(8).Height = 2;        
                worksheet.Row(13).Height = 20;       

                worksheet.Range("D10:H10").Row(1).Merge();
                worksheet.Range("J19:K19").Row(1).Merge();


                // REPORTE DE GUIA DE REMISION - CABECERA
                // Fila 1
                worksheet.Cell(7, 4).Value = cabecera.fechaEmision;

                // Fila 2
                if (cabecera.puntoPartida.Length > 52)
                {
                    worksheet.Cell(11, 3).Value = cabecera.puntoPartida.Substring(0, 52);
                }
                else
                {
                    worksheet.Cell(11, 3).Value = cabecera.puntoPartida;
                }
                
                if (cabecera.puntoLlegada.Length > 52)
                {
                    worksheet.Cell(11, 11).Value = cabecera.puntoLlegada.Substring(0, 52);
                }
                else
                {
                    worksheet.Cell(11, 11).Value = cabecera.puntoLlegada;
                }

                // Fila 3
                worksheet.Cell(14, 3).Value = cabecera.fechaInicioTraslado;
                worksheet.Cell(14, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);


                worksheet.Cell(14, 6).Value = cabecera.destRS;
                worksheet.Cell(14, 15).Value = cabecera.destCodigoPC;

                // Fila 4 - UNIDAD DE TRANSPORTE Y CONDUCTORES - EMPRESA Y TRANSPORTES
                worksheet.Cell(17, 6).Value = cabecera.transMarca + " " + cabecera.transNumPlaca;
                // Fila 5
                worksheet.Cell(18, 6).Style.NumberFormat.Format = "@";
                worksheet.Cell(18, 6).Value = cabecera.constanciaInscripcion;
                worksheet.Cell(18, 10).Value = cabecera.transRS;
                // Fila 6
                worksheet.Cell(19, 6).Value = cabecera.numeroLicenciaConducir;

                worksheet.Cell(19, 10).Style.NumberFormat.Format = "@";
                worksheet.Cell(19, 10).Value = cabecera.transCodigoPC;
                
                // DETALLE
                index = 26;
                string primer_valor = "";
                foreach (var item in detalle)
                {
                    worksheet.Cell(index, 1).Value = item.codigoProducto.Trim();
                    worksheet.Cell(index, 4).Value = item.producto.Trim();
                    
                    worksheet.Cell(index, 12).Value = item.numeroPartida;

                    worksheet.Cell(index, 14).Value = item.cantidadIngresada;
                    worksheet.Cell(index, 14).Style.NumberFormat.Format = "#,##0.000";

                    worksheet.Cell(index, 15).Value = item.codUM;

                    worksheet.Cell(index, 16).Value = item.pesoIngresado;
                    worksheet.Cell(index, 16).Style.NumberFormat.Format = "#,##0.000";

                    index++;
                    cantidadTotal += item.cantidadIngresada;
                }

                worksheet.Cell(index + 2, 14).Value = Math.Round(cantidadTotal,2);
                worksheet.Cell(index + 2, 14).Style.NumberFormat.Format = "#,##0.000";

                int finalColumnPrint = (index + 10);

                worksheet.PageSetup.PrintAreas.Add("A1:P" + "" + finalColumnPrint.ToString());
                worksheet.PageSetup.FitToPages(1, 1);

                workbook.SaveAs(rutaArchivo);

            }

        }

        public static int GridToExcel(this DataGridView migrid, string Nombre, int? abrir = null, string[,] rango = null)
        {
            var cantidad = migrid.Rows.Count;
            copyAlltoClipboard(migrid);

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlexcel = new Excel.Application();

            xlexcel.DisplayAlerts = false;
            Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];

            CR.Select();
            CR.WrapText = true;
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            delRng.Delete(Type.Missing);
            xlWorkSheet.get_Range("A1").Select();
            xlWorkSheet.get_Range("A1").WrapText = true;

            xlWorkSheet.Columns.AutoFit();
            if (rango != null)
            {
                for (int i = 0; i < (rango.Length / 2); i++)
                {
                    var ccc = rango;
                    xlWorkSheet.get_Range(rango[i, 0]).NumberFormat = rango[i, 1];                   
                }
            }

            xlWorkSheet.Cells.WrapText = true;

            Excel.Range usedRange = xlWorkSheet.UsedRange;
            usedRange.Font.Name = "Arial";
            usedRange.Font.Size = 8;
            usedRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            string AA = GetExcelColumnName(migrid.ColumnCount);

            Excel.Range headerRange = xlWorkSheet.get_Range("A1:" + AA + "1");
            headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
            headerRange.Font.Bold = true;

            var array = Nombre.Split('.').ToArray();
            if (array[array.ToList().Count - 1] == "xlsx")
            {
                xlWorkBook.SaveAs(Nombre, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            else
            {
                xlWorkBook.SaveAs(Nombre, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }

            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlexcel);

            Clipboard.Clear();
            migrid.ClearSelection();
            if (File.Exists(Nombre))
            {
                if (abrir == null)
                {
                    System.Diagnostics.Process.Start(Nombre);
                }
            }
            return 1;
        }

        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }

        private static void copyAlltoClipboard(DataGridView migrid)
        {
            DataObject dataObj = migrid.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private static void releaseObject(object obj)
        {

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

        }

    }
}
