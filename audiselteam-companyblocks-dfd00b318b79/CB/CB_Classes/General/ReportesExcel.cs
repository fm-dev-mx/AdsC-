using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace CB_Base.Classes 
{
    public static class ReportesExcel
    {
        public static string GenerarreporteProveedores(BackgroundWorker worker)
        {
            bool cancelado = false;
            string path = string.Empty;
            if (worker.CancellationPending)
                return path;

            worker.ReportProgress(10, "Generando reporte, espere...");
            //EPPlus
            //Creates a blank workbook. Use the using statment, so the package is disposed when we are done.
            using (var p = new ExcelPackage())
            {
                //AGREGAR HOJA DE TRABAJO
                var excelRow = p.Workbook.Worksheets.Add("MySheet");
                //AGREGAR VALOR A LOS RENGLONES DE EXCEL POR MEDIO DE UN INDICE
                excelRow.Cells["A1"].Value = "PROVEEDOR";
                excelRow.Cells["B1"].Value = "COMPETENCIA";
                excelRow.Cells["C1"].Value = "PUNTUACION";
                excelRow.Cells["D1"].Value = "PROMEDIO";
                excelRow.Cells["E1"].Value = "CATEGORIA";

                //estilos por rango o por renglon
                excelRow.Cells["A1:E1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["A1:E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                excelRow.Cells["A1:E1"].Style.Font.Color.SetColor(Color.Black);
                excelRow.Cells["A1:E1"].Style.Font.Bold = true;

                worker.ReportProgress(20, "Generando reporte, espere...");
                //
                int renglon = 2;
                int avance = 20;

                EvaluacionProveedor evaluacionesProveedores = new EvaluacionProveedor();
                evaluacionesProveedores.SeleccionarEvaluacionDePeriodo("2018-11-20", "2018-11-20");
                
                evaluacionesProveedores.Filas().ForEach(delegate(Fila f)
                {
                    if (worker.CancellationPending || cancelado)
                    {
                        cancelado = true;
                        return;
                    }
                    else
                    {

                        int renglonIniciaMerge = renglon;
                        int renglonFinalizaMerge = renglon + 3;

                        excelRow.Cells["A" + renglonIniciaMerge + ":A" + renglonFinalizaMerge].Merge = true;
                        excelRow.Cells["A" + renglon].Value = f.Celda("nombre");
                        excelRow.Cells["A" + renglon].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        excelRow.Cells["A" + renglon].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        EvaluacionHabilidadProveedor.Modelo().SeleccionarHabilidadesPuntuacion(Convert.ToInt32(f.Celda("id"))).ForEach(delegate(Fila filaHabilidad)
                        {
                            if (worker.CancellationPending || cancelado)
                            {
                                cancelado = true;
                                return;
                            }
                            else
                            {
                                //Competencias y puntuación
                                excelRow.Cells["B" + renglon].Value = filaHabilidad.Celda("habilidad").ToString();
                                excelRow.Cells["C" + renglon].Value = filaHabilidad.Celda("puntuacion");
                                renglon++;
                            }
                        });

                        //TEXTO DEL MERGE
                        excelRow.Cells["D" + renglonIniciaMerge + ":D" + renglonFinalizaMerge].Merge = true;
                        excelRow.Cells["D" + renglonIniciaMerge].Value = f.Celda("resultado");
                        excelRow.Cells["D" + renglonIniciaMerge].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        excelRow.Cells["D" + renglonIniciaMerge].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        //TEXTO DEL MERGE
                        excelRow.Cells["E" + renglonIniciaMerge + ":E" + renglonFinalizaMerge].Merge = true;
                        excelRow.Cells["E" + renglonIniciaMerge].Value = f.Celda("categoria").ToString();
                        excelRow.Cells["E" + renglonIniciaMerge].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        excelRow.Cells["E" + renglonIniciaMerge].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        avance++;
                        int total = Global.CalcularPorcentaje(avance, (evaluacionesProveedores.Filas().Count + 20));
                        worker.ReportProgress((total - 1), "Generando reporte, espere...");
                    }

                });

                
                if(cancelado)
                {
                    worker.ReportProgress(100, "Cancelado");
                    return string.Empty;
                }
                else
                {            
                    excelRow.Cells["A1:E" + renglon].AutoFitColumns();

                    //GUARDA EL LIBRO CON UN NOMBRE
                    string nombreArchivo= "EVALUACION_PROVEEDORES_" + DateTime.Now.ToString().Replace("/", "-").Replace(":","-") + ".xlsx";
                    path = Directory.GetCurrentDirectory() + "\\SGC\\REPORTES\\EXCEL\\PROVEEDORES";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    p.SaveAs(new FileInfo(path + "\\" + nombreArchivo));
                    worker.ReportProgress(100, "Generando reporte, espere...");
                    return path + "\\" + nombreArchivo;
                }
            }
        }
    }
}
