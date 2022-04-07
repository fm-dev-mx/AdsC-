using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OfficeOpenXml;
using System.IO;
using CB_Base.Classes;
using CB;

namespace CB_Base.Classes
{
    public static class FormatosExcel
    {
        public static void ReporteProveedores()
        {
            //EPPlus
            using (var p = new ExcelPackage())
            {
                int row = 1;
                var excelRow = p.Workbook.Worksheets.Add("MySheet");

                //AGREGAR VALOR A LOS RENGLONES DE EXCEL POR MEDIO DE UN INDICE
                //ENCABEZADO
                excelRow.Cells["A" + row].Value = "PROVEEDOR";
                excelRow.Cells["B" + row].Value = "COMPETENCIA";
                excelRow.Cells["C" + row].Value = "PUNTUACION";
                excelRow.Cells["D" + row].Value = "PROMEDIO";
                excelRow.Cells["E" + row].Value = "CATEGORIA";

                //estilos por rango o por renglon
                excelRow.Cells["A1:E1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["A1:E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                excelRow.Cells["A1:E1"].Style.Font.Color.SetColor(Color.Black);
                excelRow.Cells["A1:E1"].Style.Font.Bold = true;

                //Obtenemos la lista de proveedores con el promedio de la evaluacion
                Proveedor.Modelo().EvaluacionesProveedoresActivos().ForEach(delegate(Fila f)
                {
                    EvaluacionHabilidadProveedor.Modelo().SeleccionarHabilidadesPuntuacion(f.Celda<int>("id")).ForEach(delegate(Fila filaHabilidad)
                    {

                    });
                });
            }



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

                //MERGE PRIMERO SE HACE EL MERGE LUEGO SE AGREGA TEXTO
                excelRow.Cells["A2:A5"].Merge = true;

                //TEXTO DEL MERGE
                excelRow.Cells["A2"].Value = "TEST MERGE";
                excelRow.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                //Competencias
                excelRow.Cells["B2"].Value = "COMPETENCIA 1";
                excelRow.Cells["B3"].Value = "COMPETENCIA 2";
                excelRow.Cells["B4"].Value = "COMPETENCIA 3";
                excelRow.Cells["B5"].Value = "COMPETENCIA 4";

                //puntuacion
                excelRow.Cells["C2"].Value = "PUNTUACION 1";
                excelRow.Cells["C3"].Value = "PUNTUACION 2";
                excelRow.Cells["C4"].Value = "PUNTUACION 3";
                excelRow.Cells["C5"].Value = "PUNTUACION 4";

                //PROMEDIO
                //MERGE PRIMERO SE HACE EL MERGE LUEGO SE AGREGA TEXTO
                excelRow.Cells["D2:D5"].Merge = true;

                //TEXTO DEL MERGE
                excelRow.Cells["D2"].Value = "PROMEDIO MERGE";
                excelRow.Cells["D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["D2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                //PROMEDIO
                //MERGE PRIMERO SE HACE EL MERGE LUEGO SE AGREGA TEXTO
                excelRow.Cells["E2:E5"].Merge = true;

                //TEXTO DEL MERGE
                excelRow.Cells["E2"].Value = "CATEGORIA MERGE";
                excelRow.Cells["E2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["E2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                excelRow.Cells["A1:E6"].AutoFitColumns();

                //GUARDA EL LIBRO CON UN NOMBRE
                p.SaveAs(new FileInfo(@"C:\Users\Eilean Laborde\Desktop\TEST.xlsx"));
            }
        }

        public static void ReporteMaterialProyecto(List<Fila> materialReporte, string path)
        {
            using (var p = new ExcelPackage())
            {
                int row = 1;
                var excelRow = p.Workbook.Worksheets.Add("Reporte de material");

                //AGREGAR VALOR A LOS RENGLONES DE EXCEL POR MEDIO DE UN INDICE
                //ENCABEZADO

                excelRow.Cells["A" + row].Value = "ID REQ.";
                excelRow.Cells["B" + row].Value = "FECHA CREACION";
                excelRow.Cells["C" + row].Value = "REQUISITOR";
                excelRow.Cells["D" + row].Value = "CATEGORIA";
                excelRow.Cells["E" + row].Value = "NUMERO DE PARTE";
                excelRow.Cells["F" + row].Value = "FABRICANTE";
                excelRow.Cells["G" + row].Value = "DESCRIPCION";
                excelRow.Cells["H" + row].Value = "PIEZAS REQUERIDAS";
                excelRow.Cells["I" + row].Value = "TOTAL A ORDENAR";
                excelRow.Cells["J" + row].Value = "COSTO TOTAL";
                excelRow.Cells["K" + row].Value = "ACCESORIO PARA";
                excelRow.Cells["L" + row].Value = "ESTATUS DE COMPRA";
                excelRow.Cells["M" + row].Value = "PEOR TIEMPO DE ENTREGA";
                excelRow.Cells["N" + row].Value = "TIEMPO DE ENTREGA REAL";
                excelRow.Cells["O" + row].Value = "FECHA DE ENTREGA ESTIMADA";
                excelRow.Cells["P" + row].Value = "SUBENSAMBLE";

                //estilos por rango o por renglon
                excelRow.Cells["A1:P1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["A1:P1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                excelRow.Cells["A1:P1"].Style.Font.Color.SetColor(Color.Black);
                excelRow.Cells["A1:P1"].Style.Font.Bold = true;

                row++;

                materialReporte.ForEach(delegate (Fila mat)
                {
                    excelRow.Cells["A" + row].Value = mat.Celda("id").ToString();
                    excelRow.Cells["B" + row].Value = Global.FechaATexto(mat.Celda("fechaCreacion"), false);
                    excelRow.Cells["C" + row].Value = mat.Celda("requisitor").ToString();
                    excelRow.Cells["D" + row].Value = mat.Celda("categoria_real").ToString();
                    excelRow.Cells["E" + row].Value = mat.Celda("numero_parte").ToString();
                    excelRow.Cells["F" + row].Value = mat.Celda("fabricante").ToString();
                    excelRow.Cells["G" + row].Value = mat.Celda("descripcion").ToString();
                    excelRow.Cells["H" + row].Value = mat.Celda("piezas_requeridas").ToString();
                    excelRow.Cells["I" + row].Value = mat.Celda("strTotal").ToString();
                    excelRow.Cells["J" + row].Value = mat.Celda("precio_suma_final").ToString();
                    excelRow.Cells["L" + row].Value = mat.Celda("strAccesorioPara");
                    excelRow.Cells["L" + row].Value = mat.Celda("estatus_compra").ToString();
                    excelRow.Cells["M" + row].Value = mat.Celda("tiempoEstimadoEntrega");
                    excelRow.Cells["N" + row].Value = mat.Celda("tiempoEntregaReal");
                    excelRow.Cells["O" + row].Value = mat.Celda("fechaEstimadaEntrega");
                    excelRow.Cells["p" + row].Value = mat.Celda("subensamble");

                    row++;
                });
                excelRow.Cells["A1:P" + row].AutoFitColumns();

                //GUARDA EL LIBRO CON UN NOMBRE
                p.SaveAs(new FileInfo(path));
            }
        }
    }
}
